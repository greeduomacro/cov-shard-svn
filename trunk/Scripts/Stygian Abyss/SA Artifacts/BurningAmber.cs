using System;

namespace Server.Items
{
	public class BurningAmber : GoldRing
	{
		public override int LabelNumber{ get{ return 1114790; } } //Burning Amber

		[Constructable]
		public BurningAmber()
		{
			Hue = 1260;
	
			Attributes.RegenMana = 2;
            Attributes.BonusDex = 5;
            Resistances.Fire = 20;
            Attributes.CastRecovery = 3;
			
		}

		public BurningAmber( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
