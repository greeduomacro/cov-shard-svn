// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class BlueVeriteElemental : VeriteElemental
	{
		[Constructable]
		public BlueVeriteElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueVeriteElemental( int oreamount ) : base( oreamount )
		{
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to != null )
				Ability.DamageArmor( to, 5, 10 );
		}

		public BlueVeriteElemental( Serial serial ) : base( serial )
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