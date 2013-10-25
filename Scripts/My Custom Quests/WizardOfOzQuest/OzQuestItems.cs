using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
    public class ScarecrowBrain : Item
    {
        [Constructable]
        public ScarecrowBrain()
            : base(0x1CF0)
        {
            Weight = 1.0;
            Name = "The Scarecrow's Brain";
            Hue = 643;
        }

        public ScarecrowBrain(Serial serial)
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

    public class LionsCourageMedallion : Item
    {
        [Constructable]
        public LionsCourageMedallion()
            : base(0x2AAA)
        {
            Hue = 54;
            Name = "Lions Medallion of Courage";
            Weight = 1.0;
        }

        public LionsCourageMedallion(Serial serial)
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

    public class TinMansHeart : Item
    {
        [Constructable]
        public TinMansHeart()
            : base(0x24B)
        {
            Hue = 2032;
            Name = "Tin Man's Heart";
            Weight = 1.0;
        }

        public TinMansHeart(Serial serial)
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

    public class RubyRedSlippers : Item
    {
        [Constructable]
        public RubyRedSlippers()
            : base(0x170F)
        {
            Hue = 1200;
            Name = "Ruby Red Slippers";
            Weight = 1.0;
        }

        public RubyRedSlippers(Serial serial)
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








