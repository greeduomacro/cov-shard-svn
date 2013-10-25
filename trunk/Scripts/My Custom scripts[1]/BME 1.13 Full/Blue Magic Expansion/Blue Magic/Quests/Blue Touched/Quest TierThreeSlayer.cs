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
	public class BlueMageTierThreeSlayerQuest : BaseQuest
	{
		public override object Title{ get{ return "Blue Mage Tier Three Slayer Quest"; } }
		public override object Description{ get{ return BlueMageTierOneSlayerQuest.RandomDescription(); } }
		public override object Refuse{ get{ return "I figured as much, now keep asking till I give you something easier."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "What took you so long? I shall reward you with your very own Touched garment. If you are displeased with the one you got, you may exchange it for another for a small fee by giving me the one you don't want."; } }

		public BlueMageTierThreeSlayerQuest() : base()
		{
			AddObjective( new SlayObjective( typeof( ShadowWyrm ), "Shadow Wyrm", 7 ) );
			AddObjective( new SlayObjective( typeof( BlueBeholder ), "Beholder", 5 ) );
			AddObjective( new SlayObjective( typeof( AncientLich ), "Ancient Lich", 7 ) );
			AddObjective( new SlayObjective( typeof( Balron ), "Balron", 7 ) );

			AddReward( new BaseReward( typeof( BlueTeirTwoEnhanceDeed ), "A Enhancement Deed for Blue Mage clothing." ) );
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