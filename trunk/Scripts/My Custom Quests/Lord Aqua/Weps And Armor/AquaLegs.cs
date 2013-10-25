using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1411, 0x141a )]
	public class AquaLegs : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 24; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 16; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		public override int AosStrReq{ get{ return 80; } }

		public override int OldStrReq{ get{ return 60; } }
		public override int OldDexBonus{ get{ return 3; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public AquaLegs() : base( 0x1411 )
		{
			Weight = 5.0;
			Name = "Aqua's Holy Legs";
			Hue = 1266;
			//LootType = LootType.Blessed;
			Attributes.Luck = 110;
			Attributes.CastRecovery = 3;
			Attributes.LowerRegCost = 17;

		}

		public AquaLegs( Serial serial ) : base( serial )
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