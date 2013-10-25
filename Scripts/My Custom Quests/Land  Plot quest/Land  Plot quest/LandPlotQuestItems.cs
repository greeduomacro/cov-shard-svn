using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
    public class YourMind : Item
    {
        [Constructable]
        public YourMind()
            : base(0x1CF0)
        {
            Weight = 1.0;
            Name = "Your Mind";
            Hue = 63;
        }

        public YourMind(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

    }

    public class EternalFire : Item
    {
        [Constructable]
        public EternalFire()
            : base(0xA12)
        {
            Hue = 1360;
            Name = "Eternal Fire";
            Weight = 1.0;
        }

        public EternalFire(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class Dirt : Item
    {
        [Constructable]
        public Dirt()
            : base(0xF81)
        {
            Hue = 341;
            Name = "Dirt";
            Weight = 1.0;
        }

        public Dirt(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}









