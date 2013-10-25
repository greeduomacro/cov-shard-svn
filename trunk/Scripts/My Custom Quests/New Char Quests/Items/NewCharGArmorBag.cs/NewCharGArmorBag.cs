using System; 
using Server; 
using Server.Items;
using Server.Engines.Quests;
using Reward = Server.Engines.Quests.BaseReward;

namespace Server.Items 
{ 
	public class NewCharGArmorBag : BaseRewardBag 
	{ 
		[Constructable]
        public NewCharGArmorBag() 
		{
            DropItem(new NewGargishLeatherArms());
            DropItem(new NewGargishLeatherChest());
            DropItem(new NewGargishLeatherKilt());
            DropItem(new NewGargishLeatherLegs());
         		
		}

        public NewCharGArmorBag (Serial serial) : base(serial) 
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
