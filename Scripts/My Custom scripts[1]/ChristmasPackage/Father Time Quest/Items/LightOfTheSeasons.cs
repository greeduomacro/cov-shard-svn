using System;
using Server;

namespace Server.Items
{
	public class LightOfTheSeasons : Lantern
	{

		[Constructable]
		public LightOfTheSeasons()
		{
            Name = "Light Of The Seasons";
			Hue = 1162;
		}

        public LightOfTheSeasons(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}