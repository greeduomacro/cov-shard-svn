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

	public class PigStatue1 : Item
	{
		[Constructable]
		public PigStatue1() : this( null )
		{
		}

		[Constructable]
		public PigStatue1 ( string name ) : base ( 8449 )
		{
			Name = "Three Little Pigs Statue";
			Hue = 1015;
		}

        public PigStatue1(Serial serial)
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
