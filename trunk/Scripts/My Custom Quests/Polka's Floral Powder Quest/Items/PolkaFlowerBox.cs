using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;


namespace Server.Items
{

	public class PolkaFlowerBox : Item
	{
		[Constructable]
		public PolkaFlowerBox() : this( null )
		{
		}

		[Constructable]
		public PolkaFlowerBox ( string name ) : base ( 0x9A8 )
		{
			Name = "Polka's Flower Box";
			LootType = LootType.Blessed;
			Hue = 1581;
		}

		public PolkaFlowerBox( Serial serial ) : base ( serial )
		{
		}

      		
		public override void OnDoubleClick( Mobile m )

		{
			Item a = m.Backpack.FindItemByType( typeof(RagnalFloralPowder) );
			if ( a != null )
			{	
			Item b = m.Backpack.FindItemByType( typeof(TealiFloralPowder) );
			if ( b != null )
			{
			Item c = m.Backpack.FindItemByType( typeof(AubryFloralPowder) );
			if ( c != null )
			{
			
				m.AddToBackpack( new RawFloralPowder() );
				a.Delete();
				b.Delete();
				c.Delete();
				m.SendMessage( "You've seemed to successfully create floral powder." );
				this.Delete();
			}
			}
				else
			{
				m.SendMessage( "Are you not forgetting something?" );
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