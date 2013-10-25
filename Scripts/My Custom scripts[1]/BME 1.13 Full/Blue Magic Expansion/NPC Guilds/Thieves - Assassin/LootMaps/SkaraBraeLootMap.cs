// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class SkaraBraeLootMap : LootMap
	{
		[Constructable]
		public SkaraBraeLootMap() : base()
		{
			SetDisplay( 524, 2064, 960, 2452, 400, 400 );
		}

		public SkaraBraeLootMap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize (writer);
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize (reader);
			int version = reader.ReadInt();
		}
	}
}
