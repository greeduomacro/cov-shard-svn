using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class MailboxQuest : BaseQuest
	{			
		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 59 ); } }
		
		/* PostMaster Karen's Lost Mailbag */
		public override object Title{ get{ return "Postmaster Karen's Lost Mailbag"; } }
			
		public override object Description{ get{ return "Hey! Could you help me out? The post office needs your help! You see, I had a bag of mail to deliver, and an evil Grendel came and stole it from me! He hides out in the swampy area, North of Trinsic, East of Lord Aqua.. I will reward you well on my bags return."  ; } }
		
		public override object Refuse{ get{ return "Well fine then! Now COV won't get any mail delivered!"; } }
		
		public override object Uncomplete{ get{ return "I see you haven't gotten my mailbag yet! Please hurry!"; } }
		
		public override object Complete{ get{ return "Good Job! Here is a mailbox deed for your house, so you can send mail. Thank You!"; } }
		
		public MailboxQuest() : base()
		{								
			AddObjective( new ObtainObjective( typeof( LostMailBag ), "Lost Mailbag", 1, 0xE76 ) );
						
			AddReward( new BaseReward( typeof( RewardMailbag ), "Reward Mailbag" ) ); // 
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
	
	public class Karen : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( MailboxQuest )
			};} 
		}		
		
		[Constructable]
		public Karen() : base( "Karen", "the Mail Lady" )
		{			
		}
		
		public Karen( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );

            Female = true;
            Race = Race.Human;

            Hue = 0x83ED;
            HairItemID = 0x203B;
            HairHue = 0x454;	
		}
		
		public override void InitOutfit()
		{		
            AddItem(new Backpack(1153));
            AddItem(new Sandals(99));
            AddItem(new Tunic(99));
            AddItem(new Skirt(99));
            AddItem(new FloppyHat(99));
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