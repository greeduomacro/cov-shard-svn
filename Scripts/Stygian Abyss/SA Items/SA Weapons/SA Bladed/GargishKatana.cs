using System;
using Server.Network;
using Server.Items;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0x48BA, 0x48BB )]
	public class GargishKatana : BaseSword
	{
        public override int LabelNumber { get { return 1097491; } } ///gargish katana

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 13; } }
		public override int AosSpeed{ get{ return 46; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 2.50f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 26; } }
		public override int OldSpeed{ get{ return 58; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

        /*public override bool OnEquip(Mobile from)
        {
            if (from.Race == Race.Gargoyle)
                this.ItemID = 0xEE6A;
            return base.OnEquip(from);
        }

        public override void OnRemoved(object parent)
        {
            //Mobile m = parent as Mobile;
            //if (m != null)
              this.ItemID = 0x8BA;
            base.OnRemoved(parent);
            }*/
   
		[Constructable]
		public GargishKatana() : base( 0x48BA )
		{
			Weight = 6.0;
		}

		public GargishKatana( Serial serial ) : base( serial )
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
}