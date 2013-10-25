using System;
using Server.Items;

namespace Server.Items
{
	public class AquaNeck : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 17; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 12; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 20; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int LabelNumber{ get{ return 1041495; } } // studded gorget, ranger armor

		[Constructable]
		public AquaNeck() : base( 0x13D6 )
		{
			Weight = 5.0;
			Name = "Aqua's Defined Neck";
			Hue = 1266;
			Attributes.Luck = 150;
			Attributes.CastRecovery = 4;
			Attributes.LowerRegCost = 16;

		}

		public AquaNeck( Serial serial ) : base( serial )
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