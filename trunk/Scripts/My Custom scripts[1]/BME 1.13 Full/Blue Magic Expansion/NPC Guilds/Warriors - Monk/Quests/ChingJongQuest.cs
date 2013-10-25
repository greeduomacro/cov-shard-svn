// Created by Peoharen
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class MonkChingJongQuest : BaseQuest // Balanced Dummy
	{
		public override bool DoneOnce{ get{ return true; } }
		public override object Title{ get{ return "Find your outer self"; } }
		public override object Description{ get{ return "Hello unenlightened one. Have you made the first step in learning our ways? If not, the reward you seek is of little value and you should go else where.<br><br>Your next task is to find balance. I want you to go to four locations and meditate there on all things spiritual. Observe nature in it's works, contemplate how one would mimic them. Mastery of this skill will unlock the secrets of the elemental stances.<br><br><BASEFONT COLOR='#FF0000'>Now pay attention as you will not be told this again.</BASEFONT>"; } }
		public override object Refuse{ get{ return "This path isn't for the many, though I hope you seek to take these quests in their proper order instead."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "You have done well and are one step closer towards enlightenment. You may now use your chi channeling gloves (single click) to enter an elemental stance as often as you wish. Use them well, for this is just the beginning of things. Find my brethren and they will teach you more."; } }

		public MonkChingJongQuest() : base()
		{
			// Air
			AddObjective( new StudyObjective( new Point2D( 0, 0 ), 5, Map.Trammel, 
				new string[]
				{
					"A",
					"", "", "", // Delay 30 seconds.
					"B",
					"", "", "", // Delay 30 seconds.
					"C"
				}, 
				0 ) );

			// Earth
			AddObjective( new StudyObjective( new Point2D( 0, 0 ), 5, Map.Trammel, 
				new string[]
				{
					"A",
					"", "", "", // Delay 30 seconds.
					"B",
					"", "", "", // Delay 30 seconds.
					"C"
				}, 
				0 ) );

			// Fire
			AddObjective( new StudyObjective( new Point2D( 0, 0 ), 5, Map.Trammel, 
				new string[]
				{
					"A",
					"", "", "", // Delay 30 seconds.
					"B",
					"", "", "", // Delay 30 seconds.
					"C"
				}, 
				0 ) );

			// Water
			AddObjective( new StudyObjective( new Point2D( 0, 0 ), 5, Map.Trammel, 
				new string[]
				{
					"A",
					"", "", "", // Delay 30 seconds.
					"B",
					"", "", "", // Delay 30 seconds.
					"C"
				}, 
				0 ) );

			AddObjective( new ObtainObjective( typeof( Gold ), "Gold, Humility is required.", 20000 ) );
			AddReward( new BaseReward( typeof( MonkUpgradeOne ), 1, "Monk Upgrade, 0 to 1" ) );
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