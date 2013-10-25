//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class UWaterController : Item
	{
		public Rectangle2D Rect = new Rectangle2D( 511, 1648, 400, 400 );
		public DrowningTimer m_Timer;
		private bool m_IsActive;

		[CommandProperty( AccessLevel.Seer )]
		public bool IsActive { get { return m_IsActive; } }

		[Constructable]
		public UWaterController() : base( 3806 )
		{
			bool remove = false;

			foreach ( Item item in World.Items.Values )
			{
				if ( remove == true )
					continue;

				if ( item is UWaterController && !item.Deleted && item != this )
					remove = true;
			}

			if ( remove )
			{
				World.Broadcast( 0x35, true, "Another water controller exists in the world!" );
				Delete();
				return;
			}

			Hue = 2101; //Silverish
			Movable = false;

			m_IsActive = false;
		}

		public override bool HandlesOnMovement { get { return !m_IsActive; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m.Player )
				if ( m.Map == Map.Malas )
					if ( m.X >= 511 && m.X <= 911 )
						StartTimer();

			base.OnMovement( m, oldLocation );
		}

		public void StartTimer()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = new DrowningTimer( this );
			m_Timer.Start();

			m_IsActive = true;
		}


		public void StopTimer()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_IsActive = false;
		}

		public UWaterController( Serial serial ) : base( serial )
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
		}

		public class DrowningTimer : Timer
		{
			public UWaterController m_Controller;

			public DrowningTimer( UWaterController controller ) : base( TimeSpan.FromSeconds( 6.0 ) )
			{
				m_Controller = controller;
			}

			public bool CanBreath( Mobile m )
			{
				return /*m.FindItemOnLayer( Layer.Neck ) is GillGorget |*/ m.CanSwim;
			}

			protected override void OnTick()
			{
				//CheckAlive();

				List<Mobile> targets = new List<Mobile>();

				foreach ( Mobile m in Map.Malas.GetMobilesInBounds( m_Controller.Rect ) )
				{
					if ( m is PlayerMobile || ( m is BaseCreature && ((BaseCreature)m).ControlMaster is PlayerMobile) )
						targets.Add( m );
				}

				if ( targets.Count == 0 )
					m_Controller.StopTimer();
				else
				{
					for ( int i = 0; i < targets.Count; ++i )
					{
						if ( targets[i] == null )
							continue;

						if ( targets[i].Z > -90 || CanBreath( targets[i] ) )
							continue;

						targets[i].PlaySound( 868 );
						targets[i].SendMessage( "You cannot breath!" );
						targets[i].PlaySound( targets[i].Female ? 793 : 1065 );
						targets[i].Damage( Utility.Random( 25, 45 ) );
						targets[i].Animate( 32, 5, 1, true, false, 0 );
						targets[i].Stam -= 10;
					}
				}

				targets.Clear();
			}
		}

	}
}