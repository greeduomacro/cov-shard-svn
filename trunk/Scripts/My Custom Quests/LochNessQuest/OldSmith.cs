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
	[CorpseName( "The Old Smith's Corpse" )]
	public class OldSmith : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public OldSmith()
		{
			Name = "Eirin THe Retired Blacksmith";
                        Title = "Quest";
			Body = 400;
			CantWalk = true;
			Hue = Utility.RandomSkinHue();

			PlateArms PlateArms = new PlateArms();
			PlateArms.Hue = 2418;
			AddItem( PlateArms );
						
			PlateGloves PlateGloves = new PlateGloves();
			PlateGloves.Hue = 2418;
			AddItem( PlateGloves );

			PlateLegs PlateLegs = new PlateLegs();
			PlateLegs.Hue = 2418;
			AddItem( PlateLegs );
			
			PlateChest PlateChest = new PlateChest();
			PlateChest.Hue = 2418;
			AddItem( PlateChest );

			PlateGorget PlateGorget = new PlateGorget();
			PlateGorget.Hue = 2418;
			AddItem( PlateGorget );

                        int hairHue = 2406;

			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new PonyTail( hairHue ) ); break;
				case 1: AddItem( new Goatee( hairHue ) ); break;
			} 
			
			Blessed = true;
			
			}



		public OldSmith( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry>list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new OldSmithEntry( from, this ) ); 
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

		public class OldSmithEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public OldSmithEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( OldSmithquestGump ) ) )
					{
						mobile.SendGump( new OldSmithquestGump( mobile ));
												
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
				if( dropped is LochNessScales)
         		{
         			if(dropped.Amount!=5)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "That is not the item I asked for.", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new LochNessShield() );

				
					return true;
         		}
				else if ( dropped is LochNessShield)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I did not ask for this item.", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
