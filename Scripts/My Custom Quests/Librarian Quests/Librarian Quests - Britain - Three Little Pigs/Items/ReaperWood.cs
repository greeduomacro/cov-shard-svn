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

	public class ReaperWood : Item
	{
		[Constructable]
		public ReaperWood() : this( null )
		{
		}

		[Constructable]
		public ReaperWood ( string name ) : base ( 7127 )
		{
			Name = "Reaper Wood";
			Hue = 1109;
		}

        public ReaperWood(Serial serial)
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
