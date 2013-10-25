using System;
using Server.Items;

namespace Server.Items
{
	public class Tangle1 : HalfApron
	{
		public override int LabelNumber{ get{ return 1114784; } } // Tangle
	
		[Constructable]
		public Tangle1() : base()
		{
			Hue = 1759;

            Attributes.BonusInt = 10;
            Attributes.RegenMana = 2;
            Attributes.DefendChance = 10;
		}

		public Tangle1( Serial serial ) : base( serial )
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

