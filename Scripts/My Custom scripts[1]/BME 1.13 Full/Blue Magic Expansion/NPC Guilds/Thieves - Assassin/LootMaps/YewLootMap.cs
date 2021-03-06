// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class YewLootMap : LootMap
	{
		[Constructable]
		public YewLootMap() : base()
		{
			SetDisplay( 236, 741, 766, 1269, 400, 400 );
		}

		public YewLootMap( Serial serial ) : base( serial )
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
