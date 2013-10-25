// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedSkirt : ACreedGarb
	{
		[Constructable]
		public ACreedSkirt() : base( 5398, Layer.Shoes )
		{
			Hue = 2101;
		}

		public override void UpdateLevel()
		{
			if ( Level > 0 )
				Attributes.LowerManaCost = 15;
			else
				Attributes.LowerManaCost = 0;
		}

		public ACreedSkirt( Serial serial ) : base( serial )
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