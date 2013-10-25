/*Created by Hammerhand*/

using System;
using System.Collections;
using Server;

namespace Server.Items
{
	public class GoldenRing : Item
	{

		[Constructable]
        public GoldenRing()
            : base(0x1011)
		{
            Name = "A Golden Ring";
			Weight = 1.0; 
            Hue = 1260;

		}



        public GoldenRing(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}