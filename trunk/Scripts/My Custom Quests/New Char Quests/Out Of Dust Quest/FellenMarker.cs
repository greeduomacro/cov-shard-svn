//////////////////////////
/// Created by Mitty ////
//////////////////////// 

using System;
using Server.Items;

namespace Server.Items 
{
    public class FellenMarker : Item
    {

        [Constructable]
        public FellenMarker()
            : base(0x176B)
        {
            Weight = 0;
            Name = "FellenMarker";
            Hue = 0;
            LootType = LootType.Blessed;
            Movable = false;
            Visible = false;

        }

        public FellenMarker(Serial serial)
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