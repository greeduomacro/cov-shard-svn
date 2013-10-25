// Created by Peoharen
using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;

namespace Server.Items
{
	public abstract class BaseChivMace : BaseCustomWand
	{
		public override int DefHitSound{ get{ return 0x233; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override SkillName DefSkill{ get{ return SkillName.Macing; } }
		public override WeaponType DefType{ get{ return WeaponType.Bashing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash1H; } }

		public BaseChivMace( int charges ) : base( charges )
		{
		}

		public override bool OnEquip( Mobile from )
		{
			if ( !base.OnEquip( from ) )
				return false;

			if ( from.Skills[SkillName.Chivalry].Base > 24.9 )
				WeaponAttributes.UseBestSkill = 1;

			if ( from.Skills[SkillName.Chivalry].Base > 49.9 )
				Attributes.WeaponSpeed = 10;

			if ( from.Skills[SkillName.Chivalry].Base > 74.9 )
				Attributes.AttackChance = 10;

			if ( from.Skills[SkillName.Chivalry].Base > 99.9 )
				Attributes.WeaponDamage = 10;

			if ( from.Skills[SkillName.Chivalry].Base > 109.9 )
			{
				WeaponAttributes.HitEnergyArea = 25;
				WeaponAttributes.HitLightning = 50;
				AosElementDamages.Energy = 50;
			}

			if ( from.Skills[SkillName.Chivalry].Base > 119.9 )
			{
				Attributes.CastRecovery = 1;
				Attributes.CastSpeed = 1;
				AosElementDamages.Energy = 100;
			}

			return true;
		}

		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );

			WeaponAttributes.UseBestSkill = 0;
			Attributes.WeaponSpeed = 0;
			Attributes.AttackChance = 0;
			Attributes.WeaponDamage = 0;
			WeaponAttributes.HitEnergyArea = 0;
			WeaponAttributes.HitLightning = 0;
			Attributes.CastRecovery = 0;
			Attributes.CastSpeed = 0;
			AosElementDamages.Energy = 0;
		}

		public BaseChivMace( Serial serial ) : base( serial )
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