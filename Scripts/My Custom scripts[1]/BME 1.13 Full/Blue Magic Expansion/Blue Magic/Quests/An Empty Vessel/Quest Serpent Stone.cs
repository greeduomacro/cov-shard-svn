// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Engines.Quests
{
	public class BlueMageStoneSerpentQuest : BaseQuest
	{
		private BlueSerpentMark m_Mark;
		private Mobile NullFix;

		public override object Title{ get{ return "Search for your Mark"; } }
		public override object Description{ get{ return "I see the symbol of the Stoneserpent. It suggests you will receive a boon from the earth. A boon from the earth...? Ah yes, a look in a buried dungeon may prove beneficial. All signs point towards the mountains near Montor..."; } }
		public override object Refuse{ get{ return "Then I shall remove your memories of this."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Amazing. One final test awaits you, do you accept being a Blue Mage?"; } }

		public BlueMageStoneSerpentQuest( Mobile m ) : base()
		{
			AddObjective( new ObtainObjective( typeof( BlueSerpentMark ), "Gravel walked on by the Stoneserpent", 1 ) );
			AddReward( new BaseReward( typeof( Gold ), 10000, "The blue mage acceptence menu" ) );
			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( AddItems ) );
			NullFix = m;
		}

		private void AddItems()
		{
			new BlueSerpentMark( NullFix, (0x136B + Utility.Random( 3 )) ).MoveToWorld( new Point3D( (2126 + Utility.RandomMinMax( -3, 3 )), (25 + Utility.RandomMinMax( -2, 2 )), -32 ), Map.Ilshenar );
		}

		public override void GiveRewards()
		{
			base.GiveRewards();

			if ( Owner.HasGump( typeof( BlueAcceptGump ) ) )
				Owner.CloseGump( typeof( BlueAcceptGump ) );
				
			Owner.SendGump( new BlueAcceptGump( Owner ) );
			BlueMageSkySerpentQuest.ClearMarks( Owner );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (Item) m_Mark );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Mark = reader.ReadItem() as BlueSerpentMark;
		}
	}
}