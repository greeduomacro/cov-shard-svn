// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
	public class ArtificerSystem
	{
		public static bool IsArtificer( Mobile from )
		{
			if ( from is BaseCreature || from.AccessLevel > AccessLevel.Counselor )
				return true;

			if ( from.Skills[SkillName.ItemID].Base < 50.0 )
				return false;

			if ( from is PlayerMobile )
			{
				if ( ((PlayerMobile)from).NpcGuild != NpcGuild.TinkersGuild )
					return false;
			}

			return true;
		}
	}
}