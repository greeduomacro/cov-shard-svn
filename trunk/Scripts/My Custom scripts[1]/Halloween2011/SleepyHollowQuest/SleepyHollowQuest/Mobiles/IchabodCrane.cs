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
    [CorpseName("Ichabod Crane's Corpse")]
    public class IchabodCrane : BaseCreature
    {

        public virtual bool IsInvulnerable { get { return true; } }
        [Constructable]
        public IchabodCrane()
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4)
        {


            InitStats(31, 41, 51);


            Name = "Ichabod Crane";
            Body = 0x190;
            Hue = 1002;




            AddItem(new Server.Items.FancyShirt());
            AddItem(new Server.Items.LongPants());
            AddItem(new Server.Items.Boots());
            int hairHue = 1865;

            Utility.AssignRandomHair(this);

            Blessed = true;


            Container pack = new Backpack();
            pack.DropItem(new Gold(250, 300));
            pack.Movable = false;
            AddItem(pack);
        }

        public IchabodCrane(Serial serial)
            : base(serial)
        {
        }
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new IchabodCraneEntry(from, this));
        }
        public override void Serialize(GenericWriter writer)
        { 
            base.Serialize(writer); writer.Write((int)0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader); int version = reader.ReadInt();
        }
        public class IchabodCraneEntry : ContextMenuEntry
        {
            private Mobile m_Mobile; private Mobile m_Giver;
            public IchabodCraneEntry(Mobile from, Mobile giver) : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }
            public override void OnClick()
            {
                if (!(m_Mobile is PlayerMobile)) return;
                PlayerMobile mobile = (PlayerMobile)m_Mobile;
                {


                    if (!mobile.HasGump(typeof(IchabodCraneGump)))
                    {
                        mobile.SendGump(new IchabodCraneGump(mobile));
                    }
                }
            }
        }
        public override bool OnDragDrop(Mobile from, Item dropped)

{              
            Mobile m = from;PlayerMobile mobile = m as PlayerMobile;
            if ( mobile != null){


if( dropped is HeadlessHorsemanArm )
{
    if(dropped.Amount!=1)
{
        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "That isnt his arm!!", mobile.NetState );return false;
    }

dropped.Delete();



mobile.AddToBackpack( new Gold( 2000 ) );
mobile.AddToBackpack( new CauldronSouthAddonDeed( ) );


this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Thankyou for saving me from that awful creature!", mobile.NetState );


            return true;
        }
        {
            this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have no need for this...", mobile.NetState); return true;
        }


    }

    return false;
   }
  }
 }

