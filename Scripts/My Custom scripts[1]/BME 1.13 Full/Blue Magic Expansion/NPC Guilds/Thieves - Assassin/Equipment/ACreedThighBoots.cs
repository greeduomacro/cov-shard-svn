// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedThighBoots : ACreedGarb
	{
		[Constructable]
		public ACreedThighBoots() : base( 5905, Layer.Pants )
		{
			Hue = 1175;
		}


		public override void UpdateLevel()
		{
			if ( Level > 0 )
				Attributes.ReflectPhysical = 10;
			else
				Attributes.ReflectPhysical = 0;
		}

		public ACreedThighBoots( Serial serial ) : base( serial )
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