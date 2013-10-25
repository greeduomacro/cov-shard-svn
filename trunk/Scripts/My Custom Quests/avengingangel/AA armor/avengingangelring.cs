/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class AvengingAngelRing : GoldRing
	{
		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public AvengingAngelRing()
		{
			Name = "Ring of the Avenging Angel";
			Hue = 1286;
			Attributes.NightSight = 1;
			Attributes.LowerRegCost = 20;
			Attributes.LowerManaCost = 10;
			Attributes.SpellDamage = 10;
		}

		public AvengingAngelRing( Serial serial ) : base( serial )
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