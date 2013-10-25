
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
using Server.Engines.Plants;
using Server.Misc;
using System.Collections.Generic;
using Server.ACC.YS;

namespace Server.Mobiles
{

    public class Elendor1: Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Elendor1()
        {
            Name = "Elendor the financial planner";
            Body = 0x190;
            Hue = 0x83F8;

            AddItem(new LongPants(1151));
            AddItem(new Boots(1));
            AddItem(new Shirt(1));

            Female = true;
            CantWalk = true;
            Race = Race.Human;

            Hue = 0x83F3;			
			HairItemID = 0x2047;
			HairHue = 0x393;

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new Elendor1Entry(from, this));
        }

        public Elendor1(Serial serial)
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

        public class Elendor1Entry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public Elendor1Entry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool NewCharMoneyBag = Convert.ToBoolean(acct.GetTag("NewCharMoneyBag"));
                {
                    if (NewCharMoneyBag)
                    {
                        mobile.SendMessage("You have already done this quest. Only once per account is allowed.");
                    }
                    else
                    {

                        Item tt = mobile.Backpack.FindItemByType(typeof(Elendor1Marker));
                        if (tt != null)
                        {
                            Item ao = mobile.Backpack.FindItemByType(typeof(IronIngot));
                            Item ai = mobile.Backpack.FindItemByType(typeof(PlantBowl));
                            Item ae = mobile.Backpack.FindItemByType(typeof(BlankScroll));
                            //Item au = mobile.Backpack.FindItemByType(typeof(RivatachGlobe));
                            //Item aw = mobile.Backpack.FindItemByType(typeof(VaectorGlobe));
                            //Item ax = mobile.Backpack.FindItemByType(typeof(ValvakkaGlobe));
                            

                            if (ao == null || ao.Amount < 40 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 10 )// || au == null || au.Amount < 1 || aw == null || aw.Amount < 1 || ax == null || ax.Amount < 1 )
                            {
                                mobile.SendMessage("Is there a problem? I see you don't have all the things I asked for yet!");
                            }
                            else
                            {
                                mobile.SendGump(new Elendor1FinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(IronIngot), 40);
                                mobile.Backpack.ConsumeTotal(typeof(PlantBowl), 1);
                                mobile.Backpack.ConsumeTotal(typeof(BlankScroll), 10);
                                //mobile.Backpack.ConsumeTotal(typeof(RivatachGlobe), 1);
                                //mobile.Backpack.ConsumeTotal(typeof(VaectorGlobe), 1);
                                //mobile.Backpack.ConsumeTotal(typeof(ValvakkaGlobe), 1);
                                tt.Delete();
                                acct.SetTag("NewCharMoneyBag", "true");
                                mobile.AddToBackpack(new NewCharMoneyBag());
                                
                            }
                        }
                        else
                        {
                            mobile.SendGump(new Elendor1Gump(mobile));

                        }
                    }
                }
            }
        }
    }
}
