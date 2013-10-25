using System;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	// Based off a Dagger
	[FlipableAttribute( 0x902, 0x406A )]
	public class StoneDragonsTooth : BaseKnife
	{
        public override int LabelNumber{ get{ return 1113523; } } // Stone Dragon's Tooth

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 11; } }
		public override int AosSpeed{ get{ return 56; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 1; } }
		public override int OldMinDamage{ get{ return 3; } }
		public override int OldMaxDamage{ get{ return 15; } }
		public override int OldSpeed{ get{ return 55; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public StoneDragonsTooth() : base( 0x902 )
		{
			Weight = 1.0;
            Hue = 1154;

            AbsorptionAttributes.EaterPoison = 10;

            Attributes.RegenHits = 2;
            Attributes.WeaponDamage = 50;
            Attributes.WeaponSpeed = 10;

            WeaponAttributes.HitLowerDefend = 30;
            WeaponAttributes.HitMagicArrow = 40;
            WeaponAttributes.ResistFireBonus = 10;
		}

		public StoneDragonsTooth( Serial serial ) : base( serial )
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold = nrgy = chaos = direct = 0;
            pois = 100;
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