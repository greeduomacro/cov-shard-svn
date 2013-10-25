using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	public abstract class TolariaVendorPersistence : Item
	{
		public static bool Enabled = false;

		private static Dictionary<PlayerMobile, Mobile> NPCs = new Dictionary<PlayerMobile, Mobile>();

		// Set list of vendors, that way sell/buy lists remain intact
		public static Mobile[] TolariaVendors = 
		{
			null, // Alchemy
			null, // 
			null, // 
			null, // 
		};

		// Points that students can spawn at
		private static Point3D[] StudentPoints =
		{
			new Point3D( 9, 35, 0 ), // Southwest Cornor Downstairs 1
			new Point3D( 12, 37, 0 ), // Southwest Cornor Downstairs 2
			new Point3D( 11, 40, 0 ), // Southwest Cornor Downstairs 3
			new Point3D( 7, 39, 17 ), // Southwest Cornor Upstairs 1
			new Point3D( 6, 35, 17 ), // Southwest Cornor Upstairs 2
			new Point3D( 11, 35, 17 ), // Southwest Cornor Upstairs 3
			new Point3D( 0, 0, 0 ), // Northwest Cornor Downstairs 1
			new Point3D( 0, 0, 0 ), // Northwest Cornor Downstairs 2
			new Point3D( 0, 0, 0 ), // Northwest Cornor Downstairs 3
			new Point3D( 7, 11, 17 ), // Northwest Cornor Upstairs 1
			new Point3D( 11, 17, 17 ), // Northwest Cornor Upstairs 2
			new Point3D( 11, 13, 17 ), // Northwest Cornor Upstairs 3
			new Point3D( 0, 0, 0 ), // Northeast Cornor Downstairs 1
			new Point3D( 0, 0, 0 ), // Northeast Cornor Downstairs 2
			new Point3D( 0, 0, 0 ), // Northeast Cornor Downstairs 3
			new Point3D( 0, 0, 0 ), // Northeast Cornor Upstairs 1
			new Point3D( 0, 0, 0 ), // Northeast Cornor Upstairs 2
			new Point3D( 0, 0, 0 ), // Northeast Cornor Upstairs 3
			new Point3D( 0, 0, 0 ), // Southeast Cornor Downstairs 1
			new Point3D( 0, 0, 0 ), // Southeast Cornor Downstairs 2
			new Point3D( 0, 0, 0 ), // Southeast Cornor Downstairs 3
			new Point3D( 0, 0, 0 ), // Southeast Cornor Upstairs 1
			new Point3D( 0, 0, 0 ), // Southeast Cornor Upstairs 2
			new Point3D( 0, 0, 0 ), // Southeast Cornor Upstairs 3
			new Point3D( 15, 21, 0 ), // Lecture Hall, NorthWest Corner. X +0~2, Y + 0~6
			new Point3D( 33, 23, 0 ), // Scribe's Room 1
			new Point3D( 34, 20, 0 ), // Scribe's Room 2
			new Point3D( 34, 25, 0 ), // Scribe's Room 3
			new Point3D( 18, 12, 17 ), // Bedoom 1
			new Point3D( 28, 11, 17 ), // Bedoom 2, in chair
			new Point3D( 35, 18, 17 ), // Bedoom 3, standing in front of the chests
			new Point3D( 35, 29, 17 ), // Bedoom 4, in chair
			new Point3D( 29, 35, 17 ), // Bedoom 5, in chair
			new Point3D( 18, 35, 17 ), // Bedoom 6, in chair
			new Point3D( 11, 28, 17 ), // Bedoom 7, standing in front of the chests
			new Point3D( 12, 18, 17 ), // Bedoom 8, 
			// new Point3D( 0, 0, 0 ), // Double Bedroom 1, Side A
			// new Point3D( 0, 0, 0 ), // Double Bedroom 1, Side B
			// new Point3D( 0, 0, 0 ), // Double Bedroom 2, Side A
			// new Point3D( 0, 0, 0 ), // Double Bedroom 2, Side B
			new Point3D( 20, 35, 0 ), // Entrance 1
			new Point3D( 25, 28, 0 ), // Entrance 2
			new Point3D( 26, 32, 0 ), // Entrance 3
		};

		public static void Initialize()
		{
			if ( Enabled )
			{
				EventSink.Login += new LoginEventHandler( TolariaPlayerLogin );
				EventSink.Logout += new LogoutEventHandler( TolariaPlayerLogout );
			}
		}

		private static void TolariaPlayerLogin( LoginEventArgs e )
		{
			if ( Enabled && e.Mobile is PlayerMobile )
				RemoveNPC( (PlayerMobile)e.Mobile );
		}

		private static void TolariaPlayerLogout( LogoutEventArgs e )
		{
			if ( Enabled && e.Mobile is PlayerMobile )
				AddNPC( (PlayerMobile)e.Mobile );
		}

		public static void AddNPC( PlayerMobile pm )
		{
			if ( !BlueMageControl.IsBlueMage( pm ) )
				return;

			if ( NPCs.Keys.Count > 20 )
				return;

			if ( NPCs.ContainsKey( pm ) )
				RemoveNPC( pm );

			/*
				Vendor Code Here
			*/

			Point3D point = new Point3D();
			bool ok = true;

			// Ten tries to find a place to put an NPC, makes it harder to fill up with the more you have in the place.
			for ( int i = 0; i < 10; i++ )
			{
				point = StudentPoints[Utility.Random( StudentPoints.Length )];
				point.X += Tolaria.Home.X;
				point.Y += Tolaria.Home.Y;
				point.Z += Tolaria.Home.Z;

				foreach( BaseCreature bc in NPCs.Values )
				{
					if ( bc == null )
						continue;

					if ( bc.Home == point )
					{
						ok = false;
						break;
					}
				}

				if ( ok )
					break;
			}

			if ( !ok )
				return;

			NPCs.Add( pm, new TolariaNPC() );
			NPCs[pm].Name = pm.Name;
			NPCs[pm].Female = pm.Female;
			NPCs[pm].Race = pm.Race;
			NPCs[pm].Body = pm.Body;
			NPCs[pm].HairItemID = pm.HairItemID;
			NPCs[pm].HairHue = pm.HairHue;
			NPCs[pm].FacialHairItemID = pm.FacialHairItemID;
			NPCs[pm].FacialHairHue = pm.FacialHairHue;
			NPCs[pm].EquipItem( new Robe( 2207 ) );
			NPCs[pm].EquipItem( new Shoes( Utility.RandomNeutralHue() ) );
			Effects.SendLocationEffect( point, Map.Malas, 0x3709, 30, 9965, 0x501, 7 );
			NPCs[pm].MoveToWorld( point, Map.Malas );
		}

		public static void RemoveNPC( PlayerMobile pm )
		{
			if ( NPCs.ContainsKey( pm ) )
			{
				Mobile npc = NPCs[pm];
				NPCs.Remove( pm );
				Effects.SendLocationEffect( new Point3D( npc.X, npc.Y, npc.Z ), npc.Map, 0x3709, 30, 9965, 0x501, 7 );
				npc.Delete();
			}
		}

		private void CheckNPCs()
		{
			if ( TolariaVendors[0] == null )
				TolariaVendors[0] = new TolariaAlchemyVendor();
		}

		public TolariaVendorPersistence() : base( 0x35EC )
		{
			Visible = false;
		}

		public TolariaVendorPersistence( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			writer.Write( (int) TolariaVendors.Length );

			for ( int i = 0; i < TolariaVendors.Length; i++ )
				writer.Write( (Mobile) TolariaVendors[i] );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			int count = reader.ReadInt();

			for ( int i = 0; i < count && i < TolariaVendors.Length; i++ )
				TolariaVendors[i] = reader.ReadMobile();

			CheckNPCs();
		}
	}
}