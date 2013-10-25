// Created by Peoharen
using System;
using System.IO;
using System.Text;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
	public class BlueMageLogGump : Gump
	{
		public BlueMageLogGump() : base( 0, 0 )
		{
			string html = "";

			if ( !Directory.Exists( @"Data/BlueMagic/" ) )
				html = "There is no log file to read.";
			else if ( !File.Exists( @"Data/BlueMagic/SpellsKnownLog.txt" ) )
				html = "There is no log file to read.";
			else
			{
				try
				{
					StreamReader sr = new StreamReader( @"Data/BlueMagic/SpellsKnownLog.txt" ); 
					string fileline = "";
					int skip = 0;

					while ( fileline != null )
					{
						fileline = sr.ReadLine();

						if ( fileline != null )
						{
							if ( skip < 3 )
							{
								skip++;
							}
							else
							{
								html += fileline.Replace( "	", "    " );
								html += "<br>";
							}
						}
					}

					sr.Close();
				}
				catch( Exception ex )
				{
					Console.WriteLine("Blue Log Gump Failure: " + ex.Message );
				}
			}

			this.Closable =true;
			this.Disposable = true;
			this.Dragable = true;
			this.Resizable = false;

			AddPage( 0 );
			AddBackground( 0, 0, 460, 100, 9270 );
			AddBackground( 0, 95, 460, 300, 9270 );
			AddHtml( 15, 110, 430, 270, html, true, true );
			AddLabel( 185, 15, 1365, @"Blue Mage Log");
			AddImage( 214, 35, 113, 1365 ); // Virtue
			AddLabel( 163, 65, 1365, @"Created By Peoharen");
			AddImage( 15, 15, 112, 1365 ); // Valor
			AddItem( 57, 50, 9903, 1365 ); // Boots
			AddItem( 87, 25, 9902, 1365 ); // Robe
			AddItem( 310, 25, 9901, 1365 ); // Cloak
			AddItem( 340, 50, 9904, 1365 ); // Gloves
			AddImage( 380, 15, 110, 1365 ); // Sacrifice
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

			switch( info.ButtonID )
			{
				case 0:
				{
					break;
				}
			}
		}
	}
}