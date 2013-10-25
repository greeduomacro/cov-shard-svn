using System;

namespace Server.Items
{
	public class DemonBridleRing : GoldRing
	{
		public override int LabelNumber{ get{ return 1113651; } } //Demon Bridle Ring

		[Constructable]
		public DemonBridleRing()
		{
			Hue = 1779;
	
			Attributes.RegenMana = 1;
            Attributes.RegenHits = 1;
            Resistances.Fire = 5;
            Attributes.CastRecovery = 2;
            Attributes.CastSpeed = 1;
            Attributes.DefendChance = 10;
			
		}

		public DemonBridleRing( Serial serial ) : base( serial )
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
