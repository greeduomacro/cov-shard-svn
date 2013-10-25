// Created by Peoharen
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class MonkMukYanJongQuest : BaseQuest // Wooden Dummy used in martial arts
	{
		public override bool DoneOnce{ get{ return true; } }
		public override object Title{ get{ return "Find your inner peace"; } }
		public override object Description{ get{ return "Hello unenlightened one. Would you like to learn our ways? We are unarmed specialists quite capable of preforming many feats using our own inner strength. Our abilities are complex but can be learned if you are willing. *Note you must be willing to join the NPC Warriors Guild to use this reward*"; } }
		public override object Refuse{ get{ return "This path isn't for the many. Remember, should you choose to come back, you can only finish this quest once in your life."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "You have done well and earned the right to own these gloves. These gloves are specially enchanted to channel one's energy. By using them (double click) you can channel all sorts of power. The key is in the combination of how you use the different types of energy. Practice them well, for this is just the start of things and there is much more to come. There is a certain order of things, though you may try to learn out of order you truly would gain no benefit and would make it harder on your self. Find my brethren and they will teach you more."; } }

		public MonkMukYanJongQuest() : base()
		{
			AddObjective( new ObtainObjective( typeof( OrigamiFish ), "Though a mental haze one must show clarity.", 1 ) );
			AddObjective( new ObtainObjective( typeof( Gold ), "Gold, Humility is required.", 10000 ) );
			AddReward( new BaseReward( typeof( MonkFists ), 1, "a pair of very special gloves." ) );
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