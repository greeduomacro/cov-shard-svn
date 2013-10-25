/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class AvengingAngelLeggings : PlateLegs
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public AvengingAngelLeggings()
		{
			Name = "Leggings of the Avenging Angel";
			Hue = 2406;
            Attributes.Luck = 100;
            Attributes.DefendChance = 5;
            Attributes.LowerRegCost = 20;
            Attributes.LowerManaCost = 2;
            Attributes.BonusInt = 2;
            Attributes.BonusDex = 2;
            Attributes.BonusHits = 2;
            Attributes.BonusMana = 2;
            Attributes.RegenHits = 1;
            Attributes.BonusHits = 2;
            Attributes.RegenMana = 3;
            Attributes.CastSpeed = 1;
            Attributes.SpellDamage = 2;
            Attributes.CastRecovery = 1;
            Attributes.RegenStam = 3;
            FireBonus = 10;
            ColdBonus = 10;
            PoisonBonus = 10;
            PhysicalBonus = 10;
            EnergyBonus = 10;
		
		}

		public AvengingAngelLeggings( Serial serial ) : base( serial )
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