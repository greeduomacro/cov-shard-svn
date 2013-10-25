using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class PublicMoongate : Item
	{
		public override bool ForceShowProperties{ get{ return ObjectPropertyList.Enabled; } }

		[Constructable]
		public PublicMoongate() : base( 0xF6C )
		{
			Movable = false;
			Light = LightType.Circle300;
		}

		public PublicMoongate( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.Player )
				return;

			if ( from.InRange( GetWorldLocation(), 1 ) )
				UseGate( from );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}

		public override bool OnMoveOver( Mobile m )
		{
			// Changed so criminals are not blocked by it.
			if ( m.Player )
				UseGate( m );

			return true;
		}

		public override bool HandlesOnMovement{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m is PlayerMobile )
			{
				if ( !Utility.InRange( m.Location, this.Location, 1 ) && Utility.InRange( oldLocation, this.Location, 1 ) )
					m.CloseGump( typeof( MoongateGump ) );
			}
		}

		public bool UseGate( Mobile m )
		{
			if ( m.Criminal )
			{
				m.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
				return false;
			}
			else if ( SpellHelper.CheckCombat( m ) )
			{
				m.SendLocalizedMessage( 1005564, "", 0x22 ); // Wouldst thou flee during the heat of battle??
				return false;
			}
			else if ( m.Spell != null )
			{
				m.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
				return false;
			}
			else
			{
				m.CloseGump( typeof( MoongateGump ) );
				m.SendGump( new MoongateGump( m, this ) );

				if ( !m.Hidden || m.AccessLevel == AccessLevel.Player )
					Effects.PlaySound( m.Location, m.Map, 0x20E );

				return true;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public static void Initialize()
		{
			CommandSystem.Register( "MoonGen", AccessLevel.Administrator, new CommandEventHandler( MoonGen_OnCommand ) );
		}

		[Usage( "MoonGen" )]
		[Description( "Generates public moongates. Removes all old moongates." )]
		public static void MoonGen_OnCommand( CommandEventArgs e )
		{
			DeleteAll();

			int count = 0;

			count += MoonGen( PMList.Trammel );
			count += MoonGen( PMList.Felucca );
			count += MoonGen( PMList.Ilshenar );
			count += MoonGen( PMList.Malas );
			count += MoonGen( PMList.Tokuno );
			count += MoonGen( PMList.TerMur );
            count += MoonGen( PMList.Quests );


			World.Broadcast( 0x35, true, "{0} moongates generated.", count );
		}

		private static void DeleteAll()
		{
			List<Item> list = new List<Item>();

			foreach ( Item item in World.Items.Values )
			{
				if ( item is PublicMoongate )
					list.Add( item );
			}

			foreach ( Item item in list )
				item.Delete();

			if ( list.Count > 0 )
				World.Broadcast( 0x35, true, "{0} moongates removed.", list.Count );
		}

		private static int MoonGen( PMList list )
		{
			foreach ( PMEntry entry in list.Entries )
			{
				Item item = new PublicMoongate();

				item.MoveToWorld( entry.Location, list.Map );

				if ( entry.DestName == "Umbra" ) // Umbra
					item.Hue = 0x497;
			}

			return list.Entries.Length;
		}
	}

	public class PMEntry
	{
		private Point3D m_Location;
		private string m_DestName;

		public Point3D Location
		{
			get
			{
				return m_Location;
			}
		}

		public string DestName
		{
			get
			{
				return m_DestName;
			}
		}

		public PMEntry( Point3D loc, string name )
		{
			m_Location = loc;
			m_DestName = name;
		}
	}

	public class PMList 
	{
		private string m_Name;
		private string m_DestName;
		
		private int m_NameHue, m_DestHue;
		
		private Map m_Map;
		
		private PMEntry[] m_Entries;

		public string DestName
		{
			get
			{
				return m_DestName;
			}
		}
		public string Name
		{
			get
			{
				return m_Name;
			}
		}
		
		public int NameHue
		{
			get
			{
				return m_NameHue;
			}
		}

		public int DestHue
		{
			get
			{
				return m_DestHue;
			}
		}


		public Map Map
		{
			get
			{
				return m_Map;
			}
		}

		public PMEntry[] Entries
		{
			get
			{
				return m_Entries;
			}
		}

		public PMList( string name, int namehue, int desthue, Map map, PMEntry[] entries )
		{
			m_Map = map;
			m_Entries = entries;
			m_Name = name;
			m_NameHue = namehue;
			m_DestHue = desthue;

		}

		
		
		
		/*
		     ** Maximum of: 15 characters(Including Spaces) per PMEntry, 12 PMEntrys  per PMList, 9 PMLists. **
		     
		     
		     
		   public static readonly PmList CATAGORY NAME =
		   		new PMList( "CATAGORY NAME AGAIN", CATAGORY NAME Hue, Destinations Hue, Map.DESTINATION MAP, new PMEntry[]
		   			{
		   				new PMEntry( new Point3D( X, Y, Z, ), "DESTINATION NAME" ), << After each PMEntry you put a , 
		   				new PMEntry( new Point3D( X, Y, Z, ), "DESTINATION NAME" )  << Except for the final entry.
		   			} );
	 
		 
		 
		*/
		
		
		
		public static readonly PMList Trammel =
			new PMList( "Trammel", 3, 3, Map.Trammel, new PMEntry[]
				{
					new PMEntry( new Point3D( 4467, 1283, 5 ), "Moonglow" ), // Moonglow
					new PMEntry( new Point3D( 1336, 1997, 5 ), "Britain" ), // Britain
					new PMEntry( new Point3D( 1499, 3771, 5 ), "Jhelom" ), // Jhelom
					new PMEntry( new Point3D(  771,  752, 5 ), "Yew" ), // Yew
					new PMEntry( new Point3D( 2701,  692, 5 ), "Minoc" ), // Minoc
					new PMEntry( new Point3D( 1828, 2948,-20), "Trinsic" ), // Trinsic
					new PMEntry( new Point3D(  643, 2067, 5 ), "Skara Brae" ), // Skara Brae
					new PMEntry( new Point3D( 3563, 2139, 34), "Magincia" ), // Magincia
					new PMEntry( new Point3D( 3450, 2677, 25), "New Haven" )  // New Haven
				} );

		public static readonly PMList Felucca =
			new PMList( "Felucca", 38, 38, Map.Felucca, new PMEntry[]
				{
					new PMEntry( new Point3D( 4467, 1283, 5 ), "Moonglow" ), // Moonglow
					new PMEntry( new Point3D( 1336, 1997, 5 ), "Britain" ), // Britain
					new PMEntry( new Point3D( 1499, 3771, 5 ), "Jhelom" ), // Jhelom
					new PMEntry( new Point3D(  771,  752, 5 ), "Yew" ), // Yew
					new PMEntry( new Point3D( 2701,  692, 5 ), "Minoc" ), // Minoc
					new PMEntry( new Point3D( 1828, 2948,-20), "Trinsic" ), // Trinsic
					new PMEntry( new Point3D(  643, 2067, 5 ), "Skara Brae" ), // Skara Brae
					new PMEntry( new Point3D( 3563, 2139, 34), "Magincia" ), // Magincia
					new PMEntry( new Point3D( 5258, 3931, 82 ), "Delucia" ),  // Delucia
					new PMEntry( new Point3D( 2711, 2234, 0 ), "Buccaneer's Den" )  // Buccaneer's Den
					
				} );

		public static readonly PMList Ilshenar =
			new PMList( "Ilshenar", 567, 567, Map.Ilshenar, new PMEntry[]
				{
					new PMEntry( new Point3D( 1215,  467, -13 ), "Compassion" ), // Compassion
					new PMEntry( new Point3D(  722, 1366, -60 ), "Honesty" ), // Honesty
					new PMEntry( new Point3D(  744,  724, -28 ), "Honor" ), // Honor
					new PMEntry( new Point3D(  281, 1016,   0 ), "Humility" ), // Humility
					new PMEntry( new Point3D(  987, 1011, -32 ), "Justice" ), // Justice
					new PMEntry( new Point3D( 1174, 1286, -30 ), "Sacrifice" ), // Sacrifice
					new PMEntry( new Point3D( 1532, 1340, - 3 ), "Spirituality" ), // Spirituality
					new PMEntry( new Point3D(  528,  216, -45 ), "Valor" ), // Valor
					new PMEntry( new Point3D( 1721,  218,  96 ), "Chaos" )  // Chaos
				} );

		public static readonly PMList Malas =
			new PMList( "Malas", 507, 507, Map.Malas, new PMEntry[]
				{
					new PMEntry( new Point3D( 1015,  527, -65 ), "Luna" ), // Luna
					new PMEntry( new Point3D( 1997, 1386, -85 ), "Umbra" ),  // Umbra
                    new PMEntry( new Point3D( 741, 1382, -85 ), "Valhalla East" ),
                    new PMEntry( new Point3D( 639, 1482, -80 ), "Valhalla West" ),
                   
				} );
				
		public static readonly PMList Quests =
			new PMList( "Quests", 1153, 1153, Map.Malas, new PMEntry[]
				{
                    new PMEntry( new Point3D( 895, 1433, -90 ), "Quest Gate Castle" ) 
					//new PMEntry( new Point3D(  802, 1204, 25 ), "" ), // 
					//new PMEntry( new Point3D(  270,  628, 15 ), "" )  // 
					
				} );
				
		public static readonly PMList Tokuno =
			new PMList( "Tokuno", 453, 453, Map.Tokuno, new PMEntry[]
				{
					new PMEntry( new Point3D( 1169,  998, 41 ), "Isamu-Jima" ), // Isamu-Jima
					new PMEntry( new Point3D(  802, 1204, 25 ), "Makoto-Jima" ), // Makoto-Jima
					new PMEntry( new Point3D(  270,  628, 15 ), "Homare-Jima" )  // Homare-Jima
				} );


		public static readonly PMList TerMur =
			new PMList( "TerMur", 33, 33,  Map.TerMur, new PMEntry[]
				{
					new PMEntry( new Point3D( 852,  3526, -43 ), "Royal City" ), // Isamu-Jima
					new PMEntry( new Point3D(  926, 3989, -36 ), "Holy City" ), // Makoto-Jima
					//new PMEntry( new Point3D(  270,  628, 15 ), 1063414 )  // Homare-Jima
				} );

		
		// Put the name of your catagory in one or more of the following lists dependant on who you wish access to your catagory.
		// For example if your catagory's name was SantaClaus and you wanted it accesable to red players
		// you would put SantaClaus into the RedList Like so:
		// public static readonly PMList[] RedLists		= new PMList[] { Felucca, SantaClaus };
		
		public static readonly PMList[] QuestsLists      = new PMList[] { Trammel, Felucca, Ilshenar, Malas, Tokuno, TerMur, Quests };
		
		public static readonly PMList[] UORLists		= new PMList[] { Trammel, Felucca };
		public static readonly PMList[] UORListsYoung	= new PMList[] { Trammel, Quests };
		public static readonly PMList[] LBRLists		= new PMList[] { Trammel, Felucca, Ilshenar };
		public static readonly PMList[] LBRListsYoung	= new PMList[] { Trammel, Ilshenar };
		public static readonly PMList[] AOSLists		= new PMList[] { Trammel, Felucca, Ilshenar, Malas, TerMur, Quests };
		public static readonly PMList[] AOSListsYoung	= new PMList[] { Trammel, Ilshenar, Malas, Quests };
		public static readonly PMList[] SELists			= new PMList[] { Trammel, Felucca, Ilshenar, Malas, Tokuno, TerMur, Quests };
		public static readonly PMList[] SEListsYoung	= new PMList[] { Trammel, Ilshenar, Malas, Tokuno, TerMur, Quests };
		public static readonly PMList[] RedLists		= new PMList[] { Felucca };
		public static readonly PMList[] SigilLists		= new PMList[] { Felucca };
	}

	public class MoongateGump : Gump
	{
		private Mobile m_Mobile;
		private Item m_Moongate;
		private PMList[] m_Lists;

		public MoongateGump( Mobile mobile, Item moongate ) : base( 100, 100 )
		{
			m_Mobile = mobile;
			m_Moongate = moongate;

			PMList[] checkLists;

            if (mobile.Player)
            {
                if (Factions.Sigil.ExistsOn(mobile))
                {
                    checkLists = PMList.SigilLists;
                }
                else if (mobile.Kills >= 5)
                {
                    checkLists = PMList.RedLists;
                }
                else
                {
                    ClientFlags flags = mobile.NetState == null ? ClientFlags.None : mobile.NetState.Flags;
                    bool young = mobile is PlayerMobile ? ((PlayerMobile)mobile).Young : false;

                    if (Core.SE && (flags & ClientFlags.Tokuno) != 0)
                        checkLists = young ? PMList.SEListsYoung : PMList.SELists;
                    else if (Core.AOS && (flags & ClientFlags.Malas) != 0)
                        checkLists = young ? PMList.AOSListsYoung : PMList.AOSLists;
                    else if ((flags & ClientFlags.Ilshenar) != 0)
                        checkLists = young ? PMList.LBRListsYoung : PMList.LBRLists;
                    else
                        checkLists = young ? PMList.UORListsYoung : PMList.UORLists;
                }
			}
			else
			{ 
			 checkLists = PMList.SELists;
			}
			
			
			// *********** Advanced Programmers Only Past This Point --- EDIT AT OWN RISK!! *************

			
			
			
			m_Lists = new PMList[checkLists.Length];

			for ( int i = 0; i < m_Lists.Length; ++i )
				m_Lists[i] = checkLists[i];

			for ( int i = 0; i < m_Lists.Length; ++i )
			{
				if ( m_Lists[i].Map == mobile.Map )
				{
					PMList temp = m_Lists[i];

					m_Lists[i] = m_Lists[0];
					m_Lists[0] = temp;

					break;
				}
			}

			AddPage( 0 );

			//AddBackground( 0, 0, 380, 280, 5054 );
			AddBackground(0, 0, 335, 375, 2620);
			AddAlphaRegion( 5, 5, 330, 365 );

			AddButton( 10, 275, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			//AddHtmlLocalized( 45, 210, 140, 25, 1011036, false, false ); // OKAY
			AddLabel( 45, 275, 38, "OKAY" );

			AddButton( 10, 300, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			//AddHtmlLocalized( 45, 235, 140, 25, 1011012, false, false ); // CANCEL
			AddLabel( 45, 300, 38, "CANCEL" );

			//AddHtmlLocalized( 5, 5, 200, 20, 1012011, false, false ); // Pick your destination:
            AddLabel( 190, 5, 1153, "Pick your destination:" );
            AddLabel( 15, 5, 1153, "Facets:" );
            AddLabel( 15, 350, 1153, "COV Public Moongate System By Tannis." );
			
			for ( int i = 0; i < checkLists.Length; ++i )
			{
				AddButton( 10, 35 + (i * 25), 2117, 2118, 0, GumpButtonType.Page, Array.IndexOf( m_Lists, checkLists[i] ) + 1 );
				//AddHtmlLocalized( 30, 35 + (i * 25), 150, 20, checkLists[i].DestName, false, false );
				//AddHtml( 30, 35 + (i * 25), 150, 20, checkLists[i].DestName, false, false );
				AddLabel(30, 35 + (i * 25), checkLists[i].NameHue, checkLists[i].Name ); //Unselected Catagory's Name
			}

			for ( int i = 0; i < m_Lists.Length; ++i )
				RenderPage( i, Array.IndexOf( checkLists, m_Lists[i] ) );
		}

		private void RenderPage( int index, int offset )
		{
			PMList list = m_Lists[index];

			AddPage( index + 1 );

			AddButton( 10, 35 + (offset * 25), 2117, 2118, 0, GumpButtonType.Page, index + 1 );
			//AddHtmlLocalized( 30, 35 + (offset * 25), 150, 20, list.SelNumber, false, false );
			AddLabel(30, 35 + (offset * 25), 1153, list.Name + " <--" ); // Selected Catagory's Name

			PMEntry[] entries = list.Entries;

			for ( int i = 0; i < entries.Length; ++i )
			{
				AddRadio( 185, 35 + (i * 25), 210, 211, false, (index * 100) + i );
				//AddHtmlLocalized( 225, 35 + (i * 25), 150, 20, entries[i].DestName, false, false );
				AddLabel(210, 35 + (i * 25), list.DestHue, entries[i].DestName ); // Destination Names in Catagory
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 0 ) // Cancel
				return;
			else if ( m_Mobile.Deleted || m_Moongate.Deleted || m_Mobile.Map == null )
				return;

			int[] switches = info.Switches;

			if ( switches.Length == 0 )
				return;

			int switchID = switches[0];
			int listIndex = switchID / 100;
			int listEntry = switchID % 100;

			if ( listIndex < 0 || listIndex >= m_Lists.Length )
				return;

			PMList list = m_Lists[listIndex];

			if ( listEntry < 0 || listEntry >= list.Entries.Length )
				return;

			PMEntry entry = list.Entries[listEntry];

			if ( !m_Mobile.InRange( m_Moongate.GetWorldLocation(), 1 ) || m_Mobile.Map != m_Moongate.Map )
			{
				m_Mobile.SendLocalizedMessage( 1019002 ); // You are too far away to use the gate.
			}
			else if ( m_Mobile.Player && m_Mobile.Kills >= 5 && ( list.Map != Map.Felucca || list.Map != Map.TerMur ) )
			{
				m_Mobile.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
			}
			else if ( Factions.Sigil.ExistsOn( m_Mobile ) && list.Map != Factions.Faction.Facet )
			{
				m_Mobile.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
			}
			else if ( m_Mobile.Criminal )
			{
				m_Mobile.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
			}
			else if ( SpellHelper.CheckCombat( m_Mobile ) )
			{
				m_Mobile.SendLocalizedMessage( 1005564, "", 0x22 ); // Wouldst thou flee during the heat of battle??
			}
			else if ( m_Mobile.Spell != null )
			{
				m_Mobile.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
			}
			else if ( m_Mobile.Map == list.Map && m_Mobile.InRange( entry.Location, 1 ) )
			{
				m_Mobile.SendLocalizedMessage( 1019003 ); // You are already there.
			}
			else
			{
				BaseCreature.TeleportPets( m_Mobile, entry.Location, list.Map );

				m_Mobile.Combatant = null;
				m_Mobile.Warmode = false;
				m_Mobile.Hidden = true;

				m_Mobile.MoveToWorld( entry.Location, list.Map );

				Effects.PlaySound( entry.Location, list.Map, 0x1FE );
			}
		}
	}
}
