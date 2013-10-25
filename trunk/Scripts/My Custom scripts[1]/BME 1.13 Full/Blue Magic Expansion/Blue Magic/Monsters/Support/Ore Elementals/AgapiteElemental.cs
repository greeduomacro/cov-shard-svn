//Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class BlueAgapiteElemental : AgapiteElemental
	{
		[Constructable]
		public BlueAgapiteElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueAgapiteElemental( int oreamount ) : base( oreamount )
		{

		}

		public BlueAgapiteElemental( Serial serial ) : base( serial )
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