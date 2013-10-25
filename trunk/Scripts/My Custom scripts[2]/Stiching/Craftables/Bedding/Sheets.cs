using System;
using Server;
using Server.Network;
using Server.Regions;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	[Flipable( 0xA92, 0xA93 )]
	public class FoldedSheet : Item, IDyable
	{
        [Constructable]
		public FoldedSheet() : this( 0 )
		{
		}

		[Constructable]
		public FoldedSheet( int hue ) : base(0xA92)
		{
			Weight = 5.0;
			Name = "Folded Sheet";
            Hue = hue;
		}

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

		public FoldedSheet(Serial serial) : base(serial)
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