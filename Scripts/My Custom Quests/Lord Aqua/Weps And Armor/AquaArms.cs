using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13dc, 0x13d4 )]
	public class AquaArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 13; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 16; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 21; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		public override int AosStrReq{ get{ return 80; } }
		public override int OldStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 24; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public AquaArms() : base( 0x13DC )
		{
			Weight = 5.0;
			Name = "Aqua's Mighty Arms";
			Hue = 1266;
			Attributes.Luck = 205;
			Attributes.CastRecovery = 7;
			Attributes.LowerRegCost = 18;

		}

		public AquaArms( Serial serial ) : base( serial )
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
				Weight = 4.0;
		}
	}
}