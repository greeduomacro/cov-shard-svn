using System; 
using Server; 
using Server.Items;
using Server.Multis.Deeds;
using Server.Engines.Quests;
using Reward = Server.Engines.Quests.BaseReward;

namespace Server.Items 
{ 
	public class NewCharNecroBag : BaseRewardBag 
	{ 
		[Constructable]
        public NewCharNecroBag() 
		{

            DropItem(new NecromancerSpellbook((UInt64)0xFFFF));
  
        }		
		

        public NewCharNecroBag (Serial serial) : base(serial) 
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
