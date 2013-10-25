using System;
using Server;

namespace Server.Items
{
   public class AlligatorHide : Item
   {
      [Constructable]
      public AlligatorHide() : base( 0x1078 )
      {
 		Name = "Alligator Hide";
 		Hue = 2967;
        Weight = 0.1;
      }
      
      public AlligatorHide( Serial serial ) : base( serial )
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