using System;
using System.Collections;
using Server;
using Server.Commands;
using Server.Mobiles;
using Server.Items;

namespace Server
{
	public class GenerateOFQ
	{
		public GenerateOFQ()
		{
		}

		public static void Initialize()
		{
			CommandSystem.Register( "GenOFQ", AccessLevel.Administrator, new CommandEventHandler( GenerateOFQ_OnCommand ) );
		}

		[Usage( "GenOFQ" )]
		[Description( "Generates Orcish Forge Quest" )]
		public static void GenerateOFQ_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Generating Orcish Forge Quest..." );

			GenSpawners.CreateSpawners();

			e.Mobile.SendMessage( "Quest Generation Complete!" );
		}

		public class GenSpawners
		{

			private const bool TotalRespawn = true;
			private static TimeSpan MinTime = TimeSpan.FromMinutes( 3 );
			private static TimeSpan MaxTime = TimeSpan.FromMinutes( 5 );

			public GenSpawners()
			{
			}

			private static Queue m_ToDelete = new Queue();

			public static void ClearSpawners( int x, int y, int z, Map map )
			{
				IPooledEnumerable eable = map.GetItemsInRange( new Point3D( x, y, z ), 0 );

				foreach ( Item item in eable )
				{
					if ( item is Spawner && item.Z == z )
						m_ToDelete.Enqueue( item );
				}

				eable.Free();

				while ( m_ToDelete.Count > 0 )
					((Item)m_ToDelete.Dequeue()).Delete();
			}

			public static void CreateSpawners()
			{
				PlaceSpawns( 5136, 2016, 0, "OFQOrc" );
				PlaceSpawns( 5355, 1999, 0, "OFQOrcBrute" );
			}

			public static void PlaceSpawns( int x, int y, int z, string types )
			{

				switch ( types )
				{
					case "OFQOrc":
						MakeSpawner( "OFQOrc", x, y, z, Map.Trammel, true );
						MinTime = TimeSpan.FromMinutes( 3 );
						MaxTime = TimeSpan.FromMinutes( 5 );
						break;
					case "OFQOrcBrute":
						MakeSpawner( "OFQOrcBrute", x, y, z, Map.Trammel, true );
						MinTime = TimeSpan.FromMinutes( 3 );
						MaxTime = TimeSpan.FromMinutes( 5 );
						break;
					default:
						break;
				}
			}

			private static void MakeSpawner( string types, int x, int y, int z, Map map, bool start )
			{
				ClearSpawners( x, y, z, map );

				Spawner sp = new Spawner( types );

				sp.Count = 1;

				sp.Running = true;
				sp.HomeRange = 1;
				sp.MinDelay = MinTime;
				sp.MaxDelay = MaxTime;

				sp.MoveToWorld( new Point3D( x, y, z ), map );

			}
		}
	}
}
