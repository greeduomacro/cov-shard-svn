using System;
using Server.Items;

namespace Server.Items
{
	public class CrystalBrazier : Item
	{
		[Constructable]
		public CrystalBrazier() : base(0x35EF)
		{
			Movable = true;
			Name = "Crystal Brazier";
		}

		public CrystalBrazier(Serial serial) : base(serial)
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

			if ( Weight == 6.0 )
				Weight = 20.0;
		}
	}
}
