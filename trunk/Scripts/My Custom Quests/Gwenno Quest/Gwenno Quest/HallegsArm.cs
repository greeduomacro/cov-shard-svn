using System;
using Server.Items;

namespace Server.Items
{
	public class HallegsArm : Item
	{
		[Constructable]
		public HallegsArm() : base( 0x1DA2 )
		{
			Movable = true;
			Name = "Halleg's Arm";
		}

		public HallegsArm( Serial serial ) : base( serial )
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
