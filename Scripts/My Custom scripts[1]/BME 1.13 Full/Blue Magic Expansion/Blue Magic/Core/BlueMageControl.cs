// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	public class BlueMageControl
	{
		public static bool SkillLock = true;
		protected static int SPELLCOUNT{ get { return BlueSpellInfo.SPELLCOUNT; } }
		private static Dictionary<Serial, bool[]> BlueMageSpells = new Dictionary<Serial, bool[]>();

		// Check to mobile if it's a playermobile and adds them if they are.
		public static void AddBlueMage( Mobile m )
		{
			if ( !IsBlueMage( m ) && m is PlayerMobile )
			{
				if ( SkillLock && m.AccessLevel == AccessLevel.Player )
				{
					bool skillschanged = false;

					if ( m.Skills[SkillName.Magery].Base > 50.0 )
					{
						m.Skills[SkillName.Magery].Base = 50.0;
						skillschanged = true;
					}

					if ( m.Skills[SkillName.Chivalry].Base > 50.0 )
					{
						m.Skills[SkillName.Chivalry].Base = 50.0;
						skillschanged = true;
					}

					if ( m.Skills[SkillName.Necromancy].Base > 50.0 )
					{
						m.Skills[SkillName.Necromancy].Base = 50.0;
						skillschanged = true;
					}

					if ( m.Skills[SkillName.AnimalTaming].Base > 50.0 )
					{
						m.Skills[SkillName.AnimalTaming].Base = 50.0;
						skillschanged = true;
					}

					if ( m.Skills[SkillName.Spellweaving].Base > 50.0 )
					{
						m.Skills[SkillName.Spellweaving].Base = 50.0;
						skillschanged = true;
					}

					if ( m.Skills[SkillName.Mysticism].Base > 50.0 )
					{
						m.Skills[SkillName.Mysticism].Base = 50.0;
						skillschanged = true;
					}

					if ( skillschanged )
					{
						m.SendMessage( 1365, "You may not use Blue Magic if you have more than 50.0 trained in other spell casting skills or taming." );
						m.SendMessage( 1365, "So your skills have been adjusted." );
					}
				}

				BlueMageSpells.Add( m.Serial, new bool[SPELLCOUNT] );
				m.SendMessage( 1365, "You are now a Blue Mage." );
			}
		}

		// Removes the mobile if able.
		public static void RemoveBlueMage( Mobile m )
		{
			if ( IsBlueMage( m ) )
			{
				BlueMageSpells.Remove( m.Serial );
				m.SendMessage( 1365, "You are no longer a Blue Mage." );
			}
		}

		// Checks the mobile if it's a blue mage.
		public static bool IsBlueMage( Mobile m )
		{
			return BlueMageSpells.ContainsKey( m.Serial );
		}

		// Checks if the mobile is a blue mage and know it, this method can teach the spell if learn is true.
		public static bool CheckKnown( Mobile m, BlueMove move, bool learn )
		{
			return CheckKnown( m, move.GetType(), learn );
		}

		public static bool CheckKnown( Mobile m, BlueSpell spell, bool learn )
		{
			return CheckKnown( m, spell.GetType(), learn );
		}

		public static bool CheckKnown( Mobile m, Type type, bool learn )
		{
			if ( m == null )
				return false;
			if ( !IsBlueMage( m ) )
				return false;
			else if ( !m.Alive )
				return false;

			int spellID = BlueSpellInfo.GetNumber( type );

			if ( spellID == 100 )
				return false;

			bool[] boollist = BlueMageSpells[m.Serial];

			if ( boollist[spellID] )
				return true;
			else if ( learn )
			{
				boollist[spellID] = true;
				BlueMageSpells[m.Serial] = boollist;
				m.SendMessage( 1365, "You have learned " + BlueSpellInfo.GetName( spellID ) );
			}

			return false;
		}

		// A generic get playermobile method, used for logging.
		public static PlayerMobile GetMobile( Serial serial )
		{
			return World.FindMobile( serial ) as PlayerMobile;
		}

		// Gets the spells known list for a mobile.
		public static bool[] GetBoolList( Mobile m )
		{
			if ( !IsBlueMage( m ) )
				return new bool[SPELLCOUNT];
			else
				return BlueMageSpells[m.Serial];
		}

		public static void SetBoolList( Mobile m, bool[] list )
		{
			if ( !IsBlueMage( m ) )
				return;

			if ( list.Length != SPELLCOUNT )
				return;

			BlueMageSpells[m.Serial] = list;
		}

		// Teachs a blue mage all the spells.
		public static void LearnAll( Mobile m )
		{
			if ( !IsBlueMage( m ) )
				return;

			bool[] boollist = BlueMageSpells[m.Serial];

			for ( int i = 0; i < boollist.Length; i++ )
			{
				boollist[i] = true;
			}

			BlueMageSpells[m.Serial] = boollist;

			return;
		}


		// Adds to the WorldLoad/WorldSave events to create and load a blue mage save file.
		public static void Configure()
		{
			EventSink.WorldLoad += new WorldLoadEventHandler( Load );
			EventSink.WorldSave += new WorldSaveEventHandler( Save );
		}

		// Saves blue mage information to it's own file at Saves/BlueMagic/.
		public static void Save( WorldSaveEventArgs e )
		{
			if ( !Directory.Exists( "Saves/BlueMagic/" ) )
				Directory.CreateDirectory( "Saves/BlueMagic/" );

			if ( BlueMageSpells.Keys.Count > 0 )
			{
				BinaryFileWriter writer = new BinaryFileWriter( "Saves/BlueMagic/MobileAndSpellList.bin", false );

				writer.Write( (int)BlueMageSpells.Keys.Count );
				writer.Write( (int)SPELLCOUNT );

				foreach( KeyValuePair<Serial, bool[]> kvp in BlueMageSpells )
				{
					writer.Write( (Serial)kvp.Key );

					for( int j = 0; j < kvp.Value.Length; j++ )
					{
						writer.Write( (bool)kvp.Value[j] );
					}
				}

				writer.Close();
				PrintBlueMageLog();
			}
		}


		// Loads the MobileAndSpellList file the save method creates.
		public static void Load()
		{
			try
			{
				if ( !Directory.Exists( "Saves/BlueMagic/" ) )
					Console.WriteLine( "Blue Magic: No save file found." );
				else if ( !File.Exists( "Saves/BlueMagic/MobileAndSpellList.bin" ) )
					Console.WriteLine( "Blue Magic: No save file found." );
				else
				{
					Console.WriteLine( " " );
					Console.Write( "Blue Magic: Save file found, loading..." );

					using ( BinaryReader binReader = new BinaryReader( File.Open("Saves/BlueMagic/MobileAndSpellList.bin", FileMode.Open) ) )
					{
						BinaryFileReader reader = new BinaryFileReader( binReader );

						int keycount = reader.ReadInt();
						int oldspellcount = reader.ReadInt();

						for( int i = 0; i < keycount; i++ )
						{
							Serial serial = reader.ReadInt();

							if ( GetMobile( serial ) == null )
								continue;

							bool[] bools = new bool[SPELLCOUNT];

							for ( int j = 0; j < oldspellcount; j++ )
							{
								bools[j] = reader.ReadBool();
							}

							try
							{
								BlueMageSpells.Add( serial, bools );
							}
							catch
							{
								Console.WriteLine( "Adding serial " + serial.ToString() + " to blue spells known has failed" );
							}

						}

						reader.Close();
					}

					Console.WriteLine( "Done." );
				}
			}
			catch( Exception ex )
			{
				Console.WriteLine( "BlueMagic Load failed" );
				Console.WriteLine( "The exception was: " + ex.Message );
				Console.WriteLine( "Continuing normal world load." );
			}
		}

		// Prints out a file containing every blue mage's account, mobile name, and spells known.
		public static void PrintBlueMageLog()
		{
			if ( !Directory.Exists( "Data/BlueMagic/" ) )
				Directory.CreateDirectory( "Data/BlueMagic/" );

			string filepath = @"Data/BlueMagic/SpellsKnownLog.txt";

			if ( File.Exists( filepath ) )
				File.Delete( filepath );

			StreamWriter sw = new StreamWriter( filepath );

			sw.WriteLine("Blue Magic for UO was created by Peoharen");
			sw.WriteLine(" ");
			sw.WriteLine(" ");

			foreach( KeyValuePair<Serial, bool[]> kvp in BlueMageSpells )
			{
				Mobile mobile = GetMobile( kvp.Key );

				if ( mobile != null )
				{
					sw.WriteLine( "Account: " + mobile.Account.ToString() );
					sw.WriteLine( "\tCharacter: " + mobile.Name );
				}
				else
				{
					Serial s = kvp.Key;
					sw.WriteLine( "Unknown Account" );
					sw.WriteLine( "\tUnknown Mobile (Serial ID #" + s.ToString() + "): " );
				}

				bool knowsany = false;

				for( int j = 0; j < kvp.Value.Length; j++ )
				{
					if ( kvp.Value[j] )
					{
						if ( !knowsany )
						{
							sw.WriteLine( "\t\tSpells Known" );
							knowsany = true;
						}

						sw.WriteLine( "\t\t\t" + BlueSpellInfo.GetName( j ) );
					}
				}

				if ( !knowsany )
					sw.WriteLine( "\t\tKnows no spells" );

				sw.WriteLine("");
				sw.WriteLine("");
			}

			sw.Close();
		}

	}
}
/*
*/