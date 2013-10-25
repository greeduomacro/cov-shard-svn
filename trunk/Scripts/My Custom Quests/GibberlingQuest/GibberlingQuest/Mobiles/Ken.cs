using System;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "Ken's Corpse" )]
	public class Ken : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Ken()
		{
			Name = "Ken";
            Title = "the Gibberling Hunter";
			Body = 0x190;
			CantWalk = true;
			Hue = 0x83F8;
			AddItem( new Server.Items.Boots() );
			AddItem( new Server.Items.Shirt( 1436 ) );
			AddItem( new Server.Items.ShortPants( 1436 ) );
			AddItem( new Server.Items.CompositeBow() );
            //int hairHue = 1741;
            Utility.AssignRandomHair(this);			
			Blessed = true;
			
			}

		public Ken( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry>list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new KenEntry( from, this ) ); 
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

		public class KenEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public KenEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( KenGump ) ) )
					{
						mobile.SendGump( new KenGump( mobile ));
						
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
				if( dropped is GibberlingHead )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "No, that's not it...", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new BraceletOfLuna() );
					mobile.AddToBackpack( new Gold( 5000 ));
					mobile.SendGump( new KenFinishGump());


				
					return true;
         		}
				else if ( dropped is GibberlingHead)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no need of this, ya meathead!", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
