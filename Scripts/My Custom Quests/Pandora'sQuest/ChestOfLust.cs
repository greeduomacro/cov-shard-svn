
using System;
using Server;

namespace Server.Items
{
    public class ChestOfLust : LeatherBustierArms
    {
      
        [Constructable]
        public ChestOfLust()
        {
            Weight = 1.0;
            Name = "Chest Of Lust";
            Hue = 34;
          
        }

        public ChestOfLust(Serial serial) : base(serial)
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