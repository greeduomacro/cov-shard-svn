using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	// Based off a BlackStaff
	[FlipableAttribute( 0x905, 0x4070 )]
	public class ChannelersDefender : BaseStaff
	{
        public override int LabelNumber { get { return 1113518; } }///ChannelersDefender

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 39; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 35; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public ChannelersDefender() : base( 0x905 )
		{
			Weight = 4.0;
            Hue = 1265;
            Attributes.DefendChance = 10;
            Attributes.WeaponSpeed = 20;
            Attributes.AttackChance = 5;
            Attributes.LowerManaCost = 5;
            Attributes.SpellChanneling = 1;
            WeaponAttributes.HitLowerAttack = 60;
            Attributes.CastRecovery = 1;
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = pois = chaos = direct = 0;
            nrgy = 100;
        }
        #endregion


        public ChannelersDefender( Serial serial ) : base( serial )
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