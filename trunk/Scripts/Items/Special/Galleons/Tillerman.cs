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
    public class TillerMan : Mobile
    {
        private BaseGalleon m_Galleon;

        [CommandProperty(AccessLevel.GameMaster)]
        public BaseGalleon Galleon { get { return m_Galleon; } }

        public TillerMan(BaseGalleon galleon)
            : base()
        {
            m_Galleon = galleon;
            CantWalk = true;

            InitStats(31, 41, 51);

            SpeechHue = Utility.RandomDyedHue();

            Hue = Utility.RandomSkinHue();


            if (this.Female = Utility.RandomBool())
            {
                this.Body = 0x191;
                this.Name = NameList.RandomName("female");
                AddItem(new Kilt(Utility.RandomDyedHue()));
                AddItem(new Shirt(Utility.RandomDyedHue()));
                AddItem(new ThighBoots());
                Title = "the tillerman";
            }
            else
            {
                this.Body = 0x190;
                this.Name = NameList.RandomName("male");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
                AddItem(new Shirt(Utility.RandomDyedHue()));
                AddItem(new Sandals());
                Title = "the tillerman";
            }

            AddItem(new Bandana(Utility.RandomDyedHue()));

            Utility.AssignRandomHair(this);

            Container pack = new Backpack();

            pack.DropItem(new Gold(250, 300));

            pack.Movable = false;

            AddItem(pack);
        }

        public TillerMan(Serial serial)
            : base(serial)
        {
        }

        public void SetFacing(Direction dir)
        {
            switch (dir)
            {
                case Direction.South: Direction = Server.Direction.South; break;
                case Direction.North: Direction = Server.Direction.North; break;
                case Direction.West: Direction = Server.Direction.West; break;
                case Direction.East: Direction = Server.Direction.East; break;
            }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            if (m_Galleon != null)
            list.Add(m_Galleon.Status);
        }

        public void Say(int number)
        {
            PublicOverheadMessage(MessageType.Regular, 0x3B2, number);
        }

        public void Say(int number, string args)
        {
            PublicOverheadMessage(MessageType.Regular, 0x3B2, number, args);
        }

        public override void AddNameProperties(ObjectPropertyList list)
        {
            if (m_Galleon != null && m_Galleon.ShipName != null)
                list.Add(1042884, m_Galleon.ShipName); // the tiller man of the ~1_SHIP_NAME~
            else
                base.AddNameProperties(list);
        }

        public override void OnSingleClick(Mobile from)
        {
            if (m_Galleon != null && m_Galleon.ShipName != null)
                from.SendLocalizedMessage(1042884, m_Galleon.ShipName); // the tiller man of the ~1_SHIP_NAME~
            else
                base.OnSingleClick(from);
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (m_Galleon != null && m_Galleon.Contains(from))
                m_Galleon.BeginRename(from);
            else if (m_Galleon != null)
                m_Galleon.BeginDryDock(from);
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (dropped is MapItem && m_Galleon != null && m_Galleon.CanCommand(from) && m_Galleon.Contains(from))
            {
                m_Galleon.AssociateMap((MapItem)dropped);
            }

            return false;
        }

        public override void OnAfterDelete()
        {
            if (m_Galleon != null)
                m_Galleon.Delete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version

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

                        if (m_Galleon == null)
                            Delete();

                        break;
                    }
            }
        }
    }
}