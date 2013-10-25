using System;
using Server;

namespace Server.Items
{
	public class KageDyeTub : DyeTub
	{
        public override bool AllowLeather { get { return true; } }
        public virtual bool AllowDyables { get { return true; } }
        public override CustomHuePicker CustomHuePicker { get { return CustomHuePicker.LeatherDyeTub; } }


		[Constructable]
		public KageDyeTub()
		{
			Hue = DyedHue = 1153;
			Redyable = false;
		}

		public KageDyeTub( Serial serial ) : base( serial )
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