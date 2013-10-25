using System;
using Server;

namespace Server.Items
{
	public class WyrmSoulWarFork : WarFork 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 56; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public WyrmSoulWarFork()
		{
			Weight = 5.0;
            		Name = "a Wyrm Soul's Warfork";
            		Hue = 1154;
                         
			Attributes.AttackChance = 10;
			Attributes.BonusDex = 10;
	//		Attributes.BonusHits = 10;
	//		Attributes.BonusInt = 7;
	//		Attributes.BonusMana = 10;
	//		Attributes.BonusStam = 10;
	//		Attributes.BonusStr = 7;
	//		Attributes.CastRecovery = x;
	//		Attributes.CastSpeed = x;
	//		Attributes.DefendChance = 15;
	//		Attributes.EnhancePotions = x;
	//		Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			Attributes.Luck =120;
	//		Attributes.ReflectPhysical = x;
			Attributes.RegenHits = 1;
			Attributes.RegenMana = 1;
			Attributes.RegenStam = 1;
			Attributes.SpellChanneling = 1; // 1 for true, 0 for false
	//		Attributes.SpellDamage = x;
			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 30;
	//		Attributes.ReflectPhysical = x;
	//		Attributes.RegenHits = x;
	//		WeaponAttributes.DurabilityBonus = 15; 
	//		WeaponAttributes.HitColdArea = x;
	//		WeaponAttributes.HitDispel = x;
	//		WeaponAttributes.HitEnergyArea = x;
	//		WeaponAttributes.HitFireArea = x;
	//		WeaponAttributes.HitFireball = x;
	//		WeaponAttributes.HitHarm = x;
			WeaponAttributes.HitLeechHits = 40;
			WeaponAttributes.HitLeechMana = 40;
	//		WeaponAttributes.HitLeechStam = x;
	//		WeaponAttributes.HitLightning = x;
	//		WeaponAttributes.HitLowerAttack = x;
	//		WeaponAttributes.HitLowerDefend = x;
	//		WeaponAttributes.HitMagicArrow = x;
	//		WeaponAttributes.HitPhysicalArea = x;
	//		WeaponAttributes.HitPoisonArea = x;
	//		WeaponAttributes.LowerStatReq = x;
	//		WeaponAttributes.MageWeapon = x; // 1 for true, 0 for false.
	//		WeaponAttributes.ResistColdBonus = x;
	//		WeaponAttributes.ResistEnergyBonus = x;
	//		WeaponAttributes.ResistFireBonus = x;
	//		WeaponAttributes.ResistPhysicalBonus = x;
	//		WeaponAttributes.ResistPoisonBonus = x;
			WeaponAttributes.SelfRepair = 10;
			WeaponAttributes.UseBestSkill = 1; // 1 for true, 0 for false.
	//		PhysicalBonus = 20;
	//		FireBonus = -5;
	//		ColdBonus = 10;
	//		PoisonBonus = -10;
	//		EnergyBonus = 10;

			LootType = LootType.Blessed;
		}

		public WyrmSoulWarFork( Serial serial ) : base( serial )
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