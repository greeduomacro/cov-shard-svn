using System;
using Server;
using Server.Items;
using Server.Items.MusicBox;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class VeritaesPleaQuest : BaseQuest
	{
		/* Veritae's Plea */
		public override object Title{ get{ return 1077452; } }
		
		/* Please help us find the real Book of Truth! Awful dark 
		 * entities from beyond our world have stolen it, made fake 
		 * copies and spread them all over the dungeons. Bring me 10 
		 * of these books, and I'll give you a rare music box gear 
		 * that has been in my family for generations. Won't you please 
		 * help us find the real Book of Truth?  */	
		public override object Description{ get{ return 1077446; } }
		
		/* *frowns* I understand. It is a perilous task. Please come back to me if 
		 * you change your mind. We could really use your help. */
		public override object Refuse{ get{ return 1077427; } }
		
		/* You haven't returned enough books yet. Please gather more books. */
		public override object Uncomplete{ get{ return 1077428; } }
		
		/* Thank You, Brave Adventurer! We really appreciate your help! As promised, I have a reward for you. */
		public override object Complete{ get{ return 1077454; } }
		
		public VeritaesPleaQuest() : base()
		{								
			AddObjective( new ObtainObjective( typeof( BookOfTruth ), "Book of Truth", 10, 0x1C11 ) );
						
			AddReward( new BaseReward( typeof( VeritaesTreasureBox ), 1077447 ) ); // Veritae's Music Box Gear
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
	
	public class Veritae : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( VeritaesPleaQuest )
			};} 
		}		
		
		[Constructable]
		public Veritae() : base( "Veritae")
		{			
		}
		
		public Veritae( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = true;
			CantWalk = true;
			Race = Race.Human;
			
			Hue = 0x83F6;
			HairItemID = 0x2049;  
            HairHue = 1116;			
		}
		
		public override void InitOutfit()
		{
			AddItem( new FancyDress(53)); 
			AddItem( new Sandals(53) );
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
	
	public class VeritaesTreasureBox : RewardBox
	{
		public override int LabelNumber{ get{ return 1077444; } }
		
		[Constructable]
		public VeritaesTreasureBox() : base()
		{			
			
			AddItem( MusicBoxGears.RandomMusixBoxGears( TrackRarity.Rare ) );
			
		}
		
		public VeritaesTreasureBox( Serial serial ) : base( serial )
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
