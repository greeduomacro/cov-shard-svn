using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;

namespace Server.Commands
{
	public class HearAll
	{
		private static List<Mobile> m_HearAll = new List<Mobile>();

		public static void Initialize()
		{
			CommandSystem.Register( "hearall", AccessLevel.Seer, new CommandEventHandler( HearAll_OnCommand ) );
			EventSink.Speech += new SpeechEventHandler( OnSpeech );
		}
	
		public static void OnSpeech( SpeechEventArgs e ) 
		{ 
			if ( m_HearAll.Count > 0 )
			{
				string lowercase = e.Speech.ToLower();

				if ( lowercase == "i wish to lock this down" ||
					lowercase == "i wish to release this" ||
					lowercase == "i wish to secure this" ||
					lowercase == "all follow me" ||
					lowercase == "all attack" ||
					lowercase == "all kill" ||
					lowercase == "all stay" ||
					lowercase == "all guard me" ||
					lowercase == "bank" ||
					lowercase == "guards" )
						return;

				string msg = String.Format( "({0}): {1}", e.Mobile.Name, e.Speech );

				for ( int i = 0; i < m_HearAll.Count; i++ )
				{ 
					if ( m_HearAll[i] != e.Mobile && m_HearAll[i].AccessLevel >= e.Mobile.AccessLevel )
						m_HearAll[i].SendMessage( msg );
				}
			}
		}

		public static void HearAll_OnCommand( CommandEventArgs e )
		{
			if ( m_HearAll.Contains( e.Mobile ) )
			{
				m_HearAll.Remove( e.Mobile );
				e.Mobile.SendMessage( "HearAll deactivated." );
			}
			else
			{
				m_HearAll.Add( e.Mobile );
				e.Mobile.SendMessage( "HearAll enabled." );
			}
		}
	} 
}