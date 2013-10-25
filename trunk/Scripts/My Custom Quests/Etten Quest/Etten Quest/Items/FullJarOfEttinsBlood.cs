using System;
using Server;

namespace Server.Items
{
	   
	public class FullJarOfEttinsBlood : Item
	{
		[Constructable]
		public FullJarOfEttinsBlood() : this( null )
		{
		}

		[Constructable]
		public FullJarOfEttinsBlood( string name ) : base( 0x1006 )
		{
			Name = "a full jar of ettins blood";
			Weight = 5.0;
			Hue = 0x485;
		}

		public FullJarOfEttinsBlood( Serial serial ) : base( serial )
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