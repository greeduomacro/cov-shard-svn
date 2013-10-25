using System;
using Server;

namespace Server.Items
{
	public class RedsRing : GoldRing
	{
		public override int ArtifactRarity{ get{ return 3; } }

		[Constructable]
		public RedsRing()
		{
			Name = "Little Red Riding Hood's Ring";
			Hue = 32;
			Attributes.Luck = 250;
			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 2;
			Attributes.NightSight = 1;
			Resistances.Physical = 5;
			Resistances.Fire = 5;
			Resistances.Cold = 5;
			Resistances.Poison = 5;
			Resistances.Energy = 5;
		}

		public RedsRing( Serial serial ) : base( serial )
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

			if ( Hue == 0 )
				Hue = 0x83EA;
		}
	}
}