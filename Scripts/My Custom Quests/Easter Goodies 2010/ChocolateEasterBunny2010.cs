using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class ChocolateEasterBunny2010 : Food
	{
		[Constructable]
		public ChocolateEasterBunny2010() : base( 0x2125 )
		{
            Name = "Chocolate Easter Bunny 2010";
            Hue = Utility.RandomList(0x156, 0x21E, 0x71A);
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public ChocolateEasterBunny2010( Serial serial ) : base( serial )
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