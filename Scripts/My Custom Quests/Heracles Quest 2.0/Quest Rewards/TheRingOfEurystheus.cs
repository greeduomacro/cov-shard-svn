using System;
using Server;

namespace Server.Items
{
	public class TheRingOfEurystheus : GoldRing
	{
		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable]
		public TheRingOfEurystheus()
		{
			Name = "The Ring of Eurystheus";
			Attributes.BonusStr = 10;
			Attributes.BonusDex = 10;
			Attributes.WeaponSpeed = 20;
			Resistances.Cold = 15;
		}

		public TheRingOfEurystheus( Serial serial ) : base( serial )
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