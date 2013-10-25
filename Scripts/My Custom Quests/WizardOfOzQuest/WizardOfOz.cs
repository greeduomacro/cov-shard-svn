
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
    [CorpseName("a Wizard Of Oz corpse")]
    public class WizardOfOz : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public WizardOfOz()
        {
            Name = "The Wizard Of Oz";
            Body = 400;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            AddItem(new Server.Items.Sandals(1065));
            AddItem(new Robe(1065));
            AddItem(new WizardsHat(1065));
            //AddItem(new LongHair());
            Blessed = true;
        }

        public WizardOfOz
            (Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new WizardOfOzEntry(from, this));
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

        public class WizardOfOzEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public WizardOfOzEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item am = mobile.Backpack.FindItemByType(typeof(DorothyMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(ScarecrowBrain));
                        Item ai = mobile.Backpack.FindItemByType(typeof(LionsCourageMedallion));
                        Item ae = mobile.Backpack.FindItemByType(typeof(TinMansHeart));
                        Item au = mobile.Backpack.FindItemByType(typeof(RubyRedSlippers));

                        if (ao == null || ao.Amount < 1 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1 || au == null || au.Amount < 1 )
                        { 
                           mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendGump(new WizardOfOzGump(mobile));
                            mobile.Backpack.ConsumeTotal(typeof(ScarecrowBrain), 1);
                            mobile.Backpack.ConsumeTotal(typeof(LionsCourageMedallion), 1);
                            mobile.Backpack.ConsumeTotal(typeof(TinMansHeart), 1);
                            mobile.Backpack.ConsumeTotal(typeof(RubyRedSlippers), 1);
                            am.Delete();

                            switch (Utility.Random(1))
                            {
                                case 0: mobile.AddToBackpack(new WizardOfOzRewardBox()); break;

                            }
                        }
                    }

                    else
                    {
                        mobile.SendMessage("Why are you bothering me? Go speak to Dorothy first!");

                    }
                }
            }
        }
    }
}
