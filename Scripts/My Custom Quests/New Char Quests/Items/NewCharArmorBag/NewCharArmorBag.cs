using System; 
using Server; 
using Server.Items;
using Server.Engines.Quests;
using Reward = Server.Engines.Quests.BaseReward;

namespace Server.Items 
{ 
	public class NewCharArmorBag : BaseRewardBag 
	{ 
		[Constructable]
        public NewCharArmorBag() 
		{ 
			DropItem(new NewCharLeatherLegs());
            DropItem(new NewCharLeatherChest());
            DropItem(new NewCharLeatherGorget());
            DropItem(new NewCharLeatherArms());
            DropItem(new NewCharLeatherGloves());		
		}

        public NewCharArmorBag (Serial serial) : base(serial) 
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
