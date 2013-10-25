// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedKilt : ACreedGarb
	{
		[Constructable]
		public ACreedKilt() : base( 5431, Layer.OuterLegs )
		{
			Hue = 1109;
		}

		public override void UpdateLevel()
		{
			if ( Level > 0 )
				Attributes.LowerManaCost = 15;
			else
				Attributes.LowerManaCost = 0;
		}

		public ACreedKilt( Serial serial ) : base( serial )
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