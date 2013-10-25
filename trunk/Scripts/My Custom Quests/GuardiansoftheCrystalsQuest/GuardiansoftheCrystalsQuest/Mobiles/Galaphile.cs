
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
    [CorpseName("Galaphile's corpse")]
    public class Galaphile : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Galaphile()
        {
            Name = "Galaphile";
            Female = false;
			Race = Race.Elf;
            CantWalk = true;
            Hue = 0x8383;
			HairItemID = 0x2FBF;
			HairHue = 1267;		
            Blessed = true;
        
           
			AddItem( new ElvenBoots( 0x1BB ) );
			AddItem( new MaleElvenRobe( 0x47E ) );
			AddItem( new WildStaff() );
		}

        public Galaphile(Serial serial) : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new GalaphileEntry(from, this));
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

        public class GalaphileEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public GalaphileEntry(Mobile from, Mobile giver) : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item am = mobile.Backpack.FindItemByType(typeof(GalaphileMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(BlightCrystallineFragments));
                        Item ai = mobile.Backpack.FindItemByType(typeof(BrownCrystallineFragments));
                        Item ae = mobile.Backpack.FindItemByType(typeof(BlueCrystallineFragments));
                        Item au = mobile.Backpack.FindItemByType(typeof(MirageCrystallineFragments));
                        Item aw = mobile.Backpack.FindItemByType(typeof(PurpleCrystallineFragments));
                        Item ax = mobile.Backpack.FindItemByType(typeof(PyroclasticCrystallineFragments));

                        if (ao == null || ao.Amount < 1 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1 || au == null || au.Amount < 1 || aw == null || aw.Amount < 1 || ax == null || ax.Amount < 1)
                        { 
                           mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendGump(new GalaphileGump2(mobile));
                            mobile.Backpack.ConsumeTotal(typeof(BlightCrystallineFragments), 1);
                            mobile.Backpack.ConsumeTotal(typeof(BrownCrystallineFragments), 1);
                            mobile.Backpack.ConsumeTotal(typeof(BlueCrystallineFragments), 1);
                            mobile.Backpack.ConsumeTotal(typeof(MirageCrystallineFragments), 1);
                            mobile.Backpack.ConsumeTotal(typeof(PurpleCrystallineFragments), 1);
                            mobile.Backpack.ConsumeTotal(typeof(PyroclasticCrystallineFragments), 1);
                         
                            am.Delete();

                            switch (Utility.Random(6))
                            {
                                case 0: mobile.AddToBackpack(new COVArmorBag1()); break;
                                case 1: mobile.AddToBackpack(new COVArmorBag2()); break;
                                case 2: mobile.AddToBackpack(new ScoutArmorBag1()); break;
                                case 3: mobile.AddToBackpack(new ScoutArmorBag2()); break;
                                case 4: mobile.AddToBackpack(new SorcerersArmorBag1()); break;
                                case 5: mobile.AddToBackpack(new SorcerersArmorBag2()); break;
                                
                            }
                        }
                    }
                    else
                    {
                        mobile.SendGump(new GalaphileGump(mobile));

                    }
                }
            }
        }
    }
}
