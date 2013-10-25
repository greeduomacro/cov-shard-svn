
// scripted by Mimi & Kila Ventru
using System;
using Server;

namespace Server.Items
{
	public class GoldilocksStory : Item
	{
        [Constructable]
		public GoldilocksStory()
		{
			ItemID = 5360;
			Weight = 1.0;
			Name = "Goldilocks Compiled Story";
			Hue = 1196;

		}

		public GoldilocksStory(Serial serial)
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