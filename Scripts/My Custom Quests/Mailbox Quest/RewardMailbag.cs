using System; 
using Server; 
using Server.Items;
using Server.Multis.Deeds;
using Server.Engines.Quests;

namespace Server.Items 
{ 
	public class RewardMailbag : BaseRewardBag 
	{ 
		[Constructable]
        public RewardMailbag() 
		{
                switch (Utility.Random(2))
                {
                    case 0: DropItem(new MailboxEastAddonDeed()); break;
                    case 1: DropItem(new MailboxSouthAddonDeed()); break;  
                }
            }
               			
        public RewardMailbag(Serial serial) : base(serial) 
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
