using System;
using Server;

namespace Server.Items
{
	public class MirageCrystallineFragments : Item
	{	
		[Constructable]
		public MirageCrystallineFragments() : base( 0x223B )
		{
			//LootType = LootType.Blessed;
            Name = "Mirage Crystalline Fragments";
			Weight = 1;
			Hue = 1267;
		}

		public MirageCrystallineFragments( Serial serial ) : base( serial )
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

