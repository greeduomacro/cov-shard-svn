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

	public class EmptyBag : Item
	{
		[Constructable]
		public EmptyBag() : this( null )
		{
		}

		[Constructable]
		public EmptyBag ( string name ) : base ( 0xE76 )
		{
			Name = "Goldilocks Bag (It's Empty)";
			Hue = 1281;
		}

		public EmptyBag ( Serial serial ) : base ( serial )
		{
		}

      		
	public override void OnDoubleClick( Mobile m )

		{	
			Item [] a = m.Backpack.FindItemsByType( typeof( JustRightChair ) );
			// are there at least 1
			if ( a!= null && a.Length >= 1)
			{
			Item [] b = m.Backpack.FindItemsByType( typeof( PorridgeJustRight ) );
			// are there at least 1
			if ( b!= null && b.Length >= 1)
			{
			Item [] c = m.Backpack.FindItemsByType( typeof( PillowJustRight ) );
			// are there at least 1
			if ( c!= null && c.Length >= 1)
			{
			Item d = m.Backpack.FindItemByType( typeof( EmptyBag ) );
			if ( d != null )

			{
				// delete all of them
				for(int i=0;i<1;i++) a[i].Delete();
				for(int i=0;i<1;i++) b[i].Delete();
				for(int i=0;i<1;i++) c[i].Delete();
				d.Delete();

				// and add the Full Bag 
				m.AddToBackpack( new FullBag() );
				m.SendMessage("The bag is full, hurry back to Goldilocks for her story!");
			}
			}

			else
			{
				m.SendMessage( "Something is wrong please try again! Only the just right items are acceptable!" );
			}
		}
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
