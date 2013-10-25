// Original Author Unknown
// Updated to be halloween 2007 by GreyWolf

using System;
using Server;
using Server.Items;

namespace Server.Items
{  
	public class HalloweenBagFilled2007 : Bag
	{
           	[Constructable]
           	public HalloweenBagFilled2007()
           	{
           		Name = "Have A Spooky Halloween 2007";
			Hue = 1258;

			DropItem (new HalloweenLantern2007() );

			switch ( Utility.Random( 4 ) )
			{      	
				case 0: DropItem(new HalloweenCloak2007());
				break;

				case 1: DropItem(new HalloweenTunic2007());
				break;

				case 2: DropItem(new HalloweenDoublet2007());
				break;

				case 3: DropItem(new HalloweenBoots2007());
				break;
			}

			if ( 0.1 > Utility.RandomDouble() )
			{
				DropItem( new HalloweenOuiJaBoard2007() );
			}

           	}

           	[Constructable]
           	public HalloweenBagFilled2007(int amount)
           	{
           	}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060662, "Halloween\t2007" );
		}

           	public HalloweenBagFilled2007(Serial serial) : base( serial )
           	{
           	}

          	public override void Serialize(GenericWriter writer)
          	{
           		base.Serialize(writer);

           		writer.Write((int)0); // version 
     		}

           	public override void Deserialize(GenericReader reader)
      	{
           		base.Deserialize(reader);

          		int version = reader.ReadInt();
           	}
	}
}
