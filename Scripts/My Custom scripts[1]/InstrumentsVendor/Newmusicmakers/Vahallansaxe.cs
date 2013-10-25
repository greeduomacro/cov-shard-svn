using System;

namespace Server.Items
{
	public class Vahallansaxe : BaseInstrument
	{
		[Constructable]
		public Vahallansaxe() : base( 0x2D34, 0x5a5, 0x5C3 )
		{
			Name = "Vahallan's Wicked Golden Axe";
			Hue = 253;
			Slayer = SlayerName.Silver;
			Slayer2 = SlayerName.DaemonDismissal;
			Weight = 2.0;
		}

		public Vahallansaxe( Serial serial ) : base( serial )

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

			if ( Weight == 3.0 )
				Weight = 2.0;
		}
	}
}