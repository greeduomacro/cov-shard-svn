// Created by Peoharen
using System;
using System.Collections.Generic;
using Server;
using Server.Engines.PartySystem;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Engines.Quests
{
	public class FindingQuinaQuest : BaseQuest
	{
		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromDays( 2 ); } }

		public override object Title{ get{ return "Finding Quina"; } }
		public override object Description{ get{ return "You seem to have figured out you can't use weapons with monster techniques. There is a creature that figured out how to, but I cannot bribe it into revealing its secrets. But hey, you're an adventurer. Who cares about silly things like asking permission. Head on over to that one brownish city and poke around in there then stab the creature until it bleeds, then do it some more right? If that bothers you, you can just wait until I negotiate things out."; } }
		public override object Refuse{ get{ return "Your skill in roleplaying has increased by 0.1%. It is now -99.9%. What? you don't understand what I said? Shame shame..."; } }
		public override object Uncomplete{ get{ return "You got lost didn't you?"; } }
		public override object Complete{ get{ return "Excellent, good job. What? You want a reward? Your reward is back with Quina. Oh hey, did you think to inspect it's body?"; } }

		public FindingQuinaQuest() : base()
		{
			SlayObjective quest = new SlayObjective( typeof( BlueQuina ), "Quina", 1 );
			quest.Seconds = 1800; // 30 Minutes.
			quest.Timed = true;

			AddObjective( quest );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

}