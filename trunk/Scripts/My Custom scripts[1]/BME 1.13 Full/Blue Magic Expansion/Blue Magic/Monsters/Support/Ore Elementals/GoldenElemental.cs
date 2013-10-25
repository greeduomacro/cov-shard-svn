using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class BlueGoldenElemental : GoldenElemental
	{
		[Constructable]
		public BlueGoldenElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueGoldenElemental( int oreamount ) : base( oreamount )
		{
		}

		public BlueGoldenElemental( Serial serial ) : base( serial )
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