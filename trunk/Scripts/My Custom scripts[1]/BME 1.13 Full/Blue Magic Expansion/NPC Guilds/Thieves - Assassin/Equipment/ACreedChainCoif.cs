// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedChainCoif : ACreedGarb
	{
		[Constructable]
		public ACreedChainCoif() : base( 5051, Layer.Helm )
		{
			Hue = 2101;
		}

		public override void UpdateLevel()
		{
			if ( Level > 0 )
				Attributes.NightSight = 1;
			else
				Attributes.NightSight = 0;
		}

		public ACreedChainCoif( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}