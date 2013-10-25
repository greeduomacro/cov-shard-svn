// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class MaginciaLootMap : LootMap
	{
		[Constructable]
		public MaginciaLootMap() : base()
		{
			SetDisplay( 3530, 2022, 3818, 2298, 400, 400 );
		}

		public MaginciaLootMap( Serial serial ) : base( serial )
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
