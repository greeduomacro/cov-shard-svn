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


namespace Server.Mobiles
{
	[CorpseName( "Melbore corpse" )]
	public class Melbore : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Melbore()
		{
			Name = "Melbore";
                        Title = "the Legendairy Master Tailor";
			Body = 0x190;
			CantWalk = true;
			Hue = Utility.RandomSkinHue();
			AddItem( new Server.Items.Boots( GetBootsHue() ) );
			AddItem( new MasterRobe()); 
			AddItem( new Server.Items.GnarledStaff() );
                        int hairHue = 1153;

			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new LongHair( hairHue ) ); break;
			} 
			
			Blessed = true;
			
			}

			public virtual int GetBootsHue()
			{
			return 1623;
		}

		public Melbore( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new MelboreEntry( from, this ) ); 
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

		public class MelboreEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public MelboreEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ShardRobeGump ) ) )
					{
						mobile.SendGump( new ShardRobeGump( mobile ));
mobile.AddToBackpack( new RobeBook() );
						
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
				if( dropped is Shard)
         		{
         			if(dropped.Amount!=35)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "That is not the amount I asked for!", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new MasterRobe() );

				
					return true;
         		}
				else if ( dropped is Shard)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Why on earth would I want to have that?", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
