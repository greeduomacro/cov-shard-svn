//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server
{
	public class AssassinControl
	{
		public static bool IsAssassin( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m;

				return pm.NpcGuild == NpcGuild.ThievesGuild;
			}

			return true;
		}

		public static void NPCKilled( Mobile killer )
		{
			PlayerMobile pm = killer as PlayerMobile;

			if ( pm == null || pm.NpcGuild != NpcGuild.ThievesGuild || pm.Quests.Count == 0 )
				return;

			ACreedQuest quest = null;

			for ( int i = 0; i < pm.Quests.Count; i++ )
			{
				if ( pm.Quests[i] is ACreedQuest )
				{
					quest = (ACreedQuest)pm.Quests[i];

					if ( quest.FailIfKillNPC )
					{
						for ( int j = 0; j < quest.Objectives.Count; j++ )
							quest.Objectives[j].CurProgress = -1; // Failed.
					}
				}
			}
		}

		public static void BecomeNotorious( Mobile m )
		{
			if ( !IsAssassin( m ) )
				return;

			PlayerMobile pm = m as PlayerMobile;

			if (  pm.Quests.Count == 0 )
				return;

			ACreedQuest quest = null;

			for ( int i = 0; i < pm.Quests.Count; i++ )
			{
				if ( pm.Quests[i] is ACreedQuest )
				{
					quest = (ACreedQuest)pm.Quests[i];

					if ( quest.FailIfNoticed )
					{
						for ( int j = 0; j < quest.Objectives.Count; j++ )
							quest.Objectives[j].CurProgress = -1; // Failed.
					}
				}
			}
		}

	}
}




