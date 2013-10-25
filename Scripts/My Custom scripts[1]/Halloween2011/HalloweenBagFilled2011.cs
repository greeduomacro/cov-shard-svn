
using System;
using Server;
using Server.Items;

namespace Server.Items
{  
	public class HalloweenBagFilled2011 : Bag
	{
           	[Constructable]
           	public HalloweenBagFilled2011()
           	{
           	Name = "Have A Spooky Halloween 2011";
			Hue = 1258;

			DropItem (new HalloweenLantern2011() );

			switch ( Utility.Random( 4 ) )
			{      	
				case 0: DropItem(new HalloweenCloak2011());
				break;

				case 1: DropItem(new HalloweenTunic2011());
				break;

				case 2: DropItem(new HalloweenDoublet2011());
				break;

				case 3: DropItem(new HalloweenBoots2011());
				break;
			}

			if ( 0.1 > Utility.RandomDouble() )
			{
				DropItem( new HalloweenOuiJaBoard2011() );
			}

           	}

           	[Constructable]
           	public HalloweenBagFilled2011(int amount)
           	{
           	}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( "Halloween 2011" );
		}

           	public HalloweenBagFilled2011(Serial serial) : base( serial )
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
