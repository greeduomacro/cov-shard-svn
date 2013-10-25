using System;
using Server.Items;

namespace Server.Items
{
	public class AngelFeather : Item, ICommodity
	{
		string ICommodity.Description
		{
			get
			{
				return String.Format( Amount == 1 ? "{0} AngelFeather" : "{0} AngelFeather", Amount );
			}
		}

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

		[Constructable]
		public AngelFeather() : this( 1 )
		{
		}

		[Constructable]
		public AngelFeather( int amount ) : base( 0x1BD1 )
		{
			Stackable = true;
			Weight = 0.1;
			Amount = amount;
			Name = "AngelFeather";
			Hue = 1153;
		}

		public AngelFeather( Serial serial ) : base( serial )
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
		/*}

		public override Item Dupe( int amount )
		{
			return base.Dupe( new AngelFeather( amount ), amount );*/
		}
	}
}
