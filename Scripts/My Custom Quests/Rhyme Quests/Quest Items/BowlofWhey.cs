//Scripted by Raven's Keeper
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class BowlofWhey: Item
	{
		[Constructable]
        public BowlofWhey(): base(5631)
		{
				  Name = "a bowl of curds and whey";
				  Hue = 1150;
			
		}



        public BowlofWhey(Serial serial): base(serial)
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