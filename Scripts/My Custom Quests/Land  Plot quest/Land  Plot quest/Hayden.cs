
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
    [CorpseName("Hayden's corpse")]
    public class Hayden : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Hayden()
        {
            Name = "Hayden";
            Body = 400;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            Utility.AssignRandomHair(this);
            AddItem(new Server.Items.Sandals(GetSandalsHue()));
            AddItem(new Shirt(5));
            AddItem(new LongPants(5));
            Blessed = true;
        }

        public virtual int GetSandalsHue()
        {

            return 1;
        }

        public Hayden(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new HaydenEntry(from, this));
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

        public class HaydenEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public HaydenEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item am = mobile.Backpack.FindItemByType(typeof(HaydenMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(EternalFire));
                        Item ai = mobile.Backpack.FindItemByType(typeof(Dirt));
                        Item ae = mobile.Backpack.FindItemByType(typeof(YourMind));
                        Item au = mobile.Backpack.FindItemByType(typeof(ClueBook));


                        if (ao == null || ao.Amount < 1 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1 || au == null || au.Amount < 1 )
                        { 
                           mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.Backpack.ConsumeTotal(typeof(EternalFire), 1);
                            mobile.Backpack.ConsumeTotal(typeof(Dirt), 1);
                            mobile.Backpack.ConsumeTotal(typeof(YourMind), 1);
                           
                            am.Delete();
                            au.Delete();
                            mobile.SendGump(new HaydenFinishGump());

                            switch (Utility.Random(5))
                            {
                                case 0: mobile.AddToBackpack(new AG_1x1_plotAddonDeed()); break;
                                case 1: mobile.AddToBackpack(new AG_5x8plotAddonDeed()); break;
                                case 2: mobile.AddToBackpack(new AG_6x6plotAddonDeed()); break;
                                case 3: mobile.AddToBackpack(new AG_10x8plotAddonDeed()); break;
                                case 4: mobile.AddToBackpack(new AG_plot17x17AddonDeed()); break;
                                
                            }
                        }
                    }

                    else
                    {
                        mobile.SendGump(new HaydenGump(mobile));

                    }


                }
            }
        }
    }

}
