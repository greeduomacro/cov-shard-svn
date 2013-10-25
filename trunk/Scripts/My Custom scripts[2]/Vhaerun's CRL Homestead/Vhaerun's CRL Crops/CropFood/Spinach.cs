using System;
using Server.Network;

namespace Server.Items
{
	public class Spinach : Food
	{
		[Constructable]
		public Spinach() : this( 1 )
		{
		}

		[Constructable]
		public Spinach( int amount ) : base( amount, 0xD09 )
		{
            this.Name = "Spinach Leaf";
			this.Weight = 0.1;
			this.Stackable = true;
			this.FillFactor = 1;
			this.Hue = 0x29D;
            this.Amount = amount;
			
		}

		public Spinach( Serial serial ) : base( serial )
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