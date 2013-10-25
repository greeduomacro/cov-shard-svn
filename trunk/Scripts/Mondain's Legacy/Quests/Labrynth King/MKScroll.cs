using Server;
using System;
using Server.Items;

namespace Server.Items
{
	public class MKScroll : Item
	{		
		[Constructable]
		public MKScroll() : base( 0x227A )
		{
			Name = "Summoning Scroll of the Minotaur King";			
			Weight = 0.1;
            Hue = 247;	
		}

		public MKScroll( Serial serial ) : base( serial )
		{
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
	}
}