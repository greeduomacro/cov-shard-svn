// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class MinocLootMap : LootMap
	{
		[Constructable]
		public MinocLootMap() : base()
		{
			SetDisplay( 2360, 356, 2706, 702, 400, 400 );
		}

		public MinocLootMap( Serial serial ) : base( serial )
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
