using System;
using Server;

namespace Server.Items
{
	public class MissMuffetRing : GoldRing
	{
		public override int ArtifactRarity{ get{ return 5; } }

		[Constructable]
		public MissMuffetRing()
		{
            Name = "Little Miss Muffet's Ring";
			Hue = 1150;
			Attributes.Luck = 500;
			Attributes.NightSight = 1;
			Resistances.Poison = 25;
			
		}

        public MissMuffetRing(Serial serial)
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