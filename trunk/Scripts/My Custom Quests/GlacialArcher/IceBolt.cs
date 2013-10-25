using System;

namespace Server.Items
{
	public class IceBolt : Item, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} bolt" : "{0} bolts", Amount );
			}
		}

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

		[Constructable]
		public IceBolt() : this( 1 )
		{
		}

		[Constructable]
		public IceBolt( int amount ) : base( 0x1BFB )
		{
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
            Hue = 1152;
		}

		public IceBolt( Serial serial ) : base( serial )
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