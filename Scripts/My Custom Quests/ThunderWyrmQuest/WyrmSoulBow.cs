using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class WyrmSoulBow : CompositeBow 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 18; } }
		public override int AosSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public WyrmSoulBow()
		{
			Weight = 5.0;
            Name = "a Wyrm Soul's Bow";
            Hue = 1154;
                         
			Attributes.AttackChance = 15;
			Attributes.BonusDex = 5;
			Attributes.BonusHits = 10;
			Attributes.BonusStr = 7;
			Attributes.DefendChance = 15;	
			Attributes.Luck =200;	
			Attributes.RegenHits = 2;	
			Attributes.SpellChanneling = 1; // 1 for true, 0 for false
			Attributes.WeaponDamage = 45;
			Attributes.WeaponSpeed = 45;
			Attributes.RegenHits = 2;
			WeaponAttributes.HitLeechMana = 25;
			WeaponAttributes.HitLowerAttack = 15;
			WeaponAttributes.SelfRepair = 5;

			LootType = LootType.Blessed;
		}

		public WyrmSoulBow( Serial serial ) : base( serial )
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