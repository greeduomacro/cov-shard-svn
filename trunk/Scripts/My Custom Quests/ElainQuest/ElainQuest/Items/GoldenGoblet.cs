using System;

namespace Server.Items
{
	public class GoldenGoblet : Item
	{
		[Constructable]
		public GoldenGoblet() : base( 0x9B3 )
		{
		      Weight = 1.0;

            }

		public GoldenGoblet( Serial serial ) : base( serial )
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