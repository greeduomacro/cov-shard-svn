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
    public class BritGalleon : BaseGalleon
    {
        public override int NorthID { get { return 64; } }
        public override int EastID { get { return 65; } }
        public override int SouthID { get { return 66; } }
        public override int WestID { get { return 67; } }

        public override int HoldOffset { get { return -9; ; } }
        public override int TillerManOffset { get { return 6; } }

        public override Point2D StarboardOffset { get { return new Point2D(2, 0); } }
        public override Point2D PortOffset { get { return new Point2D(-2, 0); } }

        public override Point3D MarkOffset { get { return new Point3D(0, 1, 3); } }

        //public override BaseDockedBoat DockedBoat { get { return new SmallDockedBoat(this); } }

        [Constructable]
        public BritGalleon()
            : base()
        {
            //BoardRope b = new BoardRope(this);
            //b.Location = new Point3D(X + 3, Y - 2, Z + 18);
            //Ropes.Add(b);

            //b = new BoardRope(this);
            //b.Location = new Point3D(X - 3, Y - 2, Z + 18);
            //Ropes.Add(b);

            UpdateAllComponents();
        }

        public BritGalleon(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }
    }
}