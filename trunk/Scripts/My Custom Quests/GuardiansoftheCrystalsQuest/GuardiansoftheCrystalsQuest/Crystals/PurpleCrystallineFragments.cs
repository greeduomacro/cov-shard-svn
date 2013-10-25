using System;
using Server;

namespace Server.Items
{
	public class PurpleCrystallineFragments : Item
	{	
		[Constructable]
		public PurpleCrystallineFragments() : base( 0x223B )
		{
			//LootType = LootType.Blessed;
            Name = "Purple Crystalline Fragments";
			Weight = 1;
			Hue = 16;
		}

		public PurpleCrystallineFragments( Serial serial ) : base( serial )
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

