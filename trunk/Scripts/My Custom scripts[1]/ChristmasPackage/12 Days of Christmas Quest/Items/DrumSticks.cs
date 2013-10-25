/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
    	public class DrumSticks : Item
        {

		[Constructable]
		public DrumSticks() : base( 0x1027)
		{
        Name = "A pair of Drumsticks";
        Hue = 2107;
		}

        public DrumSticks(Serial serial)
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