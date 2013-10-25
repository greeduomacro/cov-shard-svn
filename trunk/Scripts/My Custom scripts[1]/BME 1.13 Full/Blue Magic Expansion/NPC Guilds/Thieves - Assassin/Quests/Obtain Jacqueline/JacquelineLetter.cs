// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class ACreedJacquelinesLetter : Item
	{
		[Constructable]
		public ACreedJacquelinesLetter()
		{
		}

		public ACreedJacquelinesLetter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}