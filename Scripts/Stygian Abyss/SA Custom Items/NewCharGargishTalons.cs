using System;

namespace Server.Items
{
    [FlipableAttribute(0x170d, 0x170e)]
    public class NewCharLeatherTalons : BaseShoes
    {
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }
        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

        [Constructable]
        public NewCharLeatherTalons()
            : this(0)
        {
        }

        [Constructable]
        public NewCharLeatherTalons(int hue)
            : base(0x41D8, hue)
        {
            Name = "New Char Gargish Talons";
            Weight = 1.0;
            Attributes.LowerRegCost = 100;
            LootType = LootType.Blessed;
        }

        public NewCharLeatherTalons(Serial serial)
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

	