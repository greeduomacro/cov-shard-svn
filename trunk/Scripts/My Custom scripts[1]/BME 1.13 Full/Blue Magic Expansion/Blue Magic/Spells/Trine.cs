// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 6<br>Duration: Delayed & Instantaneous<br>Target: Area<br>The caster creates several explosive runes on the ground which explode after some time." )]
	public class TrineSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"Trine", "", 230 );

		public override int PowerLevel{ get{ return 6; } }

		public TrineSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new BlueSpellTarget( this, TargetFlags.Harmful, true );
		}

		/*
		X>-3-2-1 0 1 2 3
		-3|_|_|_|_|_|_|_|
		-2|_|_|_|_|0|_|_|
		-1|_|_|_|0|0|_|_|
		 0|_|_|0|X|0|_|_|
		 1|_|0|0|0|0|_|_|
		 2|_|_|_|_|_|_|_|
		 3|_|_|_|_|_|_|_|
		*/

		private int[] m_Points = 
		{
			-2, 1,
			-1, 0,
			-1, 1,
			0, -1,
			0, 0,
			0, 1,
			1, -2,
			1, -1,
			1, 0,
			1, 1,
		};

		public override void OnTarget( Point3D point )
		{
			DateTime time = DateTime.Now + TimeSpan.FromSeconds( 12 );

			for( int i = 0; i < m_Points.Length; i += 2 )
			{
				new TrineItem( this, time ).MoveToWorld( new Point3D( point.X+m_Points[i], point.Y+m_Points[i+1], point.Z ), Caster.Map );
			}
		}
	}

	public class TrineItem : Item
	{
		private TrineSpell m_Spell;
		private DateTime m_RemoveAt;
		private bool m_JustRemove;

		public TrineItem( TrineSpell spell, DateTime removeat ) : base( 1181 )
		{
			Hue = 1150;
			ItemID = Utility.RandomList( 3676, 3679, 3682, 3685, 3688 );
			Name = "A glowing rune";
			m_Spell = spell;
			m_RemoveAt = removeat;
			m_JustRemove = false;
			Timer.DelayCall( TimeSpan.FromSeconds( 0.05 ), new TimerCallback( Check ) );
		}

		public override bool OnMoveOver( Mobile m )
		{
			Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );
			Ability.Aura( Location, Map, m_Spell.Caster, BlueSpell.GetDamage( m_Spell.Caster, m, m_Spell.DamageSkill, 1.5 ), BlueSpell.GetDamage( m_Spell.Caster, m, m_Spell.DamageSkill, 1.5 ), ResistanceType.Fire, 0, null, "", false, false );
			//SpellHelper.Damage( m_Spell, m, BlueSpell.GetDamage( m_Spell.Caster, m, m_Spell.DamageSkill, 1.5 ), 0, 0, 0, 0, 100 );
			m_JustRemove = true;

			return true;
		}

		private void Check()
		{
			if ( Deleted )
				return;
			if ( m_JustRemove )
				Delete();
			else if  ( !(DateTime.Now >= m_RemoveAt) )
				Timer.DelayCall( TimeSpan.FromSeconds( 0.05 ), new TimerCallback( Check ) );
			else
			{
				Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );
				//Ability.Aura( Location, Map, m_From, m_Damage, m_Damage, ResistanceType.Fire, 0, null, "", false, false );
				Ability.Aura( Location, Map, m_Spell.Caster, BlueSpell.GetDamage( m_Spell.Caster, null, m_Spell.DamageSkill, 1.5 ), BlueSpell.GetDamage( m_Spell.Caster, null, m_Spell.DamageSkill, 1.5 ), ResistanceType.Fire, 0, null, "", false, false );

				/*
				List<Mobile> mobiles = new List<Mobile>();

				foreach( Mobile m in GetMobilesInRange( 0 ) )
				{
					if ( m != null && BlueSpell.CanTarget( m_Spell.Caster, m, true ) )
						mobiles.Add( m );
				}

				for ( int i = 0; i < mobiles.Count; i++ )
				{
					if ( mobiles[i] != null )
						SpellHelper.Damage( m_Spell, mobiles[i], BlueSpell.GetDamage( m_Spell.Caster, mobiles[i], m_Spell.DamageSkill, 2.0 ), 0, 0, 0, 0, 100 );
				}
				*/

				Delete();
			}
		}

		public TrineItem( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Delete();
		}
	}
}
