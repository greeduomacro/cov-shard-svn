using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Misc;
using Server.Engines.Quests;

namespace Server.Items
{
	public class CasToy : Item
	{
				[Constructable]
		public CasToy() : this( 1 )
		{
		}
		[Constructable]
		public CasToy( int amount ) : base( 0x2107 )
		{
			Name = "Barbie Doll";
                        Weight = 1.0;
			
		}

		public CasToy( Serial serial ) : base( serial )
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