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

	public class FiddlersWoodBox : Item
	{
		[Constructable]
		public FiddlersWoodBox() : this( null )
		{
		}

		[Constructable]
		public FiddlersWoodBox ( string name ) : base ( 2474 )
		{
			Name = "Fiddlers Wood Box (It's Empty)";
			Hue = 1150;
		}

        public FiddlersWoodBox(Serial serial)
            : base(serial)
		{
		}

      		
	public override void OnDoubleClick( Mobile m )

		{	
			Item [] a = m.Backpack.FindItemsByType( typeof( ReaperWood ) );
			// are there at least 5 elements in the returned array?
			if ( a!= null && a.Length >= 5)
			{

                Item b = m.Backpack.FindItemByType(typeof(FiddlersWoodBox));
			if ( b != null )

			{
				// delete the first 5 of them
				for(int i=0;i<5;i++) a[i].Delete();
				b.Delete();

                // and add the Fiddlers Full Wood Box
                m.AddToBackpack(new FullWoodBox());
				m.SendMessage("The Wood Box is full, hurry back to Fiddler!");
			}
			}

			else
			{
				m.SendMessage( "More Reaper Wood is needed. There is still plenty more room..." );
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
