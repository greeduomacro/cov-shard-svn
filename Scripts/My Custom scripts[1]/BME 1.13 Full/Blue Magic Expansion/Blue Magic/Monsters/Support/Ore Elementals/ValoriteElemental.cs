// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ore elemental corpse" )]
	public class BlueValoriteElemental : ValoriteElemental
	{
		[Constructable]
		public BlueValoriteElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueValoriteElemental( int oreamount ) : base( oreamount )
		{
		}

		private DateTime m_GasDelay;

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_GasDelay )
			{
				if ( Combatant != null )
				{
					Combatant.FixedEffect( 0x3709, 10, 30, 1149, 4 );
					AOS.Damage( Combatant, this, Utility.RandomMinMax( DamageMax, (DamageMax * 2) ), 0, 25, 25, 50, 0 );
				}

				m_GasDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 6, 12 ) );
			}

			base.OnActionCombat();
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled || bc.BardTarget == this )
					damage = 0; // Immune to pets and provoked creatures
			}
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true; // Every spell is reflected back to the caster
		}

		public BlueValoriteElemental( Serial serial ) : base( serial )
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