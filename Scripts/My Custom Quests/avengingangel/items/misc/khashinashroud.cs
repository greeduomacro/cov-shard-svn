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
   public class KhashinaShroud : BaseOuterTorso
   {
      [Constructable]
      public KhashinaShroud() : base( 0x2683 )
      {
         Weight = 5.0;
         Name = "a blood stained robe";
         Layer = Layer.OuterTorso;
		 Hue= 1157;
      }

      public KhashinaShroud( Serial serial ) : base( serial )
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
