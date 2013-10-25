//////////////////////////
/// Created by Mitty ////
//////////////////////// 

using System;
using Server.Items;

namespace Server.Items 
{
    public class Ranni1Marker : Item
    {

        [Constructable]
        public Ranni1Marker()
            : base(0x176B)
        {
            Weight = 0;
            Name = "Ranni Marker";
            Hue = 0;
            LootType = LootType.Blessed;
            Movable = false;
            Visible = false;

        }

        public Ranni1Marker(Serial serial)
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