
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
    [CorpseName("Janx's corpse")]
    public class JanxTheDrunkenBlacksmith : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public JanxTheDrunkenBlacksmith()
        {
            Name = "Janx the drunken Blacksmith";
            Body = 400;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            Utility.AssignRandomHair(this);
            AddItem(new Server.Items.Sandals(GetSandalsHue()));
            AddItem(new Shirt(3));
            AddItem(new LongPants(3));
            Blessed = true;
        }

        public virtual int GetSandalsHue()
        {

            return 1;
        }

        public JanxTheDrunkenBlacksmith(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new JanxTheDrunkenBlacksmithEntry(from, this));
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

        public class JanxTheDrunkenBlacksmithEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public JanxTheDrunkenBlacksmithEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item am = mobile.Backpack.FindItemByType(typeof(JanxMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(LightningKryssP));
                        Item ai = mobile.Backpack.FindItemByType(typeof(BrightTridentP));
                        Item ae = mobile.Backpack.FindItemByType(typeof(ThunderDaggerP));


                        if (ao == null || ao.Amount < 1 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1)
                        { 
                           mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendMessage("You have returned all my items, well Done! Here is your reward");
                            mobile.Backpack.ConsumeTotal(typeof(LightningKryssP), 1);
                            mobile.Backpack.ConsumeTotal(typeof(BrightTridentP), 1);
                            mobile.Backpack.ConsumeTotal(typeof(ThunderDaggerP), 1);
                           
                            am.Delete();

                            switch (Utility.Random(3))
                            {
                                case 0: mobile.AddToBackpack(new LightningKryss()); break;
                                case 1: mobile.AddToBackpack(new BrightTrident()); break;
                                case 2: mobile.AddToBackpack(new ThunderDagger()); break;
                                
                            }
                        }
                    }

                    else
                    {
                        mobile.SendGump(new JanxTheDrunkenBlacksmithGump(mobile));

                    }


                }
            }
        }
    }

}
