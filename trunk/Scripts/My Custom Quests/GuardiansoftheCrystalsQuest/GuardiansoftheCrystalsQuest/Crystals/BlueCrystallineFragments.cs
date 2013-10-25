using System;
using Server;

namespace Server.Items
{
	public class BlueCrystallineFragments : Item
	{	
		[Constructable]
		public BlueCrystallineFragments() : base( 0x223B )
		{
			//LootType = LootType.Blessed;
            Name = "Blue Crystalline Fragments";
			Weight = 1;
			Hue = 2124;
		}

		public BlueCrystallineFragments( Serial serial ) : base( serial )
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

