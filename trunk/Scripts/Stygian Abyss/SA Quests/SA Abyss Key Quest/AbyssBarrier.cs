using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
    public class AbyssBarrier : Item
    {
      
        [Constructable]
        public AbyssBarrier() : base(0x49E)
        {
            Movable = false;
            Visible = false;
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (m.AccessLevel > AccessLevel.Player && m.Backpack != null)
                return true;
            {
                AbyssMarker am = m.Backpack.FindItemByType(typeof(AbyssMarker)) as AbyssMarker;

                if (am == null)
                {
                    m.SendLocalizedMessage(1112226);
                    return false;
                }
                else
                {
                    m.SendLocalizedMessage(1113708);
                    return true;
                }
            }
        }

        public AbyssBarrier(Serial serial): base(serial)
        {
        }

       /* public override bool OnMoveOver(Mobile m)
        {
            if (Active)
            {
                if (m.Player && m.Backpack != null)
                {

                    if (m.Backpack.FindItemByType(typeof(AbyssMarker), true) != null)
                        return base.OnMoveOver(m);

                    m.SendLocalizedMessage(1112226);
                    return true;
                }
                return true;
            }
        }*/

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            }
        }
    }

	
