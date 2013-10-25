using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class LuckyCharmsCereal2009 : Food
	{
		[Constructable]
		public LuckyCharmsCereal2009( ) : base( 0x2254 )
		{
			Name = "Lucky Charms Cereal 2009";
			Hue = 1368;
			Weight = 1;
			FillFactor = 1;
			Stackable = false;
			LootType = LootType.Blessed;
		}

		public LuckyCharmsCereal2009( Serial serial ) : base( serial )
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