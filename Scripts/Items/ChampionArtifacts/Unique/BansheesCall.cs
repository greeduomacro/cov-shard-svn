using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class BansheesCall : BaseThrown
	{
        public override int LabelNumber { get { return 1113529; } } //
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

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public BansheesCall() : base( 0x901 )
		{
			Weight = 6.0;
            Hue = 2124;
			Layer = Layer.OneHanded;

            Attributes.BonusStr = 5;
            Velocity = 35;
            //DamageModifier.Cold = 100;
            Attributes.WeaponDamage = 50;
            Attributes.WeaponSpeed = 30;
            WeaponAttributes.HitLeechHits = 45;
            WeaponAttributes.HitHarm = 40;
		}

		public BansheesCall( Serial serial ) : base( serial )
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = pois = nrgy = chaos = direct = 0;
            cold = 100;
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