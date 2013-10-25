using System;
using Server;

namespace Server.Items
{
    public class RewardSpiderMask : BaseHat
    {
        public override int BasePhysicalResistance { get { return 10; } }
        public override int BaseFireResistance { get { return 0; } }
        public override int BaseColdResistance { get { return 10; } }
        public override int BasePoisonResistance { get { return 50; } }
        public override int BaseEnergyResistance { get { return 0; } }

        public override int InitMinHits { get { return 20; } }
        public override int InitMaxHits { get { return 30; } }

        [Constructable]
        public RewardSpiderMask()
            : this(0)
        {
        }

        [Constructable]
        public RewardSpiderMask(int hue)
            : base(0x154B, hue)
        {
            Hue = 1272;
            Name = "Spider Tribal Mask";
            Weight = 2.0;
        }

        public override bool Dye(Mobile from, DyeTub sender)
        {
            from.SendLocalizedMessage(sender.FailMessage);
            return false;
        }

        public RewardSpiderMask(Serial serial)
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