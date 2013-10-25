using System;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class BigMahi : Item, ICarvable
	{
		public void Carve( Mobile from, Item item )
		{
			base.ScissorHelper( from, new RawFishSteak(), 8 );
		}

		[Constructable]
		public BigMahi() : this( 1 )
		{
		}

		[Constructable]
		public BigMahi( int amount ) : base( Utility.Random( 0x09CC, 4 ) )
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
			Name = "A Big Mahi-Mahi";
		}

		

		public BigMahi( Serial serial ) : base( serial )
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
