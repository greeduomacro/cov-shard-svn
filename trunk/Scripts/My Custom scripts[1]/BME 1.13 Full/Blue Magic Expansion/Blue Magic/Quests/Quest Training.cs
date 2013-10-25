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
	public class BlueMageTrainingQuest : BaseQuest
	{
		public override object Title{ get{ return "Blue Mage Training"; } }
		public override object Description{ get{ return "Your first task is seemling simple, go out and train the skills required to be a Blue Mage. You'll need good forensic evaluation and the ability to resist magical effects imposed on you. Also you <b>cannot</b> be a true mage, necromancer, paladin, samurai, ninja, or anything of the like."; } }
		public override object Refuse{ get{ return "This life style isn't for everyone."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Welcome back, I see your training has given you the keen insight required to be a Blue Mage."; } }

		public BlueMageTrainingQuest() : base()
		{
			AddObjective( new ApprenticeObjective( SkillName.Forensics, 51 ) );
			AddReward( new BaseReward( typeof( RingOfTheSavant ), 1077608 ) ); 
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