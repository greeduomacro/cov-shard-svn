/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
    	public class PearBranch : Item
        {

		[Constructable]
		public PearBranch() : base( 0x1B9C )
		{
        Name = "A Pear Tree Branch";
        Hue = 1281;
		}

            public PearBranch(Serial serial)
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