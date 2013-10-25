using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class FullDruidbook : DruidicSpellbook
   {

      [Constructable]
      public FullDruidbook()
      {
            this.Content = 65535;
      }

      public FullDruidbook( Serial serial ) : base( serial )
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
