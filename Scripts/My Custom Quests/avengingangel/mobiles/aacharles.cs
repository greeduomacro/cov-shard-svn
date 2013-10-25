/*

Scripted by Rosey1
Thought up by Ashe


*/
using System;
using Server;
using Server.ContextMenus;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Misc;
using System.Collections;
using System.Collections.Generic;
using Server.Targeting;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a noble corpse" )]
	public class Charles : Mobile
	{
        public virtual bool IsInvulnerable{ get{ return true; } }

		[Constructable]
		public Charles()
		{	
			Name = "Charles";
		    Body = 400;
            VirtualArmor = 50;
			CantWalk = true;
			Female = false;

            HairItemID= 0x203B;
			HairHue = 0x1;
			
            AddItem( new Server.Items.LongPants( 0x1) );
			AddItem( new Server.Items.FancyShirt( 0x481) );;
            AddItem(new Server.Items.ThighBoots( 0x1));
            AddItem( new Server.Items.FeatheredHat( 0x1 ) );
            AddItem(new Server.Items.Cloak(0x485));
			
			Blessed = true;
			
		}
		public Charles( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new CharlesEntry( from, this ) ); 
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

		public class CharlesEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public CharlesEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			 public override void OnClick()
            {
               	
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
				
				{

				  if ( mobile != null)
				  {
  					Item rs = mobile.Backpack.FindItemByType(typeof(RestorationScroll));
					Item cs = mobile.Backpack.FindItemByType(typeof(CharlesMarker7));
					Item cr = mobile.Backpack.FindItemByType(typeof(CharlesMarker6));
					Item cq = mobile.Backpack.FindItemByType(typeof(CharlesMarker5));
					Item cp = mobile.Backpack.FindItemByType(typeof(CharlesMarker4));
					Item co = mobile.Backpack.FindItemByType(typeof(CharlesMarker3));
					Item cn = mobile.Backpack.FindItemByType(typeof(CharlesMarker2));
					Item cm = mobile.Backpack.FindItemByType(typeof(CharlesMarker));
					Item fm = mobile.Backpack.FindItemByType(typeof(FallenWarriorMarker));
					Item fn = mobile.Backpack.FindItemByType(typeof(FallenWarriorMarker3));
					
					if (cs != null)
							
							{
							mobile.SendGump(new CharlesQuestGump9(mobile));
							cs.Delete();
							}
					
					else if (rs != null)
							
							{
							
							if (fn !=null)
							  {
								mobile.SendGump(new CharlesQuestGump8(mobile));
								Penthesilea pt = new Penthesilea();
								pt.MoveToWorld( new Point3D( 1546, 1683, -30), Map.Trammel);
								rs.Delete();
								fn.Delete();
							  }
							  
							  else
							   {
							   mobile.SendMessage("Are you trying to dupe me?");
							   }
							}
							    
							  
							  
					
					else if (cr != null)
					{
							
							mobile.SendGump(new CharlesQuestGump7(mobile));
							cr.Delete();
							
					}
					
					else if (cq != null)
							
							{
							mobile.SendGump(new CharlesQuestGump6(mobile));
							cq.Delete();
							}
					
					
					else if (cp != null)
							
							{
							mobile.SendGump(new CharlesQuestGump5(mobile));
							cp.Delete();
							}
					
					
					else if (co != null)
							
							{
							mobile.SendGump(new CharlesQuestGump4(mobile));
							co.Delete();
							}
					
					
					else if (cn != null)
							
							{
							mobile.SendGump(new CharlesQuestGump3(mobile));
							cn.Delete();
							}
					
					
					 else if (cm != null)
							
							{
							mobile.SendGump(new CharlesQuestGump2(mobile));
							cm.Delete();
							}
						

					
						 else if (fm != null)
							{
								mobile.SendGump(new CharlesQuestGump(mobile));
								fm.Delete();
							}
							
					 	else
									{
								mobile.SendMessage("I have no business with you");
									}
							
			       }
					
							
				}
            }
		}

		
	}
}
