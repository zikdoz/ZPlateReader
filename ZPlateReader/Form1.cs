using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.WindowsAPICodePack.Dialogs;

#region [ Code Inspection ]

// ReSharper disable InconsistentNaming
#pragma warning disable 414

#endregion

namespace ZPlateReader
{
	public partial class Form1 : Form
	{
		private struct ANPR_OPTIONS
		{
			public int min_plate_size; // Минимальная площадь номера
			public int max_plate_size; // Максимальная площадь номера
			public int Detect_Mode; // Режимы детектирования	
			public int max_text_size; // Максимальное количество символов номера + 1
			public int type_number; // Тип автомобильного номера	
			public int flags; // Дополнительные опции
		};

		private static readonly Dictionary< string, string > _latin_converter = new Dictionary< string, string >( StringComparer.OrdinalIgnoreCase )
		{
			{ "A", "а" },
			{ "B", "б" },
			{ "C", "с" },
			{ "E", "е" },
			{ "H", "н" },
			{ "K", "к" },
			{ "M", "м" },
			{ "O", "о" },
			{ "P", "р" },
			{ "T", "т" },
			{ "X", "х" },
			{ "Y", "у" }
		};

		private static readonly CommonOpenFileDialog _folder_selector = new CommonOpenFileDialog( "Folder scanner." )
		{
			IsFolderPicker = true,
			RestoreDirectory = true,
			EnsurePathExists = true
		};

		private static StreamWriter _data_writer;
		private static Stopwatch _stopwatch_working_time;
		private static ANPR_OPTIONS _anpr_options;
		private static int _read_plate_idx;

		[ DllImport( "iANPRinterface_vc12_x64.dll", CallingConvention = CallingConvention.StdCall ) ]
		private static extern int anprPlateMemoryXML( byte[] in_buffer,
			int size_buffer,
			ANPR_OPTIONS Options,
			StringBuilder xml_buffer,
			int[] size_xml_buffer );

		public Form1()
		{
			InitializeComponent();

			Shown += ( sender, args ) => init();
		}

		private void init()
		{
			backgroundWorker_main.DoWork += ( sender, args ) => scanDir( _folder_selector.FileName );

			backgroundWorker_main.RunWorkerCompleted += ( sender, args ) =>
			{
				Cursor = Cursors.Default;
				button_scan_dir.ResetBackColor();
				button_scan_dir.Enabled = true;

				label_work_time.Text = $@"{_stopwatch_working_time.Elapsed.TotalMilliseconds / 1000.0}s";
				_stopwatch_working_time.Stop();
			};

			button_scan_dir.Click += ( sender, args ) =>
			{
				if ( _folder_selector.ShowDialog() == CommonFileDialogResult.Ok )
					if ( !string.IsNullOrWhiteSpace( _folder_selector.FileName ) )
					{
						Cursor = Cursors.WaitCursor;
						button_scan_dir.BackColor = Color.OrangeRed;
						button_scan_dir.Enabled = false;

						int.TryParse( textbox_plate_idx.Text, out _read_plate_idx );
						int.TryParse( textbox_detect_mode.Text, out _anpr_options.Detect_Mode );
						int.TryParse( textbox_min_size.Text, out _anpr_options.min_plate_size );
						int.TryParse( textbox_max_size.Text, out _anpr_options.max_plate_size );
						int.TryParse( textbox_max_text_size.Text, out _anpr_options.max_text_size );
						int.TryParse( textbox_type_number.Text, out _anpr_options.type_number );
						_anpr_options.flags = ( checkbox_detect_all_plates.Checked ) ? 1 : 0;

						_stopwatch_working_time = Stopwatch.StartNew();

						backgroundWorker_main.RunWorkerAsync();
					}
			};
		}

		private static void scanDir( string root_dir )
		{
			var plate_pic_paths = Directory.GetFiles( root_dir, "*.jpg", SearchOption.AllDirectories );

			if ( plate_pic_paths.Length > 0 )
			{
				using ( _data_writer = File.AppendText( root_dir + $"\\{( root_dir = Path.GetFileName( root_dir ) )}.csv" ) )
				{
					Parallel.For( 0, plate_pic_paths.Length, i => readPlate( plate_pic_paths[ i ], root_dir ) );
//					for ( int i = 0, end = plate_pic_paths.Length; i < end; ++i )
//						readPlate( plate_pic_paths[ i ], root_dir );
				}
			}
		}

		private static void readPlate( string plate_file_path, string root_dir )
		{
			try
			{
				using ( var stream = File.OpenRead( plate_file_path ) )
				{
					var size = ( int ) stream.Length;
					var buffer = new byte[ size ];

					using ( var memory_stream = new MemoryStream() )
					{
						int temp;

						while ( ( temp = stream.Read( buffer, 0, buffer.Length ) ) > 0 )
							memory_stream.Write( buffer, 0, temp );
					}

					var buffer_builder = new StringBuilder( 10000 );
					int[] size_builder = { 10000 };

					string pic_no = Path.GetFileNameWithoutExtension( plate_file_path ),
						sub_dir = Path.GetFileName( plate_file_path.Substring( 0, plate_file_path.LastIndexOf( pic_no, StringComparison.OrdinalIgnoreCase ) - 1 ) ),
						plate = "";

					if ( anprPlateMemoryXML( buffer, size, _anpr_options, buffer_builder, size_builder ) == 0 )
					{
						using ( var reader = XmlReader.Create( new StringReader( buffer_builder.ToString() ) ) )
						{
							reader.ReadToFollowing( "allnumbers" );
							reader.MoveToFirstAttribute();

							for ( int i = 0, end = Math.Min( int.Parse( reader.Value ), _read_plate_idx ); i < end; ++i )
							{
								reader.ReadToFollowing( "number" );
								reader.MoveToFirstAttribute();
							} // left only the last one

							plate = ( !string.IsNullOrWhiteSpace( reader.Value )
									&& ( reader.Value.LastIndexOf( ':' ) >= 0 )
								? reader.Value.Substring( 0, reader.Value.LastIndexOf( ':' ) )
								: reader.Value ); // read only plate data
						}
					}

					_data_writer.WriteLine( $@"{pic_no}|" // pic_number
											+ $@"{( !string.IsNullOrWhiteSpace( plate ) ? latinToCyrillic( plate ) : "-" )}|"
											+ $@"{root_dir}|"
											+ $@"{sub_dir}|"
											+ $@"{( plate.Any( chr => chr == '?' ) ? "!" : "" )}" ); // if plate has any '?'
				}
			}
			catch ( Exception exception )
			{
				MessageBox.Show( @"Something reaaaally bad happened with file:" + Environment.NewLine
								+ $@"Path: {plate_file_path}" + Environment.NewLine + Environment.NewLine
								+ exception.Message + Environment.NewLine, @".//Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		private static string latinToCyrillic( string lating_string ) =>
			string.Concat( lating_string.ToUpper()
				.Select( chr => ( _latin_converter.ContainsKey( chr.ToString() )
					? _latin_converter[ chr.ToString() ]
					: chr.ToString() ) ) );
	}
}