using System;
using Server;

namespace Server.Items
{
	public class BouraTailShield : WoodenKiteShield
	{
        public override int LabelNumber { get { return 1112361; } }
		public override int ArtifactRarity{ get{ return 11; } }

        public override int BasePhysicalResistance{ get{ return 8; } }
        public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public BouraTailShield()
		{
            Weight = 5.0;
			ItemID = 0x1B78;
			Hue = 553;
            ArmorAttributes.ReactiveParalyze = 10;
			Attributes.ReflectPhysical = 10;
			
		}

		public BouraTailShield( Serial serial ) : base( serial )
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

			if ( Attributes.NightSight == 0 )
				Attributes.NightSight = 1;
		}
	}
}