// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedLeafGloves : ACreedGarb
	{
		[Constructable]
		public ACreedLeafGloves() : base( 12230, Layer.Gloves )
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

		public ACreedLeafGloves( Serial serial ) : base( serial )
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