using System;

namespace Server.Items
{
	public class AbominableSnowmansFur : Item
	{
		//public override int LabelNumber{ get{ return 1074676; } } // Grobu's Fur
	
		[Constructable]
		public AbominableSnowmansFur() : base( 0x11F4 )
		{
            Name = "Abominable Snowman's Fur";
			Weight = 1.0;
			Hue = 1153;
		}

        public AbominableSnowmansFur(Serial serial)
            : base(serial)
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

