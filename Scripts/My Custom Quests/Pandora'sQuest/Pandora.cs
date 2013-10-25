
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
    [CorpseName("pandora's corpse")]
    public class Pandora : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Pandora()
        {
            Name = "Pandora";
            Body = 401;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            AddItem(new Server.Items.Sandals(GetSandalsHue()));
            AddItem(new Robe(34));
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

        public Pandora(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new PandoraEntry(from, this));
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

        public class PandoraEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public PandoraEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {
                    Item am = mobile.Backpack.FindItemByType(typeof(PandoraMarker));
                    if (am != null)
                    {
                        Item ao = mobile.Backpack.FindItemByType(typeof(PrideCrystal));
                        Item ai = mobile.Backpack.FindItemByType(typeof(GreedCrystal));
                        Item ae = mobile.Backpack.FindItemByType(typeof(LustCrystal));
                        Item au = mobile.Backpack.FindItemByType(typeof(EnvyCrystal));
                        Item aw = mobile.Backpack.FindItemByType(typeof(GluttonyCrystal));
                        Item ax = mobile.Backpack.FindItemByType(typeof(SlothCrystal));
                        Item av = mobile.Backpack.FindItemByType(typeof(WrathCrystal));


                        if (ao == null || ao.Amount < 1 || ai == null || ai.Amount < 1 || ae == null || ae.Amount < 1 || au == null || au.Amount < 1 || aw == null || aw.Amount < 1 || ax == null || ax.Amount < 1 || av == null || av.Amount < 1)
                        { 
                           mobile.SendMessage("You do not have all the required items");
                        }
                        else
                        {
                            mobile.SendGump(new PandoraGump2(mobile));
                            mobile.Backpack.ConsumeTotal(typeof(PrideCrystal), 1);
                            mobile.Backpack.ConsumeTotal(typeof(GreedCrystal), 1);
                            mobile.Backpack.ConsumeTotal(typeof(LustCrystal), 1);
                            mobile.Backpack.ConsumeTotal(typeof(EnvyCrystal), 1);
                            mobile.Backpack.ConsumeTotal(typeof(GluttonyCrystal), 1);
                            mobile.Backpack.ConsumeTotal(typeof(SlothCrystal), 1);
                            mobile.Backpack.ConsumeTotal(typeof(WrathCrystal), 1);
                            am.Delete();

                            switch (Utility.Random(10))
                            {
                                case 0: mobile.AddToBackpack(new BBQSouthAddonDeed()); break;
                                case 1: mobile.AddToBackpack(new SoulstoneFragmentToken()); break;
                                case 2: mobile.AddToBackpack(new AG_BloodAltarAddonDeed()); break;
                                case 3: mobile.AddToBackpack(new BankHiive()); break;
                                case 4: mobile.AddToBackpack(new AG_BloodSkeletonsAddonDeed()); break;
                                case 5: mobile.AddToBackpack(new ItemBlessDeed()); break;
                                case 6: mobile.AddToBackpack(new RidablePolarDeed()); break;
                                case 7: mobile.AddToBackpack(new HeritageToken()); break;
                                case 8: mobile.AddToBackpack(new CloakOfInvisibility()); break;
                                //case 9: mobile.AddToBackpack(new SerenityWallSouthAddonDeed()); break;
                                case 9: mobile.AddToBackpack(new BBQEastAddonDeed()); break;

                            }
                        }
                    }
                    else
                    {
                        mobile.SendGump(new PandoraGump(mobile));

                    }
                }
            }
        }
    }
}
