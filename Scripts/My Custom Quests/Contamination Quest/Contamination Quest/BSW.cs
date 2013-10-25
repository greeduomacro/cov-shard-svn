
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

    public class BSW : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public BSW()
        {
            Name = "A Britian Sewer Worker";
            Body = 0x190;
            Hue = 0x83F8;

            AddItem(new LongPants(1152));
            AddItem(new Boots(1));
            AddItem(new Shirt(1));
            AddItem(new FloppyHat(1152));

            HairItemID = 0x203B;
            HairHue = 2;
            Blessed = true;

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new BSWEntry(from, this));
        }

        public BSW(Serial serial)
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

        public class BSWEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public BSWEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item cc = mobile.Backpack.FindItemByType(typeof(CMarker));
                    if (cc != null)
                    {
                        Item aa = mobile.Backpack.FindItemByType(typeof(LilyPad1));
                        Item ab = mobile.Backpack.FindItemByType(typeof(LilyPad2));
                        Item ac = mobile.Backpack.FindItemByType(typeof(LilyPad3));
                        Item ad = mobile.Backpack.FindItemByType(typeof(LilyPad4));

                        if (aa == null || aa.Amount < 1 || ab == null || aa.Amount < 1 || ac == null || ac.Amount < 1 || ad == null || ad.Amount < 1 )
                        {
                            mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendGump(new BSWFGump(mobile));
                            mobile.Backpack.ConsumeTotal(typeof(LilyPad1), 1);
                            mobile.Backpack.ConsumeTotal(typeof(LilyPad2), 1);
                            mobile.Backpack.ConsumeTotal(typeof(LilyPad3), 1);
                            mobile.Backpack.ConsumeTotal(typeof(LilyPad4), 1);
                            cc.Delete();

                            switch (Utility.Random(6))
                            {
                                case 0: mobile.AddToBackpack(new BlackWellAddonDeed()); break;
                                case 1: mobile.AddToBackpack(new BrownWellAddonDeed()); break;
                                case 2: mobile.AddToBackpack(new MarbleWellAddonDeed()); break;
                                case 3: mobile.AddToBackpack(new RedWellAddonDeed()); break;
                                case 4: mobile.AddToBackpack(new StoneWellAddonDeed()); break;
                                case 5: mobile.AddToBackpack(new WoodWellAddonDeed()); break;
                            }
                        }
                    }
                    else
                    {
                        mobile.SendGump(new BSWGump(mobile));
                    }
                }
            }
        }
    }
}
            


                        
                    
                
            
        
    

