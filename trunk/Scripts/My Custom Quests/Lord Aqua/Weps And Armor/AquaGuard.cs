using System;
using Server;

namespace Server.Items
{
	public class AquaGuard : BaseShield
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 30; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 300; } }
		public override int InitMaxHits{ get{ return 750; } }

		public override int AosStrReq{ get{ return 80; } }

		public override int ArmorBase{ get{ return 25; } }

		[Constructable]
		public AquaGuard() : base( 0x1B76 )
		{
			Weight = 5.0;
			Name = "Aqua's Guard";
			Attributes.SpellChanneling = 1;
			Attributes.BonusStr = 10;
			Hue = 1266;
			Attributes.LowerRegCost = 18;

		}

		public AquaGuard( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
