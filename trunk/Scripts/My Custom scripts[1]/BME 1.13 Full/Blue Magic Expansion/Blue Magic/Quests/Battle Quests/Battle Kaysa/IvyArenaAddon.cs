// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class IvyArenaAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new IvyArenaAddonDeed(); } }

		[Constructable]
		public IvyArenaAddon()
		{
			// Corners
			AddComponent( new AddonComponent( 90 ), 0, 0, 0 );
			//AddComponent( new AddonComponent( 89 ), 40, 40, 0 );

			// Grass Floor
			for ( int i = 1; i < 41; i++ )
				for ( int j = 1; j < 41; j++ )
					AddComponent( new AddonComponent( 13178 ), i, j, 0 );

			#region West Wall
			for ( int i = 0; i < 10; i++ )
			{
				switch( Utility.Random( 3 ) )
				{
					case 0: // 5 solid walls
					{
						for ( int j = 1; j < 5; j++ )
							AddComponent( new AddonComponent( 642 ), 0, j + (i * 4), 0 );

						break;
					}
					case 1: // Small crack
					{
						switch( Utility.Random( 3 ) )
						{
							case 0:
							{
								AddComponent( new AddonComponent( 636 ), 0, 1 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 1 + (i * 4), 5 );
								AddComponent( new AddonComponent( 633 ), 0, 1 + (i * 4), 10 );
								AddComponent( new AddonComponent( 636 ), 0, 2 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 2 + (i * 4), 5 );
								AddComponent( new AddonComponent( 634 ), 0, 2 + (i * 4), 10 );
								AddComponent( new AddonComponent( 642 ), 0, 3 + (i * 4), 0 );
								AddComponent( new AddonComponent( 642 ), 0, 4 + (i * 4), 0 );
								break;
							}
							case 1:
							{
								AddComponent( new AddonComponent( 642 ), 0, 1 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 2 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 2 + (i * 4), 5 );
								AddComponent( new AddonComponent( 633 ), 0, 2 + (i * 4), 10 );
								AddComponent( new AddonComponent( 636 ), 0, 3 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 3 + (i * 4), 5 );
								AddComponent( new AddonComponent( 634 ), 0, 3 + (i * 4), 10 );
								AddComponent( new AddonComponent( 642 ), 0, 4 + (i * 4), 0 );
								break;
							}
							case 2:
							{
								AddComponent( new AddonComponent( 642 ), 0, 1 + (i * 4), 0 );
								AddComponent( new AddonComponent( 642 ), 0, 2 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 3 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 3 + (i * 4), 5 );
								AddComponent( new AddonComponent( 633 ), 0, 3 + (i * 4), 10 );
								AddComponent( new AddonComponent( 636 ), 0, 4 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 0, 4 + (i * 4), 5 );
								AddComponent( new AddonComponent( 634 ), 0, 4 + (i * 4), 10 );
								break;
							}
						}
						break;
					}
					case 2: // Large crack
					{
						AddComponent( new AddonComponent( 636 ), 0, 1 + (i * 4), 0 );
						AddComponent( new AddonComponent( 636 ), 0, 1 + (i * 4), 5 );
						AddComponent( new AddonComponent( 633 ), 0, 1 + (i * 4), 10 );
						AddComponent( new AddonComponent( 636 ), 0, 2 + (i * 4), 0 );
						AddComponent( new AddonComponent( 633 ), 0, 2 + (i * 4), 5 );
						AddComponent( new AddonComponent( 636 ), 0, 3 + (i * 4), 0 );
						AddComponent( new AddonComponent( 634 ), 0, 3 + (i * 4), 5 );
						AddComponent( new AddonComponent( 636 ), 0, 4 + (i * 4), 0 );
						AddComponent( new AddonComponent( 636 ), 0, 4 + (i * 4), 5 );
						AddComponent( new AddonComponent( 634 ), 0, 4 + (i * 4), 10 );
						break;
					}
				}
			}
			#endregion


			#region East Wall
			for ( int i = 0; i < 10; i++ )
			{
				switch( Utility.Random( 3 ) )
				{
					case 0: // 5 solid walls
					{
						for ( int j = 1; j < 5; j++ )
							AddComponent( new AddonComponent( 642 ), 40, j + (i * 4), 0 );

						break;
					}
					case 1: // Small crack
					{
						switch( Utility.Random( 3 ) )
						{
							case 0:
							{
								AddComponent( new AddonComponent( 636 ), 40, 1 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 1 + (i * 4), 5 );
								AddComponent( new AddonComponent( 633 ), 40, 1 + (i * 4), 10 );
								AddComponent( new AddonComponent( 636 ), 40, 2 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 2 + (i * 4), 5 );
								AddComponent( new AddonComponent( 634 ), 40, 2 + (i * 4), 10 );
								AddComponent( new AddonComponent( 642 ), 40, 3 + (i * 4), 0 );
								AddComponent( new AddonComponent( 642 ), 40, 4 + (i * 4), 0 );
								break;
							}
							case 1:
							{
								AddComponent( new AddonComponent( 642 ), 40, 1 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 2 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 2 + (i * 4), 5 );
								AddComponent( new AddonComponent( 633 ), 40, 2 + (i * 4), 10 );
								AddComponent( new AddonComponent( 636 ), 40, 3 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 3 + (i * 4), 5 );
								AddComponent( new AddonComponent( 634 ), 40, 3 + (i * 4), 10 );
								AddComponent( new AddonComponent( 642 ), 40, 4 + (i * 4), 0 );
								break;
							}
							case 2:
							{
								AddComponent( new AddonComponent( 642 ), 40, 1 + (i * 4), 0 );
								AddComponent( new AddonComponent( 642 ), 40, 2 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 3 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 3 + (i * 4), 5 );
								AddComponent( new AddonComponent( 633 ), 40, 3 + (i * 4), 10 );
								AddComponent( new AddonComponent( 636 ), 40, 4 + (i * 4), 0 );
								AddComponent( new AddonComponent( 636 ), 40, 4 + (i * 4), 5 );
								AddComponent( new AddonComponent( 634 ), 40, 4 + (i * 4), 10 );
								break;
							}
						}
						break;
					}
					case 2: // Large crack
					{
						AddComponent( new AddonComponent( 636 ), 40, 1 + (i * 4), 0 );
						AddComponent( new AddonComponent( 636 ), 40, 1 + (i * 4), 5 );
						AddComponent( new AddonComponent( 633 ), 40, 1 + (i * 4), 10 );
						AddComponent( new AddonComponent( 636 ), 40, 2 + (i * 4), 0 );
						AddComponent( new AddonComponent( 633 ), 40, 2 + (i * 4), 5 );
						AddComponent( new AddonComponent( 636 ), 40, 3 + (i * 4), 0 );
						AddComponent( new AddonComponent( 634 ), 40, 3 + (i * 4), 5 );
						AddComponent( new AddonComponent( 636 ), 40, 4 + (i * 4), 0 );
						AddComponent( new AddonComponent( 636 ), 40, 4 + (i * 4), 5 );
						AddComponent( new AddonComponent( 634 ), 40, 4 + (i * 4), 10 );
						break;
					}
				}
			}
			#endregion


			#region North Wall
			for ( int i = 0; i < 10; i++ )
			{
				switch( Utility.Random( 3 ) )
				{
					case 0: // 5 solid walls
					{
						for ( int j = 1; j < 5; j++ )
							AddComponent( new AddonComponent( 641 ), j + (i * 4), 0, 0 );

						break;
					}
					case 1: // Small crack
					{
						switch( Utility.Random( 3 ) )
						{
							case 0:
							{
								AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 0, 5 );
								AddComponent( new AddonComponent( 632 ), 1 + (i * 4), 0, 10 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 0, 5 );
								AddComponent( new AddonComponent( 635 ), 2 + (i * 4), 0, 10 );
								AddComponent( new AddonComponent( 641 ), 3 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 641 ), 4 + (i * 4), 0, 0 );
								break;
							}
							case 1:
							{
								AddComponent( new AddonComponent( 641 ), 1 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 0, 5 );
								AddComponent( new AddonComponent( 632 ), 2 + (i * 4), 0, 10 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 0, 5 );
								AddComponent( new AddonComponent( 635 ), 3 + (i * 4), 0, 10 );
								AddComponent( new AddonComponent( 641 ), 4 + (i * 4), 0, 0 );
								break;
							}
							case 2:
							{
								AddComponent( new AddonComponent( 641 ), 1 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 641 ), 2 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 0, 5 );
								AddComponent( new AddonComponent( 632 ), 3 + (i * 4), 0, 10 );
								AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 0, 0 );
								AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 0, 5 );
								AddComponent( new AddonComponent( 635 ), 4 + (i * 4), 0, 10 );
								break;
							}
						}
						break;
					}
					case 2: // Large crack
					{
						AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 0, 0 );
						AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 0, 5 );
						AddComponent( new AddonComponent( 632 ), 1 + (i * 4), 0, 10 );
						AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 0, 0 );
						AddComponent( new AddonComponent( 632 ), 2 + (i * 4), 0, 5 );
						AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 0, 0 );
						AddComponent( new AddonComponent( 635 ), 3 + (i * 4), 0, 5 );
						AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 0, 0 );
						AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 0, 5 );
						AddComponent( new AddonComponent( 635 ), 4 + (i * 4), 0, 10 );
						break;
					}
				}
			}
			#endregion


			#region South Wall
			for ( int i = 0; i < 10; i++ )
			{
				switch( Utility.Random( 3 ) )
				{
					case 0: // 5 solid walls
					{
						for ( int j = 1; j < 5; j++ )
							AddComponent( new AddonComponent( 641 ), j + (i * 4), 40, 0 );

						break;
					}
					case 1: // Small crack
					{
						switch( Utility.Random( 3 ) )
						{
							case 0:
							{
								AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 40, 5 );
								AddComponent( new AddonComponent( 632 ), 1 + (i * 4), 40, 10 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 40, 5 );
								AddComponent( new AddonComponent( 635 ), 2 + (i * 4), 40, 10 );
								AddComponent( new AddonComponent( 641 ), 3 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 641 ), 4 + (i * 4), 40, 0 );
								break;
							}
							case 1:
							{
								AddComponent( new AddonComponent( 641 ), 1 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 40, 5 );
								AddComponent( new AddonComponent( 632 ), 2 + (i * 4), 40, 10 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 40, 5 );
								AddComponent( new AddonComponent( 635 ), 3 + (i * 4), 40, 10 );
								AddComponent( new AddonComponent( 641 ), 4 + (i * 4), 40, 0 );
								break;
							}
							case 2:
							{
								AddComponent( new AddonComponent( 641 ), 1 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 641 ), 2 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 40, 5 );
								AddComponent( new AddonComponent( 632 ), 3 + (i * 4), 40, 10 );
								AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 40, 0 );
								AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 40, 5 );
								AddComponent( new AddonComponent( 635 ), 4 + (i * 4), 40, 10 );
								break;
							}
						}
						break;
					}
					case 2: // Large crack
					{
						AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 40, 0 );
						AddComponent( new AddonComponent( 631 ), 1 + (i * 4), 40, 5 );
						AddComponent( new AddonComponent( 632 ), 1 + (i * 4), 40, 10 );
						AddComponent( new AddonComponent( 631 ), 2 + (i * 4), 40, 0 );
						AddComponent( new AddonComponent( 632 ), 2 + (i * 4), 40, 5 );
						AddComponent( new AddonComponent( 631 ), 3 + (i * 4), 40, 0 );
						AddComponent( new AddonComponent( 635 ), 3 + (i * 4), 40, 5 );
						AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 40, 0 );
						AddComponent( new AddonComponent( 631 ), 4 + (i * 4), 40, 5 );
						AddComponent( new AddonComponent( 635 ), 4 + (i * 4), 40, 10 );
						break;
					}
				}
			}
			#endregion
		}

		public IvyArenaAddon( Serial serial ) : base( serial )
		{
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
	}

	public class IvyArenaAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new IvyArenaAddon(); } }

		public IvyArenaAddonDeed()
		{
			Name = "an ivy arena addon";
		}

		public IvyArenaAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}