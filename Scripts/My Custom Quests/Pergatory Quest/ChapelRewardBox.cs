using System;
using Server;
using Server.Items;
using Server.Multis.Deeds;
using Server.Engines.Quests;
using Reward = Server.Engines.Quests.BaseReward;


namespace Server.Items
{
	public class ChapelRewardBox : RewardBox
	{

        [Constructable]
        public ChapelRewardBox()
        {
            Name = "Chapel Reward Box";
            Hue = 1377;

            switch (Utility.Random(11))
            {
                           
                 case 0: DropItem(new PottedCactusDeed()); break;
                 case 1: DropItem(new PottedTree()); break;
                 case 2: DropItem(new PottedTree1()); break;
                 case 3: DropItem(new PottedPlant()); break;
                 case 4: DropItem(new PottedPlant1()); break;
                 case 5: DropItem(new PottedPlant2()); break;
                 case 6: DropItem(new AG_3x3daisyvaseAddonDeed()); break;
                 case 7: DropItem(new AG_colorfulrosevaseAddonDeed()); break;
                 case 8: DropItem(new AG_daisyvaseAddonDeed()); break;
                 case 9: DropItem(new AG_redrosevaseAddonDeed()); break;
                 case 10: DropItem(new AG_lilliesvaseAddonDeed()); break;

            }
        }
        
        public ChapelRewardBox(Serial serial)
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