using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xE89, 0xE8a )]
	public class ResonantStaffofEnlightenment : BaseStaff
	{
        public override int LabelNumber { get { return 1113757; } } // Resonant Staff of Enlightenment

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 14; } }
		public override int AosSpeed{ get{ return 48; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 2.25f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 28; } }
		public override int OldSpeed{ get{ return 48; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		[Constructable]
		public ResonantStaffofEnlightenment() : base( 0xE89 )
		{
			Weight = 4.0;
            Hue = 1895;

            SkillBonuses.Skill_1_Name = SkillName.Magery;
            SkillBonuses.Skill_1_Value = -10;

            Attributes.SpellChanneling = 1;
            Attributes.WeaponDamage = -40;
            Attributes.WeaponSpeed = 20;
            Attributes.DefendChance = 10;

            WeaponAttributes.HitMagicArrow = 40;
            AbsorptionAttributes.ResonanceCold = 20;
		}

        public ResonantStaffofEnlightenment(Serial serial): base(serial)
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