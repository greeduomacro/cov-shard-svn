// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ore elemental corpse" )]
	public class BlueCopperElemental : CopperElemental
	{
		[Constructable]
		public BlueCopperElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueCopperElemental( int oreamount ) : base( oreamount )
		{
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null )
				from.Damage( (damage / 2), this );
		}

		/*
		Done in CopperElemental
		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true; // Every spell is reflected back to the caster
		}
		*/

		public BlueCopperElemental( Serial serial ) : base( serial )
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