// Created by Peoharen
using System;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class BlueBoots : BlueClothing
	{
		[Constructable]
		public BlueBoots() : base( 0x2FC4, Layer.Shoes )
		{
			Name = "Blue Mage Boots";
		}

		public BlueBoots( Serial serial ) : base( serial )
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
