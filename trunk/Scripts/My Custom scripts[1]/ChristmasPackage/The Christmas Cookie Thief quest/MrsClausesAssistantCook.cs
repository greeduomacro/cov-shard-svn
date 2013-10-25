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

namespace Server.Mobiles
{

    public class MrsClausesAssistantCook : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public MrsClausesAssistantCook()
        {
            Name = "Lorin-the assistant cook";
            Body = 0x190;
            Hue = 0x83F8;

            AddItem(new LongPants(267));
            AddItem(new Boots(1));
            AddItem(new Shirt(33));
            AddItem(new Bonnet(1153));

            HairItemID = 0x203B;
            HairHue = 267;
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new MrsClausesAssistantCookEntry(from, this));
        }

        public MrsClausesAssistantCook(Serial serial)
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

        public class MrsClausesAssistantCookEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public MrsClausesAssistantCookEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool ApronRecieved = Convert.ToBoolean(acct.GetTag("ApronRecieved"));
                {
                    if (ApronRecieved)
                    {
                        mobile.SendMessage("You have already done this quest.");
                    }
                    else
                    {
                        Item cm = mobile.Backpack.FindItemByType(typeof(CookMarker));
                        if (cm != null)
                        {
                            Item af = mobile.Backpack.FindItemByType(typeof(AbominableSnowmansFur));

                            if (af == null || af.Amount < 1)
                            {
                                mobile.SendMessage("You do not have all the required items");
                            }
                            else
                            {
                                mobile.SendGump(new MCACFinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(AbominableSnowmansFur), 1);
                                cm.Delete();
                                acct.SetTag("ApronRecieved", "true");
                                mobile.AddToBackpack(new MrsClausesApron());

                            }
                        }
                        else
                        {
                            mobile.SendGump(new MCACGump(mobile));

                        }
                    }
                }
            }
        }
    }
}
