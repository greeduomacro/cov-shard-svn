
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
    [CorpseName("Athenas's corpse")]
    public class Athena : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Athena()
        {
            Name = "Athena";
            Body = 401;
            CantWalk = true;
            Female = true;
            //Direction = FacingSouth;
            Hue = Utility.RandomSkinHue();
            AddItem(new Server.Items.Sandals(GetSandalsHue()));
            AddItem(new Robe(30)); 
            AddItem(new LongHair(1153));

            Blessed = true;

        }

        public virtual int GetSandalsHue()
        {

            return 30;
        }

        public Athena(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new AthenaEntry(from, this));
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

        public class AthenaEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public AthenaEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                Account acct = (Account)mobile.Account;
                bool SirenSashRecieved = Convert.ToBoolean(acct.GetTag("SirenSashRecieved"));

                 if (SirenSashRecieved)
                    {
                        mobile.SendMessage("You have already done this quest.");
                    }
                    else
                    {
                               
                    Item am = mobile.Backpack.FindItemByType(typeof(BloodyHeartMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(BloodyHeart));


                        if (ao == null || ao.Amount < 30)
                        {
                            mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendGump(new AthenaGump2(mobile));
                            mobile.Backpack.ConsumeTotal(typeof(BloodyHeart), 30);

                            am.Delete();
                            acct.SetTag("SirenSashRecieved", "true");
                            mobile.AddToBackpack(new SirenInvasionSash());

                        }

                    }
                    else
                    {
                        mobile.SendGump(new AthenaGump(mobile));

                    }
                }
            }
        }
    }
}

