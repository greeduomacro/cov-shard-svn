using System;
using Server;

namespace Server.Items
{
	public class AquaHelm : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 16; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int ArmorBase{ get{ return 30; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public AquaHelm() : base( 0x140E )
		{
			Weight = 5.0;
			Name = "Aqua's Battle Helm";
			Hue = 1266;
			Attributes.Luck = 125;
			Attributes.CastRecovery = 7;
			Attributes.LowerRegCost = 18;

		}

		public AquaHelm( Serial serial ) : base( serial )
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
				Weight = 5.0;
		}
	}
}