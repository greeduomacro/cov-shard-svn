using System;
using System.Text;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
    public class SpecialCommodityDeed : Item // Create the item class which is derived from the base item class
    {
        private int m_Amount = 0;
        private int m_Resource = 0;

        [CommandProperty(AccessLevel.Administrator)]
        public int Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public int Resource
        {
            get { return m_Resource; }
            set { m_Resource = value; }
        }

        [Constructable]
        public SpecialCommodityDeed(int amount, int resource) : base(0x14F0)
        {
            Weight = 1.0;
            Name = "Custom Resource Commodity Deed";
            LootType = LootType.Blessed;
            Hue = 1195;

            m_Amount = amount;
            m_Resource = resource;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add(1060658, "Amount \t{0}", m_Amount.ToString());
            switch (m_Resource)
            {
                case 1: list.Add(1060659, "Resource \tIron Ingots"); break;
                case 2: list.Add(1060659, "Resource \tDullCopper Ingots"); break;
                case 3: list.Add(1060659, "Resource \tShadowIron Ingots"); break;
                case 4: list.Add(1060659, "Resource \tCopper Ingots"); break;
                case 5: list.Add(1060659, "Resource \tBronze Ingots"); break;
                case 6: list.Add(1060659, "Resource \tGold Ingots"); break;
                case 7: list.Add(1060659, "Resource \tSilver Ingots"); break;
                case 8: list.Add(1060659, "Resource \tAgapite Ingots"); break;
                case 9: list.Add(1060659, "Resource \tVerite Ingots"); break;
                case 10: list.Add(1060659, "Resource \tValorite Ingots"); break;
                case 11: list.Add(1060659, "Resource \tJade Ingots"); break;
                case 12: list.Add(1060659, "Resource \tMoonstone Ingots"); break;
                case 13: list.Add(1060659, "Resource \tSunstone Ingots"); break;
                //case 14: list.Add(1060659, "Resource \t Ingots"); break;
                
                case 101: list.Add(1060659, "Resource \tNormal Leather"); break;
                case 102: list.Add(1060659, "Resource \tSpined Leather"); break;
                case 103: list.Add(1060659, "Resource \tHorned Leather"); break;
                case 104: list.Add(1060659, "Resource \tBarbed Leather"); break;
                case 105: list.Add(1060659, "Resource \tDaemon Leather"); break;
                case 106: list.Add(1060659, "Resource \tDragon Leather"); break;
                //case 107: list.Add(1060659, "Resource \Leather"); break;

                case 201: list.Add(1060659, "Resource \tRed Scales"); break;
                case 202: list.Add(1060659, "Resource \tYellow Scales"); break;
                case 203: list.Add(1060659, "Resource \tBlack Scales"); break;
                case 204: list.Add(1060659, "Resource \tGreen Scales"); break;
                case 205: list.Add(1060659, "Resource \tWhite Scales"); break;
                case 206: list.Add(1060659, "Resource \tBlue Scales"); break;
             

                case 301: list.Add(1060659, "Resource \tRegular Logs"); break;
                case 302: list.Add(1060659, "Resource \tOak Logs"); break;
                case 303: list.Add(1060659, "Resource \tAsh Logs"); break;
                case 304: list.Add(1060659, "Resource \tYew Logs"); break;
                case 305: list.Add(1060659, "Resource \tHeartwood Logs"); break;
                case 306: list.Add(1060659, "Resource \tBloodwood Logs"); break;
                case 307: list.Add(1060659, "Resource \tFrostwood Logs"); break;
                case 308: list.Add(1060659, "Resource \tPine Logs"); break;
                case 309: list.Add(1060659, "Resource \tCedar Logs"); break;
                case 310: list.Add(1060659, "Resource \tCherry Logs"); break;
                case 311: list.Add(1060659, "Resource \tMahogany Logs"); break;

                case 401: list.Add(1060659, "Resource \tRegular Boards"); break;
                case 402: list.Add(1060659, "Resource \tOak Boards"); break;
                case 403: list.Add(1060659, "Resource \tAsh Boards"); break;
                case 404: list.Add(1060659, "Resource \tYew Boards"); break;
                case 405: list.Add(1060659, "Resource \tHeartwood Boards"); break;
                case 406: list.Add(1060659, "Resource \tBloodwood Boards"); break;
                case 407: list.Add(1060659, "Resource \tFrostwood Boards"); break;
                case 408: list.Add(1060659, "Resource \tPine Boards"); break;
                case 409: list.Add(1060659, "Resource \tCedar Boards"); break;
                case 410: list.Add(1060659, "Resource \tCherry Boards"); break;
                case 411: list.Add(1060659, "Resource \tMahogany Boards"); break;

            }

        }

        public SpecialCommodityDeed(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((int)m_Amount);
            writer.Write((int)m_Resource);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            LootType = LootType.Blessed;

            int version = reader.ReadInt();
            m_Amount = reader.ReadInt();
            m_Resource = reader.ReadInt();
        }

        public override bool DisplayLootType { get { return true; } }

        public override void OnDoubleClick(Mobile from)
        {
            BankBox box = from.FindBankNoCreate();
            if (box != null && IsChildOf(box))
            {
                from.SendMessage(88, "Your goods are returned to you.");
                switch (m_Resource)
                {
                    case 0: break;
                    case 1: box.DropItem(new IronIngot(m_Amount)); this.Delete(); break;
                    case 2: box.DropItem(new DullCopperIngot(m_Amount)); this.Delete(); break;
                    case 3: box.DropItem(new ShadowIronIngot(m_Amount)); this.Delete(); break;
                    case 4: box.DropItem(new CopperIngot(m_Amount)); this.Delete(); break;
                    case 5: box.DropItem(new BronzeIngot(m_Amount)); this.Delete(); break;
                    case 6: box.DropItem(new GoldIngot(m_Amount)); this.Delete(); break;
                    case 7: box.DropItem(new SilverIngot(m_Amount)); this.Delete(); break;
                    case 8: box.DropItem(new AgapiteIngot(m_Amount)); this.Delete(); break;
                    case 9: box.DropItem(new VeriteIngot(m_Amount)); this.Delete(); break;
                    case 10: box.DropItem(new ValoriteIngot(m_Amount)); this.Delete(); break;
                    case 11: box.DropItem(new JadeIngot(m_Amount)); this.Delete(); break;
                    case 12: box.DropItem(new MoonstoneIngot(m_Amount)); this.Delete(); break;
                    case 13: box.DropItem(new SunstoneIngot(m_Amount)); this.Delete(); break;
                    //case 13: box.DropItem(new Ingot(m_Amount)); this.Delete(); break;
                    
                    
                    case 101: box.DropItem(new Leather(m_Amount)); this.Delete(); break;
                    case 102: box.DropItem(new SpinedLeather(m_Amount)); this.Delete(); break;
                    case 103: box.DropItem(new HornedLeather(m_Amount)); this.Delete(); break;
                    case 104: box.DropItem(new BarbedLeather(m_Amount)); this.Delete(); break;
                    case 105: box.DropItem(new DaemonLeather(m_Amount)); this.Delete(); break;
                    case 106: box.DropItem(new DragonLeather(m_Amount)); this.Delete(); break;
                    //case 107: box.DropItem(new Leather(m_Amount)); this.Delete(); break;

                    case 201: box.DropItem(new RedScales(m_Amount)); this.Delete(); break;
                    case 202: box.DropItem(new YellowScales(m_Amount)); this.Delete(); break;
                    case 203: box.DropItem(new BlackScales(m_Amount)); this.Delete(); break;
                    case 204: box.DropItem(new GreenScales(m_Amount)); this.Delete(); break;
                    case 205: box.DropItem(new WhiteScales(m_Amount)); this.Delete(); break;
                    case 206: box.DropItem(new BlueScales(m_Amount)); this.Delete(); break;
                    //case 207: box.DropItem(new Scales(m_Amount)); this.Delete(); break;

                    case 301: box.DropItem(new Log(m_Amount)); this.Delete(); break;
                    case 302: box.DropItem(new OakLog(m_Amount)); this.Delete(); break;
                    case 303: box.DropItem(new AshLog(m_Amount)); this.Delete(); break;
                    case 304: box.DropItem(new YewLog(m_Amount)); this.Delete(); break;
                    case 305: box.DropItem(new HeartwoodLog(m_Amount)); this.Delete(); break;
                    case 306: box.DropItem(new BloodwoodLog(m_Amount)); this.Delete(); break;
                    case 307: box.DropItem(new FrostwoodLog(m_Amount)); this.Delete(); break;
                    case 308: box.DropItem(new PineLog(m_Amount)); this.Delete(); break;
                    case 309: box.DropItem(new CedarLog(m_Amount)); this.Delete(); break;
                    case 310: box.DropItem(new CherryLog(m_Amount)); this.Delete(); break;
                    case 311: box.DropItem(new MahoganyLog(m_Amount)); this.Delete(); break;

                    case 401: box.DropItem(new Board(m_Amount)); this.Delete(); break;
                    case 402: box.DropItem(new OakBoard(m_Amount)); this.Delete(); break;
                    case 403: box.DropItem(new AshBoard(m_Amount)); this.Delete(); break;
                    case 404: box.DropItem(new YewBoard(m_Amount)); this.Delete(); break;
                    case 405: box.DropItem(new HeartwoodBoard(m_Amount)); this.Delete(); break;
                    case 406: box.DropItem(new BloodwoodBoard(m_Amount)); this.Delete(); break;
                    case 407: box.DropItem(new FrostwoodBoard(m_Amount)); this.Delete(); break;
                    case 408: box.DropItem(new PineBoard(m_Amount)); this.Delete(); break;
                    case 409: box.DropItem(new CedarBoard(m_Amount)); this.Delete(); break;
                    case 410: box.DropItem(new CherryBoard(m_Amount)); this.Delete(); break;
                    case 411: box.DropItem(new MahoganyBoard(m_Amount)); this.Delete(); break;


                }
            }
            else
            {
                from.SendMessage(88, "The deed only works in your bankbox.");
            }
        }
    }
}