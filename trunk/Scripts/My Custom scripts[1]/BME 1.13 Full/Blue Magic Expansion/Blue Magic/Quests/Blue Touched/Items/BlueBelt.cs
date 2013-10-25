// Created by Peoharen
using System;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class BlueBelt : BlueClothing
	{
		[Constructable]
		public BlueBelt() : base( 0x2B68, Layer.Waist )
		{
			Name = "Blue Mage Belt";
		}

		public BlueBelt( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}