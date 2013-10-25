// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class ACreedAntoineQuest : ACreedQuest
	{
		public override bool FailIfNoticed{ get { return true; } }

		public override object Title{ get{ return "Antoine's Boat"; } }
		public override object Description{ get{ return "I need you to preform a task for me. It's a simple one really. Head on over near the docks and acquire a boat deed for me. It's a very special deed to a very dear boat of mine. Don't get caught."; } }
		public override object Refuse{ get{ return "Oh well, thanks for nothing."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Ahh thank you."; } }

		public ACreedAntoineQuest( Mobile m ) : base()
		{
			AddObjective( new ObtainObjective( typeof( ACreedAntoinesDeed ), "Antoine's Boat Deed.", 1 ) );
			AddReward( new BaseReward( typeof( Florin ), 200, "200 florins" ) );
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