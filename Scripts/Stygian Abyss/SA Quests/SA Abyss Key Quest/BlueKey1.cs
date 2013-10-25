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
	public class BlueKey1 : AbyssKey
	{
		public override int LabelNumber{ get{ return 1111646; } } // Blue Key Fragment
		public override int Lifespan{ get{ return 21600; } }
	
		[Constructable]
		public BlueKey1() : base( 0x1012 )
		{
			Weight = 1.0;
			Hue = 0x5D; // TODO check
            LootType = LootType.Blessed;
            Movable = false;
		}

        public override void OnDoubleClick(Mobile from)
        {
            if (this.RootParent == from)
            {
                Item item = from.Backpack.FindItemByType(typeof(BlueKey1));
                if (item != null )
                {
                    from.SendMessage("You already have a key!");
                    return;

                    }
            }
        }
                   
           
		public BlueKey1( Serial serial ) : base( serial )
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

