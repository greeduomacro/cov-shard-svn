
//Scripted by Mimi and Kila Ventru
using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class RedsScroll : Item
	{
        [Constructable]
		public RedsScroll()
        {
			ItemID = 5357;
            Weight = 1.0;
			Name = "Litle Red Ridding Hood's piece of the story";
			Hue = 32;
				
        }

		public override void OnDoubleClick(Mobile from)
        {
			Item n = from.Backpack.FindItemByType(typeof(WolfsScroll));
            if (n != null)
            {
				from.AddToBackpack(new LittleRedRiddingHoodStory());
                n.Delete();
                Delete();
            }
            else
            {
                from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You lack the other peice of the story to combine with this", from.NetState);
            }
		}

		public RedsScroll(Serial serial)
            : base(serial)
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