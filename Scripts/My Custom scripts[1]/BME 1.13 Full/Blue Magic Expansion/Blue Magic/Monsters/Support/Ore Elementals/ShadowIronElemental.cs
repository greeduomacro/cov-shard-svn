// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class BlueShadowIronElemental : ShadowIronElemental
	{
		[Constructable]
		public BlueShadowIronElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueShadowIronElemental( int oreamount ) : base( oreamount )
		{
		}

		/*
		Done in ShadowIronElemental
		public override bool BreathImmune{ get{ return true; } }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled || bc.BardTarget == this )
					damage = 0; // Immune to pets and provoked creatures
			}
		}

		public override void AlterDamageScalarFrom( Mobile caster, ref double scalar )
		{
			scalar = 0.0; // Immune to magic
		}
		
		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			damage = 0;
		}
		*/

		public BlueShadowIronElemental( Serial serial ) : base( serial )
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