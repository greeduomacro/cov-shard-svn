//Scripted by Raven's Keeper
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class RewardCrystalineSpider: Item
	{
		[Constructable]
        public RewardCrystalineSpider(): base(9669)
		{
            Name = "a Crystaline Spider Statue";
				  Hue = 1266;
			
		}



        public RewardCrystalineSpider(Serial serial)
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