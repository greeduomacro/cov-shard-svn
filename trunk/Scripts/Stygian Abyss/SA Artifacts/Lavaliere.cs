using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Lavaliere : GoldNecklace
	{
		public override int LabelNumber{ get{ return 1114843; } } // Lavaliere

		[Constructable]
		public Lavaliere()
		{
            Weight = 1.0;
			Hue = 1779;
            AbsorptionAttributes.EaterKinetic = 20;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 15;
            Attributes.DefendChance = 10;
            Resistances.Physical = 15;
		}

        public Lavaliere(Serial serial): base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
