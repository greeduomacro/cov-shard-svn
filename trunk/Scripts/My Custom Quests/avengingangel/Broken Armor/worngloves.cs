/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class WornGloves : PlateGloves
	{
		[Constructable]
		public WornGloves()
		{
			Name = "Worn Plate Gloves";
			Hue = 1355;
			PoisonBonus = -13;
			EnergyBonus = -13;
			ColdBonus = -13;
			FireBonus = -13;
			PhysicalBonus = -13;
		}

		public WornGloves( Serial serial ) : base( serial )
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

		
		}
	}
}