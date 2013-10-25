using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;

namespace Server.Items
{
   public class sdeggs : Item
   {
      [Constructable]
      public sdeggs() : base( 2485 )
      {
         Name = "Snow Drake eggs";
         Hue = 1150;

      }
      public override void OnDoubleClick( Mobile from )
      {

	PlayerMobile pm = from as PlayerMobile;
    {
           		from.FixedParticles( 0x373A, 10, 15, 5036, EffectLayer.Head ); 
                from.PlaySound( 521 );
        		SnowDrake SnowDrake = new SnowDrake();
        		SnowDrake.Controlled = true;
        		SnowDrake.ControlMaster = from;
        		SnowDrake.IsBonded = true;
        		SnowDrake.Location = from.Location;
        		SnowDrake.Map = from.Map;
        		World.AddMobile( SnowDrake );

               		from.SendMessage( "You hatch a Snow Drake from the eggs you looted, and it is now your loyal pet." );
      			this.Delete();

                if (from.Followers > from.FollowersMax)
                {
                    from.SendMessage(" You cannot hatch the eggs you have too many followers!");
                }
             }
          }
      public sdeggs( Serial serial ) : base( serial )
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
