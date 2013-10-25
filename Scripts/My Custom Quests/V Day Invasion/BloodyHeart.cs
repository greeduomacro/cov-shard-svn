using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BloodyHeart : BaseReagent, ICommodity
    {

        string ICommodity.Description
        {
            get
            {
                return String.Format("{0} Bloody Heart", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public BloodyHeart()
            : this(1)
        {
            Name = "Bloody Heart";
            Hue = 33;

        }

        [Constructable]
        public BloodyHeart(int amount)
            : base(0x24B, amount)
        {
            Name = "BloodyHeart";
            Hue = 33;
        }

        public BloodyHeart(Serial serial)
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