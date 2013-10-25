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
    [CorpseName("Father Time's Corpse")]
    public class FatherTime : BaseCreature
    {
        public virtual bool IsInvulnerable { get { return true; } }
        [Constructable]
        public FatherTime()
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4)
        {


            InitStats(31, 41, 51);


            Name = "Father Time";
            Title = "The Keeper of the Ages";
            Body = 0x190;
            Hue = 1002;

            HairItemID = 0x203C;
            HairHue = 2101;

            FacialHairItemID = 0x203E;
            FacialHairHue = 2101;

            AddItem(new Server.Items.SandalsOfTimeWalking());
            AddItem(new Server.Items.StaffOfTime());
            AddItem(new Server.Items.RobeOfTheEons());

            Blessed = true;
            CantWalk = true;
        }

        public FatherTime(Serial serial) : base(serial) { }
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new FatherTimeEntry(from, this));
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
        public class FatherTimeEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;
            public FatherTimeEntry(Mobile from, Mobile giver)
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


                    if (!mobile.HasGump(typeof(FatherTimeGump)))
                    {
                        mobile.SendGump(new FatherTimeGump(mobile));
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
                if (dropped is BabyTime)
                {
                    if (dropped.Amount != 1)
                    {
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "No, that's not it...", mobile.NetState);
                        return false;
                    }

                    dropped.Delete();
                    mobile.AddToBackpack(new QuestBag());
                    mobile.AddToBackpack(new Gold(2500));
                    mobile.SendGump(new FatherTimeFinishGump());



                    return true;
                }
                else if (dropped is Whip)
                {
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, 1054071, mobile.NetState);
                    return false;
                }
                else
                {
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have no need of this!", mobile.NetState);
                }
            }
            return false;
        }
    }

}