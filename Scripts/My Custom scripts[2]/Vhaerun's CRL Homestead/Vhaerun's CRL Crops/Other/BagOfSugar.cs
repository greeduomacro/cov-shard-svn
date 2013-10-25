using System;
using Server.Network;


namespace Server.Items
{
	public class BagOfSugar : Item
	{
        [Constructable]
		public BagOfSugar() : this( 1 )
		{
		}

		[Constructable]
		public BagOfSugar( int amount ) : base( 0x1039 )
		{
            Name = "Bag of Sugar";
			Weight = 5.0;
			Hue = 1153;
            Stackable = true;
            Amount = amount;
			
		}

		public BagOfSugar( Serial serial ) : base( serial )
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