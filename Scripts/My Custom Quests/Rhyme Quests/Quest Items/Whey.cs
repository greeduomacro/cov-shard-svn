//Scripted by Raven's Keeper
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Whey : Item
	{
		[Constructable]
        public Whey ()
            : base(3854)
		{
				  Name = "whey";
				  Hue = 1150;
            Stackable = false;
			
		}

        

        public Whey(Serial serial)
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