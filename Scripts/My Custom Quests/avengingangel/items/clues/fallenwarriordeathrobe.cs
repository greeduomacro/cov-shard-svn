/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
   [FlipableAttribute( 0x2683, 0x2684 )]
   public class FallenWarriorShroud : BaseOuterTorso
   {
      [Constructable]
      public FallenWarriorShroud() : base( 0x2683 )
      {
         Weight = 5.0;
         Name = "Shroud";
         Layer = Layer.OuterTorso;
      }

      public FallenWarriorShroud( Serial serial ) : base( serial )
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
