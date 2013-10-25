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

	public class WolfStatue2 : Item
	{
		[Constructable]
		public WolfStatue2() : this( null )
		{
		}

		[Constructable]
		public WolfStatue2 ( string name ) : base ( 9682 )
		{
			Name = "The Big Bad Wolf Statue";
			Hue = 1158;
		}

        public WolfStatue2(Serial serial)
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
