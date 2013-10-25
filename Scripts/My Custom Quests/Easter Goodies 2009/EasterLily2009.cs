using System;

namespace Server.Items
{
	[FlipableAttribute( 0xC8B, 0xC8C)]
	public class EasterLily2009 : Item
	{
		[Constructable]
		public EasterLily2009() : base( 0xC8B )
		{
			Weight = 1.0;
			Name = "Easter Lily 2009";
			LootType = LootType.Blessed;			
		}

		public EasterLily2009(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}