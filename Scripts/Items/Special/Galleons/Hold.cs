//******************\\
//*****Marlando******\\
//********************\\
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Movement;
using Server.Network;
using Server.Multis;
using Server.Gumps;

namespace Server.Customs.Galleons
{
    public class Hold : Container
    {
        private BaseGalleon m_Galleon;

        public Hold(BaseGalleon boat)
            : base(0x3EAE)
        {
            m_Galleon = boat;
            Movable = false;
        }

        public Hold(Serial serial)
            : base(serial)
        {
        }

        public void SetFacing(Direction dir)
        {
            switch (dir)
            {
                case Direction.East: ItemID = 0x3E65; break;
                case Direction.West: ItemID = 0x3E93; break;
                case Direction.North: ItemID = 0x3EAE; break;
                case Direction.South: ItemID = 0x3EB9; break;
            }
        }

        public override bool OnDragDrop(Mobile from, Item item)
        {
            if (m_Galleon == null || !m_Galleon.Contains(from) || m_Galleon.IsMoving)
                return false;

            return base.OnDragDrop(from, item);
        }

        public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
        {
            if (m_Galleon == null || !m_Galleon.Contains(from) || m_Galleon.IsMoving)
                return false;

            return base.OnDragDropInto(from, item, p);
        }

        public override bool CheckItemUse(Mobile from, Item item)
        {
            if (item != this && (m_Galleon == null || !m_Galleon.Contains(from) || m_Galleon.IsMoving))
                return false;

            return base.CheckItemUse(from, item);
        }

        public override bool CheckLift(Mobile from, Item item, ref LRReason reject)
        {
            if (m_Galleon == null || !m_Galleon.Contains(from) || m_Galleon.IsMoving)
                return false;

            return base.CheckLift(from, item, ref reject);
        }

        public override void OnAfterDelete()
        {
            if (m_Galleon != null)
                m_Galleon.Delete();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (m_Galleon == null || !m_Galleon.Contains(from))
            {
                if (m_Galleon.TillerMan != null)
                    m_Galleon.TillerMan.Say(502490); // You must be on the ship to open the hold.
            }
            else if (m_Galleon.IsMoving)
            {
                if (m_Galleon.TillerMan != null)
                    m_Galleon.TillerMan.Say(502491); // I can not open the hold while the ship is moving.
            }
            else
            {
                base.OnDoubleClick(from);
            }
        }

        public override bool IsDecoContainer
        {
            get { return false; }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(m_Galleon);
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

                        if (m_Galleon == null || Parent != null)
                            Delete();

                        Movable = false;

                        break;
                    }
            }
        }
    }
}