// Created by Peoharen
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class MonkMaJongQuest : BaseQuest // Horse Dummy used in martial arts
	{
		public override bool DoneOnce{ get{ return true; } }
		public override object Title{ get{ return "Find your inner balance"; } }
		public override object Description{ get{ return "Hello unenlightened one. Have you made the first step in learning our ways? If not, the reward you seek is of little value and you should go else where.<br><br>You're path continues. Now it is time to learn the balance of the light and of the darkness. You have a gift of understanding what you see, and so you shall study those in action and prove that you have more than just mental abilities.<br><br> I require you to kill a leader of the light, a Holy Ethereal Warrior. They can be found in Ilshenar, within the mountains East of the Compassion Gate. A Blue Mage can likely show you the way. I also require you to kill a leader of the dark, a Balor. They can be found in several places but perhaps you may try Blood Dungeon in Ilshenar, it is East of the Spirituality gate."; } }
		public override object Refuse{ get{ return "This path isn't for the many, though I hope you seek to take these quests in their proper order instead."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "You have done well and have learned to balance the light and dark within your soul. You may now build those energies up until they become a potent source of power (strike menu now has a light/dark energy bar which become buttons when one is filled). Because you are a monk of enlightenment, neither an absolute good nor evil, should you ever find those abilities in balance, light will prevail. Find my brethren and they will teach you more."; } }

		public MonkMaJongQuest() : base()
		{
			AddObjective( new SlayObjective( typeof( BlueEtherealWarrior ), "Holy Ethereal Warrior", 5 ) );
			AddObjective( new SlayObjective( typeof( Balron ), "A Balron", 5 ) );
			AddObjective( new ObtainObjective( typeof( Gold ), "Gold, Humility is required.", 40000 ) );
			AddReward( new BaseReward( typeof( MonkUpgradeThree ), 1, "Monk Upgrade, 2 to 3" ) );
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