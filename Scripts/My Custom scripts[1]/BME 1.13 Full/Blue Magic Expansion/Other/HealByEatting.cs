// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server
{
	public class HealByEating
	{
		// This little snippet allows you to heal HP by eating food.
		// Players with less than 25.0 in TasteID are ignored.
		// Formula: You heal 20~50 HP per hunger point restored.
		// Also Hunger drops by one point per five minutes. 
		// Before you ask, there is NO event for Thirst, so I can't tap into it like this.

		public static void Initialize()
		{
			EventSink.HungerChanged += delegate( HungerChangedEventArgs e )
			{
				if ( e.Mobile.Skills[SkillName.TasteID].Base < 25.0 )
					return;

				int diff = e.Mobile.Hunger - e.OldValue;

				if ( diff > 0 )
				{
					e.Mobile.Hits += diff * ((1 + (int)(e.Mobile.Skills[SkillName.TasteID].Value / 25)) * 10); // +10~+50 per point of hunger healed.
				}
			};
		}
	}
}