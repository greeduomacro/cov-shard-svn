using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;

namespace Server.Items
{
   public class RidablePolarDeed : Item
   {
      [Constructable]
      public RidablePolarDeed() : base( 5360 )
      {
         Name = "A Ridable Polar Bear Deed";
         Hue = 204;
         Weight = 1.0;
         LootType = LootType.Blessed;

      }

      public override void OnDoubleClick( Mobile from )
      {

	PlayerMobile pm = from as PlayerMobile;

			//if ( !IsChildOf( from.Backpack ) )
			{
				//from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			//else if( from.InRange( this.GetWorldLocation(), 1 ) ) 
		        {
           		from.FixedParticles( 0x373A, 10, 15, 5036, EffectLayer.Head ); 
                from.PlaySound( 521 );
        		RidablePolar RidablePolar = new RidablePolar();
        		RidablePolar.Controlled = true;
        		RidablePolar.ControlMaster = from;
        		RidablePolar.IsBonded = true;
        		RidablePolar.Location = from.Location;
        		RidablePolar.Map = from.Map;
        		World.AddMobile( RidablePolar );

               		from.SendMessage( "You click the deed, and a polar bear appears! It is now your loyal pet." );
      			this.Delete();
		        } 
		        //else 
		        { 
		            from.SendLocalizedMessage( 500446 ); // That is too far away. 
		        }
      }

      public RidablePolarDeed(Serial serial)
          : base(serial)
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
   }
}
