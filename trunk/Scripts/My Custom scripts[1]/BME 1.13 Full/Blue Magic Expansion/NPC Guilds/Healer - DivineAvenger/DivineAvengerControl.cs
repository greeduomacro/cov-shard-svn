//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server
{
	public class DivineAvengerControl
	{
		public static bool IsDivineAvenger( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m;

				return pm.NpcGuild == NpcGuild.HealersGuild;
			}

			return true;
		}

		public static int GetHolyPoints( Mobile m )
		{
			if ( !IsDivineAvenger( m ) )
				return 0;
			else
				return 0;
		}
	}
}