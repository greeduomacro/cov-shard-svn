using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class PergatoryPQuest : BaseQuest
	{		
		public override QuestChain ChainID{ get{ return QuestChain.PergatoryP; } }
		public override Type NextQuest{ get{ return typeof( ClothingTheCongregation ); } }
		
		/* Pergatory Quest */
		public override object Title{ get{ return "Pergatory Quest"; } }
		
		public override object Description{ get{ return "So you have sinned and want to make amends. My congregation has been hit with bad luck and is in need of many things. Let me get you started.<BR><BR>What I need first is for you to go and get 50 raw ribs to help feed the congregation. Go get them and bring them to me..."; } }

        public override object Refuse { get { return "Such a pity, To live in such darkness.... If you change your mind, I'll be here."; } }

        public override object Uncomplete { get { return "You haven't completed your duties to the church yet, you have more to do!"; } }

        public override object Complete { get { return "Oh Wonderful! Now that we have fed some of the poor, I have more duties for you..."; } }
		
		public PergatoryPQuest() : base()
		{
            AddObjective(new ObtainObjective( typeof( RawRibs ), "Raw Ribs", 50, 0x9F1 ) );		
							
			AddReward( new BaseReward( "Getting closer to forgiveness for your sins." ) ); 

		}
		
		//public override void OnCompleted()
		//{
			//Owner.SendLocalizedMessage( 1074541, null, 0x23 ); // You have discovered an important clue!						
			//Owner.PlaySound( CompleteSound );
		//}
		
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
	
	public class ClothingTheCongregation : BaseQuest
	{		
		public override QuestChain ChainID{ get{ return QuestChain.PergatoryP; } }
		public override Type NextQuest{ get{ return typeof( BuildingUpQuest ); } }
		
		public override object Title{ get{ return "Clothing The Congregation"; } }
		
		
		public override object Description{ get{ return "I need you to gather a few things for me to help clothe the people of the church. If you would, gather 50 wool to clothe the female members, and 50 spined leather to clothe men. Go get them and bring them to me..."; } }

        public override object Refuse { get { return "Such a pity, To live in such darkness.... If you change your mind, I'll be here."; } }

        public override object Uncomplete { get { return "You haven't completed your duties to the church yet, you have more to do!"; } }

        public override object Complete { get { return "Oh this is good news! Now we can move on to your next task..."; } }
		
		public ClothingTheCongregation() : base()
		{								
			AddObjective( new ObtainObjective( typeof( Wool ), "Piles of Wool", 50, 0xDF8 ));
            AddObjective( new ObtainObjective( typeof( SpinedLeather ), "Spined Leather", 50, 0x1081 ));

            AddReward(new BaseReward("Getting closer to forgiveness for your sins.")); }

		
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
	
	public class BuildingUpQuest : BaseQuest
	{		
		public override QuestChain ChainID{ get{ return QuestChain.PergatoryP; } }
		public override Type NextQuest{ get{ return typeof( TithingQuest ); } }
		
		public override object Title{ get{ return "Building houses for the Needy"; } }

        public override object Description { get { return "You done much for the church so far but a few more things need to be done. Now that we have fed and clothed the needy, I need your help gathering some supplies to help build some new houses for the poor.<BR><BR>I need you to go and bring back 50 Pine logs, and 50 Shadow Iron Ingots..."; } }

        public override object Refuse { get { return "Such a pity, To live in such darkness.... If you change your mind, I'll be here."; } }
		
		public override object Uncomplete{ get{ return "Really? You have almost completed your duties to the church, why quit now?"; } }

        public override object Complete { get { return "Good Job! Now there is but one thing I ask of you to do...."; } }
		
		public BuildingUpQuest() : base()
		{
            AddObjective(new ObtainObjective(typeof(PineLog), "Pine Logs", 50, 0x1BDD));
            AddObjective(new ObtainObjective(typeof(ShadowIronIngot), "Shadow Iron Ingots", 50, 0x1BF2));

            AddReward(new BaseReward("Getting closer to forgiveness for your sins.")); 
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
	
	public class TithingQuest : BaseQuest
	{		
		public override QuestChain ChainID{ get{ return QuestChain.PergatoryP; } }
		
		public override object Title{ get{ return "Tithing to the Church...;"; } }
		
		
		public override object Description{ get{ return "You have done so much in repenting for your sins. There is but one last thing I ask of you...<BR><BR>If you could see your way to tithing 1000 gold to the church, I will not only reward you for your efforts, but also absolve you of all your sins!"; } }


        public override object Refuse { get { return "Such a pity, To live in such darkness.... If you change your mind, I'll be here."; } }


        public override object Uncomplete { get { return "Really? You have almost completed your duties to the church, why quit now?"; } }
		
		
		public override object Complete{ get{ return "You have proven yourself and are absolved of all your sins! Here is your reward for your hard work."; } }
		
		public TithingQuest() : base()
		{
            AddObjective(new ObtainObjective(typeof(Gold), "Gold", 1000, 0xEED));

            AddReward(new BaseReward(typeof(ChapelRewardBox), "Chapel Reward Box"));
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