/*Created by Hammerhand*/

using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RecipeFragment10 : Item
    {
        public override string DefaultName
        {
            get { return "Recipe Fragment 10"; }
        }

        [Constructable]
        public RecipeFragment10()
            : base(0x14ED)
        {
            base.Weight = 1.0;
            Hue = 0;
        }

        public RecipeFragment10(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}