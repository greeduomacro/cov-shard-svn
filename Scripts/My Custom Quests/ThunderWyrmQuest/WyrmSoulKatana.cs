using System;
using Server;

namespace Server.Items
{
	public class WyrmSoulKatana : Katana 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }

		public override int AosMinDamage{ get{ return 16; } }
		public override int AosMaxDamage{ get{ return 19; } }
		public override int AosSpeed{ get{ return 46; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public WyrmSoulKatana()
		{
			Weight = 5.0;
            		Name = "a Wyrm Soul's Katana";
            		Hue = 1154;

                    Attributes.SpellChanneling = 1;
                    Attributes.BonusStr = 5;
                    Attributes.RegenHits = 15;
                    Attributes.RegenStam = 15;
                    WeaponAttributes.UseBestSkill = 1;
                    WeaponAttributes.HitLeechStam = 10;
                    Attributes.AttackChance = 18;
                    Attributes.DefendChance = 15;
                    Attributes.WeaponDamage = 40;
                    Attributes.WeaponSpeed = 35;
                    Attributes.ReflectPhysical = 25;
                    WeaponAttributes.ResistPhysicalBonus = 15;
                    WeaponAttributes.DurabilityBonus = 15;
                    WeaponAttributes.SelfRepair = 5;
                    WeaponAttributes.HitLightning = 30;
			        LootType = LootType.Blessed;
		}

		public WyrmSoulKatana( Serial serial ) : base( serial )
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