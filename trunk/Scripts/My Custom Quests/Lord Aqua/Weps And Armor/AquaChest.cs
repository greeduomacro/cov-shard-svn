using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x144f, 0x1454 )]
	public class AquaChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int OldDexBonus{ get{ return 0; } }

		public override int ArmorBase{ get{ return 46; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int LabelNumber{ get{ return 1041372; } } // daemon bone armor

		[Constructable]
		public AquaChest() : base( 0x144F )
		{
			Weight = 5.0;
			Name = "Aqua's Pure Chest";
			Hue = 1266;
			Attributes.Luck = 50;
			Attributes.CastRecovery = 5;
			Attributes.LowerRegCost = 16;

		}

		public AquaChest( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			if ( Weight == 1.0 )
				Weight = 6.0;
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}