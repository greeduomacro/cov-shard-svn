using System;
using Server;

namespace Server.Items
{
	public class CandleOfLove1 : Item
	{
		[Constructable]
		public CandleOfLove1() : base( 7188 )
		{
			LootType = LootType.Blessed;
			Light = LightType.Circle150;
		}

		public CandleOfLove1( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060662, "Valentines Day\t2010" );
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
