using System;
using Server;

namespace Server.Items
{
	public class RingOfTheEttins : GoldRing
	{

		public override int ArtifactRarity{ get{ return 1; } } 

		[Constructable]
		public RingOfTheEttins()
		{
			Name = "Ring Of Ettin's Strength";
			Hue = 0x21E;
			Attributes.BonusHits = 5;
			Attributes.BonusStr = 5;
			Attributes.ReflectPhysical = 5;
			Attributes.WeaponDamage = 10;
		}

		public RingOfTheEttins( Serial serial ) : base( serial )
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
				Hue = 0x21E;
		}
	}
}