

//Scripted by Mimi & Kila Ventru

using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class WolfsScroll : Item
	{
		[Constructable]
		public WolfsScroll()
		{
			ItemID = 5357;
			Weight = 1.0;
			Name = "The Wolf's section of the story";
			Hue = 1544;

		}

		public override void OnDoubleClick(Mobile from)
		{
			Item nm = from.Backpack.FindItemByType(typeof(RedsScroll));
			if (nm != null)
			{
				from.AddToBackpack(new LittleRedRiddingHoodStory());
				nm.Delete();
				Delete();
			}
			else
			{
				from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You lack the other peice to combine with this", from.NetState);
			}
		}

		public WolfsScroll(Serial serial)
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