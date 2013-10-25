// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 5<br>Duration: (Bonus * 3) Seconds<br>Target: Enemy<br>Prevents the target from defending it's self properly halving their resistance." )]
	public class GuardOffSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"GuardOff", "", 260 );

		public override int PowerLevel{ get{ return 5; } }

		public GuardOffSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				//target.FixedEffect( 0x37B9, 10, 5 );

				// West
				Effects.SendMovingEffect( 
					new Entity( Serial.Zero, new Point3D( target.X, target.Y, target.Z - 15 ), target.Map ), 
					new Entity( Serial.Zero, new Point3D( target.X - 7, target.Y, target.Z + 20 ), target.Map ), 
					14678, 5, 1, false, false, 1, 4 );

				// North
				Effects.SendMovingEffect( 
					new Entity( Serial.Zero, new Point3D( target.X, target.Y, target.Z - 15 ), target.Map ), 
					new Entity( Serial.Zero, new Point3D( target.X, target.Y - 7, target.Z + 20 ), target.Map ), 
					14662, 5, 1, false, false, 1, 4 );

				// East
				Effects.SendMovingEffect( 
					new Entity( Serial.Zero, new Point3D( target.X, target.Y, target.Z - 15 ), target.Map ), 
					new Entity( Serial.Zero, new Point3D( target.X + 7, target.Y, target.Z + 20 ), target.Map ), 
					14678, 5, 1, false, false, 1, 4 );

				// South
				Effects.SendMovingEffect( 
					new Entity( Serial.Zero, new Point3D( target.X, target.Y, target.Z - 15 ), target.Map ), 
					new Entity( Serial.Zero, new Point3D( target.X, target.Y + 7, target.Z + 20 ), target.Map ), 
					14662, 5, 1, false, false, 1, 4 );


				BeginGuardOff( target, Caster );

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}

			FinishSequence();
		}

		private static Dictionary<Serial, Timer> m_Table = new Dictionary<Serial, Timer>();

		public static void BeginGuardOff( Mobile m, Mobile caster )
		{
			if ( m_Table.ContainsKey( m.Serial ) )
			{
				Timer timer = m_Table[m.Serial];
				timer.Stop();
				m_Table.Remove( m.Serial );
			}

			List<ResistanceMod> mods = new List<ResistanceMod>();
			mods.Add( new ResistanceMod( ResistanceType.Physical, -(m.PhysicalResistance / 2) ) );
			mods.Add( new ResistanceMod( ResistanceType.Fire, -(m.FireResistance / 2) ) );
			mods.Add( new ResistanceMod( ResistanceType.Cold, -(m.ColdResistance / 2) ) );
			mods.Add( new ResistanceMod( ResistanceType.Poison, -(m.PoisonResistance / 2) ) );
			mods.Add( new ResistanceMod( ResistanceType.Energy, -(m.EnergyResistance / 2) ) );

			Double duration = ( BlueSpell.ScaleBySkill( caster, SkillName.Forensics ) * 3.0 );

			InternalTimer timertostart = new InternalTimer( m, mods, duration );
			timertostart.Start();
			m_Table.Add( m.Serial, timertostart );

			for ( int i = 0; i < mods.Count; ++i )
				m.AddResistanceMod( mods[i] );

			m.SendMessage( "Your guard has been lowered" );
		}

		public static void EndGuardOff( Mobile m, List<ResistanceMod> mods )
		{
			for ( int i = 0; i < mods.Count; ++i )
				m.RemoveResistanceMod( mods[i] );

			Timer t = m_Table[m.Serial];

			if ( t != null )
				t.Stop();

			m_Table.Remove( m.Serial );

			m.SendMessage( "Your guard returns to normal" );
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private List<ResistanceMod> m_Mods;

			public InternalTimer( Mobile m, List<ResistanceMod> mods, double duration ) : base( TimeSpan.FromSeconds( duration ) )
			{
				m_Mobile = m;
				m_Mods = mods;
			}

			protected override void OnTick()
			{
				EndGuardOff( m_Mobile, m_Mods );
			}
		}
	}
}