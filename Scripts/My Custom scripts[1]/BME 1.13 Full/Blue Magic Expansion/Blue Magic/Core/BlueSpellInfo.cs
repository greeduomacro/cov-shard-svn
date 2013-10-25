// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Spells.BlueMagic
{
	public partial class BlueSpellInfo
	{
		private static Type[] m_Spells = 
		{
			typeof( AngelsSnackSpell ),		// Finding Qunia
			typeof( AutoLifeSpell ),		// Trapped Pixe (escort quest)
			typeof( BadBreathSpell ),
			typeof( BlowUpSpell ),			// BlueBomb (gazer)
			typeof( DemiSpell ),			// BlueImp (---)
			typeof( DragonForceSpell ), 	// BlueDragon (orderdragon with the six flame for breath)

			typeof( DrainTouchMove ),		// BlueWight (zombie with energy drain)
			typeof( FiftyNeedlesSpell ),	// BlueCactuar (dryad)
			typeof( FlameThrowerSpell ),	// BlueGolem (---)
			typeof( FrogDropSpell ),		// BlueQuina (human, mustard bomb, trance mode, lowers karma/fame per hit)
			typeof( GoblinPunchMove ),		// BlueGoblin (uses bandages, tosses bolas)

			typeof( GuardOffSpell ),		// BlueRuneBeetle (---)
			typeof( Level4HolySpell ),		// BluePixie (white and holy prefix)
			typeof( LimitGloveMove ),		// BlueCatoblepas (lots of hp, area earthquake and lightning attack)
			typeof( MagicHammerSpell ),		// 
			typeof( MatraMagicSpell ),		// Turkey (minchamp-like)

			typeof( MightyGuardSpell ),		// BlueIronBeetle (100% resists, requires guardoff ot lots of time to kill)
			typeof( MindBlastSpell ),		// BlueMindflayer (grapple and brain eatting)
			typeof( NightSpell ),			// 
			typeof( PoisonClawMove ),		// Ivy (boss, )
			typeof( ShadowFlareSpell ),		// BlueUltimateWeapon (dark night abilities)

			typeof( ShieldSpell ),			// 
			typeof( StareSpell ),			// BlueBeholder (eye attacks)
			typeof( SwitchSpell ),			// BlueMongbat (polymorphs you into a mongbat to annoy the hell out of you)
			typeof( ThrustKickMove ), 		// BlueSkitteringHopper (---)
			typeof( TrineSpell ),			// 

			typeof( VanishSpell ), 			// 
			typeof( WhiteWindSpell ),		// BlueEtherealWarrior (white and holy prefix)
			typeof( TravelerSpell )
		};

		public static int SPELLCOUNT{ get{ return m_Spells.Length; } }

		#region UseBluePowers
		// String support for the bm command
		public static bool UseBluePower( Mobile from, string spell )
		{
			Type t = ScriptCompiler.FindTypeByFullName( "Server.Spells.BlueMagic." + spell );

			if ( t == null )
				t = ScriptCompiler.FindTypeByFullName( "Server.Spells.BlueMagic." + spell + "spell" );

			if ( t == null )
				t = ScriptCompiler.FindTypeByFullName( "Server.Spells.BlueMagic." + spell + "move" );
				
			if ( t != null )
					return UseBluePower( from, t );
			else
				return false;
		}

		// Number support for the bm command
		public static bool UseBluePower( Mobile from, int number )
		{
			return UseBluePower( from, m_Spells[CheckNumber( number )] );
		}

		// The main method used
		public static bool UseBluePower( Mobile from, Type t )
		{
			if ( t == null )
				return false;
			else if ( Array.IndexOf( m_Spells, t ) == -1 )
				return false;
			else if ( t.IsSubclassOf( typeof( BlueMove ) ) )
			{
				BlueMove bluemove = NewMove( t, from );

				if ( bluemove != null )
				{
					BlueMove.SetCurrentMove( from, bluemove );
					from.SendMessage( "You prepare to use a monster's special attack" );
					return true;
				}
			}
			else if ( t.IsSubclassOf( typeof( BlueSpell ) ) )
			{
				BlueSpell bluespell = BlueSpellInfo.NewSpell( t, from );

				if ( bluespell != null )
				{
					bluespell.Cast();
					return true;
				}
			}

			return false;
		}
		#endregion

		#region NewBlueSpell
		// creates a new spell instance
		public static BlueSpell NewSpell( Type t, Mobile caster )
		{
			if ( t == null )
				return null;
			else if ( t.IsSubclassOf( typeof( BlueSpell ) ) )
			{
				object[] someparams = new object[1];
				someparams[0] = caster;

				try
				{
					return (BlueSpell)Activator.CreateInstance( t, someparams );
				}
				catch( Exception ex )
				{
					Console.WriteLine( "Creating a new bluespell has failed." );
					Console.WriteLine( "The exception was: " + ex.Message );
				}
			}

			return null;
		}

		// creates a new move instance
		public static BlueMove NewMove( Type t, Mobile caster )
		{
			if ( t == null )
				return null;
			else if ( t.IsSubclassOf( typeof( BlueMove ) ) )
			{
				try
				{
					return (BlueMove)Activator.CreateInstance( t );
				}
				catch( Exception ex )
				{
					Console.WriteLine( "Creating a new bluemove has failed." );
					Console.WriteLine( "The exception was: " + ex.Message );
				}
			}

			return null;
		}
		#endregion

		#region OtherBlueStuff
		// sanity check
		public static int CheckNumber( int number )
		{
			if ( number < 0 )
				number = 0;
			else if ( number >= SPELLCOUNT )
				number %= SPELLCOUNT; // Randomness!

			return number;
		}

		public static bool IsBlueMove( int number )
		{
			return m_Spells[CheckNumber( number )].IsSubclassOf( typeof( BlueMove ) );
		}

		public static void UpdateTitle( Mobile m )
		{
			switch( KnowsThisMany( m ) / 5 )
			{
				case 1: m.Title = "the Apprentice Blue Mage"; break;
				case 2: m.Title = "the Journeyman Blue Mage"; break;
				case 3: m.Title = "the Expert Blue Mage"; break;
				case 4: m.Title = "the Adept Blue Mage"; break;
				case 5: m.Title = "the Master Blue Mage"; break;
				case 6: m.Title = "the Grandmaster Blue Mage"; break;
			}
		}

		public static int KnowsThisMany( Mobile m )
		{
			if ( !BlueMageControl.IsBlueMage( m ) )
				return 0;

			int count = 0;
			bool[] known = BlueMageControl.GetBoolList( m );

			for ( int i = 0; i < known.Length; i++ )
			{
				if ( known[i] )
					++count;
			}

			return count;
		}

		public static bool KnowsAllSpells( Mobile m )
		{
			return KnowsAll( m, 1 );
		}

		public static bool KnowsAllMoves( Mobile m )
		{
			return KnowsAll( m, 2 );
		}

		public static bool KnowsAll( Mobile m, int type )
		{
			if ( !BlueMageControl.IsBlueMage( m ) )
				return false;

			bool spells = true, moves = true;
			bool[] known = BlueMageControl.GetBoolList( m );

			for ( int i = 0; i < known.Length; i++ )
			{
				if ( known[i] )
					continue;
				else if ( IsBlueMove( i ) )
					moves = false;
				else
					spells = false;
			}

			if ( type == 1 )
				return spells;
			else if ( type == 2 )
				return moves;
			else
				return spells && moves;
		}
		#endregion

		#region gets
		public static Type GetSpellType( int number )
		{
			return m_Spells[ CheckNumber( number ) ];
		}

		public static int GetNumber( Type t )
		{
			int number = 100;

			for ( int i = 0; i < SPELLCOUNT; i++ )
				if ( m_Spells[i] == t )
				{
					number = i;
					break;
				}

			return number;
		}

		// gets the name of a blue spell or move using a type
		public static string GetName( Type t )
		{
			if ( t == null )
				return "";

			string name = t.Name;

			if ( t.IsSubclassOf( typeof( BlueMove ) ) )
			{
				return name.Remove( (t.Name.Length - 4), 4 );
			}
			else if ( t.IsSubclassOf( typeof( BlueSpell ) ) )
			{
				return name.Remove( (t.Name.Length - 5), 5 );
			}
			else
				return "";
		}

		// gets the name of a blue spell or move using an number
		public static string GetName( int spellID )
		{
			spellID = CheckNumber( spellID );

			string name = m_Spells[spellID].Name;

			if ( m_Spells[spellID].IsSubclassOf( typeof( BlueMove ) ) )
			{
				return name.Remove( (m_Spells[spellID].Name.Length - 4), 4 );
			}
			else if ( m_Spells[spellID].IsSubclassOf( typeof( BlueSpell ) ) )
			{
				return name.Remove( (m_Spells[spellID].Name.Length - 5), 5 );
			}
			else
				return "";
		}

		// creates a list containing the names of all blue spells & moves
		public static string[] GetNames()
		{
			string[] spells = new string[SPELLCOUNT];
			string name = "";

			for( int i = 0; i < SPELLCOUNT; i++ )
			{
				name = m_Spells[i].Name;

				if ( m_Spells[i].IsSubclassOf( typeof( BlueMove ) ) )
				{
					spells[i] = name.Remove( (m_Spells[i].Name.Length - 4), 4 );
				}
				else if ( m_Spells[i].IsSubclassOf( typeof( BlueSpell ) ) )
				{
					spells[i] = name.Remove( (m_Spells[i].Name.Length - 5), 5 );
				}
				else
					spells[i] = "";
			}

			return spells;
		}
		#endregion

	}
}
/*



*/



