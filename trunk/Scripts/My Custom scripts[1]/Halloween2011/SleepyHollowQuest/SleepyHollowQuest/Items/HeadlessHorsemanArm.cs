using System;
using Server;

namespace Server.Items
{
	public class HeadlessHorsemanArm : Item
	{
		[Constructable]
		public HeadlessHorsemanArm() : base( 0x1DA2 )
		{
            Name = "Headless Horseman Arm";
            Hue = 1154;
		}

        public HeadlessHorsemanArm(Serial serial)
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