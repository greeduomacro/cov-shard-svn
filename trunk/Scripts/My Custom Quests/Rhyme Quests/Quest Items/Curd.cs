//Scripted by Raven's Keeper
//Scripted by Raven's Keeper
using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Curd : Item
	{
		[Constructable]
        public Curd()
            : base(2486)
		{
				  Name = "a curd";
				  Hue = 1150;
                  Stackable = false;
		}

               
		public Curd( Serial serial ) : base( serial )
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