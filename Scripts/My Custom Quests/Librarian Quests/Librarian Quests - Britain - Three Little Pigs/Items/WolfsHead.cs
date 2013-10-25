using System;
using Server;

namespace Server.Items
{
	public class WolfsHead : BearMask
	{
		public override int LabelNumber{ get{ return 1070637; } }

		[Constructable]
		public WolfsHead()
		{
			Hue = 32;
			Name = "The Big Bad Wolf's Head";
			
		}

        public WolfsHead(Serial serial)
            : base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			
		}
	}
}