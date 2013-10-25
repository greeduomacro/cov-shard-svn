using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SwordofGwenno : Broadsword, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 12; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public SwordofGwenno()
		{
			Name = "The Sword Of Gwenno";
			Hue = 1131;
			
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;
         	Quality = WeaponQuality.Exceptional;

				
				WeaponAttributes.HitMagicArrow = 15;
				WeaponAttributes.HitLeechHits = 10;
				WeaponAttributes.HitLeechMana = 10;
				WeaponAttributes.HitLeechStam = 20;
				WeaponAttributes.HitLowerAttack = 20;
				WeaponAttributes.HitLowerDefend = 25;
				Attributes.BonusHits = 10;
				Attributes.WeaponDamage = 30;
				Attributes.WeaponSpeed = 35;
				Attributes.RegenHits = 3;
				Attributes.SpellChanneling = 1;
				Attributes.CastSpeed = 1;
				Attributes.RegenMana = 3;
				Slayer = SlayerName.Silver; 
		}

		

		public SwordofGwenno( Serial serial ) : base( serial )
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