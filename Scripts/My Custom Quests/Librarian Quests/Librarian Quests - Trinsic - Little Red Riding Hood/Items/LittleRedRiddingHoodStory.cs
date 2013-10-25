
// scripted by Mimi & Kila Ventru
using System;
using Server;

namespace Server.Items
{
	public class LittleRedRiddingHoodStory : Item
	{
        [Constructable]
		public LittleRedRiddingHoodStory()
		{
			ItemID = 5360;
			Weight = 1.0;
			Name = "Compiled Story";
			Hue = 1150;

		}

		public LittleRedRiddingHoodStory(Serial serial)
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