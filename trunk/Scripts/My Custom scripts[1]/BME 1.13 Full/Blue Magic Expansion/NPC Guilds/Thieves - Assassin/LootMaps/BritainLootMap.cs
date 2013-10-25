// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class BritainLootMap : LootMap
	{
		[Constructable]
		public BritainLootMap() : base()
		{
			SetDisplay( 1092, 1396, 1736, 1924, 400, 400 );
		}

		public BritainLootMap( Serial serial ) : base( serial )
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
