using System;
using Server.Items;
using Server.Mobiles;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2641, 0x2642 )]
	public class BasiliskHideBreastplate : BaseArmor
	{
        public override int LabelNumber { get { return 1115444; } }///Basilisk Hide Breastplate

		public override int BasePhysicalResistance{ get{ return 12; } }
		public override int BaseFireResistance{ get{ return 14; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 11; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int AosStrReq{ get{ return 75; } }
		public override int OldStrReq{ get{ return 60; } }

		public override int OldDexBonus{ get{ return -8; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Dragon; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RedScales; } }

		[Constructable]
		public BasiliskHideBreastplate() : base( 0x2641 )
		{
			Weight = 10.0;
            Hue = 3;
            Attributes.BonusDex = 5;
            Attributes.DefendChance = 5;
            Attributes.RegenMana = 1;
            Attributes.RegenStam = 2;
            Attributes.RegenHits = 2;
            Attributes.LowerManaCost = 5;
            AbsorptionAttributes.EaterDamage = 10;
		}

		public BasiliskHideBreastplate( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 15.0;
		}
	}
}