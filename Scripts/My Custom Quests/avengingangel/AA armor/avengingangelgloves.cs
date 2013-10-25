/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class AvengingAngelGloves : PlateGloves
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public AvengingAngelGloves()
		{
			Name = "Gloves of the Avenging Angel";
			Hue = 2406;
            Attributes.LowerRegCost = 20;
            Attributes.BonusInt = 3;
            Attributes.RegenMana = 3;
            Attributes.LowerManaCost = 3;
            Attributes.RegenHits = 3;
            Attributes.BonusMana = 5;
            Attributes.CastSpeed = 1;
            Attributes.SpellDamage = 2;
            Attributes.Luck = 100;
            FireBonus = 2;
            ColdBonus = 2;
            PoisonBonus = 2;
            PhysicalBonus = 2;
            EnergyBonus = 2;
		
		}

		public AvengingAngelGloves( Serial serial ) : base( serial )
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