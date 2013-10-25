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
    [CorpseName("RachelMurphy's Corpse")]
    public class RachelMurphy : BaseCreature
    {
        public virtual bool IsInvulnerable { get { return true; } }
        [Constructable]
        public RachelMurphy()
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4)
        {


            InitStats(31, 41, 51);


            Name = "Rachel Murphy";
            Title = "the Botanist";
            Body = 0x191;
            Hue = 1002;

            HairItemID = 0x2049;
            HairHue = 2413;


            AddItem(new Server.Items.Shoes(Utility.RandomNeutralHue()));
            AddItem(new Server.Items.ShortPants(Utility.RandomRedHue()));
            AddItem(new Server.Items.Tunic(Utility.RandomNeutralHue()));

            Blessed = true;
            CantWalk = true;
        }

        public RachelMurphy(Serial serial) : base(serial) { }
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new RachelMurphyEntry(from, this));
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
        public class RachelMurphyEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;
            public RachelMurphyEntry(Mobile from, Mobile giver)
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


                    if (!mobile.HasGump(typeof(RachelMurphyGump)))
                    {
                        mobile.SendGump(new RachelMurphyGump(mobile));
                    }
                }
            }
        }

    }

}