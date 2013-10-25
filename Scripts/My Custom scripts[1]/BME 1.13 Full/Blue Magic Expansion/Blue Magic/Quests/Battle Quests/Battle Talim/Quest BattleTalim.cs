// Created by Peoharen
using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Engines.Quests
{
	public class BattleTalimQuest : BaseQuest
	{
		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromDays( 7 ); } }

		public override object Title{ get{ return "Battle: Talim Moore"; } }
		public override object Description{ get{ return "You should not see this."; } }
		public override object Refuse{ get{ return ""; } }
		public override object Uncomplete{ get{ return ""; } }
		public override object Complete{ get{ return ""; } }

		public BattleTalimQuest() : base()
		{
			SlayObjective quest = new SlayObjective( typeof( BlueMarkov ), "Markov Tirel", 1 );
			quest.Seconds = 1800; // 30 Minutes.
			quest.Timed = true;

			AddObjective( quest );
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
	}
}