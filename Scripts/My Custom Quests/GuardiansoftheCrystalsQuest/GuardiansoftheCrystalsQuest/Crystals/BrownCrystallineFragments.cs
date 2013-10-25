using System;
using Server;

namespace Server.Items
{
	public class BrownCrystallineFragments : Item
	{	
		[Constructable]
		public BrownCrystallineFragments() : base( 0x223B )
		{
			//LootType = LootType.Blessed;
            Name = "Brown Crystalline Fragments";
			Weight = 1;
			Hue = 1863;
		}

		public BrownCrystallineFragments( Serial serial ) : base( serial )
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

