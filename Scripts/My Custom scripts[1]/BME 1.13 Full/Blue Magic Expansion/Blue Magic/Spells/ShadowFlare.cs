// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 8<br>Duration: Instantaneous<br>Target: Enemy, Area 5<br>Deals a large amount of damage to an area after a brief delay." )]
	public class ShadowFlareSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"ShadowFlare", "", 203 );

		public override int PowerLevel{ get{ return 8; } }
		public override int Range{ get{ return 3; } }

		public ShadowFlareSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new BlueSpellTarget( this, TargetFlags.Harmful, true );
		}

		public override void OnTarget( Point3D target )
		{
				new InternalTimer( this, target ).Start();
				//mob.PlaySound( 0x5C8 );
		}

		public override void VisualEffects( Point3D point )
		{
			/* SendLocationParticles( 
			IEntity e, 
			int itemID, int speed, int duration, int hue, int renderMode, int effect, int unknown ); */

			// Effects.SendLocationEffect( point, Caster.Map, 0x3728, 13 );
			Effects.SendLocationEffect( point, Caster.Map, 0x3728, 13, 1435, 4 );

			//Effects.SendLocationParticles(
				//new Entity( Serial.Zero, point, Caster.Map ), 
				//0x3660 /*itemid*/, 1 /*speed*/, 15 /*duration*/, 1102 /*hue*/, 4 /*renderMode*/, 0 /*effect*/, 0 /*unknown*/ );
		}

		public override void SpellEffect( Mobile target )
		{
			int dam = GetDamage( Caster, target, CastSkill, 2.0 );
			dam += GetDamage( Caster, target, DamageSkill, 2.0 );
			SpellHelper.Damage( this, target, dam, 20, 20, 20, 20, 20 );
			BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
		}

		private class InternalTimer : Timer
		{
			private ShadowFlareSpell m_Spell;
			private Point3D m_Target;
			private int m_Count;

			public InternalTimer( ShadowFlareSpell spell, Point3D target ) : base( TimeSpan.FromMilliseconds( 50.0 ), TimeSpan.FromMilliseconds( 50.0 ) )
			{
				m_Spell = spell;
				m_Target = target;
				m_Count = 0;
			}

			protected override void OnTick()
			{
				m_Count++;

				if ( m_Count < 17 )
				{
					Effects.SendMovingParticles( 
						new Entity( Serial.Zero, new Point3D( m_Target.X - Utility.RandomMinMax( -7, 7 ), m_Target.Y - Utility.RandomMinMax( -7, 7 ), m_Target.Z ), m_Spell.Caster.Map ), 
						new Entity( Serial.Zero, new Point3D( m_Target.X, m_Target.Y, m_Target.Z+10 ), m_Spell.Caster.Map ), 
						0x36D4, 15, 0, false, false/*Explodes*/, 1174/*hue*/, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

					if ( m_Count % 2 == 0 )
						Effects.SendLocationParticles( EffectItem.Create( m_Target, m_Spell.Caster.Map, EffectItem.DefaultDuration ), 
							0x3660/*ItemID*/, 1/*Speed*/, 15/*Duration*/, 1101+(m_Count/2)/*Hue*/, 4/*RenderMode*/, 0/*Effect*/, 0/*Unknown*/ );

				}
				else if ( m_Count < 20 )
				{
					if ( m_Count % 2 == 0 )
						Effects.SendLocationParticles( EffectItem.Create( m_Target, m_Spell.Caster.Map, EffectItem.DefaultDuration ), 
							0x3660/*ItemID*/, 1/*Speed*/, 15/*Duration*/, 1174/*Hue*/, 4/*RenderMode*/, 0/*Effect*/, 0/*Unknown*/ );
				}
				else
				{
					m_Spell.DoBurstEffect( m_Spell, m_Target );
					Stop();
				}
			}
		}



	}
}
/*
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X - Utility.Random( 5 ), mob.Y - Utility.Random( 5 ), mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 ); // 1174 = hue
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X - Utility.Random( 5 ), mob.Y + Utility.Random( 5 ), mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X + Utility.Random( 5 ), mob.Y - Utility.Random( 5 ), mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X + Utility.Random( 5 ), mob.Y + Utility.Random( 5 ), mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X - Utility.Random( 5 ), mob.Y, mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X, mob.Y - Utility.Random( 5 ), mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X + Utility.Random( 5 ), mob.Y, mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
				Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( mob.X, mob.Y + Utility.Random( 5 ), mob.Z ), mob.Map ), mob, 0x36D4, 15, 0, false, true, 1174, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

*/