using System;

namespace Server.Items
{
	[Server.Engines.Craft.Forge]
	public class PortableForge : Item
	{
		[Constructable]
		public PortableForge() : base( 0xFB1 )
		{
			Name = "a Portable Forge";
			Hue = 1161;
			Movable = true;
			LootType = LootType.Blessed;
		}

		public PortableForge( Serial serial ) : base( serial )
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