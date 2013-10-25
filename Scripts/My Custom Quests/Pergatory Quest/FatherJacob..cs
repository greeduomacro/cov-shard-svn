using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class PergatoryQuest : BaseQuest
	{						
		
		public override object Title{ get{ return "Pergatory Quest"; } }


        public override object Description { get { return "So you have sinned and want to make amends. My congregation has been hit with bad luck and is in need of many things. Let me get you started.<BR> 1.) Help someone build a house by collecting 50 Pine logs. 2.) Help clothe the female congregation by collecting 50 Wool. 3.) Help feed the some of the congregation by collecting 50 Raw ribs. 4.) Help clothe the men in the congregation by collecting 50 Spined leather. 5.) Help equip the fighters of the congregation by collecting 50 Shadow iron ingots. 6.) Tithe 1000 gold to the Chapel for upkeep."; } }


        public override object Refuse { get { return "Such a pity, To live in such darkness.... If you change your mind, I'll be here."; } }


        public override object Uncomplete { get { return "You haven't completed your Quest yet, you have more to do!"; } }


        public override object Complete { get { return "You have completed the quest! Return to Father Jacob for your reward."; } }
		
		public PergatoryQuest() : base()
		{
            AddObjective( new ObtainObjective( typeof( PineLog ), "Pine Logs", 50, 0x1BDD ));
            AddObjective( new ObtainObjective( typeof( Wool ), "Piles of Wool", 50, 0xDF8 ));
            AddObjective( new ObtainObjective( typeof( RawRibs ), "Raw Ribs", 50, 0x9F1 ));
            AddObjective( new ObtainObjective( typeof( SpinedLeather ), "Spined Leather", 50, 0x1081 ));
			AddObjective( new ObtainObjective( typeof( ShadowIronIngot ), "Shadow Iron Ingots", 50, 0x1BF2 ));
            AddObjective( new ObtainObjective( typeof( Gold ), "Gold", 1000, 0xEED ));

			AddReward( new BaseReward( typeof(ChapelRewardBox), "Chapel Reward Box" ) ); 
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
	
	public class FatherJacob : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( PergatoryQuest )
			};} 
		}
		
		[Constructable]
		public FatherJacob() : base( "Father Jacob", "The town minister" )
		{			
		}
		
		public FatherJacob( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = false;
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
			AddItem( new Robe( 0x1BB ) );	
			
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