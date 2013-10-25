// Created by Peoharen
using System;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class BluePants : BlueClothing
	{
		[Constructable]
		public BluePants() : base( 0x2FC3, Layer.Pants ) // Human Pants: 0x1539
		{
			Name = "Blue Mage Pants";
		}

		public BluePants( Serial serial ) : base( serial )
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