
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

    public class Wakita : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Wakita()
        {
            Name = "Wakita the housing broker";
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
            list.Add(new WakitaEntry(from, this));
        }

        public Wakita(Serial serial)
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

        public class WakitaEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public WakitaEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool NewCharRewardBag = Convert.ToBoolean(acct.GetTag("NewCharRewardBag"));
                {
                    if (NewCharRewardBag)
                    {
                        mobile.SendMessage("You have already done this quest. Only once per account is allowed.");
                    }
                    else
                    {

                        Item tt = mobile.Backpack.FindItemByType(typeof(WakitaMarker));
                        if (tt != null)
                        {
                            Item ao = mobile.Backpack.FindItemByType(typeof(Board));
                            //Item ai = mobile.Backpack.FindItemByType(typeof(KrysanGlobe));
                            //Item ae = mobile.Backpack.FindItemByType(typeof(MyxkionGlobe));
                            //Item au = mobile.Backpack.FindItemByType(typeof(RivatachGlobe));
                            //Item aw = mobile.Backpack.FindItemByType(typeof(VaectorGlobe));
                            //Item ax = mobile.Backpack.FindItemByType(typeof(ValvakkaGlobe));
                            

                            if (ao == null || ao.Amount < 100 )//|| ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1 || au == null || au.Amount < 1 || aw == null || aw.Amount < 1 || ax == null || ax.Amount < 1 )
                            {
                                mobile.SendMessage("Is there a problem? I see you don't have enough boards yet!");
                            }
                            else
                            {
                                mobile.SendGump(new WakitaFinishGump(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(Board), 100);
                                //mobile.Backpack.ConsumeTotal(typeof(KrysanGlobe), 1);
                                //mobile.Backpack.ConsumeTotal(typeof(MyxkionGlobe), 1);
                                //mobile.Backpack.ConsumeTotal(typeof(RivatachGlobe), 1);
                                //mobile.Backpack.ConsumeTotal(typeof(VaectorGlobe), 1);
                                //mobile.Backpack.ConsumeTotal(typeof(ValvakkaGlobe), 1);
                                tt.Delete();
                                acct.SetTag("NewCharRewardBag", "true");
                                mobile.AddToBackpack(new NewCharRewardBag());
                                
                            }
                        }
                        else
                        {
                            mobile.SendGump(new WakitaGump(mobile));

                        }
                    }
                }
            }
        }
    }
}
