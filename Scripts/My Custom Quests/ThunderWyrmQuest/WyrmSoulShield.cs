using System;
using Server;

namespace Server.Items
{
	public class WyrmSoulShield : OrderShield 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public WyrmSoulShield()
		{
			Weight = 5.0;
            		Name = "a Wyrm Soul's Shield";
            		Hue = 1154;
                         
	//		Attributes.AttackChance = x;
	//		Attributes.BonusDex = 7;
	 //		Attributes.BonusHits = 10;
	//		Attributes.BonusInt = 7;
	//		Attributes.BonusMana = 10;
			Attributes.BonusStam = 10;
	//		Attributes.BonusStr = 7;
	//		Attributes.CastRecovery = x;
	//		Attributes.CastSpeed = x;
			Attributes.DefendChance = 20;
	//		Attributes.EnhancePotions = x;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 5;
			Attributes.Luck =120;
			Attributes.ReflectPhysical = 10;
			Attributes.RegenHits = 1;
			Attributes.RegenMana = 1;
			Attributes.RegenStam = 1;
			Attributes.SpellChanneling = 1; // 1 for true, 0 for false
	//		Attributes.SpellDamage = x;
	//		Attributes.WeaponDamage = x;
	//		Attributes.WeaponSpeed = x;
			Attributes.ReflectPhysical = 15;
	//		WeaponAttributes.DurabilityBonus = 10;
	//		WeaponAttributes.HitColdArea = x;
	//		WeaponAttributes.HitDispel = x;
	//		WeaponAttributes.HitEnergyArea = x;
	//		WeaponAttributes.HitFireArea = x;
	//		WeaponAttributes.HitFireball = x;
	//		WeaponAttributes.HitHarm = x;
	//		WeaponAttributes.HitLeechHits = x;
	//		WeaponAttributes.HitLeechMana = x;
	//		WeaponAttributes.HitLeechStam = x;
	//		WeaponAttributes.HitLightning = x;
	//		WeaponAttributes.HitLowerAttack = x;
	//		WeaponAttributes.HitLowerDefend = x;
	//		WeaponAttributes.HitMagicArrow = x;
	//		WeaponAttributes.HitPhysicalArea = x;
	//		WeaponAttributes.HitPoisonArea = x;
	//		WeaponAttributes.LowerStatReq = x;
	//		WeaponAttributes.MageWeapon = x; // 1 for true, 0 for false.
	//		Attributes.ResistColdBonus = 10;
	//		Attributes.ResistEnergyBonus = 10;
	//		Attributes.ResistFireBonus = 10;
	//		Attributes.ResistPhysicalBonus = 10;
	//		Attributes.ResistPoisonBonus = 10;
	//		Attributes.SelfRepair = 10;
	//		WeaponAttributes.UseBestSkill = x; // 1 for true, 0 for false.
			PhysicalBonus = 10;
			FireBonus = 8;
			ColdBonus = 8;
			PoisonBonus = 8;
			EnergyBonus = 8;

			LootType = LootType.Blessed;
		}

		public WyrmSoulShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}