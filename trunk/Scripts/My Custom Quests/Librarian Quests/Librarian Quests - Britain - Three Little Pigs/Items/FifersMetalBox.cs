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

	public class FifersMetalBox : Item
	{
		[Constructable]
		public FifersMetalBox() : this( null )
		{
		}

		[Constructable]
		public FifersMetalBox ( string name ) : base ( 2472 )
		{
			Name = "Metal Box (It's Empty)";
			Hue = 0;
		}

        public FifersMetalBox(Serial serial)
            : base(serial)
		{
		}

      		
	public override void OnDoubleClick( Mobile m )

		{	
			Item [] a = m.Backpack.FindItemsByType( typeof( GoldStraw ) );
			// are there at least 5 elements in the returned array?
			if ( a!= null && a.Length >= 5)
			{

			Item b = m.Backpack.FindItemByType( typeof( FifersMetalBox ) );
			if ( b != null )

			{
				// delete the first 5 of them
				for(int i=0;i<5;i++) a[i].Delete();
				b.Delete();

				// and add the Full Metal Box
				m.AddToBackpack( new FullMetalBox() );
				m.SendMessage("The Metal Box is full, hurry back to Fifer!");
			}
			}

			else
			{
				m.SendMessage( "More Golden Straw is needed. There is still plenty more room..." );
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
