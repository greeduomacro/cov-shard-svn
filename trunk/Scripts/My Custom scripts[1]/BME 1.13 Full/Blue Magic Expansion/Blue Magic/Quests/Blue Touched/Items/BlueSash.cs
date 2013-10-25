// Created by Peoharen
using System;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class BlueSash : BlueClothing
	{
		[Constructable]
		public BlueSash() : base( 0x1541, Layer.MiddleTorso )
		{
			Name = "Blue Mage Sash";
		}

		public BlueSash( Serial serial ) : base( serial )
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