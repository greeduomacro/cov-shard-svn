
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
    [CorpseName("Dorothy's corpse")]
    public class Dorothy : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Dorothy()
        {
            Name = "Dorothy";
            Body = 401;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
    
            AddItem(new PlainDress(1366));
            AddItem(new HalfApron(1150));
            //AddItem(new LongHair());
            //hairHue = 1526;
            Blessed = true;
        }

        public Dorothy(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new DorothyEntry(from, this));
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

        public class DorothyEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public DorothyEntry(Mobile from, Mobile giver)
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
                        mobile.SendMessage("You don't have all the items we need yet!");
                    }
                    else
                    {
                        mobile.SendGump(new DorothyGump(mobile));
                    }


                }
            }
        }
    }
}
        
    


