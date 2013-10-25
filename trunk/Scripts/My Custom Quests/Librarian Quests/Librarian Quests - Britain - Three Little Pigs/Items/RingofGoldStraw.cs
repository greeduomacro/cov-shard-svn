using System;
using Server;

namespace Server.Items
{
	public class RingofGoldStraw : GoldRing
	{
		public override int ArtifactRarity{ get{ return 3; } }

		[Constructable]
		public RingofGoldStraw()
		{
            Name = "Ring of Golden Straw";
			Hue = 1161;
			Attributes.Luck = 200;
			Attributes.NightSight = 1;
			Resistances.Cold = 8;
			Resistances.Poison = 8;
					}

        public RingofGoldStraw(Serial serial)
            : base(serial)
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