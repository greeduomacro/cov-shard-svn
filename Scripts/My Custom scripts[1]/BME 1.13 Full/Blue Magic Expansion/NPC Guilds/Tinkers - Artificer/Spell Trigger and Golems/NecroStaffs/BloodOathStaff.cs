// Created by Peoharen
using System;
using Server;
using Server.Spells.Necromancy;

namespace Server.Items
{
	public class BloodOathStaff : BaseNecroStaff
	{
		[Constructable]
		public BloodOathStaff() : base( 10 )
		{
			Name = "Staff of Blood Oath";
		}

		public override void OnWandUse( Mobile from )
		{
			Cast( new BloodOathSpell( from, this ) );
		}

		public BloodOathStaff( Serial serial ) : base( serial )
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