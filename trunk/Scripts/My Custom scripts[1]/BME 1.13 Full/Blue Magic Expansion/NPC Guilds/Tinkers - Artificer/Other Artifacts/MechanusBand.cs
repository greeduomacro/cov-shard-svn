// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class MechanusBand : GoldBracelet, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable]
		public MechanusBand()
		{
			Name = "Mechanus Band";
			Hue = 1190;
			LootType = LootType.Blessed;
			Attributes.SpellDamage = 25;
		}

		public MechanusBand( Serial serial ) : base( serial )
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