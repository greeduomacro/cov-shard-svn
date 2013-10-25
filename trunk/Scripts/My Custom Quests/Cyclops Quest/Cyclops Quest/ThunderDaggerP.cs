using System;
using Server;

namespace Server.Items
{
	public class ThunderDaggerP : Dagger
	{
		[Constructable]
		public ThunderDaggerP()
		{
            Name = "a prototype of a Thunder Dagger";
			ItemID = 0xF51;
			Hue = 1276;
			
		}

		public ThunderDaggerP( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}