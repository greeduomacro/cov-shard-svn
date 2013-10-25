
using System;
using Server;
using Server.ContextMenus;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Misc;
using System.Collections.Generic;
using Server.ACC.YS;

namespace Server.Mobiles
{

    public class TS2 : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public TS2()
        {
            Name = "Denton Merster The Ancient Dragon Keeper";
            Body = 0x190;
            Hue = 0x83F8;

            AddItem(new LongPants(1151));
            AddItem(new Boots(1));
            AddItem(new Shirt(1));
            AddItem(new FloppyHat(1151));

            HairItemID = 0x203B;
            HairHue = 1153;
            Blessed = true;

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new TS2Entry(from, this));
        }

        public TS2(Serial serial)
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

        public class TS2Entry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public TS2Entry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool PlayerTravelBookRecieved = Convert.ToBoolean(acct.GetTag("PlayerTravelBookRecieved"));
                {
                    if (PlayerTravelBookRecieved)
                    {
                        mobile.SendMessage("You have already done this quest.");
                    }
                    else
                    {

                        Item tt = mobile.Backpack.FindItemByType(typeof(TS2Marker));
                        if (tt != null)
                        {
                            Item ao = mobile.Backpack.FindItemByType(typeof(KealdiaGlobe));
                            Item ai = mobile.Backpack.FindItemByType(typeof(KrysanGlobe));
                            Item ae = mobile.Backpack.FindItemByType(typeof(MyxkionGlobe));
                            Item au = mobile.Backpack.FindItemByType(typeof(RivatachGlobe));
                            Item aw = mobile.Backpack.FindItemByType(typeof(VaectorGlobe));
                            Item ax = mobile.Backpack.FindItemByType(typeof(ValvakkaGlobe));
                            

                            if (ao == null || ao.Amount < 1 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1 || au == null || au.Amount < 1 || aw == null || aw.Amount < 1 || ax == null || ax.Amount < 1 )
                            {
                                mobile.SendMessage("You do not have all the required items");
                            }
                            else
                            {
                                mobile.SendGump(new TS2FinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(KealdiaGlobe), 1);
                                mobile.Backpack.ConsumeTotal(typeof(KrysanGlobe), 1);
                                mobile.Backpack.ConsumeTotal(typeof(MyxkionGlobe), 1);
                                mobile.Backpack.ConsumeTotal(typeof(RivatachGlobe), 1);
                                mobile.Backpack.ConsumeTotal(typeof(VaectorGlobe), 1);
                                mobile.Backpack.ConsumeTotal(typeof(ValvakkaGlobe), 1);
                                tt.Delete();
                                acct.SetTag("PlayerTravelBook", "true");
                                mobile.AddToBackpack(new PlayerTravelBook());
                                
                            }
                        }
                        else
                        {
                            mobile.SendGump(new TS2Gump(mobile));

                        }
                    }
                }
            }
        }
    }
}
