/*

Scripted by Rosey1
Thought up by Ashe


*/

using System;
using Server;

namespace Server.Items
{
	public class AvengingAngelGorget : PlateGorget
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public AvengingAngelGorget()
		{
			Name = "Gorget of the Avenging Angel";
			Hue = 2406;
            Attributes.Luck = 100;
            Attributes.LowerManaCost = 5;
            Attributes.BonusHits = 5;
            Attributes.BonusMana = 5;
            Attributes.RegenMana = 3;
            Attributes.BonusDex = 5;
            Attributes.RegenHits = 2;
            Attributes.RegenStam = 2;
            Attributes.CastSpeed = 1;
            Attributes.SpellDamage = 5;
            Attributes.CastRecovery = 1;
            FireBonus = 5;
            ColdBonus = 5;
            PoisonBonus = 5;
            PhysicalBonus = 5;
            EnergyBonus = 5;
		
		}

		public AvengingAngelGorget( Serial serial ) : base( serial )
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