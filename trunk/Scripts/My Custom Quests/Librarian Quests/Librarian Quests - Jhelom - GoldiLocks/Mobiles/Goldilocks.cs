using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Accounting;

namespace Server.Mobiles
{
[CorpseName( "Goldilocks Corpse" )]
	public class Goldilocks : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Goldilocks()
		{
			Name = "Brunneta";
						Title = "Goldilocks";
			Body = 0x191;
			CantWalk = true;
			Hue = Utility.RandomSkinHue();


			AddItem( new Server.Items.Cloak( 1281 ) );
			AddItem( new Server.Items.Tunic( 1281 ) );




			ThighBoots ThighBoots = new ThighBoots();
			ThighBoots.Hue = 1281;
			AddItem( ThighBoots );




						int hairHue = 1281;
			
			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new LongHair( hairHue ) ); break;
			} 
			Blessed = true;
			
		}




		public Goldilocks( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
					list.Add( new GoldilocksEntry( from, this ) );
			}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public class GoldilocksEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

			public GoldilocksEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{


						  if( !( m_Mobile is PlayerMobile ) )
					return;

				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( Goldilocks ) ) )
					{
						mobile.SendGump( new GoldilocksGump( mobile ));
                        mobile.AddToBackpack( new EmptyBag() );
					}
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{



					Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is FullBag )
			{
				if( dropped.Amount!=1)
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "You have done it now I remember my part in the story! Here is the compiled story as I have promised. My gratitude for getting rid of the three bears!", mobile.NetState );
					return false;
				}

					dropped.Delete();
					mobile.SendGump( new GoldilocksGump2(m) );

				if( 1 > Utility.RandomDouble() ) // 1 = 100% = chance to drop


			switch ( Utility.Random( 1 ))

			{

					case 0: mobile.AddToBackpack( new GoldilocksStory() ); break;


			}



         		}
				else if ( dropped is FullBag )
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I can not remember my story from that!", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
				


				


