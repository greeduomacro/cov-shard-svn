using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class SnowyTree2011 : Item
	{
		[Constructable]
		public SnowyTree2011() : base( 0x2377 )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public SnowyTree2011( Serial serial ) : base( serial )
		{
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			LabelTo( from, "Christmas 2011" ); // Winter 2011
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( "Christmas 2011"  ); // Winter 2011
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