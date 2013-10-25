/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;
using Server.ContextMenus;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Misc;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
	public class AOLClue : Item
	{
        [Constructable]
        public AOLClue()
        {
            ItemID = 5357;
            Weight = 1.0;
            Name = "A cryptic clue";
            Hue = 1055;
				
        }

        public override void OnDoubleClick(Mobile from)
        {
           	from.SendGump(new AOLClueGump());
          
        }

        public AOLClue(Serial serial) : base(serial)
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