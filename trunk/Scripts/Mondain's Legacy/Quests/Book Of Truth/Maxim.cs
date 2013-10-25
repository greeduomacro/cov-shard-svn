using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class TruthAndRedemptionQuest : BaseQuest
	{
		public override bool DoneOnce{ get{ return true; } }
		
		/* Truth and Redemption */
		public override object Title{ get{ return 1077451; } }
		
		/* Thank you for responding to our call for help. As you know, 
		 * dark entities from beyond our world have stolen the Book of Truth. 
		 * To keep us from finding the book, they have created thousands of false 
		 * books, which are carried by the denizens of dungeons Covetous, Deceit, 
		 * Despise, Destard, Hythloth, Shame and Wrong. Return 25 of these copies 
		 * to me, and I shall reward you with a sword unlike any other in the lands. */	
		public override object Description{ get{ return 1077445; } }
		
		/* *frowns* I understand. It is a perilous task. Please come back to me if 
		 * you change your mind. We could really use your help. */
		public override object Refuse{ get{ return 1077427; } }
		
		/* You haven't returned enough books yet. Please gather more books. */
		public override object Uncomplete{ get{ return 1077428; } }
		
		/* Thank You, Brave Adventurer! We really appreciate your help! As promised, I have a reward for you. */
		public override object Complete{ get{ return 1077454; } }
		
		public TruthAndRedemptionQuest() : base()
		{								
			AddObjective( new ObtainObjective( typeof( BookOfTruth ), "Book of Truth", 25, 0x1C11 ) );
						
			AddReward( new BaseReward( typeof( TheRedeemer ), 1077442 ) ); // The Redeemer
		}
		
/*		public static bool CanOffer( BaseQuest quest )
		{
			if ( Owner.InProgress( quest.GetType( VeracitysPleaQuest ) ) )
			{
				Owner.SendLocalizedMessage( 1077455 ); // Thou hast already begun collecting books for someone else.
				return false;					
			}
			if ( quest.GetType( VeritaesPleaQuest ) != InProgress );
			{
				Owner.SendLocalizedMessage( 1077455 ); // Thou hast already begun collecting books for someone else.
				return false;					
			}
			
			return true;
		}
		public override bool CanOffer()
		{		
			return Owner.Quests( !InProgress( VeracitysPleaQuest || VeritaesPleaQuest ) )
		}
*/		
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
	
	public class Maxim : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( TruthAndRedemptionQuest )
			};} 
		}		
		
		[Constructable]
		public Maxim() : base( "Maxim" )
		{			
		}
		
		public Maxim( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = false;
			CantWalk = true;
			Race = Race.Human;
			
			Hue = 0x83F6;
			HairItemID = 0x2048;  
            HairHue = 1116;			
		}
		
		public override void InitOutfit()
		{
			AddItem( new Tunic(2102)); 
			AddItem( new Boots(1175) );
			AddItem( new LongPants( 1175 ) );
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
	
/*	public class MaximsTreasureBox : RewardBox
	{
		//public override int LabelNumber{ get{ return 1077444; } }
		
		[Constructable]
		public MaximsTreasureBox() : base()
		{
			Name = "Maxim's Treasure Box";
			
			AddItem( new TheRedeemer() );
			
		}
		
		public MaximsTreasureBox( Serial serial ) : base( serial )
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
*/
