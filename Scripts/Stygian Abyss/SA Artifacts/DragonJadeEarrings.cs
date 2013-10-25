using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
    public class DragonJadeEarrings : BaseEarrings
    {
        public override int LabelNumber { get { return 1113720; } } //Dragon Jade Earrings

        /*public override int BasePhysicalResistance { get { return 9; } }
        public override int BaseFireResistance { get { return 16; } }
        public override int BaseColdResistance { get { return 5; } }
        public override int BasePoisonResistance { get { return 13; } }
        public override int BaseEnergyResistance { get { return 3; } }*/

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override Race RequiredRace { get { return Race.Gargoyle; } }
        public override bool CanBeWornByGargoyles { get { return true; } }

        [Constructable]
        public DragonJadeEarrings(): base(0x4212)
        {
            Weight = 1.0;
            Hue = 1164;
            Attributes.RegenStam = 3;
            Attributes.RegenHits = 2;
            Attributes.BonusDex = 5;
            Attributes.BonusStr = 5;
            AbsorptionAttributes.EaterFire = 10;
            Attributes.LowerManaCost = 5;

        }

        public DragonJadeEarrings(Serial serial): base(serial)
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

