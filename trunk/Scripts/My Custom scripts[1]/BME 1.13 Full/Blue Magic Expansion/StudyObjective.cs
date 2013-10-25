// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Regions;

namespace Server.Engines.Quests
{	
	public class StudyObjective : BaseObjective
	{
		public Point2D Point;
		public int Range;
		public Map Map;
		public string[] Messages;
		public int OnMessage;
		private StudyTimer Timer;

		public StudyObjective( Point2D point, Map map, string[] messages ) : this( point, 5, map, messages, 0 )
		{
		}

		public StudyObjective( Point2D point, int range, Map map, string[] messages, int seconds ) : base( 1, seconds )
		{
			Point = point;
			Range = range;
			Map = map;
			Messages = messages;
			OnMessage = 0;

			CheckTimer();
		}

		private void CheckTimer()
		{
			if ( !Completed && !Failed && Messages.Length > 0 )
			{
				Timer = new StudyTimer( this );
				Timer.Start();
			}
		}

		public void OnTick()
		{
			if ( Quest.Owner.InRange( Point, Range ) && Quest.Owner.Map == Map )
			{
				if ( OnMessage < Messages.Length && Messages[OnMessage] != String.Empty )
					Quest.Owner.SendMessage( Messages[OnMessage] );

				++OnMessage;

				if ( OnMessage >= Messages.Length )
				{
					CurProgress = MaxProgress; // Completed
					Timer.Stop();
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (Point2D)Point );
			writer.Write( (int)Range );
			writer.Write( (Map)Map );

			writer.Write( (int)Messages.Length );

			for ( int i = 0; i < Messages.Length; i++ )
				writer.Write( (string)Messages[i] );

			writer.Write( (int)OnMessage );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			Point = reader.ReadPoint2D();
			Range = reader.ReadInt();
			Map = reader.ReadMap();

			int count = reader.ReadInt();
			Messages = new string[ count ];

			for ( int i = 0; i < count; i++ )
				Messages[i] = reader.ReadString();

			OnMessage = reader.ReadInt();
		}	

		public class StudyTimer : Timer
		{
			private StudyObjective m_Objective;
			private int OnMessage;

			public StudyTimer( StudyObjective objective ) : base( TimeSpan.FromSeconds( 10 ), TimeSpan.FromSeconds( 10 ) )
			{
				m_Objective = objective;
				OnMessage = 0;
			}

			protected override void OnTick()
			{
				if ( m_Objective.Completed || m_Objective.Failed )
					Stop();
				else if ( m_Objective.Quest == null || m_Objective.Quest.Owner == null )
					Stop();
				else
					m_Objective.OnTick();
			}
		}
	}
}