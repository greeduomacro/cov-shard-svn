/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class AvengingAngelHelmet : PlateHelm
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public AvengingAngelHelmet()
		{
			Name = "Helmet of the Avenging Angel";
			Hue = 2406;
			PoisonBonus = 5;
			EnergyBonus = 10;
			ColdBonus = 5;
			FireBonus = 5;
			PhysicalBonus = 7;
			Attributes.ReflectPhysical = 10;
			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.DurabilityBonus = 120;
		
		}

		public AvengingAngelHelmet( Serial serial ) : base( serial )
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