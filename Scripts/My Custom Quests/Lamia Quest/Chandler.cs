using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server;
using Server.Items;
using Server.Gumps;


namespace Server.Mobiles
{
    public class Chandler : BaseGuildmaster
	    {
        public override NpcGuild NpcGuild { get { return NpcGuild.TailorsGuild; } }

		public override bool ClickTitle{ get{ return false; } }
		
		private static bool m_Talked; // flag to prevent spam 
		
		      string[] kfcsay = new string[] // things to say while greating 
		      { 
		         "Hello fair traveler, Click on me for a mythical story and a quest",   
      };

		[Constructable]
		public Chandler() : base ("Artifact")
		{
			Name = "Chandler";
			Female = false;
            Body = 0x190;

			AddItem( new Server.Items.FancyShirt() );
			AddItem( new Server.Items.LongPants() );
			AddItem( new Server.Items.BodySash() );
			AddItem( new Server.Items.FloppyHat() );
			}
			public override void OnMovement( Mobile m, Point3D oldLocation ) 
			               {                                                    
			         if( m_Talked == false ) 
			         { 
			            if ( m.InRange( this, 2 ) ) 
			            {                
			               m_Talked = true; 
			               SayRandom( kfcsay, this ); 
			               this.Move( GetDirectionTo( m.Location ) ); 
			                  // Start timer to prevent spam 
			               SpamTimer t = new SpamTimer(); 
			               t.Start(); 
			            } 
			         } 
			      } 
			
			      private class SpamTimer : Timer 
			      { 
			         public SpamTimer() : base( TimeSpan.FromSeconds( 90 ) ) 
			         { 
			            Priority = TimerPriority.OneSecond; 
			         } 
			
			         protected override void OnTick() 
			         { 
			            m_Talked = false; 
			         } 
			      } 
			
			      private static void SayRandom( string[] say, Mobile m ) 
			      { 
			         m.Say( say[Utility.Random( say.Length )] ); 
			      } 
					public Chandler( Serial serial ) : base( serial )
					{
		}
	
	
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new ChandlerEntry( from, this ) ); 
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
		
		public class ChandlerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ChandlerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ChandlerGump ) ) )
					{
						mobile.SendGump( new ChandlerGump( mobile ));
						
				         	
				         }
				         
				  }       
				     
                        }
           }
   }   
}	
					 				       
					 				         