
// scripted by Mimi & Kila Ventru
using System;
using Server;

namespace Server.Items
{
	public class ThreePigsCombinedScroll : Item
	{
        [Constructable]
		public ThreePigsCombinedScroll()
		{
			ItemID = 5360;
			Weight = 1.0;
			Name = "Three Pigs Combined Scrolls";
			Hue = 1150;

		}

        public ThreePigsCombinedScroll(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}