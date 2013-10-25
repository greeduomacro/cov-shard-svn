using System;
using Server;

namespace Server.Items
{
	public class PyroclasticCrystallineFragments : Item
	{	
		[Constructable]
		public PyroclasticCrystallineFragments() : base( 0x223B )
		{
			//LootType = LootType.Blessed;
            Name = "Pyroclastic Crystalline Fragments";
			Weight = 1;
			Hue = 2130;
		}

		public PyroclasticCrystallineFragments( Serial serial ) : base( serial )
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

