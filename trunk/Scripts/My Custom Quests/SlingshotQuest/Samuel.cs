using System; 
using Server; 
using System.Collections;
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Mobiles
{
    [CorpseName("Samuel's corpse")]
    public class Samuel : Mobile
    {
        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public Samuel()
        {
            InitStats(100, 100, 100);
            Name = "Samuel";
            CantWalk = true;
            Body = 0x190;
            Hue = 0x83F8;
            Blessed = true;

            AddItem(new ShortPants(32));
            AddItem(new Shoes(32));
            AddItem(new Shirt());
            AddItem(new FeatheredHat(32));

            HairItemID = 0x203B;
            HairHue = 1175;

        }

        public override void OnMovement(Mobile m, Point3D oldLocation)/////To Fix/////
        {

            if (m.Alive && m is PlayerMobile)
            {
                PlayerMobile pm = (PlayerMobile)m;


                if (InRange(pm, 2) && !InRange(oldLocation, 2))
                {

                    SlingShott sh = pm.Backpack.FindItemByType(typeof(SlingShott)) as SlingShott;
                    SlingShotMarker sm = pm.Backpack.FindItemByType(typeof(SlingShotMarker)) as SlingShotMarker;


                    if (sm == null)
                    {
                        if (!pm.HasGump(typeof(SamuelGump)))
                        {
                            pm.SendGump(new SamuelGump(pm));

                            return;
                        }
                    }
                    else if (sm != null && sh == null)
                    {
                        Say("You are not finished with this quest yet, please hurry!");

                        return;
                    }
                    else if (sh != null)
                    {
                        Say("Oh Good! You did it! Can you please hand me the slingshot?");

                          return;
                        }
                    }
                }
            }
        
        public Samuel(Serial serial)
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

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            Mobile m = from;
            PlayerMobile mobile = m as PlayerMobile;
            Item sm = mobile.Backpack.FindItemByType(typeof(SlingShotMarker));
           
            if (sm != null && mobile != null)
            {
               if (dropped is SlingShott)
                {
                    if (dropped.Amount != 1)
                    {
                        int amount = dropped.Amount;
                        this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have no need for that! My dad is gonna punish me for sure!.", mobile.NetState);
                        return false;
                    }
                    dropped.Delete();
                    sm.Delete();
                    if (Utility.Random(100) < 100)
                        switch (Utility.Random(1))
                        {
                            case 0: mobile.AddToBackpack(new SlingShot()); break;

                        }
                    mobile.SendGump(new SamuelFinishGump(mobile));
                    return true;
                }
                else if (dropped is SlingShot)
                {
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, 1054071, mobile.NetState);
                    return false;
                }
                else
                {
                    this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have no need for that! My dad is going to punish me for sure!", mobile.NetState);
                }
            }
            return false;
        }
    }
}


