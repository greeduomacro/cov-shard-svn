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

	public class WoodenHorseStatueRare : Item
	{
		[Constructable]
		public WoodenHorseStatueRare() : this( null )
		{
		}

		[Constructable]
		public WoodenHorseStatueRare ( string name ) : base ( 16382 )
		{
			Name = "Rare Wooden Horse Statue";
			Hue = 1109;
		}

        public WoodenHorseStatueRare(Serial serial)
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
