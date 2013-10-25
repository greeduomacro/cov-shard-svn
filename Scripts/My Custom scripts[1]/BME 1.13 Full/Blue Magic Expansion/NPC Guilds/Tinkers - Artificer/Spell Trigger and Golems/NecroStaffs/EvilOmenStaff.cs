// Created by Peoharen
using System;
using Server;
using Server.Spells.Necromancy;

namespace Server.Items
{
	public class EvilOmenStaff : BaseNecroStaff
	{
		[Constructable]
		public EvilOmenStaff() : base( 15 )
		{
			Name = "Staff of Evil Omen";
		}

		public override void OnWandUse( Mobile from )
		{
			Cast( new EvilOmenSpell( from, this ) );
		}

		public EvilOmenStaff( Serial serial ) : base( serial )
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