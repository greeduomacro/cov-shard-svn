//////////////////////////
/// Created by Mitty ////
//////////////////////// 

using System;
using Server.Items;

namespace Server.Items 
{
    public class WakitaMarker : Item
    {
        private DateTime m_DecayTime;
        private Timer m_Timer;

        [Constructable]
        public WakitaMarker()
            : base(0x176B)
        {
            Weight = 0;
            Name = "Wakita Marker";
            Hue = 0;
            LootType = LootType.Blessed;
            Movable = false;
            Visible = false;

        }

        public WakitaMarker(Serial serial)
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