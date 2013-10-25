using System;
using Server;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class TyballsKey : Item
	{
		
        [Constructable]
		public TyballsKey() : base( 0x1012 )
		{
			Hue = 0x489;
            Weight = 1.0;
        
            Movable = false;
		}

        public override void OnDoubleClick(Mobile from)
        {
            Item a = from.Backpack.FindItemByType(typeof(AbyssMarker));
            Item z = from.Backpack.FindItemByType(typeof(TyballsKey));

            if (a != null && z != null)
            {
                from.SendMessage("You have completed a Sacred quest already!");
                z.Delete();
            }
            else if (a == null)
            {
                Item b = from.Backpack.FindItemByType(typeof(BlueKey1));
                Item r = from.Backpack.FindItemByType(typeof(RedKey1));

                if (b == null || b.Amount < 1 || r == null || r.Amount < 1)
                {
                    from.SendMessage("You do not have all the required quest items");
                }

                else if (from != null && from.Alive && from.Backpack != null && this.RootParent == from)
                {
                    ArrayList list = new ArrayList();

                    foreach (Item item in from.Backpack.Items)
                    {
                        if (item is TyballsKey) list.Add(item);
                        else if (item is RedKey1) list.Add(item);
                        else if (item is BlueKey1) list.Add(item);
                    }
                    foreach (Item item in list) item.Delete();

                    from.SendLocalizedMessage(1113708);
                    from.PlaySound(0xF6);
                    from.PlaySound(0x1F7);
                    from.FixedParticles(0x3709, 1, 30, 1153, 13, 3, EffectLayer.Head);
                    from.AddToBackpack(new AbyssMarker());
                }
                else
                {
                    from.SendMessage("You can't use that without Tyballs key in your pack!");
                }
            }
        }
             	
		public TyballsKey( Serial serial ) : base( serial )
		{
		}		
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}