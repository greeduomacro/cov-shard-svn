
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

    public class NoseyKalei : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public NoseyKalei()
        {
            Name = "Nosey Kalei--A concerned citizen";
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
            list.Add(new NoseyKaleiEntry(from, this));
        }

        public NoseyKalei(Serial serial)
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

        public class NoseyKaleiEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public NoseyKaleiEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool EasterApronRecieved = Convert.ToBoolean(acct.GetTag("EasterApron"));
                {
                    if (EasterApronRecieved)
                    {
                        mobile.SendMessage("You have already done this quest.");
                    }
                    else
                    {

                        Item tt = mobile.Backpack.FindItemByType(typeof(EasterGoalMarker));
                        if (tt != null)
                        {

                            Item ao = mobile.Backpack.FindItemByType(typeof(BunnyKey));
                           
                            if (ao == null || ao.Amount < 1 )
                            {
                                mobile.SendMessage("You do not have all the required items");
                            }
                            else
                            {
                                mobile.SendGump(new NoseyKaleiFinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(BunnyKey), 1);
                                tt.Delete();

                                acct.SetTag("EasterApron", "true");
                                mobile.AddToBackpack(new EasterApron());

                            }
                        }
                        else
                        {
                            mobile.SendGump(new NoseyKaleiGump(mobile));

                        }
                    }
                }
            }
        }
    }
}
