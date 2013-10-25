// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class SerpentsHoldLootMap : LootMap
	{
		[Constructable]
		public SerpentsHoldLootMap() : base()
		{
			SetDisplay( 2714, 3329, 3100, 3639, 400, 400 );
		}

		public SerpentsHoldLootMap( Serial serial ) : base( serial )
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
