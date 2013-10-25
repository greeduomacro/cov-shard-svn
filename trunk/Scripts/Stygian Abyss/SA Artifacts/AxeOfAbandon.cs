using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	// Based off a DoubleAxe
	[FlipableAttribute( 0x8FD, 0x4068 )]
	public class AxeOfAbandon : BaseAxe
	{
        public override int LabelNumber { get { return 1113863; } }///Axe Of Abandon

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 33; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 35; } }
		public override int OldSpeed{ get{ return 37; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public AxeOfAbandon() : base( 0x8FD )
		{
			Weight = 6.0;
            Hue = 1164;
            WeaponAttributes.HitLowerDefend = 40;
            WeaponAttributes.BattleLust = 10;
            Attributes.CastSpeed = 1;
            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 50;
			Attributes.DefendChance = 10;
            Attributes.AttackChance = 15;
		}

		public AxeOfAbandon( Serial serial ) : base( serial )
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