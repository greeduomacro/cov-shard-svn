// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class BuccaneersDenLootMap : LootMap
	{
		[Constructable]
		public BuccaneersDenLootMap() : base()
		{
			SetDisplay( 2500, 1900, 3000, 2400, 400, 400 );
		}

		public BuccaneersDenLootMap( Serial serial ) : base( serial )
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
