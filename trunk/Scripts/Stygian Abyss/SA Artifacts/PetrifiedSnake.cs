using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	// Based off a GnarledStaff
	[FlipableAttribute( 0x906, 0x406F )]
	public class PetrifiedSnake : BaseStaff
	{
        public override int LabelNumber { get { return 1113528; } }///Petrified Snake


		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 33; } }
		public override float MlSpeed{ get{ return 3.25f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 30; } }
		public override int OldSpeed{ get{ return 33; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 50; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public PetrifiedSnake() : base( 0x906 )
		{
			Weight = 3.0;
            Hue = 1438;

            Slayer = SlayerName.SnakesBane;

            AbsorptionAttributes.EaterPoison = 20;

            WeaponAttributes.HitLowerDefend = 30;
            WeaponAttributes.HitMagicArrow = 30;
            Attributes.WeaponDamage = 50;
            Attributes.WeaponSpeed = 30;

            WeaponAttributes.ResistPoisonBonus = 20;

		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = nrgy = chaos = direct = 0;
            pois = 100;
        }
        #endregion

		public PetrifiedSnake( Serial serial ) : base( serial )
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