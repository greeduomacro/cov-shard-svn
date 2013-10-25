// Created by Peoharen
using System;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class BlueCloak : BlueClothing
	{
		[Constructable]
		public BlueCloak() : base( 0x26AD, Layer.Cloak )
		{
			Name = "Blue Mage Cloak";
		}

		public BlueCloak( Serial serial ) : base( serial )
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