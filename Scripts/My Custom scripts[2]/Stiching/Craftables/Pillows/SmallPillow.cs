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
	public class SmallPillow : Item, IDyable
	{
		[Constructable]
		public SmallPillow() : base(0x1915)
		{
			Weight = 5.0;
			Name = "A Small Pillow";
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }
    
		public SmallPillow(Serial serial) : base(serial)
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