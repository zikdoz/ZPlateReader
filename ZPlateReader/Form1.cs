﻿using System;
using System.Collections.Generic;
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

// S	TODO: output only the last plate (in case of detecting 1+ plate in the pic)
// S	TODO: any-case latin -> lowercase cyrillic
// S	TODO: choose a root directory and scan all the subdirectories and call "readPlate" for each file
//	TODO: save data to the scan_data.csv: pic_no, plate, root_dir, sub_dir\sub_dir2\...
// S	TODO: if plate has any "?" marks, then append an "!"-mark to the end of the plate
// S	TODO: if nothing was read - print plate as empty

namespace ZPlateReader
{
	public partial class Form1 : Form
	{
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

		private struct ANPR_OPTIONS
		{
			public int min_plate_size; // Минимальная площадь номера
			public int max_plate_size; // Максимальная площадь номера
			public int Detect_Mode; // Режимы детектирования	
			public int max_text_size; // Максимальное количество символов номера + 1
			public int type_number; // Тип автомобильного номера	
			public int flags; // Дополнительные опции
		};

		[ DllImport( "iANPRinterface_vc12_x64.dll", CallingConvention = CallingConvention.StdCall ) ]
		private static extern int anprPlateMemoryXML( byte[] in_buffer,
			int size_buffer,
			ANPR_OPTIONS Options,
			StringBuilder xml_buffer,
			int[] size_xml_buffer );

		public Form1()
		{
			InitializeComponent();

			button_scan_dir.Click += ( sender, args ) =>
			{
				if ( _folder_selector.ShowDialog() == CommonFileDialogResult.Ok )
					if ( !string.IsNullOrWhiteSpace( _folder_selector.FileName ) )
						scanDir( _folder_selector.FileName );
			};
		}

		private static void scanDir( string root_dir )
		{
			var plate_pic_paths = Directory.GetFiles( root_dir, "*.jpg", SearchOption.AllDirectories );

			Parallel.For( 0, plate_pic_paths.Length, i => readPlate( plate_pic_paths[ i ] ) );
		}

		private static void readPlate( string plate_file_path )
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

					var anpr_options = new ANPR_OPTIONS
					{
						Detect_Mode = 14,
						min_plate_size = 500,
						max_plate_size = 25000,
						max_text_size = 20,
						type_number = 0,
						flags = 7
					};

					var buffer_builder = new StringBuilder( 10000 );
					int[] size_builder = { 10000 };

					if ( anprPlateMemoryXML( buffer, size, anpr_options, buffer_builder, size_builder ) == 0 )
					{
						using ( var reader = XmlReader.Create( new StringReader( buffer_builder.ToString() ) ) )
						{
							reader.ReadToFollowing( "allnumbers" );
							reader.MoveToFirstAttribute();

							for ( int i = 0, end = int.Parse( reader.Value ); i < end; ++i )
							{
								reader.ReadToFollowing( "number" );
								reader.MoveToFirstAttribute();
							} // left only the last one

							var plate = ( !string.IsNullOrWhiteSpace( reader.Value )
								? reader.Value.Substring( 0, reader.Value.LastIndexOf( ':' ) )
								: "" ); // read only plate data

							Console.WriteLine( $@"{plate_file_path}, {latinToCyrillic( plate )}, {( plate.Any( chr => chr == '?' ) ? "!" : "" )}" );
						}
					}
					else
						Console.WriteLine( $@"{plate_file_path}, -," );
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