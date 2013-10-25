// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class ACreedJacquelineQuest : ACreedQuest
	{
		public override bool FailIfKillNPC{ get{ return true; } }

		public override object Title{ get{ return "Jacqueline's Insurance"; } }
		public override object Description{ get{ return "My house burned down last month and I gave my proof of insurance to the agent but he kept it to him self. Now I can't take them to court. Could you obtain the insurance ticket for me? Just be sure not to hurt anyone ok?"; } }
		public override object Refuse{ get{ return "Oh well, thanks for nothing."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Ahh thank you, here is your reward."; } }

		public ACreedJacquelineQuest() : base()
		{
			AddObjective( new ObtainObjective( typeof( ACreedJacquelinesLetter ), "Jacqueline's letter.", 1 ) );
			AddReward( new BaseReward( typeof( Florin ), 100, "100 florins" ) );
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