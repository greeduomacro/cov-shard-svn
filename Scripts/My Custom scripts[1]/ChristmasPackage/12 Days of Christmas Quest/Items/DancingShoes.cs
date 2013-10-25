/*Created by Hammerhand*/

using System;
using Server.Misc;

namespace Server.Items
{
    public class DancingShoes : Sandals
    {

        [Constructable]
        public DancingShoes()
            : base(0x170d)
        {
            Name = "Dancing Shoes";
            Hue = 1276;

        }

        public DancingShoes(Serial serial)
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