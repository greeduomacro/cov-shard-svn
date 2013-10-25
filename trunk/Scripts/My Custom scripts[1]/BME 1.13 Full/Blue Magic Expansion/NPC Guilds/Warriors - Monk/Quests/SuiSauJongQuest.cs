// Created by Peoharen
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class MonkSuiSauJongQuest : BaseQuest // Breaking Hand Dummy used in martial arts
	{
		public override bool DoneOnce{ get{ return true; } }
		public override object Title{ get{ return "Find your inner self"; } }
		public override object Description{ get{ return "Hello unenlightened one. Have you made the first step in learning our ways? If not, the reward you seek is of little value and you should go else where.<br><br>You're path continues. You have learned to become one with nature, now you must learn to become one with your self. Upon understanding what I mean you will be able to heal your self though your own chi.<br><br><BASEFONT COLOR='#FF0000'>Now pay attention as you will not be told this again.</BASEFONT> I require you to study the eight virtue shrines in Trammel. Remain next to them and pray for enlightenment."; } }
		public override object Refuse{ get{ return "This path isn't for the many, though I hope you seek to take these quests in their proper order instead."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "You have done well and have learned to find your inner self. You may now use the gloves to invoke a Wholeness Of Body (in the strike menu). Upon using this ability your mana will be removed but worry not. For as long as you take no actions and your spirit is able you will benefit from superior mental and physical regeneration. Ending your trance will return to you your newly increased mana, though breaking this trance early shall penalize the returned essence of your spirit. Find my brethren and they will teach you more."; } }

		public MonkSuiSauJongQuest() : base()
		{
			// ?
			AddObjective( new StudyObjective( new Point2D( 0, 0 ), 5, Map.Trammel, 
				new string[]
				{
					"A",
					"B",
					"C"
				}, 
				0 ) );

			AddObjective( new ObtainObjective( typeof( Gold ), "Gold, Humility is required.", 30000 ) );
			AddReward( new BaseReward( typeof( MonkUpgradeTwo ), 1, "Monk Upgrade, 1 to 2" ) );
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