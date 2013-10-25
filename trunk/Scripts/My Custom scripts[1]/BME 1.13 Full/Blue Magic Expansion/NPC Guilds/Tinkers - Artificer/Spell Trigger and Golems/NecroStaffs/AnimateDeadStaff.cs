// Created by Peoharen
using System;
using Server;
using Server.Spells.Necromancy;

namespace Server.Items
{
	public class AnimateDeadStaff : BaseNecroStaff
	{
		[Constructable]
		public AnimateDeadStaff() : base( 10 )
		{
			Name = "Staff of Animate Dead";
		}

		public override void OnWandUse( Mobile from )
		{
			Cast( new AnimateDeadSpell( from, this ) );
		}

		public AnimateDeadStaff( Serial serial ) : base( serial )
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