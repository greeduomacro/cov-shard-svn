using System;
using Server;

namespace Server.Items
{
	public class GuildDyeTub : DyeTub
	{
        public override bool AllowLeather { get { return true; } }
        public override CustomHuePicker CustomHuePicker { get { return CustomHuePicker.LeatherDyeTub; } }


		[Constructable]
		public GuildDyeTub()
		{
			Hue = DyedHue = 1152;
			Redyable = false;
		}

		public GuildDyeTub( Serial serial ) : base( serial )
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
		}
	}
}