// Created by Peoharen
using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;

namespace Server.Items
{
	public abstract class BaseNecroStaff : BaseCustomWand
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 20; } }
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

		public override int DefHitSound{ get{ return 0x233; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override SkillName DefSkill{ get{ return SkillName.Macing; } }
		public override WeaponType DefType{ get{ return WeaponType.Staff; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash2H; } }

		public BaseNecroStaff( int charges ) : base( charges )
		{
			ItemID = 0x13F8;
			Weight = 3.0;
		}

		public override bool OnEquip( Mobile from )
		{
			if ( !base.OnEquip( from ) )
				return false;

			if ( from.Skills[SkillName.Necromancy].Base > 24.9 )
				WeaponAttributes.MageWeapon = 30;

			if ( from.Skills[SkillName.Necromancy].Base > 49.9 )
				Attributes.CastRecovery = 1;

			if ( from.Skills[SkillName.Necromancy].Base > 74.9 )
				Attributes.CastSpeed = 1;

			if ( from.Skills[SkillName.Necromancy].Base > 99.9 )
				Attributes.DefendChance = 10;

			if ( from.Skills[SkillName.Necromancy].Base > 109.9 )
			{
				WeaponAttributes.HitLeechHits = 25;
				WeaponAttributes.HitFireball = 50;
				AosElementDamages.Fire = 50;
			}

			if ( from.Skills[SkillName.Necromancy].Base > 119.9 )
			{
				Attributes.AttackChance = 25;
				WeaponAttributes.HitLowerDefend = 50;
				AosElementDamages.Fire = 100;
			}

			return true;
		}

		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );

			WeaponAttributes.MageWeapon = 0;
			Attributes.CastRecovery = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			WeaponAttributes.HitLeechHits = 0;
			WeaponAttributes.HitFireball = 0;
			Attributes.AttackChance = 0;
			WeaponAttributes.HitLowerDefend = 0;
			AosElementDamages.Fire = 0;
		}

		public BaseNecroStaff( Serial serial ) : base( serial )
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