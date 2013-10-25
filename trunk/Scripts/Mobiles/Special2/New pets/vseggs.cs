using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;

namespace Server.Items
{
   public class vseggs : Item
   {
      [Constructable]
      public vseggs() : base( 2485 )
      {
         Name = "Volt Spider eggs";
         Hue = 0x4fd;
      }

      public override void OnDoubleClick( Mobile from )
      {

          PlayerMobile pm = from as PlayerMobile;
          {
              from.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
              from.PlaySound(521);
              VoltSpider VoltSpider = new VoltSpider();
              VoltSpider.Controlled = true;
              VoltSpider.ControlMaster = from;
              VoltSpider.IsBonded = true;
              VoltSpider.Location = from.Location;
              VoltSpider.Map = from.Map;
              World.AddMobile(VoltSpider);

                  from.SendMessage("You hatch a Volt Spider from the eggs you looted, and it is now your loyal pet.");
                  this.Delete();

              if ( from.Followers > from.FollowersMax )
              {
                  from.SendMessage(" You cannot hatch the eggs you have too many followers!");
              }
          }
      }

      public vseggs( Serial serial ) : base( serial )
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
