// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class BlueDraconicRune : Item
	{
		[Constructable]
		public BlueDraconicRune() : this( 1 )
		{
		}

		[Constructable]
		public BlueDraconicRune( int amount ) : base( 0x1422 )
		{
			Name = "Draconic Rune";
			Hue = 1365;
			Stackable = true;

			Amount = amount;
		}

		public BlueDraconicRune( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}