// Created by Peoharen
using System;
using Server;
using Server.Spells.Necromancy;

namespace Server.Items
{
	public class CorpseSkinStaff : BaseNecroStaff
	{
		[Constructable]
		public CorpseSkinStaff() : base( 15 )
		{
			Name = "Staff of Corpse Skin";
		}

		public override void OnWandUse( Mobile from )
		{
			Cast( new CorpseSkinSpell( from, this ) );
		}

		public CorpseSkinStaff( Serial serial ) : base( serial )
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