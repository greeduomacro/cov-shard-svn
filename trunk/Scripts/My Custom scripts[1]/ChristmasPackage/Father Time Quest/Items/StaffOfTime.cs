using System;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{

	public class StaffOfTime : BaseStaff
	{
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosMinDamage { get { return 18; } }
        public override int AosMaxDamage { get { return 27; } }
        public override int AosSpeed { get { return 39; } }

        public override int ArtifactRarity { get { return 640; } }
        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }

		[Constructable]
        public StaffOfTime()
            : base(0x13F8)
		{
            Name = "Staff Of Time";
            Hue = 1153;

            LootType = LootType.Blessed;
            Attributes.SpellChanneling = 1;
            Attributes.NightSight = 1;
            Attributes.RegenHits = 3;
            Attributes.RegenStam = 3;

            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.HitLeechStam = 18;

            Attributes.AttackChance = 15;
            Attributes.DefendChance = 18;
            Attributes.WeaponSpeed = 28;
            Attributes.Luck = 200;
            Attributes.ReflectPhysical = 19;
            WeaponAttributes.HitPhysicalArea = 10;
            WeaponAttributes.ResistPhysicalBonus = 20;
            WeaponAttributes.SelfRepair = 5;

            Attributes.CastSpeed = 1;
            Attributes.CastRecovery = 3;
            Attributes.LowerManaCost = 20;
            Attributes.LowerRegCost = 15;
		}

        public StaffOfTime(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); 
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}