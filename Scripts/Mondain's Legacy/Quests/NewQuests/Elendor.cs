using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Plants;

namespace Server.Engines.Quests
{
	public class StartupCostQuest : BaseQuest
	{						
		
		public override object Title{ get{ return "Startup Cost Quest"; } }
		
		
		public override object Description{ get{ return "I see your new to COV and might need a little more money to get you going here on the shard. you know, *startup-money*. If you could see your way to go get some things for me, I will give you a nice check for your efforts. The items I need you to get are: 40 Iron ingots, 10 Blank scrolls, 1 Plant Bowl, and 3 Slices of Bacon. Bring these back to me, and you'll get your check."; } }
		
		
		public override object Refuse{ get{ return "Are you sure? Brit doesn't need another beggar, or deadbeat panhandling around here! If you change your mind, I'll be here."; } }


        public override object Uncomplete { get { return "Hmmm, I don't pay unless you bring back Everything! Nice try!"; } }


        public override object Complete { get { return "Well done! Now I can finish my project. Here is the nice bankcheck I promised!"; } }
		
		public StartupCostQuest() : base()
		{					
			AddObjective( new ObtainObjective( typeof( IronIngot ), "Iron Ingots", 40, 0x1BF2 ) );
            AddObjective( new ObtainObjective( typeof( BlankScroll ), "Blank Scrolls", 10, 0xEF3 ));
            AddObjective( new ObtainObjective( typeof( PlantBowl ), "Plant Bowl", 1, 0x15FD ));
            AddObjective( new ObtainObjective( typeof( Bacon ), "Slice of Bacon", 1, 0x979 ));
						
			AddReward( new BaseReward( typeof(NewCharMoneyBag), "New Char Money Bag" ) ); 
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
	
	public class Elendor : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( StartupCostQuest )
			};} 
		}
		
		[Constructable]
		public Elendor() : base( "Elendor", "the financial planner" )
		{			
		}
		
		public Elendor( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = true;
			CantWalk = true;
			Race = Race.Human;
			
			Hue = 0x83F3;			
			HairItemID = 0x2047;
			HairHue = 0x393;
			FacialHairItemID = 0x203F;
			FacialHairHue = 0x393;
		}
		
		public override void InitOutfit()
		{
			AddItem( new Backpack() );			
			AddItem( new Boots( 0x717 ) );	
			AddItem( new LongPants( 0x1BB ) );	
			AddItem( new FancyShirt( 0x71 ) );	
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