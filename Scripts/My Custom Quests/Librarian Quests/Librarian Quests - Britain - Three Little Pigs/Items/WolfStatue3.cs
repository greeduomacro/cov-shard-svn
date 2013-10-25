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

	public class WolfStatue3 : Item
	{
		[Constructable]
		public WolfStatue3() : this( null )
		{
		}

		[Constructable]
		public WolfStatue3 ( string name ) : base ( 9682 )
		{
			Name = "The Big Bad Wolf Statue";
			Hue = 1150;
		}

        public WolfStatue3(Serial serial)
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
