// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class ACreedRamondoQuest : ACreedQuest
	{
		public override object Title{ get{ return "Ramondo's Letter"; } }
		public override object Description{ get{ return "I paid a courier to deliver a letter for me but I never got one back. And I heard talk that the courier I hired is prone to forgetting to deliver letters and it may still be at his house. Can you see if it is and get it for me?"; } }
		public override object Refuse{ get{ return "Oh well, thanks for nothing."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Ahh thank you, now I will use a highly recommended courier to deliver this."; } }

		public ACreedRamondoQuest() : base()
		{
			AddObjective( new ObtainObjective( typeof( ACreedRamondosLetter ), "Ramondo's letter.", 1 ) );
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