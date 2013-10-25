using System;
using Server;

namespace Server.Items
{
    public class CrystalSkull : Item
    {
        private bool m_Decays;
        private DateTime m_DecayTime;
        private Timer m_Timer;

        [Constructable]
        public CrystalSkull()
            : this(true)
        {
        }

      
        [Constructable]
        public CrystalSkull(bool decays)
            : base(Utility.Random(0x1AE2, 3))
        {
            Name = "The Crystal Creator's Skull";
            Weight = 1.0;
            Hue = 1152;

            if (decays)
            {
                m_Decays = true;
                m_DecayTime = DateTime.Now + TimeSpan.FromMinutes(8);

                m_Timer = new InternalTimer(this, m_DecayTime);
                m_Timer.Start();
            }
        }

        public CrystalSkull(Serial serial)
            : base(serial)
        {
        }

        public override void OnAfterDelete()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            base.OnAfterDelete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(m_Decays);

            if (m_Decays)
                writer.WriteDeltaTime(m_DecayTime);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Decays = reader.ReadBool();

                        if (m_Decays)
                        {
                            m_DecayTime = reader.ReadDeltaTime();

                            m_Timer = new InternalTimer(this, m_DecayTime);
                            m_Timer.Start();
                        }

                        break;
                    }
            }
        }

        private class InternalTimer : Timer
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
            }
        }
    }
}
            
        
    
