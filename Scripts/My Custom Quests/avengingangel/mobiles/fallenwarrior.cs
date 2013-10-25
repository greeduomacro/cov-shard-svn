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

namespace Server.Mobiles
{
	[CorpseName( "a fallen warrior corpse" )]
	public class FallenWarrior : Mobile
	{
        public virtual bool IsInvulnerable{ get{ return true; } }
                
		[Constructable]
		public FallenWarrior()
		{
			Name = "FallenWarrior";
		    Body = 402;
            VirtualArmor = 50;
			CantWalk = true;
			
			Female = false;

            AddItem( new Server.Items.FallenWarriorShroud() );
			
			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			
			hair.Hue = Utility.RandomHairHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
			
			Blessed = true;
			
		}
		public FallenWarrior( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new FallenWarriorEntry( from, this ) ); 
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

		public class FallenWarriorEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public FallenWarriorEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			 public override void OnClick()
            {
                
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
				
				{	Item fm = mobile.Backpack.FindItemByType(typeof(FallenWarriorMarker2));
					 if (fm != null)
					{
						
						Item ei = mobile.Backpack.FindItemByType(typeof(EnergizedIngot));
					    Item bp = mobile.Backpack.FindItemByType(typeof(BrokenPlateArms));
						Item cg = mobile.Backpack.FindItemByType(typeof (CrackedGorget));
						Item cl = mobile.Backpack.FindItemByType(typeof (CrushedLeggings));
						Item sb = mobile.Backpack.FindItemByType(typeof (ShatteredBreastPlate));
						Item sh = mobile.Backpack.FindItemByType(typeof (SplitHelm));
						Item wg = mobile.Backpack.FindItemByType(typeof (WornGloves));
						
                        if ( fm == null || fm.Amount < 1 || bp == null || bp.Amount < 1 || cg== null || cg.Amount < 1 || cl== null || cl.Amount < 1 || sb== null || sb.Amount < 1 || sh== null || sh.Amount < 1 || wg== null || wg.Amount < 1 || ei== null || ei.Amount < 1 ) 
						{
						mobile.SendMessage("Have you come back with all the items?");
						}	
						
						else
                        {
                        
                            mobile.SendGump(new FallenWarriorQuestGump2(mobile));
                            mobile.Backpack.ConsumeTotal( typeof( EnergizedIngot ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( CrackedGorget ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( BrokenPlateArms ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( CrushedLeggings ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( ShatteredBreastPlate ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( SplitHelm ), 1 );
                            mobile.Backpack.ConsumeTotal( typeof( WornGloves ), 1 );
							mobile.AddToBackpack( new AvengingAngelArms () );
							mobile.AddToBackpack(  new  AvengingAngelBreastPlate() );
							mobile.AddToBackpack(  new  AvengingAngelGloves() );
							mobile.AddToBackpack(  new  AvengingAngelGorget () );
							mobile.AddToBackpack(  new  AvengingAngelHelmet() );
							mobile.AddToBackpack(  new  AvengingAngelLeggings () );
							mobile.AddToBackpack(  new  AvengingAngelRing () );
							fm.Delete();
					
                        }
                    }
					
							else
                            {
                                mobile.SendGump(new FallenWarriorQuestGump(mobile));
								mobile.AddToBackpack(new FallenWarriorMarker ());

							
                            }
					
                    
                }
				
				
				
            }
		}

		
	}
}
