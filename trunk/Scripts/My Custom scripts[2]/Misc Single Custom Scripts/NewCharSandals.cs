using System;

namespace Server.Items
{
    [FlipableAttribute(0x170d, 0x170e)]
    public class NewCharSandals : BaseShoes
    {
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public NewCharSandals()
            : this(0)
        {
        }

        [Constructable]
        public NewCharSandals(int hue)
            : base(0x170D, hue)
        {
            Name = "New Char Sandals";
            Weight = 1.0;
            Attributes.LowerRegCost = 100;
            LootType = LootType.Blessed;
        }

        public NewCharSandals(Serial serial)
            : base(serial)
        {
        }

        public override bool Dye(Mobile from, DyeTub sender)
        {
            from.SendLocalizedMessage(sender.FailMessage);
            return false;
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

	