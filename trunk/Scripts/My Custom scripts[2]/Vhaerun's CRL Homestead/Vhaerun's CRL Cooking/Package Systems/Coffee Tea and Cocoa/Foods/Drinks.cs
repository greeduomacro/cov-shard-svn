using System;
using Server.Network;

namespace Server.Items
{
	public class PotOfCoffee : Food
	{
		[Constructable]
		public PotOfCoffee() : this( 1 )
		{
		}

		[Constructable]
		public PotOfCoffee( int amount ) : base( amount, 0x9D6)
		{
			this.Weight = 1.0;
			this.FillFactor = 2;
			this.Hue = 0x45D;
			this.Name = "Pot of Coffee";
		}

		public PotOfCoffee( Serial serial ) : base( serial )
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

	public class PotOfTea : Food
	{
		[Constructable]
		public PotOfTea() : this( 1 )
		{
		}

		[Constructable]
		public PotOfTea( int amount ) : base( amount, 0x24E6)
		{
			this.Weight = 1.0;
			this.FillFactor = 2;
			this.Hue = 0x5DF;
			this.Name = "Pot of Tea";
		}

		public PotOfTea( Serial serial ) : base( serial )
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

	public class MugOfCocoa : Food
	{
		[Constructable]
		public MugOfCocoa() : this( 1 )
		{
		}

		[Constructable]
		public MugOfCocoa( int amount ) : base( amount, 0x996)
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
			this.Hue = 0x45D;
			this.Name = "Mug of Cocoa";
		}

		public MugOfCocoa( Serial serial ) : base( serial )
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