
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

    public class Ranni1 : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Ranni1()
        {
            Name = "Ranni the novice mage";
            Body = 0x190;
            Hue = 0x83F8;

            AddItem(new LongPants(1151));
            AddItem(new Boots(1));
            AddItem(new Shirt(1));

            Female = false;
            CantWalk = true;
            Race = Race.Human;

            HairItemID = 0x203C;
            HairHue = 0x6B1;

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new Ranni1Entry(from, this));
        }

        public Ranni1(Serial serial)
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

        public class Ranni1Entry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public Ranni1Entry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool NewCharMagicBag = Convert.ToBoolean(acct.GetTag("NewCharMagicBag"));
                {
                    if (NewCharMagicBag)
                    {
                        mobile.SendMessage("You have already done this quest. Only once per account is allowed.");
                    }
                    else
                    {

                        Item tt = mobile.Backpack.FindItemByType(typeof(Ranni1Marker));
                        if (tt != null)
                        {
                            Item ao = mobile.Backpack.FindItemByType(typeof(SpidersSilk));
                            Item ai = mobile.Backpack.FindItemByType(typeof(Nightshade));
                            Item ae = mobile.Backpack.FindItemByType(typeof(Ginseng));
                            Item au = mobile.Backpack.FindItemByType(typeof(BlackPearl));
                            //Item aw = mobile.Backpack.FindItemByType(typeof(VaectorGlobe));
                            //Item ax = mobile.Backpack.FindItemByType(typeof(ValvakkaGlobe));
                            

                            if (ao == null || ao.Amount < 20 || ai == null || ai.Amount < 20 || ae == null || ae.Amount < 20 || au == null || au.Amount < 20 )// || aw == null || aw.Amount < 1 || ax == null || ax.Amount < 1 )
                            {
                                mobile.SendMessage("Is there a problem? I see you don't have enough regents yet!");
                            }
                            else
                            {
                                mobile.SendGump(new Ranni1FinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(SpidersSilk), 20);
                                mobile.Backpack.ConsumeTotal(typeof(Nightshade), 20);
                                mobile.Backpack.ConsumeTotal(typeof(Ginseng), 20);
                                mobile.Backpack.ConsumeTotal(typeof(BlackPearl), 20);
                                tt.Delete();
                                acct.SetTag("NewCharMagicBag", "true");
                                mobile.AddToBackpack(new NewCharMagicBag());
                                
                            }
                        }
                        else
                        {
                            mobile.SendGump(new Ranni1Gump(mobile));

                        }
                    }
                }
            }
        }
    }
}
