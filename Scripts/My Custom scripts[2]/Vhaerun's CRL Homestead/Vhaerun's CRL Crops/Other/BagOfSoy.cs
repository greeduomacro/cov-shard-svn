using System;
using Server.Network;


namespace Server.Items
{
	public class BagOfSoy : Item
	{
         [Constructable]
		public BagOfSoy() : this( 1 )
		{
		}

		[Constructable]
		public BagOfSoy( int amount ) : base( 0x1039 )
		{
            Name = "Bag of Soy";
			Weight = 5.0;
			Hue = 0x3D5;
            Stackable = true;
            Amount = amount;
		}

		public BagOfSoy( Serial serial ) : base( serial )
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