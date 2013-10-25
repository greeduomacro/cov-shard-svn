/* Created by Hammerhand*/

using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("Donovan MacKennzie's Corpse")]
    public class DonovanMacKennzie : BaseCreature
    {
        public virtual bool IsInvulnerable { get { return true; } }
        [Constructable]
        public DonovanMacKennzie()
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4)
        {


            InitStats(31, 41, 51);


            Name = "Donovan MacKennzie";
            Title = "the Historian";
            Body = 0x190;
            Hue = 1002;

            HairItemID = 0x203B;
            HairHue = 44;

            FacialHairItemID = 0x203F;
            FacialHairHue = 44;

            AddItem(new Server.Items.Boots(Utility.RandomNeutralHue()));
            AddItem(new Server.Items.LongPants(Utility.RandomBlueHue()));
            AddItem(new Server.Items.FormalShirt(Utility.RandomNeutralHue()));

            Blessed = true;
            CantWalk = true;
        }

        public DonovanMacKennzie(Serial serial) : base(serial) { }
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new DonovanMacKennzieEntry(from, this));
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
        public class DonovanMacKennzieEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;
            public DonovanMacKennzieEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }
            public override void OnClick()
            {
                if (!(m_Mobile is PlayerMobile)
)
                    return;
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {


                    if (!mobile.HasGump(typeof(DonovanMacKennzieGump)))
                    {
                        mobile.SendGump(new DonovanMacKennzieGump(mobile));
                    }
                }
            }
        }

    }

}