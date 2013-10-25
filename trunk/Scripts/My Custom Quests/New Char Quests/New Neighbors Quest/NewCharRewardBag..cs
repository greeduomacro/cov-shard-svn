using System; 
using Server; 
using Server.Items;
using Server.Multis.Deeds;
using Server.Engines.Quests;
using Reward = Server.Engines.Quests.BaseReward;

namespace Server.Items 
{ 
	public class NewCharRewardBag : BaseRewardBag 
	{ 
		[Constructable]
        public NewCharRewardBag() 
		{
            //switch (Utility.Random(3))
            //{
                //case 0: DropItem(new LargeMarbleDeed()); break;
                DropItem(new LargeMarbleDeed()); //break;
                //case 2: DropItem(new TwoStoryStonePlasterHouseDeed()); break;
               
            }		
		

        public NewCharRewardBag (Serial serial) : base(serial) 
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
