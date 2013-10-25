
using System;
using Server;

namespace Server.Items
{
    public class SkirtOfLust : LeatherSkirt
    {
      
        [Constructable]
        public SkirtOfLust()
        {
            Weight = 10.0;
            Name = "Skirt Of Lust";
            Hue = 34;      

        }

        public SkirtOfLust(Serial serial) : base(serial)
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