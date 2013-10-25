
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
    [CorpseName("telendra's corpse")]
    public class Telendra : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Telendra()
        {
            Name = "Telendra";
            Body = 401;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            AddItem(new Server.Items.Sandals(GetSandalsHue()));
            AddItem(new WizardsHat(1));
            AddItem(new Robe(1));
            int hairHue = 771;
            Blessed = true;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
        }

        public virtual int GetSandalsHue()
        {
            return 1;
        }

        public Telendra(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new TelendraEntry(from, this));
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

        public class TelendraEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public TelendraEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item av = mobile.Backpack.FindItemByType(typeof(RecluseStingMarker));
                    Item az = mobile.Backpack.FindItemByType(typeof(RecluseStingAntidotePotion));

                   // if (mobile == null)
                   // {
                       // return;
                   // }

                    if (mobile.BodyMod != 155 && av == null && az != null)
                    {
                        mobile.SendGump(new RecluseCuredGump2());
                        az.Delete();
                    }
                    else
                    {

                        Item aa = mobile.Backpack.FindItemByType(typeof(TelendraMarker));
                        if (aa != null)
                        {
                            Item ao = mobile.Backpack.FindItemByType(typeof(BacterialMud));
                            Item ai = mobile.Backpack.FindItemByType(typeof(DragonFlesh));
                            Item ae = mobile.Backpack.FindItemByType(typeof(SerpentEggs));
                            Item au = mobile.Backpack.FindItemByType(typeof(DriedFlower));
                            Item aw = mobile.Backpack.FindItemByType(typeof(HerbalWater));

                            if (ao == null || ao.Amount < 5 || ai == null || ai.Amount < 3 || ae == null || ae.Amount < 5 || au == null || au.Amount < 3 || aw == null || aw.Amount < 6)
                            {
                                mobile.SendMessage("You do not have all the required ingredients. You better hurry!");
                            }
                            else
                            {
                                mobile.SendGump(new TelendraGump2(mobile));
                                mobile.Backpack.ConsumeTotal(typeof(BacterialMud), 5);
                                mobile.Backpack.ConsumeTotal(typeof(DragonFlesh), 3);
                                mobile.Backpack.ConsumeTotal(typeof(SerpentEggs), 5);
                                mobile.Backpack.ConsumeTotal(typeof(DriedFlower), 3);
                                mobile.Backpack.ConsumeTotal(typeof(HerbalWater), 6);

                                aa.Delete();

                                mobile.AddToBackpack(new RecluseStingAntidotePotion());
                            }
                        }
                        else
                        {
                            Item ab = mobile.Backpack.FindItemByType(typeof(TelendraMarker2));
                            if (ab != null)
                            {
                                Item ac = mobile.Backpack.FindItemByType(typeof(EvilTannisHead));

                                if (ac == null || ac.Amount < 1)
                                {
                                    mobile.SendMessage("You didn't kill him! No reward for you!");
                                }
                                else
                                {
                                    mobile.SendGump(new TelendraFinishGump()); 
                                    mobile.Backpack.ConsumeTotal(typeof(EvilTannisHead), 1);

                                    ab.Delete();
                                    av.Delete();

                                    mobile.AddToBackpack(new HeritageToken());
                                }
                            }
                            else if (av != null && az == null)
                            {
                                    mobile.SendGump(new TelendraGump(mobile));
                                }
                            else
                            {
                                mobile.SendMessage("I have no business with you!");
                            }
                        }
                    }
                }
            }
        }
    }
}
    
