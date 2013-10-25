/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
    	public class PipePiece : Item
        {

		[Constructable]
		public PipePiece() : base( 0xF8A )
		{
        Name = "A piece of pipe";
        Hue = 2301;
		}

        public PipePiece(Serial serial)
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