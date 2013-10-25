//******************\\
//*****Marlando******\\
//********************\\
using System;
using System.Collections;
using Server;
using Server.Multis;
using Server.Items;

namespace Server.Customs.Galleons
{
    public enum RopeSide { Port, Starboard }

    public class BoardRope : Item
    {
        private BaseGalleon m_Galleon;
        private bool m_Locked;

        [Constructable]
        public BoardRope(BaseGalleon galleon)
            : base(5368)
        {
            m_Galleon = galleon;
            m_Locked = true;

            Movable = false;
        }

        [Constructable]
        public BoardRope()
            : base(5368)
        {
            m_Locked = true;
            Movable = false;

            m_Galleon = BaseGalleon.FindGalleonAt(new Point2D(X, Y), Map);
            if (m_Galleon != null)
                m_Galleon.Ropes.Add(this);
        }

        public BoardRope(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version

            writer.Write(m_Galleon);
            writer.Write(m_Locked);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Galleon = reader.ReadItem() as BaseGalleon;
                        m_Locked = reader.ReadBool();

                        if (m_Galleon == null)
                            Delete();

                        break;
                    }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public BaseGalleon Galleon { get { return m_Galleon; } set { m_Galleon = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Locked { get { return m_Locked; } set { m_Locked = value; } }

        public override void OnDoubleClickDead(Mobile from)
        {
            OnDoubleClick(from);
        }

        public override void OnDoubleClick(Mobile from)
        {
            
        }
    }
}