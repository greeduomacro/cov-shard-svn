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
	[CorpseName( "Doman's Corpse" )]
	public class Doman : Mobile
	{
           public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public Doman()
		{
			Name = "Ettin Slayer Doman";

			Body = 0x190;
			CantWalk = true;
			Hue = 0x83EA;
			AddItem( new Server.Items.LongPants( 1421 ) );
			AddItem( new Server.Items.Boots( 1175 ) );
			AddItem( new Server.Items.Shirt( 1175 ) );
			AddItem( new LargeBattleAxe() );


                        int hairHue = 1175;

			switch ( Utility.Random( 1 ) )
			{
				case 0: AddItem( new LongHair( hairHue ) ); break;
			} 			
			Blessed = true;			
			}
		public Doman( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry>list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new DomanEntry( from, this ) ); 
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

		public class DomanEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public DomanEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( DomanGump ) ) )
					{
						mobile.SendGump( new DomanGump( mobile ));
						mobile.AddToBackpack( new JarOfEttinsBlood() );				
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
				if( dropped is FullJarOfEttinsBlood )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "No, that's not it...", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 

					mobile.AddToBackpack( new Gold( 8000 ));
					//mobile.SendGump( new DomanFinishGump());

				switch (Utility.Random( 3 ))
				{
					case 0: mobile.AddToBackpack( new RingOfTheEttins() ); break;
					case 1: mobile.AddToBackpack( new EarringsOfTheEttins() ); break;
					case 2: mobile.AddToBackpack( new BraceletOfTheEttins() ); break;
				}
                    mobile.SendGump(new DomanFinishGump());
				
					return true;
         		}
				else if ( dropped is FullJarOfEttinsBlood)
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Oh no, I have no need of this!", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
