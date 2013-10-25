using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class LilyPad1 : Item
    {

        [Constructable]
        public LilyPad1()
            : base(3338)
        {
            Hue = 138;
            Name = "Croaker's Lily Pad";
        }

        public LilyPad1(Serial serial)
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


    public class LilyPad2 : Item
    {

        [Constructable]
        public LilyPad2()
            : base(3338)
        {
            Hue = 1717;
            Name = "Muckers's Lily Pad";
        }

        public LilyPad2(Serial serial)
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


    public class LilyPad3 : Item
    {

        [Constructable]
        public LilyPad3()
            : base(3338)
        {
            Hue = 1196;
            Name = "Twitcher's Lily Pad";
        }

        public LilyPad3(Serial serial)
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

    public class LilyPad4 : Item
    {

        [Constructable]
        public LilyPad4()
            : base(3338)
        {
            Hue = 2963;
            Name = "Mud Lord's Lily Pad";
        }

        public LilyPad4(Serial serial)
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

