// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	public class TouchedDyer : Item
	{
		[Constructable]
		public TouchedDyer() : base( 0x1AF9 )
		{
			Name = "Touched Dyer";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.CloseGump( typeof( TouchedDyeGump ) );
			from.SendGump( new TouchedDyeGump() );
		}

		public TouchedDyer( Serial serial ) : base( serial )
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