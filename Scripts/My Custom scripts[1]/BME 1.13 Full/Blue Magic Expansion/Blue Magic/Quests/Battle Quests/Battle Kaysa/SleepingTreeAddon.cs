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
	public class SleepingTreeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new SleepingTreeAddonDeed(); } }

		[Constructable]
		public SleepingTreeAddon()
		{
			int itemid = 0;

			switch( Utility.Random( 5 ) )
			{
				case 0:
				{
					itemid = 0x0CCD + (Utility.Random( 3 ) * 3);
					AddComponent( new AddonComponent( itemid ), 0, 0, 0 );
					AddComponent( new AddonComponent( itemid + 1 ), 0, 0, 0 );
					break;
				}
				case 1:
				{
					itemid = 0x0CD6 + (Utility.Random( 2 ) * 2);
					AddComponent( new AddonComponent( itemid ), 0, 0, 0 );
					AddComponent( new AddonComponent( itemid + 1 ), 0, 0, 0 );
					break;
				}
				case 2:
				{
					itemid = 0x0CDA + (Utility.Random( 5 ) * 3);
					AddComponent( new AddonComponent( itemid ), 0, 0, 0 );
					AddComponent( new AddonComponent( itemid + 1 ), 0, 0, 0 );
					break;
				}
				case 3:
				{
					itemid = 0x0CF8 + (Utility.Random( 4 ) * 3);
					AddComponent( new AddonComponent( itemid ), 0, 0, 0 );
					AddComponent( new AddonComponent( itemid + 1 ), 0, 0, 0 );
					break;
				}
				case 4:
				{
					itemid = 0x0D94 + (Utility.Random( 6 ) * 4);
					AddComponent( new AddonComponent( itemid ), 0, 0, 0 );
					AddComponent( new AddonComponent( itemid + 1 ), 0, 0, 0 );
					break;
				}
			}
		}

		public void WakeUp( Mobile m )
		{
			Visible = false;

			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y, this.Z + 4 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y, this.Z ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y, this.Z - 4 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X, this.Y + 1, this.Z + 4 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X, this.Y + 1, this.Z ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X, this.Y + 1, this.Z - 4 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y + 1, this.Z + 11 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y + 1, this.Z + 7 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y + 1, this.Z + 3 ), this.Map, 0x3728, 13, 1435, 4 );
			Effects.SendLocationEffect( new Point3D( this.X + 1, this.Y + 1, this.Z - 1 ), this.Map, 0x3728, 13, 1435, 4 );

			int max = Utility.Random( 3 ) + 1;

			for ( int i = 0; i < max; i++ )
			{
				BlueTreeGuardian creature = new BlueTreeGuardian();
				creature.Freeze( TimeSpan.FromSeconds( 1.1 ) );
				creature.MoveToWorld( this.Location, this.Map );
				creature.Animate( 12, 5, 1, true, false, 0 );
				creature.Combatant = m;
			}

			Delete();
		}

		public SleepingTreeAddon( Serial serial ) : base( serial )
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

	public class SleepingTreeAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new SleepingTreeAddon(); } }

		public SleepingTreeAddonDeed()
		{
			Name = "a sleeping tree addon";
		}

		public SleepingTreeAddonDeed( Serial serial ) : base( serial )
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