
//Scripted by Mimi and Kila Ventru
using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class FiddlerPigsScroll : Item
	{
        [Constructable]
		public FiddlerPigsScroll()
        {
			ItemID = 5357;
            Weight = 1.0;
			Name = "Three Little Pigs, Fiddler's Scroll";
			Hue = 1103;
				
        }

		public override void OnDoubleClick(Mobile from)
        {
			Item n = from.Backpack.FindItemByType(typeof(FiferPigsScroll));
            if (n != null)
            {
				from.AddToBackpack(new FiferandFiddlerpigsScroll());
                n.Delete();
                Delete();
            }
            else
            {
                from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You need Fifer Pig's Scroll to combine with Fiddler's", from.NetState);
            }
		}

        public FiddlerPigsScroll(Serial serial)
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