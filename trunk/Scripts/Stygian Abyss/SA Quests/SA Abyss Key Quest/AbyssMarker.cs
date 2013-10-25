//////////////////////////
/// Created by Mitty ////
//////////////////////// 

using System;
using Server.Items;

namespace Server.Items 
{
    public class AbyssMarker : Item
    {
        [Constructable]
        public AbyssMarker()
            : base(0x176B)
        {
            Weight = 0;
            Name = "Abyss Marker";
            Hue = 0;
            LootType = LootType.Blessed;
            Movable = false;
            Visible = false;
        }

        public AbyssMarker(Serial serial)
            : base(serial)
        {
        }

        //public override void OnAfterDelete()
        //{
            //if (m_Timer != null)
               // m_Timer.Stop();

            //base.OnAfterDelete();
        //}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            //writer.WriteDeltaTime(m_DecayTime);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

           // m_DecayTime = reader.ReadDeltaTime();
           // m_Timer = new InternalTimer(this, m_DecayTime);
           // m_Timer.Start();

        }

        /*private class InternalTimer : Timer
        {
            private Item m_Item;

            public InternalTimer(Item item, DateTime end)
                : base(end - DateTime.Now)
            {
                m_Item = item;
            }

            protected override void OnTick()
            {
                m_Item.Delete();
            }*/
        }
    }
 