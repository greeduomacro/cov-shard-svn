using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class StoneSlithClaw : BaseThrown
	{
        public override int LabelNumber{ get{ return 1112393; } } // Stone Slith Claw

		public override int MinThrowRange{ get{ return 4; } }		// MaxRange 8

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.MovingShot; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfusedThrow; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 9; } }
		public override int OldMaxDamage{ get{ return 41; } }
		public override int OldSpeed{ get{ return 20; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public StoneSlithClaw() : base( 0x901 )
		{
			Weight = 6.0;
			Layer = Layer.OneHanded;
            Hue = 2035;

            WeaponAttributes.HitHarm = 40;
            WeaponAttributes.HitLowerDefend = 40;
            Attributes.WeaponSpeed = 25;
            Attributes.WeaponDamage = 45;

            Slayer = SlayerName.Exorcism;
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            fire = cold = pois = nrgy = chaos = direct = 0;
            phys = 100;
        }
        #endregion

		public StoneSlithClaw( Serial serial ) : base( serial )
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