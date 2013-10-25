// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class NujelmLootMap : LootMap
	{
		[Constructable]
		public NujelmLootMap() : base()
		{
			SetDisplay( 3446, 1030, 3832, 1424, 400, 400 );
		}

		public NujelmLootMap( Serial serial ) : base( serial )
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
