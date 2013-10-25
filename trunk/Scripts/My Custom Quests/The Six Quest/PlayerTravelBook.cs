//This script is the string version of publicmoongate.cs script found on the RunUO forums.  
//I simply, renamed it, changed it to moveable and changed the pic to that of a hued bodbook.
//Many of the locations were copied from Traveling Books script by Broze The Newb        
//Modified by Ashlar, beloved of Morrigan

using System; 
using System.Collections.Generic; 
using Server; 
using Server.Gumps; 
using Server.Network; 
using Server.Mobiles; 

namespace Server.Items 
{ 
   public class PlayerTravelBook : Item 
   { 
      [Constructable] 
      public PlayerTravelBook() : base( 0x2252 ) 
      { 
         Movable = true; 
         Light = LightType.Circle300;
         Hue = 5; 
         Weight = 3;  
         Name = "Player Travel Book"; 
         LootType = LootType.Blessed;
 
      } 

      public PlayerTravelBook( Serial serial ) : base( serial ) 
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
         return !m.Player || UseGate( m ); 
      } 

      public bool UseGate( Mobile m ) 
      { 
         if ( m.Criminal ) 
         { 
            m.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily. 
            return false; 
         } 
         else if ( Server.Spells.SpellHelper.CheckCombat( m ) ) 
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
            m.CloseGump( typeof( PlayerTravelBookGump ) ); 
            m.SendGump( new PlayerTravelBookGump( m, this ) ); 

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

   public class PMEntry 
   { 
      private Point3D m_Location; 
      private string m_Text; 

      public Point3D Location 
      { 
         get 
         { 
            return m_Location; 
         } 
      } 

      public string Text 
      { 
         get 
         { 
            return m_Text; 
         } 
      } 

      public PMEntry( Point3D loc, string text ) 
      { 
         m_Location = loc; 
         m_Text = text; 
      } 
   } 

   public class PMList 
   { 
      private string m_Text, m_SelText; 
      private Map m_Map; 
      private PMEntry[] m_Entries; 

      public string Text 
      { 
         get 
         { 
            return m_Text; 
         } 
      } 

      public string SelText 
      { 
         get 
         { 
            return m_SelText; 
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

      public PMList( string text, string selText, Map map, PMEntry[] entries ) 
      { 
         m_Text = text; 
         m_SelText = selText; 
         m_Map = map; 
         m_Entries = entries; 
      } 

      public static readonly PMList Felucca = 
         new PMList( "Felucca", "Felucca", Map.Felucca, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 1430,1703,9 ), "Britain" ), // Britain 
			   new PMEntry( new Point3D( 2705,2162,0 ), "Buccaneers Den" ),  // Bucs Den
			   new PMEntry( new Point3D( 2237,1214,0 ), "Cove" ),  // Cove
			   new PMEntry( new Point3D( 1417,3821,0 ), "Jhelom" ), // Jhelom 
			   new PMEntry( new Point3D( 3728,2164,20 ), "Magincia" ), // Magincia
			   new PMEntry( new Point3D( 2526,583,0 ), "Minoc" ), // Minoc
			   new PMEntry( new Point3D( 4471,1177,0 ), "Moonglow" ), // Moonglow 
			   new PMEntry( new Point3D( 3770,1308,0 ), "Nu'Jelm" ),  // NuJhelom 
			   new PMEntry( new Point3D( 3626,2612,0 ), "Occlo" ),  // Occlo
			   new PMEntry( new Point3D( 2895,3479,15 ), "Serpents Hold" ),  // Serpents Hold
			   new PMEntry( new Point3D(  598,2134,0 ), "Skara Brae" ), // Skara Brae 
			   new PMEntry( new Point3D( 1823,2821,0 ), "Trinsic" ), // Trinsic 
               new PMEntry( new Point3D( 2899,676,0 ), "Vesper" ),  // Vesper 
               new PMEntry( new Point3D(  542,985,0 ), "Yew" ), // Yew 
               //new PMEntry( new Point3D( 5272,3995,37 ), "Delucia" ),  // Delucia
               //new PMEntry( new Point3D( 5729,3209,-1 ), "Papua" ),  // Papua
               new PMEntry( new Point3D( 1361,895,0 ), "Wind" )  // Wind
            } ); 

      public static readonly PMList FeluccaDungeons = 
         new PMList( "Felucca Dungeons", "Felucca Dungeons", Map.Felucca, new PMEntry[] 
		{
               new PMEntry( new Point3D( 558,1649,0 ), "Blighted Grove" ), // Blighted Grove
			   new PMEntry( new Point3D( 2498,921,0 ), "Covetous" ),  // Covetous
			   new PMEntry( new Point3D( 4596,3630,30 ), "Daemon Temple" ),  // Daemon Temple
			   new PMEntry( new Point3D( 4111,434,5 ), "Deceit" ),  // Deceit
			   new PMEntry( new Point3D( 1306,1076,0 ), "Despise" ),  // Despise
			   new PMEntry( new Point3D( 1170,2639,0), "Destard" ),  // Destard
			   new PMEntry( new Point3D( 2928,3408,5 ), "Fire" ),  // Fire
			   new PMEntry( new Point3D( 4721,3824,0 ), "Hythloth" ),  // Hythloth
               new PMEntry( new Point3D( 1998,87,4 ), "Ice" ),  // Ice
			   //new PMEntry( new Point3D( 5766,2634,43 ), "Ophidian Temple" ),  // Ophidian Temple
			   new PMEntry( new Point3D( 1022,1434,0 ), "Orc Caves" ), //Orc Caves
			   new PMEntry( new Point3D( 1716,2990,0 ), "Painted Caves" ), // Painted Caves
			   //new PMEntry( new Point3D( 5594,3019,36 ), "Palace of Paroxysmus" ), //Palace of Paroxysmus
			   new PMEntry( new Point3D( 3786,1096,14 ), "Prism of Light" ), // Prism of Light
			   new PMEntry( new Point3D( 796,1611,0 ), "Sanctuary" ), // Sanctuary
               new PMEntry( new Point3D( 511,1565,0 ), "Shame" ),  // Shame
			   new PMEntry( new Point3D( 1728,814,0 ), "Solen Hive A" ), // Solen Hive A
			   new PMEntry( new Point3D( 2613,761,0 ), "Solen Hive B" ), // Solen Hive B
			   new PMEntry( new Point3D( 1693,2786,0 ), "Solen Hive C" ), // Solen Hive C
			   new PMEntry( new Point3D( 731,1448,0 ), "Solen Hive D" ), // Solen Hive D
			   //new PMEntry( new Point3D( 5464,3151,-61 ), "Terathan Keep" ),  // Terathan Keep
               new PMEntry( new Point3D( 2043,238,10 ), "Wrong" )  // Wrong
		} );

		public static readonly PMList FeluccaMisc = 
         new PMList( "Felucca Misc", "Felucca Misc", Map.Felucca, new PMEntry[] 
		{
               new PMEntry( new Point3D( 2176,1307,0 ), "Cove Orc Forts" ), // Cove Orc Forts
			   new PMEntry( new Point3D( 2385,3485,3 ), "Fisherman's Hut" ), // Fisherman's Hut
			   new PMEntry( new Point3D( 1320,545,31 ), "Great Waterfall" ), // Great Waterfall
			   new PMEntry( new Point3D( 788,1451,0 ), "Heart Clearing" ), // Heart Clearing
			   new PMEntry( new Point3D( 1149,2236,40 ), "Hedge Maze" ), // Hedge Maze
			   new PMEntry( new Point3D( 1687,2986,0 ), "Hidden Valley" ), // Hidden Valley
			   new PMEntry( new Point3D( 2494,3585,5 ), "Island Temple" ), // Island Temple
			   new PMEntry( new Point3D( 1957,2079,0 ), "Marble Island" ), // Marble Island
			   //new PMEntry( new Point3D( 5758,2692,45 ), "Ophidian Fort" ), // Ophidian Fort
			   new PMEntry( new Point3D( 1017,2667,0 ), "Statue & Bridge" ), // Statue & Bridge
			   //new PMEntry( new Point3D( 5212,25,15 ), "Wind Park" ), // Wind Park
			   new PMEntry( new Point3D( 884,1682,0 ), "Yew Brigands" ), // Yew Brigands
			   new PMEntry( new Point3D( 634,1504,0 ), "Yew Orc Fort" ), // Yew Orc Fort
			   new PMEntry( new Point3D( 964,754,0 ), "Yew Crypts" ), // Yew Crypts
		} );

		public static readonly PMList FeluccaShrines = 
         new PMList( "Felucca Shrines", "Felucca Shrines", Map.Felucca, new PMEntry[] 
		{
               new PMEntry( new Point3D( 1458,844,5 ), "Chaos" ), // Chaos
			   new PMEntry( new Point3D( 1858,875,-1 ), "Compassion" ), // Compassion
			   new PMEntry( new Point3D( 4210,563,42 ), "Honesty" ), // Honesty
			   new PMEntry( new Point3D( 1727,3528,3 ), "Honor" ), // Honor
			   new PMEntry( new Point3D( 4274,3697,0 ), "Humility" ), // Humility
			   new PMEntry( new Point3D( 1301,634,16 ), "Justice" ), // Justice
			   new PMEntry( new Point3D( 3355,290,4 ), "Sacrifice" ), // Sacrifice
			   new PMEntry( new Point3D( 1595,2490,20 ), "Spirituality" ), // Spirituality
			   new PMEntry( new Point3D( 2492,3931,5 ), "Valor" ), // Valor
		} );

        /*public static readonly PMList FeluccaChamps =
          new PMList("Felucca Champs", "Felucca Champs", Map.Felucca, new PMEntry[] 
		{
               new PMEntry( new Point3D( 5571,821,45 ), "Despise Champ" ), // Despise Champ
			   new PMEntry( new Point3D( 5180,728,0 ), "Deciet Champ" ), // Deciet Champ
			   new PMEntry( new Point3D( 5247,831,22 ), "Destard Champ" ), // Destard Champ
			   new PMEntry( new Point3D( 5805,1350,3 ), "Fire Champ" ), // Fire Champ
			   new PMEntry( new Point3D( 5177,1611,0 ), "Terethan Champ" ), // Terethan Champ
        } );*/

      public static readonly PMList Trammel = 
         new PMList( "Trammel", "Trammel", Map.Trammel, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 1430,1703,9 ), "Britain" ), // Britain 
			   new PMEntry( new Point3D( 2705,2162,0 ), "Buccaneers Den" ),  // Bucs Den 
			   new PMEntry( new Point3D( 2237,1214,0 ), "Cove" ),  // Cove 
			  // new PMEntry( new Point3D( 3626,2612,0 ), "Haven" ),  // Haven
               new PMEntry( new Point3D( 3499,2572,14), "New Haven"),
			   new PMEntry( new Point3D( 1417,3821,0 ), "Jhelom" ), // Jhelom 
			   new PMEntry( new Point3D( 3728,2164,20 ), "Magincia" ), // Magincia 
			   new PMEntry( new Point3D( 2526,583,0 ), "Minoc" ), // Minoc 
			   new PMEntry( new Point3D( 4471,1177,0 ), "Moonglow" ), // Moonglow 
			   new PMEntry( new Point3D( 3770,1308,0 ), "Nu'Jelm" ),  // Nu'Jelm 
			   new PMEntry( new Point3D( 2895,3479,15 ), "Serpents Hold" ),  // Serpents Hold
			   new PMEntry( new Point3D(  598,2134,0 ), "Skara Brae" ), // Skara Brae
			   new PMEntry( new Point3D( 1823,2821,0 ), "Trinsic" ), // Trinsic 
			   new PMEntry( new Point3D( 2899,676,0 ), "Vesper" ),  // Vesper 
			   new PMEntry( new Point3D(  542,985,0 ), "Yew" ), // Yew 
               new PMEntry( new Point3D( 5272,3995,37 ), "Delucia" ),  // Delucia
               new PMEntry( new Point3D( 5729,3209,-1 ), "Papua" ),  // Papua
               new PMEntry( new Point3D( 1361,895,0 ), "Wind" )  // Wind
            } ); 

      public static readonly PMList TrammelDungeons = 
         new PMList( "Trammel Dungeons", "Trammel Dungeons", Map.Trammel, new PMEntry[] 
		{
               new PMEntry( new Point3D( 558,1649,0 ), "Blighted Grove" ), // Blighted Grove
			   new PMEntry( new Point3D( 2498,921,0 ), "Covetous" ),  // Covetous
			   new PMEntry( new Point3D( 4596,3630,30 ), "Daemon Temple" ),  // Daemon Temple
			   new PMEntry( new Point3D( 4111,434,5 ), "Deceit" ),  // Deceit
			   new PMEntry( new Point3D( 1301,1080,0 ), "Despise" ),  // Despise
			   new PMEntry( new Point3D( 1176,2637,0 ), "Destard" ),  // Destard
			   new PMEntry( new Point3D( 2923,3409,8 ), "Fire" ),  // Fire
			   new PMEntry( new Point3D( 4721,3824,0 ), "Hythloth" ),  // Hythloth
               new PMEntry( new Point3D( 1999,81,4 ), "Ice" ),  // Ice
			  // new PMEntry( new Point3D( 5766,2634,43 ), "Ophidian Temple" ),  // Ophidian Temple
			   new PMEntry( new Point3D( 1022,1434,0 ), "Orc Caves" ), //Orc Caves
			   new PMEntry( new Point3D( 1716,2990,0 ), "Painted Caves" ), // Painted Caves
			   //new PMEntry( new Point3D( 5587,3021,37 ), "Palace of Paroxysmus" ), //Palace of Paroxysmus
			   new PMEntry( new Point3D( 3786,1096,14), "Prism of Light" ), // Prism of Light
			   new PMEntry( new Point3D( 796,1611,0 ), "Sanctuary" ), // Sanctuary
               new PMEntry( new Point3D( 511,1565,0 ), "Shame" ),  // Shame
			   new PMEntry( new Point3D( 1728,814,0 ), "Solen Hive A" ),  // Solen Hive A
			   new PMEntry( new Point3D( 2613,761,0 ), "Solen Hive B" ), // Solen Hive B
			   new PMEntry( new Point3D( 1693,2786,0 ), "Solen Hive C" ), // Solen Hive C
			   new PMEntry( new Point3D( 731,1448,0 ), "Solen Hive D" ), // Solen Hive D
			   //new PMEntry( new Point3D( 5451,3143,-60 ), "Terathan Keep" ),  // Terathan Keep
               new PMEntry( new Point3D( 2043,238,10 ), "Wrong" )  // Wrong
		} );


		public static readonly PMList TrammelMisc = 
         new PMList( "Trammel Misc", "Trammel Misc", Map.Trammel, new PMEntry[] 
		{
               new PMEntry( new Point3D( 2176,1307,0 ), "Cove Orc Forts" ), // Cove Orc Forts
			   new PMEntry( new Point3D( 2385,3485,3 ), "Fisherman's Hut" ), // Fisherman's Hut
			   new PMEntry( new Point3D( 1320,545,31 ), "Great Waterfall" ), // Great Waterfall
			   new PMEntry( new Point3D( 788,1451,0 ), "Heart Clearing" ), // Heart Clearing
			   new PMEntry( new Point3D( 1149,2236,40 ), "Hedge Maze" ), // Hedge Maze
			   new PMEntry( new Point3D( 1687,2986,0 ), "Hidden Valley" ), // Hidden Valley
			   new PMEntry( new Point3D( 2494,3585,5 ), "Island Temple" ), // Island Temple
			   new PMEntry( new Point3D( 1957,2079,0 ), "Marble Island" ), // Marble Island
			   //new PMEntry( new Point3D( 5758,2692,45 ), "Ophidian Fort" ), // Ophidian Fort
			   new PMEntry( new Point3D( 1017,2667,0 ), "Statue & Bridge" ), // Statue & Bridge
			   //new PMEntry( new Point3D( 5212,25,15 ), "Wind Park" ), // Wind Park
			   new PMEntry( new Point3D( 884,1682,0 ), "Yew Brigands" ), // Yew Brigands
			   new PMEntry( new Point3D( 634,1504,0 ), "Yew Orc Fort" ), // Yew Orc Fort
			   new PMEntry( new Point3D( 964,754,0 ), "Yew Crypts" ), // Yew Crypts
		} );

		public static readonly PMList TrammelShrines = 
         new PMList( "Trammel Shrines", "Trammel Shrines", Map.Trammel, new PMEntry[] 
		{
               new PMEntry( new Point3D( 1458,844,5 ), "Chaos" ), // Chaos
			   new PMEntry( new Point3D( 1858,875,-1 ), "Compassion" ), // Compassion
			   new PMEntry( new Point3D( 4210,563,42 ), "Honesty" ), // Honesty
			   new PMEntry( new Point3D( 1727,3528,3 ), "Honor" ), // Honor
			   new PMEntry( new Point3D( 4274,3697,0 ), "Humility" ), // Humility
			   new PMEntry( new Point3D( 1301,634,16 ), "Justice" ), // Justice
			   new PMEntry( new Point3D( 3355,290,4 ), "Sacrifice" ), // Sacrifice
			   new PMEntry( new Point3D( 1595,2490,20 ), "Spirituality" ), // Spirituality
			   new PMEntry( new Point3D( 2492,3931,5 ), "Valor" ), // Valor
		} );

      public static readonly PMList IlshenarCityShrine = 
         new PMList( "Ilsh Cities/Shrines", "Ilsh Cities/Shrines", Map.Ilshenar, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 852,602,-40 ), "Gargoyle City" ),  // Gargoyle 
			   new PMEntry( new Point3D( 1203,1124,-25 ), "Lakeshire" ),  // Lakeshire
               new PMEntry( new Point3D( 819,1130,-29 ), "Mistas" ),  // Mistas
               new PMEntry( new Point3D( 1706,205,104 ), "Montor" ),  // Montor
               new PMEntry( new Point3D( 1747,236,58 ), "Chaos" ), // Chaos Shrine
			   new PMEntry( new Point3D( 1217,469,-13 ), "Compassion" ), // Compassion Shrine
			   new PMEntry( new Point3D( 720,1356,-59 ), "Honesty" ), // Honesty Shrine
			   new PMEntry( new Point3D( 748,731,-29 ), "Honor" ), // Honor Shrine
			   new PMEntry( new Point3D( 287,1019,0 ), "Humility" ), // Humility Shrine
			   new PMEntry( new Point3D( 987,1002,-36 ), "Justice" ), // Justice Shrine
			   new PMEntry( new Point3D( 1172,1288,-30 ), "Sacrifice" ), // Sacrifice Shrine
			   new PMEntry( new Point3D( 1530,1340,-3 ), "Spirituality" ), // Spirituality Shrine
			   new PMEntry( new Point3D( 529,212,-42 ), "Valor" ) // Valor Shrine
               
            } ); 

			public static readonly PMList IlshenarDungForts = 
         new PMList( "Ilsh Dungeons", "Ilsh Dungeons", Map.Ilshenar, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 940,503,-30 ), "Ancient Lair" ), // Ancient Lair
			   new PMEntry( new Point3D( 576,1150,-100 ), "Ankh Dungeon" ),  // Ankh
			   new PMEntry( new Point3D( 1118,651,-80 ), "Blackthorne's Castle" ), // Blackthorne's Caslte
			   new PMEntry( new Point3D( 1747,1171,-2 ), "Blood Dungeon" ),  // Blood 
			   new PMEntry( new Point3D( 887,1303,-71 ), "Cyclops" ), // Cyclops
			   new PMEntry( new Point3D( 349,1432,15 ), "Elemental Arena" ), // Elemental Arena
			   new PMEntry( new Point3D( 852,777,-80 ), "Exodus Dungeon" ), // Exodus Dungeon
			   new PMEntry( new Point3D( 314,1357,-25 ), "Lizardman Fort" ), // Lizardman Fort
			   new PMEntry( new Point3D( 641,849,-59 ), "Ratman Fort" ), // Ratman Fort
			   new PMEntry( new Point3D( 1788,573,71 ), "Rock Dungeon" ), // Rock Dungeon
			   new PMEntry( new Point3D( 1151,659,-80 ), "Savage Camp" ),  // Savage 
               new PMEntry( new Point3D( 548,462,-53 ), "Sorceror's Dungeon" ),  // Sorceror's 
               new PMEntry( new Point3D( 1362,1033,-8 ), "Spectre Dungeon" ),  // Spectre 
			   new PMEntry( new Point3D( 1450,1478,-28 ), "Twisted Weald" ), // Twisted Weald
               new PMEntry( new Point3D( 651,1302,-58 ), "Wisp Dungeon" )  // Wisp 
               
            } );

            public static readonly PMList IlshenarChamps =
              new PMList("Ilshenar Champs", "Ilshenar Champs", Map.Ilshenar, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 473,952,-87 ), "Humility Champ" ), // Humility Champ
			   new PMEntry( new Point3D( 1640,1117,-7 ), "Spirituality Champ" ),  // Spirituality Champ
               new PMEntry( new Point3D( 410,360,-56 ), "Valor Champ" ), // Valor Champ
            } );

      public static readonly PMList Malas = 
         new PMList( "Malas", "Malas", Map.Malas, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 1053,508,-90 ), "Luna Library" ), // Luna
               new PMEntry( new Point3D( 992,528,-50 ), "Luna Bank" ), // Luna
               new PMEntry( new Point3D( 2047,1353,-85 ), "Umbra" ),  // Umbra
               new PMEntry( new Point3D( 736,1381,-90 ), "Valhalla East" ),//Valhalla East
               new PMEntry( new Point3D( 639,1482,-80), "Valhalla West" ),//Valhalla West
			   new PMEntry( new Point3D( 2074,1374,-75 ), "Bedlam" ), //Bedlam
               new PMEntry( new Point3D( 2368,1267,-85 ), "Doom" ),  // Doom 
			   new PMEntry( new Point3D( 1727,982,-80 ), "Labyrinth" ), //Labyrinth
			   new PMEntry( new Point3D( 2368,1160,-90 ), "Arena" ), // Arena
			   new PMEntry( new Point3D( 1597,1829,-110 ), "Orc Fort Desert" ), // Orc Fort Desert
			   new PMEntry( new Point3D( 1343,1259,-90 ), "Orc Fort Mountain" ), // Orc Fort Mountain
			   new PMEntry( new Point3D( 2161,1164,-84 ), "Corrupted Forest" ), // Corrupted Forest
			   new PMEntry( new Point3D( 1355,601,-89 ), "Crystal Fens" ), // Crystal Fens
			   new PMEntry( new Point3D( 1860,1798,-110 ), "Forgotten Pyramid" ), // Forgotten Pyramid
			   new PMEntry( new Point3D( 2192,343,-90 ), "Grimswind Ruins" ), // Grimswind Ruins
			   new PMEntry( new Point3D( 1070,1434,-90 ), "Hanse's Hostel" ), // Hanse's Hostel
			   new PMEntry( new Point3D( 1257,1416,-95 ), "Mining Mountains" ), // Mining Mountains
			   new PMEntry( new Point3D( 1527,437,-90 ), "Northern Mountains" ), // Northern Mountains
            } ); 

      public static readonly PMList Tokuno = 
         new PMList( "Tokuno", "Tokuno", Map.Maps[4], new PMEntry[] 
            { 
               new PMEntry( new Point3D( 322,430,32 ), "Homare Bushido Dojo" ), // Homare Bushido Dojo
			   new PMEntry( new Point3D( 203,985,18 ), "Homare Crane Marsh" ),  // Homare Crane Marsh
               new PMEntry( new Point3D( 1346,768,20 ), "The Citadel" ), // The Citadel
			   new PMEntry( new Point3D( 279,1192,20 ), "Homare Defiance Point" ), // Homare Defiance Point
			   new PMEntry( new Point3D( 204,650,33 ), "Homare Echo Fields" ), // Homare Echo Fields
			   new PMEntry( new Point3D( 502,503,32 ), "Homare Kitsune Woods" ), // Homare Kitsune Woods
               new PMEntry( new Point3D( 255,789,63 ), "Homare Yomotsu Mine" ),  // Homare Yomotsu Mine
               new PMEntry( new Point3D( 727,1048,33 ), "Makoto Desert" ),  // Makoto Desert
               new PMEntry( new Point3D( 741,1261,30 ), "Makoto Zento" ), // Makoto Zento
			   new PMEntry( new Point3D( 1013,535,29 ), "Isamu Dragon Valley" ), // Isamu Dragon Valley
               new PMEntry( new Point3D( 970,222,23 ), "Isamu Fan Dancer's Dojo" ), // Isamu Fan Dancer's Dojo 
			   new PMEntry( new Point3D( 1068,845,41 ), "Isamu Lotus Lake" ), // Isamu Lotus Lake
               new PMEntry( new Point3D( 1234,772,3 ), "Isamu Mt. Sho Castle" ),  // Isamu Mt. Sho Castle 
			   new PMEntry( new Point3D( 1191,1114,17 ), "Isamu Storm Point" ), // Isamu Storm Point
			   new PMEntry( new Point3D( 925,155,48 ), "Isamu Winter Spur" ), // Isamu Winter Spur
               new PMEntry( new Point3D( 1044,523,15 ), "Isamu Valor Shrine" )  // Isamu Valor Shrine 
            } );

      public static readonly PMList TokunoChamp =
       new PMList("TokunoChamp", "TokunoChamp", Map.Maps[4], new PMEntry[] 
            { 
               new PMEntry( new Point3D( 910,472,24 ), "Tokuno Champ" ), // Tokuno Champ
            } );

      /*public static readonly PMList T2AChamps =
       new PMList("T2AChamps", "T2AChamps", Map.Felucca, new PMEntry[] 
            { 
               new PMEntry( new Point3D( 5498,2367,36 ), "N.W. Ice" ), // N.W. Ice
               new PMEntry( new Point3D( 6021,2399,23 ), "N.E Ice" ), // N.E. Ice
               new PMEntry( new Point3D( 5549,2628,15 ), "Oasis Champ" ),  // Oasis Champ
               new PMEntry( new Point3D( 5641, 2928,15 ), "Papua Champ" ),//Papua Champ
               new PMEntry( new Point3D( 6020,2942,30), "Tera Sanctum" ),//Tera Sanctum Champ
			   new PMEntry( new Point3D( 5256,3165,85 ), "Mountain Plateau Champ" ), //Mountain Plateau Champ
               new PMEntry( new Point3D( 5279,3354,31 ), "Damwind Thicket Champ" ),  //Damwind Thicket Champ 
			   new PMEntry( new Point3D( 5957,3458,0 ), "Hoppers Bog Champ" ), //Hoppers Bog Champ
			   new PMEntry( new Point3D( 5916,3632,2 ), "Orc Fort Champ" ), //Orc Fort Champ
			   new PMEntry( new Point3D( 5554,3742,0 ), "Lord Oaks Champ" ), //Lord Oaks Champs
			   new PMEntry( new Point3D( 5976,3872,1 ), "Kaldun Champ" ), //Kaldun Champ
               new PMEntry( new Point3D( 5722,3976,20 ), "Tortoise Champ" ), //Tortoise Champ

            } );*/
       
      /*Here you can edit what facets to show on the TravelBooks...*/ 

      public static readonly PMList[] UORLists = new PMList[]{ Felucca, Trammel, TrammelDungeons, FeluccaDungeons }; 
      public static readonly PMList[] LBRLists = new PMList[]{ Felucca, Trammel, IlshenarCityShrine, IlshenarChamps, TrammelDungeons, FeluccaDungeons, TokunoChamp }; 
      public static readonly PMList[] AOSLists = new PMList[]{ Felucca, FeluccaDungeons, FeluccaMisc, FeluccaShrines, Trammel, TrammelDungeons, TrammelMisc, TrammelShrines, IlshenarCityShrine, IlshenarDungForts, IlshenarChamps, Malas, Tokuno, TokunoChamp  }; 
      public static readonly PMList[] RedLists = new PMList[]{ Felucca, FeluccaDungeons }; 
   } 

   public class PlayerTravelBookGump : Gump 
   { 
      private Mobile m_Mobile; 
      private Item m_PlayerTravelBook; 
      private PMList[] m_Lists; 

      public PlayerTravelBookGump( Mobile mobile, Item PlayerTravelBook ) : base( 100, 100 ) 
      { 
         m_Mobile = mobile; 
         m_PlayerTravelBook = PlayerTravelBook; 

         PMList[] checkLists; 

         if ( mobile.Player ) 
         { 
            if ( mobile.Kills >= 5 ) 
            { 
               checkLists = PMList.RedLists; 
            } 
            else 
            {
                ClientFlags flags = mobile.NetState == null ? ClientFlags.None : mobile.NetState.Flags;
               // bool young = mobile is PlayerMobile ? ((PlayerMobile)mobile).Young : false;

                if (Core.AOS && (flags & ClientFlags.Malas) != 0)
                    checkLists = PMList.AOSLists;
                else if (Core.SE && (flags & ClientFlags.Tokuno) != 0)
                    checkLists = PMList.LBRLists;
                else
                    checkLists = PMList.UORLists;
            } 
         } 
         else 
         { 
            checkLists = PMList.AOSLists; 
         } 

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

         AddBackground( 0, 0, 450, 590, 5054 ); 

         AddButton( 10, 475, 4005, 4007, 1, GumpButtonType.Reply, 0 ); 
         AddHtmlLocalized( 45, 475, 140, 25, 1011036, false, false ); // OKAY 

         AddButton( 10, 500, 4005, 4007, 0, GumpButtonType.Reply, 0 ); 
         AddHtmlLocalized( 45, 500, 140, 25, 1011012, false, false ); // CANCEL 

         AddHtmlLocalized( 5, 5, 200, 20, 1012011, false, false ); // Pick your destination: 

         for ( int i = 0; i < checkLists.Length; ++i ) 
         { 
            AddButton( 10, 35 + (i * 25), 2117, 2118, 0, GumpButtonType.Page, Array.IndexOf( m_Lists, checkLists[i] ) + 1 ); 
            AddHtml( 30, 35 + (i * 25), 150, 20, checkLists[i].Text, false, false ); 
         } 

         for ( int i = 0; i < m_Lists.Length; ++i ) 
            RenderPage( i, Array.IndexOf( checkLists, m_Lists[i] ) ); 
      } 

      private void RenderPage( int index, int offset ) 
      { 
         PMList list = m_Lists[index]; 

         AddPage( index + 1 ); 

         AddButton( 10, 35 + (offset * 25), 2117, 2118, 0, GumpButtonType.Page, index + 1 ); 
         AddHtml( 30, 35 + (offset * 25), 150, 20, list.SelText, false, false ); 

         PMEntry[] entries = list.Entries; 

         for ( int i = 0; i < entries.Length; ++i ) 
         { 
            AddRadio( 200, 35 + (i * 25), 210, 211, false, (index * 100) + i ); 
            AddHtml( 225, 35 + (i * 25), 150, 20, entries[i].Text, false, false ); 
         } 
      } 

      public override void OnResponse( NetState state, RelayInfo info ) 
      { 
         if ( info.ButtonID == 0 ) // Cancel 
            return; 
         else if ( m_Mobile.Deleted || m_PlayerTravelBook.Deleted || m_Mobile.Map == null ) 
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

         if ( !m_Mobile.InRange( m_PlayerTravelBook.GetWorldLocation(), 1 ) || m_Mobile.Map != m_PlayerTravelBook.Map ) 
         { 
            m_Mobile.SendLocalizedMessage( 1019002 ); // You are too far away to use the gate. 
         } 
         else if ( m_Mobile.Player && m_Mobile.Kills >= 5 && list.Map != Map.Trammel ) 
         { 
            m_Mobile.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there. 
         } 
         else if ( m_Mobile.Criminal ) 
         { 
            m_Mobile.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily. 
         } 
         else if ( Server.Spells.SpellHelper.CheckCombat( m_Mobile ) ) 
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
            m_Mobile.Hidden = false; 
            m_Mobile.Map = list.Map; 
            m_Mobile.Location = entry.Location; 

            Effects.PlaySound( entry.Location, list.Map, 0x1FE ); 
         } 
      } 
   } 
} }
