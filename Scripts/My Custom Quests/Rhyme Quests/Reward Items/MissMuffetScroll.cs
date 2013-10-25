
//Scripted by Mimi and Kila Ventru
using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class MissMuffetScroll : Item
	{
        [Constructable]
		public MissMuffetScroll()
        {
			ItemID = 5357;
            Weight = 1.0;
			Name = "To summon a Spider Queen";
			Hue = 1366;
				
        }

		public MissMuffetScroll(Serial serial)
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