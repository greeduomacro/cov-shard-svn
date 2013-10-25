// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Network;
using System.Collections;

namespace Server.Items
{
	public class JhelomLootMap : LootMap
	{
		[Constructable]
		public JhelomLootMap() : base()
		{
			SetDisplay( 1088, 3572, 528, 4056, 400, 400 );
		}

		public JhelomLootMap( Serial serial ) : base( serial )
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
