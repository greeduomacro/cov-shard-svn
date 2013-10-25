using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	// Based off a Warfork
	[FlipableAttribute( 0x907, 0x4076 )]
	public class BladeOfBattle : BaseSword
	{
        public override int LabelNumber { get { return 1113525; } }///Blade Of Battle

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 13; } }
		public override int AosSpeed{ get{ return 43; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 4; } }
		public override int OldMaxDamage{ get{ return 32; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x236; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

		[Constructable]
		public BladeOfBattle() : base( 0x907 )
		{
            Weight = 6.0;
            Hue = 1164;
            WeaponAttributes.HitLowerDefend = 40;
            WeaponAttributes.BattleLust = 25;
            
            Attributes.WeaponSpeed = 25;
            Attributes.WeaponDamage = 50;
            Attributes.DefendChance = 10;
            Attributes.AttackChance = 15;
		}

		public BladeOfBattle( Serial serial ) : base( serial )
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