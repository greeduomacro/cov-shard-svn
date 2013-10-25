/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;

namespace Server.Items
{
	public class EnergizedIngot : Item
	{
		[Constructable]
		public EnergizedIngot() : base( 0x1BF2 )
		{
			Name = "Energized Ingot";
			Hue= 1286;
			Weight = 0.1;	

		}

		public EnergizedIngot( Serial serial ) : base( serial )
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