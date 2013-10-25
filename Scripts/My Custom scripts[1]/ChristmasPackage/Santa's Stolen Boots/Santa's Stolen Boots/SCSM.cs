
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

    public class SantaClauseShoeMaker : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public SantaClauseShoeMaker()
        {
            Name = "Larry the elven shoemaker";
            Body = 0x190;
            Hue = 0x83F8;

            AddItem(new LongPants(1153));
            AddItem(new Boots(1));
            AddItem(new Shirt(33));
            AddItem(new Bonnet(1153));

            HairItemID = 0x203B;
            HairHue = 267;
            Blessed = true;

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new SantaClauseShoemakerEntry(from, this));
        }

        public SantaClauseShoeMaker(Serial serial)
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

        public class SantaClauseShoemakerEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public SantaClauseShoemakerEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool SantaBootsRecieved = Convert.ToBoolean(acct.GetTag("SantaBootsRecieved"));
                {
                    if (SantaBootsRecieved)
                    {
                        mobile.SendMessage("You have already done this quest.");
                    }
                    else
                    {

                        Item sc = mobile.Backpack.FindItemByType(typeof(SCMMarker));
                        if (sc != null)
                        {
                            Item ao = mobile.Backpack.FindItemByType(typeof(SCFBL));


                            if (ao == null || ao.Amount < 1)
                            {
                                mobile.SendMessage("You do not have all the required items");
                            }
                            else
                            {
                                mobile.SendGump(new SCSMFinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(SCFBL), 1);
                                sc.Delete();
                                acct.SetTag("SantaBootsRecieved", "true");
                                mobile.AddToBackpack(new SCFB());
                            }
                        }
                        else
                        {
                            mobile.SendGump(new SCSMGump(mobile));

                        }
                    }
                }
            }
        }
    }
}
