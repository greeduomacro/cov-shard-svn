
//Scripted by Mimi and Kila Ventru
using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class FiferandFiddlerpigsScroll : Item
	{
        [Constructable]
		public FiferandFiddlerpigsScroll()
        {
			ItemID = 5357;
            Weight = 1.0;
			Name = "Three Little Pigs, Fifer and Fiddler Pig's Scroll";
			Hue = 32;
				
        }

		public override void OnDoubleClick(Mobile from)
        {
			Item n = from.Backpack.FindItemByType(typeof(PracticalPigsScroll));
            if (n != null)
            {
				from.AddToBackpack(new ThreePigsCombinedScroll());
                n.Delete();
                Delete();
            }
            else
            {
                from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You need Fifer Pig's Scroll to combine with Fiddler's", from.NetState);
            }
		}

        public FiferandFiddlerpigsScroll(Serial serial)
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