using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Accounting;
using System.Collections.Generic;

namespace Server.Mobiles
{
    [CorpseName("Polka's corpse")]
    public class Polka : Mobile
    {
        //public virtual bool IsInvulnerable{ get{ return true; } }

        [Constructable]
        public Polka()
        {
            Name = "Polka";
            Body = 0x191;
            CantWalk = true;
            Hue = 0x3ea;

            Blessed = true;

            HairItemID = 0x203C;
            HairHue = 2213;

            FancyDress body = new FancyDress();
            body.Hue = 1643;
            AddItem(body);

            Sandals feet = new Sandals();
            feet.Hue = 1150;
            AddItem(feet);


        }

        public Polka(Serial serial)
            : base(serial)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new PolkaEntry(from, this));
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

        public class PolkaEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public PolkaEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                if (!(m_Mobile is PlayerMobile))
                    return;

                PlayerMobile mobile = (PlayerMobile)m_Mobile;

                {
                    if (!mobile.HasGump(typeof(PolkaGump)))
                    {
                        mobile.SendGump(new PolkaGump(mobile));

                    }
                }
            }
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            Mobile m = from;
            PlayerMobile mobile = m as PlayerMobile;
               
            if (mobile != null)
            {
                if (dropped is RawFloralPowder)
                {
                    if (dropped.Amount != 1)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Collect all the flowers silly!", mobile.NetState);
                        return false;
                    }
                        dropped.Delete();
                    
                        switch (Utility.Random(10))
                        {
                            case 0: mobile.AddToBackpack(new AG_windowboxeast1AddonDeed()); break;
                            case 1: mobile.AddToBackpack(new AG_windowboxeast2AddonDeed()); break;
                            case 2: mobile.AddToBackpack(new AG_windowboxeast3AddonDeed()); break;
                            case 3: mobile.AddToBackpack(new AG_windowboxeast4AddonDeed()); break;
                            case 4: mobile.AddToBackpack(new AG_windowboxeast5AddonDeed()); break;
                            case 5: mobile.AddToBackpack(new AG_windowboxsouth1AddonDeed()); break;
                            case 6: mobile.AddToBackpack(new AG_windowboxsouth2AddonDeed()); break;
                            case 7: mobile.AddToBackpack(new AG_5x3lilyplanterAddonDeed()); break;
                            case 8: mobile.AddToBackpack(new AG_PlanterEastAddonDeed()); break;
                            case 9: mobile.AddToBackpack(new AG_PlanterSouthAddonDeed()); break;

                             mobile.SendMessage("Thank you for your help!");
                             return true;
                        }
                    }
                    else
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Why on earth would I want to have that?", mobile.NetState);
                    }
                }
                return false;
            }
        }
    }


