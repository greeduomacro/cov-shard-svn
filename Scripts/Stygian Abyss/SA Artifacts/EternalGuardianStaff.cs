using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13F8, 0x13F9 )]
	public class EternalGuardianStaff : BaseStaff
	{
        public override int LabelNumber { get { return 1112443; } } // Eternal Guardian Staff

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 33; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.25f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 30; } }
		public override int OldSpeed{ get{ return 33; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public EternalGuardianStaff() : base( 0x13F8 )
		{
			Weight = 3.0;
            Hue = 1284;
            Attributes.SpellChanneling = 1;
            Attributes.LowerManaCost = 5;
            Attributes.SpellDamage = 10;
            SkillBonuses.Skill_1_Name = SkillName.Mysticism;
            SkillBonuses.Skill_1_Value = 15;

		}

		public EternalGuardianStaff( Serial serial ) : base( serial )
		{
		}

        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            fire = cold = pois = nrgy = chaos = direct = 0;
            phys = 100;
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