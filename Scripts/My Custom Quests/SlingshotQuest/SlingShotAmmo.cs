using System;

namespace Server.Items
{
	public class SlingShotAmmo : Item, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} slingshotammo" : "{0} slingshotammo", Amount );
			}
		}

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public SlingShotAmmo() : this( 1 )
		{
		}

		[Constructable]
		public SlingShotAmmo( int amount ) : base( 3979 )
		{
            Name = " Sling Shot Ammo ";
            Hue = 2220;
			Stackable = true;
			Amount = amount;
		}

		public SlingShotAmmo( Serial serial ) : base( serial )
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