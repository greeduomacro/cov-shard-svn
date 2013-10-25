/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class AvengingAngelArms : PlateArms
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public AvengingAngelArms()
		{
			Name = "Arms of the Avenging Angel";
			Hue = 2406;
            Attributes.SpellDamage = 10;
            ArmorAttributes.MageArmor = 1;
            Attributes.LowerRegCost = 15;
            Attributes.BonusHits = 5;
            Attributes.BonusMana = 5;         
            Attributes.RegenMana = 3;          
            Attributes.Luck = 100;
            FireBonus = 2;
            ColdBonus = 2;
            PoisonBonus = 2;
            PhysicalBonus = 2;
            EnergyBonus = 2;
		
		}

		public AvengingAngelArms( Serial serial ) : base( serial )
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