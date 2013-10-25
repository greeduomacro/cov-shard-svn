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
    [CorpseName("the corpse Kristobal Cortez")]
    public class KristobalCortez : BaseCreature
    {
        public virtual bool IsInvulnerable { get { return true; } }
        [Constructable]
        public KristobalCortez()
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4)
        {


            InitStats(31, 41, 51);


            Name = "Kristobal Cortez";
            Title = "the Herbalist";
            Body = 0x190;
            Hue = 1040;

            HairItemID = 0x2048;
            HairHue = 2312;

            FacialHairItemID = 0x2040F;
            FacialHairHue = 2312;

            AddItem(new Server.Items.Boots(Utility.RandomNeutralHue()));
            AddItem(new Server.Items.LongPants(Utility.RandomRedHue()));
            AddItem(new Server.Items.FormalShirt(Utility.RandomNeutralHue()));

            Blessed = true;
            CantWalk = true;
        }

        public KristobalCortez(Serial serial) : base(serial) { }
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new KristobalCortezEntry(from, this));
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
        public class KristobalCortezEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;
            public KristobalCortezEntry(Mobile from, Mobile giver)
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


                    if (!mobile.HasGump(typeof(KristobalCortezGump)))
                    {
                        mobile.SendGump(new KristobalCortezGump(mobile));
                    }
                }
            }
        }

    }

}