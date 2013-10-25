// Scripted by Karmageddon
using System;

namespace Server.Items
{
	public class MeraktusScroll : Item
	{		
		[Constructable]
		public MeraktusScroll() : base( 0x227A )
		{
			Name = "Scroll to summon Meraktus";			
			Weight = 0.1;
            Hue = 0;//////////////////////////////////////////////////////////////////			
		}

		public MeraktusScroll( Serial serial ) : base( serial )
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