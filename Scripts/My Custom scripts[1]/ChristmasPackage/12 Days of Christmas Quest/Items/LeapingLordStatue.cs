/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
    	public class LeapingLordStatue : Item
        {

		[Constructable]
		public LeapingLordStatue() : base( 0x212F )
		{
        Name = "A LeapingLord Statue";
        Hue = 2222;
		}

            public LeapingLordStatue(Serial serial)
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