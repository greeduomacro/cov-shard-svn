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
     	public class OFQOrc : BaseGuildmaster
	    {
		public override NpcGuild NpcGuild{ get{ return NpcGuild.BlacksmithsGuild; } }

		public override bool ClickTitle{ get{ return false; } }

		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }		

		[Constructable]
		public OFQOrc() : base( "Blacksmith" )
		{
			Name = "Engaged Orc Blacksmith";
			Body = 17;
			BaseSoundID = 0x45A;			
		}
		
		public OFQOrc( Serial serial ) : base( serial )
		{
		}
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new OFQOrcEntry( from, this ) ); 
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
		
		public class OFQOrcEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public OFQOrcEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( OFQOrcGump ) ) )
					{
						mobile.SendGump( new OFQOrcGump( mobile ));
						
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
				if( dropped is OFQRing )
         		{
         			

					dropped.Delete();
 
				mobile.SendMessage( "Thank you for bringing my wedding ring back. I hope you find your reward useful." );
				mobile.AddToBackpack( new OrcishForge() );
					
					return true;

         		}
				
         		else
         		{
					SayTo( from, "Leave me alone! All I want is my wedding ring back." );
     			}
			}
			return false;

		
		}

	}
}