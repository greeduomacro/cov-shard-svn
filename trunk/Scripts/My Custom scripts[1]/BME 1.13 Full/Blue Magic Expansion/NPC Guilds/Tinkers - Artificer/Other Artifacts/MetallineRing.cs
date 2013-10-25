// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class MetallineRing : GoldRing, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable]
		public MetallineRing()
		{
			Name = "Metalline Ring";
			Hue = 1190;
			LootType = LootType.Blessed;
			Attributes.SpellDamage = 25;
		}

		public MetallineRing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}
