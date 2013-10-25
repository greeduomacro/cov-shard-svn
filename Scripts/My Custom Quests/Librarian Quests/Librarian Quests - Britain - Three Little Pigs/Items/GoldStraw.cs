using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{

	public class GoldStraw : Item
	{
		[Constructable]
		public GoldStraw() : this( null )
		{
		}

		[Constructable]
		public GoldStraw ( string name ) : base ( 3894 )
		{
			Name = "Golden Straw";
			Hue = 1161;
		}

        public GoldStraw(Serial serial)
            : base(serial)
		{
		}

      		
		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}
