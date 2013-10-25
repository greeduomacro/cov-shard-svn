// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class MoonglowLootMap : LootMap
	{
		[Constructable]
		public MoonglowLootMap() : base()
		{
			SetDisplay( 4156, 808, 4732, 1528, 400, 400 );
		}

		public MoonglowLootMap( Serial serial ) : base( serial )
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
