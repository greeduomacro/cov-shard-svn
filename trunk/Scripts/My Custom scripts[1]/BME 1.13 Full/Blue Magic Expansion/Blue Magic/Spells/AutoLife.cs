// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 8<br>Duration: Up to 9 minutes.<br>Target: Living Ally<br>While under the effects of this spell your hit point regeneration is increased and it will restore your life if you die.<br><br>Secondary Effect<br>Level: 8<br>Duration: Instantaneous<br>Target: Dead player or pet.<br>Resurrects the target." )]
	public class AutoLifeSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
		"AutoLife", "", 230 );

		public override int PowerLevel{ get{ return 8; } }
		public override bool IsHarmful{ get{ return false; } }

		public AutoLifeSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckBSequence( target, true ) )
			{
				if ( target is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)target;

					if ( !bc.IsDeadPet )
					{
						Caster.SendMessage( "That animal is still alive." );
					}
					else if ( bc.ControlMaster != null )
					{
						bc.ControlMaster.CloseGump( typeof( PetResurrectGump ) );
						bc.ControlMaster.SendGump( new PetResurrectGump( Caster, bc ) );
						AutoLifeSpell.ResurrectEffect( bc );
					}
				}
				else if ( !target.Alive )
				{
					target.CloseGump( typeof( AutoLifeGump ) );
					target.SendGump( new AutoLifeGump() );
				}
				else if ( target is PlayerMobile )
				{
					PlayerMobile pm = (PlayerMobile)target;
					BeginAutoLife( pm, (int)(ScaleBySkill( Caster, DamageSkill ) * 3) );
					BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
				}
			}

			FinishSequence();
		}

		public static void ResurrectEffect( Mobile m )
		{
			m.PlaySound( 0x214 );

			Effects.SendLocationParticles( 
				EffectItem.Create( new Point3D( m.X - 1, m.Y - 1, m.Z ), m.Map, EffectItem.DefaultDuration ), 
				0x3709, 10, 30, 1153, 4, 0, 0);
			Effects.SendLocationParticles( 
				EffectItem.Create( new Point3D( m.X - 1, m.Y + 1, m.Z ), m.Map, EffectItem.DefaultDuration ), 
				0x3709, 10, 30, 1153, 4, 0, 0);
			Effects.SendLocationParticles( 
				EffectItem.Create( new Point3D( m.X + 1, m.Y - 1, m.Z ), m.Map, EffectItem.DefaultDuration ), 
				0x3709, 10, 30, 1153, 4, 0, 0);
			Effects.SendLocationParticles( 
				EffectItem.Create( new Point3D( m.X + 1, m.Y + 1, m.Z ), m.Map, EffectItem.DefaultDuration ), 
				0x3709, 10, 30, 1153, 4, 0, 0);
		}

		#region Tracking
		private static Dictionary<Serial, Timer> m_Table = new Dictionary<Serial, Timer>();

		public static void CheckStatus( PlayerMobile pm )
		{
			if ( pm == null )
				return;

			if ( pm.Alive )
				pm.Hits += 5;
			else
			{
				pm.CloseGump( typeof( AutoLifeGump ) );
				pm.SendGump( new AutoLifeGump() );
			}
		}

		public static bool HasAutoLife( PlayerMobile pm )
		{
			return m_Table.ContainsKey( pm.Serial );
		}

		public static void BeginAutoLife( PlayerMobile pm, int duration )
		{
			if ( m_Table.ContainsKey( pm.Serial ) )
			{
				Timer timer = m_Table[pm.Serial];
				timer.Stop();
				m_Table.Remove( pm.Serial );
			}

			InternalTimer timertostart = new InternalTimer( pm, duration );
			timertostart.Start();
			m_Table.Add( pm.Serial, timertostart );
			pm.SendMessage( 1365, "You gain the benefit of Auto-Life." );
		}

		public static void EndAutoLife( PlayerMobile pm )
		{
			if ( m_Table.ContainsKey( pm.Serial ) )
			{
				pm.SendMessage( 1365, "You no longer have the benefit of Auto-Life." );
				CheckStatus( pm );

				Timer t = m_Table[pm.Serial];

				if ( t != null )
					t.Stop();

				m_Table.Remove( pm.Serial );
			}
		}

		private class InternalTimer : Timer
		{
			private PlayerMobile m_PM;
			private int m_Count;
			private int m_MaxCount;

			public InternalTimer( PlayerMobile pm, int duration ) : base( TimeSpan.FromSeconds( 6.0 ), TimeSpan.FromSeconds( 6.0 ) )
			{
				m_PM = pm;
				m_Count = 0;
				m_MaxCount = duration;
			}

			protected override void OnTick()
			{
				if ( m_PM == null )
					Stop();
				else if ( !AutoLifeSpell.HasAutoLife( m_PM ) )
					Stop();
				else if ( m_Count > m_MaxCount )
					AutoLifeSpell.EndAutoLife( m_PM );
				else
				{
					AutoLifeSpell.CheckStatus( m_PM );
					m_Count++;
				}
			}
		}
		#endregion

		public class AutoLifeGump : Gump
		{
			public AutoLifeGump() : base( 25, 25 )
			{
				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddPage( 0 );

				AddBackground(0, 0, 275, 75, 9270 );
				AddImage( 15, 15, 2298, 1365 );
				AddLabel( 70, 15, 1365, "Auto Life" );
				AddLabel( 70, 35, 1365, "Resurrect now?" );
				AddButton( 194, 25, 247, 248, 1, GumpButtonType.Reply, 0 );
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( sender.Mobile == null || sender.Mobile.Alive )
					return;
				else if ( info.ButtonID == 0 )
					return;

				Mobile m = sender.Mobile;

				AutoLifeSpell.ResurrectEffect( m );

				if ( m is PlayerMobile )
					AutoLifeSpell.EndAutoLife( (PlayerMobile)m );

				Misc.Titles.AwardFame( m, -(m.Fame / 10), true );
				m.Resurrect();

				if ( m.AccessLevel == AccessLevel.Player )
				{
					VirtueLevel level = VirtueHelper.GetLevel( m, VirtueName.Compassion );

					switch( level )
					{
						case VirtueLevel.Seeker: m.Hits = AOS.Scale( m.HitsMax, 20 ); break;
						case VirtueLevel.Follower: m.Hits = AOS.Scale( m.HitsMax, 40 ); break;
						case VirtueLevel.Knight: m.Hits = AOS.Scale( m.HitsMax, 80 ); break;
						default: m.Hits = 10; break;
					}
				}
				else
				{
					m.Hits = m.HitsMax;
					m.Stam = m.StamMax;
					m.Mana = m.ManaMax;
					m.Karma = m.Fame = 0;
					m.BodyValue = 987;
				}
			}
		}
	}
}