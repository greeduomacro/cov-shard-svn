//Scripted by Mimi & Kila Ventru
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class FullMetalBox : Item
	{
		[Constructable]
        public FullMetalBox(): base(2472)
		{
            Name = "A Full Metal Box";
				  Hue = 1161;
			
		}

        public FullMetalBox(Serial serial)
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