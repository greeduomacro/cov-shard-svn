using System;

namespace Server.Items
{
	public class SCFBL : Boots
	{
		//public override int LabelNumber{ get{ return 1074676; } } // Grobu's Fur
	
		[Constructable]
		public SCFBL() : base()
		{
            Name = "Santa's Stolen Boots";
			Weight = 1.0;
			Hue = 1;
		}

        public SCFBL(Serial serial)
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

