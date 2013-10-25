using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class LochNessShield : MetalKiteShield, ITokunoDyable 
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public LochNessShield()
		{
			Weight = 5.0;
            		Name = "The Shield Of The Lochness";
            		Hue = 1144;

			Attributes.AttackChance = 15;
			Attributes.DefendChance = 15;
			Attributes.SpellChanneling = 1;

			Attributes.Luck = 150;
			Attributes.NightSight = 1;
			ColdBonus = 10;
			FireBonus = 10;
			EnergyBonus = 10;
			PoisonBonus = 10;
			PhysicalBonus = 10;

			LootType = LootType.Blessed;
		}

		public LochNessShield( Serial serial ) : base( serial )
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