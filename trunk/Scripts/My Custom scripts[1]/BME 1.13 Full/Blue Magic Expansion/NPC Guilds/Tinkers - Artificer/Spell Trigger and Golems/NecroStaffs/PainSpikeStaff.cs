// Created by Peoharen
using System;
using Server;
using Server.Spells.Necromancy;

namespace Server.Items
{
	public class PainSpikeStaff : BaseNecroStaff
	{
		[Constructable]
		public PainSpikeStaff() : base( 15 )
		{
			Name = "Staff of Pain Spike";
		}

		public override void OnWandUse( Mobile from )
		{
			Cast( new PainSpikeSpell( from, this ) );
		}

		public PainSpikeStaff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}