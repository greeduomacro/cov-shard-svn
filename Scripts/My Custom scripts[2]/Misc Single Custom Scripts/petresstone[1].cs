// Script created by Kamageddon of Dark Daemon //
// This script will only work with RunUO RCO 1 as far as I know, untested on previous versions//

using System; 
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Items
{ 
   public class PetRes : Item 
   { 
   
      [Constructable] 
      public PetRes() : base( 0xED4 ) 
      { 
         Movable = false; 
         Hue = 0x250; 
         Name = "a Pet Res Stone"; 
      } 
      
      public PetRes( Serial serial ) : base( serial )
      {
      
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

      public override void OnDoubleClick( Mobile m )
      {      
      				
      		if ( m.InRange( GetWorldLocation(), Core.AOS ? 2 : 1 ) )
			{
				m.RevealingAction();

				m.SendMessage( "What pet would you like to resurrect?" );

				m.Target = new PetResTarget();
			}
			else
			{
	 			m.SendLocalizedMessage( 500295 ); // You are too far away to do that.
			}
		}

	private class PetResTarget : Target
	{

		public PetResTarget( ) : base( 1, false, TargetFlags.Beneficial )
		{
	}	
	            
        protected override void OnTarget( Mobile m, object obj )
        {
      	  if(obj is Mobile)
      		  { 
         	  Mobile mob = (Mobile)obj;		

			  if ( mob.IsDeadBondedPet )
			  {
				BaseCreature bc = mob as BaseCreature;

				{					
					bc.PlaySound( 0x214 );
					bc.FixedEffect( 0x376A, 10, 16 );

					bc.ResurrectPet();

					m.SendMessage( "Your pet has been resurrected." );
					}	
				}
			}
 		}
 	}
 }
 } 

