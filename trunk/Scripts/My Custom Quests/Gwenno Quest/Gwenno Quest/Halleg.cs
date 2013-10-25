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
	[CorpseName( "Halleg's corpse" )]
	public class Halleg : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Halleg()
		{
			Name = "Halleg";
            Title = "the Old Fool";
		    Body = 0x190;
			Hue = Utility.RandomSkinHue();
			CantWalk = true;
			AddItem( new Server.Items.Boots( GetBootsHue() ) );
			AddItem( new HoodedShroudOfShadows( 116 ) ); 
                    
			
			Blessed = true;
			
			}

			public virtual int GetBootsHue()
			{
			return 1157;
		}

		public Halleg( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry>list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new HallegEntry( from, this ) ); 
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

		public class HallegEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public HallegEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( HallegGump ) ) )
					{
						mobile.SendGump( new HallegGump( mobile ));
//
						
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
				if( dropped is HallegsArm )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "So ya beat Rolph? Wow...", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
					mobile.AddToBackpack( new HallegsAdvice() );
					mobile.SendMessage( "There ya go, now beat the Scourge!" );

				int rand = Utility.Random(1);
				switch (rand)
				{				
					case 0:
						m.SendMessage("Good Luck!");
						m.Map = Map.Ilshenar;
						m.Location = new Point3D(2114,1029,-28);
						break;
				}
					return true;
         		}
				else if ( dropped is HallegsArm )
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
