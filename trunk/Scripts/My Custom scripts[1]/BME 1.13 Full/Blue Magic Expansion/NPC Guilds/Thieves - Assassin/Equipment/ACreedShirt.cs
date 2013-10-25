// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedShirt : ACreedGarb
	{
		[Constructable]
		public ACreedShirt() : base( 7933, Layer.Shirt )
		{
			Hue = 1175;
		}

		public override void UpdateLevel()
		{
			if ( Level > 0 )
				Attributes.EnhancePotions = 25;
			else
				Attributes.EnhancePotions = 0;
		}

		public ACreedShirt( Serial serial ) : base( serial )
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