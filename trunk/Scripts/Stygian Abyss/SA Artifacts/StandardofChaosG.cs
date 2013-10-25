using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	// Based off a Spear
	[FlipableAttribute( 0x904, 0x406D )]
	public class StandardofChaosG : BaseSpear
	{
        public override int LabelNumber { get { return 1113522; } }// Standard of Chaos

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 13; } }
		public override int AosSpeed{ get{ return 42; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 36; } }
		public override int OldSpeed{ get{ return 46; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public StandardofChaosG() : base( 0x904 )
		{
            Weight = 2.0;
            Hue = 1426;

            Attributes.WeaponDamage = -40;
            Attributes.WeaponSpeed = 30;
            Attributes.CastSpeed = 1;

            WeaponAttributes.HitLowerDefend = 40;
            WeaponAttributes.HitFireball = 20;
            WeaponAttributes.HitHarm = 30;
            WeaponAttributes.HitLightning = 10;
		}

		public StandardofChaosG( Serial serial ) : base( serial )
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = pois = nrgy = direct = 0;
            chaos = 100;
        }
        #endregion

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