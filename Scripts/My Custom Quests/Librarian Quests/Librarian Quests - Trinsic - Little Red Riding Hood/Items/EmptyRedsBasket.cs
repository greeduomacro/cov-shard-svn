using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Items;

namespace Server.Items
{

	public class EmptyRedsBasket : Item
	{
		[Constructable]
		public EmptyRedsBasket() : this( null )
		{
		}

		[Constructable]
		public EmptyRedsBasket ( string name ) : base ( 0x990 )
		{
			Name = "Reds Basket (It's Empty)";
			Hue = 32;
		}

		public EmptyRedsBasket ( Serial serial ) : base ( serial )
		{
		}

      		
	public override void OnDoubleClick( Mobile m )

		{	
			Item [] a = m.Backpack.FindItemsByType( typeof( GreenApple ) );
			// are there at least 10 elements in the returned array?
			if ( a!= null && a.Length >= 10)
			{

			Item b = m.Backpack.FindItemByType( typeof( EmptyRedsBasket ) );
			if ( b != null )

			{
				// delete the first 10 of them
				for(int i=0;i<10;i++) a[i].Delete();
				b.Delete();

				// and add the full basket of green apples
				m.AddToBackpack( new FruitBasket() );
				m.SendMessage("The basket is full, hurry back to Massie for your reward!");
			}
			}

			else
			{
				m.SendMessage( "Massie's grandmother needs lots of green apples. There is still room for more..." );
			}
		}
		
		
		
		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}
