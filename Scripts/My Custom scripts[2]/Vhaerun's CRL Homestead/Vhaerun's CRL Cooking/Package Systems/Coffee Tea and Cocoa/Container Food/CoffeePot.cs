using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class CoffeePot : Item
	{
		
		[Constructable]
		public CoffeePot() : base( 0x24E6 )
		{
			Weight = 1.0;
			Name = "Coffee Pot";
		}

		public CoffeePot( Serial serial ) : base( serial )
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