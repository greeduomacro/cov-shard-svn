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
	public class BlueMageTierOneSlayerQuest : BaseQuest
	{
		private static string[] DescriptionChat =
		{
			"Your mission should you choose to accept it is to rid the world of all evil, or at least in part since it's not like you are some kind of adventuring hero or anything. This message will cause you to self destruct in three minutes. ... Just kidding. Or am I?",
			"Help help my dress is in a pinch, dinner is burning and there is a mouse at my feet or something like that. Man I am going to get in so much trouble for saying that...<br> Just head out and kill some stuff for me alright?",
			"You there look like an estimed murderer on a rampage through town to rob us of everything we own. Perfect, I have a list of monsters I want you to kill and will reward you for doing so. Oh and my reward isn't on me so tuck that weapon away.",
			"Are we there yet? Eer I meant are you done killing the creatures I asked you to do? ... What do you mean I didn't ask you about that? I'm pretty sure I have and you just keep coming back, you know what to do so head on out of here.",
			"...And then I said that was <i>not</i> the gazer's eyestock and she was horrified. Oh hey dear chap, I got a task for you with an interesting reward. Now hop to hop to so I may continue our little chat here.",
			"Look at my cloak. My cloak is amazing. With a stroke of a breeze it flies like the wind and it falls back again when tug on my... Oh hello. Up to pretend you are a death dealer again?",
			"I could stand here talking or you could get to action.",
			"I just learned how to be bored. I learned it from you, now to fix your problem I have just the quest for you.",
			"Did you know the clothing I sell cannot be touched by non blue mages? I weave them so. The required ingredent is tears from a drowning orphane, eer I mean Balron bones, Lich's dust, and the like. Care to gather some ingredents for me?",
			"Oh hey your mom was telling me about you last night. She says you have great skill at killing foul beasts, care to make your mom a truth teller for once?",
			"So I was talking to your bedmate the other day for some reason and your name came up a bit, mostly with the words \"I hope\" and \"don't show up right now\", but never the less there was some bragging. I'd like to test your skills."
		};

		public static string RandomDescription()
		{
			return DescriptionChat[Utility.Random(DescriptionChat.Length)];
		}

		public override object Title{ get{ return "Blue Mage Tier One Slayer Quest"; } }
		public override object Description{ get{ return RandomDescription(); } }
		public override object Refuse{ get{ return "Fine fine, enjoy your day and I hope it rains."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Done already? Good good. I shall reward you with your very own Touched garment. If you are displeased with the one you got, you may exchange it for another for a small fee by giving me the one you don't want."; } }

		public BlueMageTierOneSlayerQuest() : base()
		{
			AddObjective( new SlayObjective( typeof( Drake ), "Drake", 5 ) );
			AddObjective( new SlayObjective( typeof( Gazer ), "Gazer", 5 ) );
			AddObjective( new SlayObjective( typeof( Lich ), "Lich", 5 ) );
			AddObjective( new SlayObjective( typeof( Daemon ), "Daemon", 5 ) );

			switch( Utility.RandomMinMax( 0, 8 ) )
			{
				case 0: AddReward( new BaseReward( typeof( BlueArms ), "Blue Mage Arms" ) ); break;
				case 1: AddReward( new BaseReward( typeof( BlueBelt ), "Blue Mage Belt" ) ); break;
				case 2: AddReward( new BaseReward( typeof( BlueBoots ), "Blue Mage Boots" ) ); break;
				case 3: AddReward( new BaseReward( typeof( BlueCloak ), "Blue Mage Cloak" ) ); break;
				case 4: AddReward( new BaseReward( typeof( BlueHat ), "Blue Mage Hat" ) ); break;
				case 5: AddReward( new BaseReward( typeof( BluePants ), "Blue Mage Pants" ) ); break;
				case 6: AddReward( new BaseReward( typeof( BlueSash ), "Blue Mage Sash" ) ); break;
				case 8: AddReward( new BaseReward( typeof( BlueShirt ), "Blue Mage Shirt" ) ); break;
			}
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