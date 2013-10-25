using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class VeracitysPleaQuest : BaseQuest
	{					
		/* Veracity's Plea */
		public override object Title{ get{ return 1077450; } }
		
		/* The Book of Truth has been stolen! 'Tis said that the dark entities from 
		 * beyond our world are behind this evil deed, and to keep us from finding it, 
		 * they've made lots of copies. My twin sister and I have made a pledge to 
		 * help return the book to safety, but I'm afraid that we wouldn't be very 
		 * useful in the dungeons. We're going to help Mistress Menzzobaanea examine 
		 * any of the copies that you can bring us, and I promise to give you a small 
		 * reward for each one that you bring to me.  */	
		public override object Description{ get{ return 1077443; } }
		
		/* *frowns* I understand. It is a perilous task. Please come back to me if 
		 * you change your mind. We could really use your help. */
		public override object Refuse{ get{ return 1077427; } }
		
		/* You haven't returned enough books yet. Please gather more books. */
		public override object Uncomplete{ get{ return 1077428; } }
		
		/* Thank You, Brave Adventurer! We really appreciate your help! As promised, I have a reward for you. */
		public override object Complete{ get{ return 1077454; } }
		
		public VeracitysPleaQuest() : base()
		{								
			AddObjective( new ObtainObjective( typeof( BookOfTruth ), "Book of Truth", 1, 0x1C11 ) );
						
			AddReward( new BaseReward( typeof( VeracityTreasureBox ), 1077444 ) ); // Veracity's Treasure Box
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
	
	public class Veracity : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( VeracitysPleaQuest )
			};} 
		}		
		
		[Constructable]
		public Veracity() : base( "Veracity", "the Seeker of Truth" )
		{			
		}
		
		public Veracity( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = true;
			CantWalk = true;
			Race = Race.Human;
			
			Hue = 0x83F6;
			HairItemID = 0x203c;  
            HairHue = 1116;			
		}
		
		public override void InitOutfit()
		{
			AddItem( new FancyDress(2213)); 
			AddItem( new Sandals(2213) );
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
	
	public class VeracityTreasureBox : RewardBox
	{
		public override int LabelNumber{ get{ return 1077444; } }
		
		[Constructable]
		public VeracityTreasureBox() : base()
		{			
			
			AddItem( new BankCheck( 6000 ) );
			
		}
		
		public VeracityTreasureBox( Serial serial ) : base( serial )
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
