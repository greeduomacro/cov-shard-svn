// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server.Spells;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 7<br>Duration: Instantaneous<br>Target: Cone 1~7<br>The caster breathes a cloud of highly toxic gas infecting them with many ailments." )]
	public class BadBreathSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"BadBreath", "", 230 );

		public override int PowerLevel{ get{ return 7; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Cone; } }
		public override int Range{ get{ return GetRange(); } }

		private int GetRange() // Every 20.0 in CastSkill = +1 to range.
		{
			if ( Caster != null )
				return (int)(Caster.Skills[CastSkill].Value * 0.05);
			else
				return 5;
		}

		public BadBreathSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnCast()
		{
			base.OnCast();

			if ( Caster.Female )
				Caster.PlaySound( 0x337 );
			else
				Caster.PlaySound( 0x449 );
		}

		public bool FullPower()
		{
			if ( Caster is BaseCreature || Caster.AccessLevel > AccessLevel.Player )
				return true;
			else if ( Caster is PlayerMobile )
			{
				if ( Caster.FindItemOnLayer( Layer.Ring ) is MalborosRing )
					return true;
				else
					return false;
			}
			else
				return false;
		}

		public override void SpellEffect( Mobile target )
		{
			if ( target == Caster )
				return;

			target.SendMessage( "You breath in a noxious gas" );

			// Done primarly to draw aggro.
			SpellHelper.Damage( this, target, GetDamage( Caster, target, DamageSkill, 0.5 ), 0, 0, 100, 0, 0 );

			if ( target == null )
				return;

			int dc = 10 + (int)ScaleBySkill( Caster, DamageSkill );
			int debuff = (int)( ScaleBySkill( Caster, DamageSkill ) / 2 );
			debuff = -debuff;
			bool totalfail = true;

			StringBuilder sb = new StringBuilder();
			sb.Append( "You see " );
			sb.Append( target.Name );
			sb.Append( " suffer penalties to:" );

			if ( FullPower() )
				dc += 120;

			if ( !SavingThrow( target, DDSave.Will, dc ) )
			{
				Slow.SlowWalk( target, dc*2 );
				target.SendMessage( "You have been slowed" );
				sb.Append (" Speed" );
				totalfail = false;
			}

			if ( !SavingThrow( target, DDSave.Fort, dc ) )
			{
				target.AddSkillMod( new TimedSkillMod( SkillName.Tactics, true, debuff, TimeSpan.FromSeconds( dc*2 ) ) );
				target.AddStatMod( new StatMod( StatType.Str, "Bad Breath Str", debuff, TimeSpan.FromSeconds( dc*2 ) ) );
				target.AddStatMod( new StatMod( StatType.Dex, "Bad Breath Dex", debuff, TimeSpan.FromSeconds( dc*2 ) ) );
				target.AddStatMod( new StatMod( StatType.Int, "Bad Breath Int", debuff, TimeSpan.FromSeconds( dc*2 ) ) );
				sb.Append( " Tactics" );
				totalfail = false;

				if ( dc > 120 )
					target.AddSkillMod( new TimedSkillMod( SkillName.MagicResist, true, debuff, TimeSpan.FromSeconds( dc*2 ) ) );
			}

			if ( !SavingThrow( target, DDSave.Refl, dc ) )
			{
				ResistanceMod[] mods =
				{
					new ResistanceMod( ResistanceType.Physical, debuff ),
					new ResistanceMod( ResistanceType.Fire, debuff ),
					new ResistanceMod( ResistanceType.Cold, debuff ),
					new ResistanceMod( ResistanceType.Poison, debuff ),
					new ResistanceMod( ResistanceType.Energy, debuff )
				};

				for ( int i = 0; i < mods.Length; ++i )
					target.AddResistanceMod( mods[i] );

				TimedResistanceMod.AddMod( target, "Bad Breath", mods, TimeSpan.FromSeconds( Caster.Skills[DamageSkill].Value ) );
				sb.Append( " Resistance" );
				totalfail = false;
			}

			if ( dc > 120 )
			{
				target.ApplyPoison( Caster, Poison.Greater );
			}

			if ( totalfail )
				Caster.SendMessage( target.Name + " saved against your spell." );
			else
				Caster.SendMessage( sb.ToString() );
		}

		public override void VisualEffects( Point3D point )
		{
			Effects.SendLocationParticles( EffectItem.Create( point, Caster.Map, EffectItem.DefaultDuration ), 
				0x36BD/*ItemID*/, 1/*Speed*/, 20/*Duration*/, 1154/*Hue*/, 4/*RenderMode*/, 0/*Effect*/, 0/*Unknown*/ );
		}
	}
}