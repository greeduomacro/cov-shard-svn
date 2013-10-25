
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
    [CorpseName("Rotten Tooth Willy corpse")]
    public class RTW : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public RTW()
        {
            Name = "Rotten Tooth Willy";
            Body = 400;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            AddItem(new Server.Items.Sandals(GetSandalsHue()));
            AddItem(new LongPants(1));
            AddItem(new StrawHat(56));
            int hairHue = 37;
            Blessed = true;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new LongHair(hairHue)); break;
            }
        }

        public virtual int GetSandalsHue()
        {

            return 1149;
        }

        public RTW(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new RTWEntry(from, this));
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

        public class RTWEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public RTWEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item am = mobile.Backpack.FindItemByType(typeof(RTWMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(AlligatorHide));
                       
                        if (ao == null || ao.Amount < 1 )
                        { 
                           mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendGump(new RTWGump2(mobile));
                            mobile.Backpack.ConsumeTotal(typeof(AlligatorHide), 1);
                            
                            am.Delete();

                            switch (Utility.Random(4))
                            {
                                case 0: mobile.AddToBackpack(new AlligatorBelt()); break;
                                case 1: mobile.AddToBackpack(new AlligatorBoots()); break;
                                case 2: mobile.AddToBackpack(new AlligatorHideHat()); break;
                                case 3: mobile.AddToBackpack(new AlligatorHideQuiver()); break;
                               
                            }
                        }
                    }
                    else
                    {
                        mobile.SendGump(new RTWGump(mobile));

                    }
                }
            }
        }
    }
}
