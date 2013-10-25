// Created by Peoharen
// MINE: SpawnNames
// MITTY: CreaturesName
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Commands
{
	public class BlueCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "BlueSpawn", AccessLevel.Administrator, new CommandEventHandler( BlueSpawnCommand_OnCommand ) );
			CommandSystem.Register( "BlueRemove", AccessLevel.Administrator, new CommandEventHandler( BlueRemoveCommand_OnCommand ) );
		}

		[Description( "Removes stuff for Blue Magic" )]
		public static void BlueRemoveCommand_OnCommand( CommandEventArgs e )
		{
			BlueSpawnerPersistence.RemoveSpawners();
		}

		[Description( "Spawns stuff for Blue Magic" )]
		public static void BlueSpawnCommand_OnCommand( CommandEventArgs e )
		{
			BlueSpawnerPersistence bsp = new BlueSpawnerPersistence();

			if ( bsp != null )
			{
				bsp.Map = Map.Malas;

				if ( !bsp.GenerateSpawners() )
					e.Mobile.SendMessage( 1365, "Blue Monster Spawners Created." );
				else
				{
					e.Mobile.SendMessage( 1365, "Old Blue Monster Spawners Removed." );
					e.Mobile.SendMessage( 1365, "Blue Monster Spawners Created." );
				}
			}
		}
	}
}

namespace Server.Items
{
	public class BlueSpawnerPersistence : Item
	{
		public static BlueSpawnerPersistence Persist;
		public static ArrayList BlueStuff = new ArrayList();

		public BlueSpawnerPersistence() : base( 0x1F1C )
		{
			Name = "Blue Spawner Persistence";
			Movable = false;

			if ( Persist == null || Persist.Deleted )
				Persist = this;
			else
				base.Delete();
		}

		public static bool RemoveSpawners()
		{
			bool erased = false;

			if ( BlueStuff.Count != 0 )
			{
				for( int i = BlueStuff.Count - 1; i > -1; i-- )
				{
					if ( BlueStuff[i] is Item )
						((Item)BlueStuff[i]).Delete();
				}

				erased = true;
			}

			return erased;
		}

		public bool GenerateSpawners()
		{
			Spawner spawner;
			Static item;
			Teleporter tele;
			bool erased = RemoveSpawners();

			#region Angels Snack
			// Loot/Quest, found on Qunia
			#endregion

			#region Autolife
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1959, 513, -20 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueTrappedPixie" );
			BlueStuff.Add( spawner );
			#endregion

			#region Bad Breath
			#endregion

			#region Blow Up
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1650, 351, -3 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueBomb" );
			spawner.Count = 5;
			spawner.HomeRange = 8;
			BlueStuff.Add( spawner );
			#endregion

			#region Demi
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 327, 532, -34 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueImp" );
			spawner.Count = 2;
			spawner.HomeRange = 8;
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 327, 532, -33 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "Imp" );
			spawner.Count = 3;
			spawner.HomeRange = 8;
			BlueStuff.Add( spawner );
			#endregion

			#region Dragon Force
			spawner = new Spawner(); // [go 1178 1512, -68
			spawner.MoveToWorld( new Point3D( 1178, 1512, -68 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BLDragon" );
			spawner.HomeRange = 6;
			BlueStuff.Add( spawner );
			#endregion

			#region Drain Touch
			// Self Spawning
			#endregion

			#region Fifty Needles
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1530, 671, -14 ), Map.Ilshenar );
			spawner.Count = 3;
			spawner.SpawnNames.Add( "BlueCactuar" );
			BlueStuff.Add( spawner );
			#endregion

			#region Flame Thrower
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1931, 36, -28 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueGolem" );
			BlueStuff.Add( spawner );
			#endregion

			#region Frog Drop
			QuinaTele quinatele = new QuinaTele();
			quinatele.MoveToWorld( new Point3D( 919, 993, 12 ), Map.Ilshenar );
			BlueStuff.Add( quinatele );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1757, 888, -24 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueQuina" );
			BlueStuff.Add( spawner );
			// Frogs
			item = new Static( 8553 );
			item.MoveToWorld( new Point3D( 1778, 872, -24 ), Map.Ilshenar );
			BlueStuff.Add( item );
			item = new Static( 8552 );
			item.MoveToWorld( new Point3D( 1777, 872, -24 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1778, 873, -25 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1647, 721, -13 );
			BlueStuff.Add( tele );
			FrogSwampAddon frogdropaddon = new FrogSwampAddon();
			frogdropaddon.MoveToWorld( new Point3D( 1645, 699, -24 ), Map.Ilshenar );
			BlueStuff.Add( frogdropaddon );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1647, 721, -13 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1778, 873, -25 );
			BlueStuff.Add( tele );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1657, 711, -23 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueFrog" );
			spawner.HomeRange = 8;
			spawner.Count = 10;
			BlueStuff.Add( spawner );
			#endregion

			#region Goblin Punch
			GoblinCaveAddon goblincaveaddon = new GoblinCaveAddon();
			goblincaveaddon.MoveToWorld( new Point3D( 1906, 674, -21 ), Map.Ilshenar );
			BlueStuff.Add( goblincaveaddon );
			// Teleporters
			item = new Static( 8553 );
			item.MoveToWorld( new Point3D( 1706, 589, 13 ), Map.Ilshenar );
			BlueStuff.Add( item );
			item = new Static( 8553 );
			item.MoveToWorld( new Point3D( 1707, 589, 13 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1706, 590, 11 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1973, 832, -4 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1707, 590, 12 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1974, 832, -4 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1973, 832, -4 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1706, 590, 11 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1974, 832, -4 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1707, 590, 12 );
			BlueStuff.Add( tele );
			// Spawners
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1976, 808, -11 ), Map.Ilshenar ); // Main Room
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 10;
			spawner.Count = 10;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2007, 796, -21 ), Map.Ilshenar ); // Side of the Main Room
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 8;
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1968, 777, -21 ), Map.Ilshenar ); // First 'T'
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 12;
			spawner.Count = 5;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1923, 792, -21 ), Map.Ilshenar ); // Top of Circle
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 12;
			spawner.Count = 5;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1938, 807, -21 ), Map.Ilshenar ); // Bottom of Circle
			spawner.SpawnNames.Add( "Beetle" );
			spawner.SpawnNames.Add( "Beetle" );
			spawner.SpawnNames.Add( "Beetle" );
			spawner.SpawnNames.Add( "Beetle" );
			spawner.SpawnNames.Add( "Beetle" );
			spawner.SpawnNames.Add( "FireBeetle" );
			spawner.Count = 2;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1995, 758, -21 ), Map.Ilshenar ); // Another Cross Way
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 12;
			spawner.Count = 5;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1979, 742, -21 ), Map.Ilshenar ); // Just after the one above.
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 12;
			spawner.Count = 5;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1963, 727, -21 ), Map.Ilshenar ); // 'T' headed to the 2nd level
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.HomeRange = 12;
			spawner.Count = 5;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1945, 762, -21 ), Map.Ilshenar ); // Dirt Dead End (beetle here)
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.SpawnNames.Add( "BlueGoblinCaster" );
			spawner.SpawnNames.Add( "BlueGoblinMelee" );
			spawner.SpawnNames.Add( "BlueGoblin" );
			spawner.HomeRange = 12;
			spawner.Count = 5;
			BlueStuff.Add( spawner );
			#endregion

			#region Guard Off
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 318, 1228, -38 ), Map.Ilshenar );
			spawner.HomeRange = 8;
			spawner.SpawnNames.Add( "BlueRuneBeetle" );
			BlueStuff.Add( spawner );
			#endregion

			#region Level 4 Holy
			// See White Wind
			#endregion

			#region Limit Glove
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 907, 1283, -46 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueCatoblepas" );
			BlueStuff.Add( spawner );
			#endregion

			#region Magic Hammer
			#endregion

			#region Matra Magic
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1080, 1060, 0 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueTurkey" );
			spawner.HomeRange = 15;
			spawner.Count = 10;
			spawner.MinDelay = TimeSpan.FromSeconds( 30 );
			spawner.MaxDelay = TimeSpan.FromSeconds( 30 );
			BlueStuff.Add( spawner );
			#endregion

			#region Mighty Guard
			BeetleCaveAddon beetlecaveaddon = new BeetleCaveAddon();
			beetlecaveaddon.MoveToWorld( new Point3D( 1952, 567, -26 ), Map.Ilshenar );
			BlueStuff.Add( beetlecaveaddon );

			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1963, 684, -21 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 2025, 701, -9 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 2025, 701, -9 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1963, 684, -21 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 2026, 701, -9 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1963, 684, -21 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 2025, 701, -9 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1963, 684, -21 );
			BlueStuff.Add( tele );
			// Spawners
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2024, 675, -26 ), Map.Ilshenar ); // First Junction
			spawner.SpawnNames.Add( "BlueDullCopperElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1993, 675, -26 ), Map.Ilshenar ); // Near Center of Plus: Guards
			spawner.SpawnNames.Add( "BlueShadowIronElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1993, 648, -26 ), Map.Ilshenar ); // End of Plus
			spawner.SpawnNames.Add( "BlueMixedOreElemental" );
			spawner.HomeRange = 1;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2042, 660, -26 ), Map.Ilshenar ); // Minor dead End T
			spawner.SpawnNames.Add( "BlueCopperElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2058, 640, -26 ), Map.Ilshenar ); // Right Before Big Room
			spawner.SpawnNames.Add( "BlueBronzeElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2076, 576, -26 ), Map.Ilshenar ); // NE/E Meet Up
			spawner.SpawnNames.Add( "BlueIronBeetle" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2019, 613, -26 ), Map.Ilshenar ); // W Dead End
			spawner.HomeRange = 2;
			spawner.SpawnNames.Add( "BlueGoldElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2021, 586, -26 ), Map.Ilshenar ); // First Corner Headed to Lv 3
			spawner.Count = 3;
			spawner.SpawnNames.Add( "BlueAgapiteElemental" );
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1977, 605, -26 ), Map.Ilshenar ); // Second Corner Headed to Lv 3
			spawner.HomeRange = 10;
			spawner.Count = 8;
			spawner.SpawnNames.Add( "BlueEarthElemental" );
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 2049, 607, -26 ), Map.Ilshenar ); // Center of Large Room
			spawner.SpawnNames.Add( "BlueEarthElemental" );
			spawner.HomeRange = 8;
			spawner.Count = 10;
			BlueStuff.Add( spawner );
			#endregion

			#region Mindblast
			// Teleporters
			Moongate moon = new Moongate();
			moon.Dispellable = false;
			moon.Target = new Point3D( 362, 666, -28 );
			moon.TargetMap = Map.Ilshenar;
			moon.Hue = 991;
			moon.Name = "To a far off place...";
			moon.MoveToWorld( new Point3D( 1183, 1130, -5 ), Map.Ilshenar );
			BlueStuff.Add( moon );

			item = new Static( 14186 );
			item.Hue = 991;
			item.MoveToWorld( new Point3D( 1183, 1130, -5 ), Map.Ilshenar );
			BlueStuff.Add( item );

			ArcaneCircleAddon arcanecircleaddon = new ArcaneCircleAddon();
			arcanecircleaddon.Hue = 991;
			arcanecircleaddon.MoveToWorld( new Point3D( 1183, 1130, -5 ), Map.Ilshenar );
			BlueStuff.Add( arcanecircleaddon );

			moon = new Moongate();
			moon.Dispellable = false;
			moon.Target = new Point3D( 1183, 1130, -5 );
			moon.TargetMap = Map.Ilshenar;
			moon.Hue = 991;
			moon.Name = "Back to your reality.";
			moon.MoveToWorld( new Point3D( 362, 666, -28 ), Map.Ilshenar );
			BlueStuff.Add( moon );

			// Area
			MindflayerAddon mindflayeraddon = new MindflayerAddon();
			mindflayeraddon.MoveToWorld( new Point3D( 323, 658, -28 ), Map.Ilshenar );
			BlueStuff.Add( mindflayeraddon );
			new MindflayerRegion();

			// Spawners
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 329, 666, -28 ), Map.Ilshenar );
			spawner.Count = 2;
			spawner.SpawnNames.Add( "BlueMindflayer" );
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 338, 666, -28 ), Map.Ilshenar );
			spawner.Count = 2;
			spawner.SpawnNames.Add( "BlueMindflayer" );
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 347, 666, -28 ), Map.Ilshenar );
			spawner.Count = 2;
			spawner.SpawnNames.Add( "BlueMindflayer" );
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 355, 666, -28 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueMindflayer" );
			BlueStuff.Add( spawner );
			#endregion

			#region Night
			#endregion

			#region Poison Claw
			// Quest
			#endregion

			#region Shadow Flare
			// Quest
			#endregion

			#region Shield
			#endregion

			#region Stare
			item = new Static( 1180 );
			item.Hue = 1;
			item.MoveToWorld( new Point3D( 1960, 642, -26 ), Map.Ilshenar );
			BlueStuff.Add( item );
			item = new Static( 1180 );
			item.Hue = 1;
			item.MoveToWorld( new Point3D( 1961, 642, -26 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1960, 642, -26 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1962, 495, 39 );
			BlueStuff.Add( tele );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1961, 642, -26 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1962, 495, 39 );
			BlueStuff.Add( tele );
			BeholderCaveAddon beholdercave = new BeholderCaveAddon();
			beholdercave.MoveToWorld( new Point3D( 1948, 481, -20 ), Map.Ilshenar );
			BlueStuff.Add( beholdercave );

			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1962, 496, 57 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1961, 642, -26 );
			BlueStuff.Add( tele );

			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1977, 488, 27 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "Gazer" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1979, 505, 7 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "ElderGazer" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			item = new Static( 1180 );
			item.Hue = 1;
			item.MoveToWorld( new Point3D( 1952, 515, -20 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1952, 515, -20 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1959, 542, 40 );
			BlueStuff.Add( tele );

			item = new Static( 3024 ); // Sign
			item.MoveToWorld( new Point3D( 1951, 515, -26 ), Map.Ilshenar );
			item.Name = "Warning! Point of no return (without recall).";
			BlueStuff.Add( item );
			item = new Static( 19 ); // Pole
			item.MoveToWorld( new Point3D( 1951, 515, -20 ), Map.Ilshenar );
			BlueStuff.Add( item );

			AnkhNorth ankh = new AnkhNorth( true );
			ankh.Hue = 1109;
			ankh.MoveToWorld( new Point3D( 1955, 540, -20 ), Map.Ilshenar );
			BlueStuff.Add( ankh );

			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1975, 546, -20 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueBeholder" );
			spawner.MinDelay = TimeSpan.FromMinutes( 1 );
			spawner.MaxDelay = TimeSpan.FromMinutes( 3 );
			BlueStuff.Add( spawner );
			#endregion

			#region Switch
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 607, 1315, -55 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueMongbat" );
			spawner.Count = 5;
			spawner.HomeRange = 8;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 607, 1315, -54 ), Map.Ilshenar );
			spawner.Count = 15;
			spawner.HomeRange = 8;
			spawner.SpawnNames.Add( "Mongbat" );
			BlueStuff.Add( spawner );
			#endregion

			#region Thrust Kick
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1412, 804, -24 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueSkitteringHopper" );
			spawner.Count = 3;
			spawner.HomeRange = 8;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1412, 804, -24 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "SkitteringHopper" );
			spawner.Count = 5;
			spawner.HomeRange = 8;
			BlueStuff.Add( spawner );
			#endregion

			#region Trine
			#endregion

			#region Vanish
			#endregion

			#region White Wind
			// A to B
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1463, 270, 42 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1463, 270, 42 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1191, 498, 103 );
			BlueStuff.Add( tele );
			// B to A
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1191, 498, 103 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1191, 498, 103 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1463, 270, 42 );
			BlueStuff.Add( tele );
			// Walk over fix
			item = new Static( 16168 );
			item.MoveToWorld( new Point3D( 1194, 507, 104 ), Map.Ilshenar );
			BlueStuff.Add( item );
			item = new Static( 16168 );
			item.MoveToWorld( new Point3D( 1194, 508, 104 ), Map.Ilshenar );
			BlueStuff.Add( item );
			item = new Static( 16168 );
			item.MoveToWorld( new Point3D( 1195, 507, 104 ), Map.Ilshenar );
			BlueStuff.Add( item );
			item = new Static( 16168 );
			item.MoveToWorld( new Point3D( 1195, 508, 104 ), Map.Ilshenar );
			BlueStuff.Add( item );
			// Monsters
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1199, 511, 95 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueSnowElemental" );
			spawner.Count = 4;
			BlueStuff.Add( spawner );
			// C to D
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1212, 507, 63 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1212, 507, 63 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1455, 310, 100 );
			BlueStuff.Add( tele );
			// D to C
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1455, 310, 100 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1455, 310, 100 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1212, 507, 63 );
			BlueStuff.Add( tele );
			// Monsters
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1457, 290, 80 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueSnowElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1455, 307, 109 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueSnowElemental" );
			spawner.Count = 3;
			BlueStuff.Add( spawner );
			// E to F
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1461, 290, 71 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1461, 290, 71 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1226, 428, 71 );
			BlueStuff.Add( tele );
			// F to E
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1226, 428, 71 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1226, 428, 71 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1461, 290, 71 );
			BlueStuff.Add( tele );
			// Monsters
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 1240, 439, 89 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueSnowElemental" );
			spawner.Count = 6;
			BlueStuff.Add( spawner );
			// G to H
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 1257, 455, 65 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 1257, 455, 65 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 430, 612, -32 );
			BlueStuff.Add( tele );
			// H to G
			item = new Static( 14186 );
			item.MoveToWorld( new Point3D( 430, 612, -32 ), Map.Ilshenar );
			BlueStuff.Add( item );
			tele = new Teleporter();
			tele.MoveToWorld( new Point3D( 430, 612, -32 ), Map.Ilshenar );
			tele.MapDest = Map.Ilshenar;
			tele.PointDest = new Point3D( 1257, 455, 65 );
			BlueStuff.Add( tele );
			// Monsters
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 450, 619, -29 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BlueEtherealWarrior" );
			spawner.Count = 3;
			spawner.HomeRange = 10;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 450, 619, -28 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "BluePixie" );
			spawner.Count = 6;
			spawner.HomeRange = 10;
			BlueStuff.Add( spawner );
			spawner = new Spawner();
			spawner.MoveToWorld( new Point3D( 450, 619, -27 ), Map.Ilshenar );
			spawner.SpawnNames.Add( "Wisp" );
			spawner.Count = 4;
			spawner.HomeRange = 10;
			BlueStuff.Add( spawner );
			#endregion


			return erased;
		}

		public BlueSpawnerPersistence( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version

			writer.Write( (Item)Persist );
			writer.WriteItemList( BlueStuff );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Persist = (BlueSpawnerPersistence)reader.ReadItem();
			BlueStuff = (ArrayList)reader.ReadItemList();
			new MindflayerRegion();
		}
	}
}