using System;
using Server.Network;

namespace Server.Items
{
	public class Cherries : Food
	{
		[Constructable]
		public Cherries() : this( 1 )
		{
		}

		[Constructable]
		public Cherries( int amount ) : base( amount, 0xF2A )
		{
			this.Weight = 1.0;
			this.FillFactor = 2;
			this.Hue = 0x27;
			this.Name = "Cherries";
		}

		public Cherries( Serial serial ) : base( serial )
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