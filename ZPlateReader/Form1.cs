using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

// S	TODO: output only the last plate (in case of detecting 1+ plate in the pic)
//	TODO: latin -> cyrillic
//	TODO: choose root directory and scan all the subdirectories and call "PlateReader" for each file
//	TODO: save data to the scan_data.csv: pic_no, plate, root_dir, sub_dir
//	TODO: if plate has any "?" marks, then append an "!"-mark to the end of the plate
//	TODO: if nothing was read - print plate as empty

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

		[ DllImport( "iANPRinterface_vc12_x64.dll", CallingConvention = CallingConvention.StdCall ) ]
		private static extern int anprPlateMemoryXML( byte[] in_buffer,
			int size_buffer,
			ANPR_OPTIONS Options,
			StringBuilder xml_buffer,
			int[] size_xml_buffer );

		public Form1()
		{
			InitializeComponent();
		}

		private void button_test_Click( object sender, EventArgs e )
		{
			if ( openFileDialog_main.ShowDialog() == DialogResult.OK )
			{
				try
				{
					using ( var stream = openFileDialog_main.OpenFile() )
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

						anprPlateMemoryXML( buffer, size, anpr_options, buffer_builder, size_builder );

						using ( var reader = XmlReader.Create( new StringReader( buffer_builder.ToString() ) ) )
						{
							reader.ReadToFollowing( "allnumbers" );
							reader.MoveToFirstAttribute();

							for ( int i = 0, end = int.Parse( reader.Value ); i < end; ++i )
							{
								reader.ReadToFollowing( "number" );
								reader.MoveToFirstAttribute();
							}

							Console.WriteLine( reader.Value.Substring( 0, reader.Value.LastIndexOf( ':' ) ) );
						}
					}
				}
				catch ( Exception exception )
				{
					MessageBox.Show( @"Something reaaaally bad happened.." + Environment.NewLine + exception.Message, @".//Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
				}
			}
		}
	}
}