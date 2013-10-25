/* Created By Hammerhand */

using System;
using Server.Misc;

namespace Server.Items
{

    public class RobeOfTheEons : Robe
    {
        public override int PhysicalResistance { get { return 15; } }
        public override int FireResistance { get { return 18; } }
        public override int ColdResistance { get { return 15; } }
        public override int PoisonResistance { get { return 13; } }
        public override int EnergyResistance { get { return 26; } } 

        [Constructable]
        public RobeOfTheEons()
            : base(0x1F03)
        {
            Name = "The Robe Of The Eons";
            Hue = 0x481;


        }


        public RobeOfTheEons(Serial serial)
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
}