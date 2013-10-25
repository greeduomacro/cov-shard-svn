// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class TrinsicLootMap : LootMap
	{
		[Constructable]
		public TrinsicLootMap() : base()
		{
			SetDisplay( 1792, 2630, 2118, 2952, 400, 400 );
		}

		public TrinsicLootMap( Serial serial ) : base( serial )
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
