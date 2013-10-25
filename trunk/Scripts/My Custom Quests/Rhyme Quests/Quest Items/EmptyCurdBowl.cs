
//Scripted by Raven's Keeper
using System;
using Server;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class EmptyCurdBowl : Item
	{
        [Constructable]
		public EmptyCurdBowl()
        {
			ItemID = 0x990;
            Weight = 1.0;
			Name = "Empty Curd Bowl";
			Hue = 1109;
				
        }

		public override void OnDoubleClick(Mobile from)
        {
			Item n = from.Backpack.FindItemByType(typeof(Curd));
            if (n != null)
            {
				from.AddToBackpack(new BowlofWhey());
                n.Delete();
                Delete();
                from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Finally I have the bowl of curds and whey for the child! Now I must quickly return to her.", from.NetState);
            
            }
            else
            {
                from.PrivateOverheadMessage(MessageType.Regular, 1153, false, "You must have a curd", from.NetState);
            }
		}

        public EmptyCurdBowl(Serial serial)
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