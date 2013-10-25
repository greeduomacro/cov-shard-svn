using System;

namespace Server.Items
{
	public class CladdaghRing2009 : BaseRing
	{
		[Constructable]
		public CladdaghRing2009() : base( 0x108A )
		{
			Name = "Claddagh Ring 2009";
			Hue = 2244;
			Weight = 0.1;
			Attributes.Luck = 100;
			LootType = LootType.Blessed;			
		}

		public CladdaghRing2009( Serial serial ) : base( serial )
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