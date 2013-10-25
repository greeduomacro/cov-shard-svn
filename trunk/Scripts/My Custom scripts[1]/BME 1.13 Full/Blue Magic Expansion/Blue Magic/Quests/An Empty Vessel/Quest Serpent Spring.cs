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
	public class BlueMageSpringSerpentQuest : BaseQuest
	{
		private BlueSerpentMark m_Mark;
		private Mobile NullFix;

		public override object Title{ get{ return "Search for your Mark"; } }
		public override object Description{ get{ return "I see the symbol of the Springserpent. It suggests a sojourn to the sea. Yes, a tranquil journey near the waves. Replace your weapon with a fishing pole and fate will smile upon you."; } }
		public override object Refuse{ get{ return "Then I shall remove your memories of this."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Amazing. One final test awaits you, do you accept being a Blue Mage?"; } }

		public BlueMageSpringSerpentQuest( Mobile m ) : base()
		{
			AddObjective( new ObtainObjective( typeof( BlueSerpentMark ), "Fishing Rod engraved with the Springserpent", 2 ) );
			AddReward( new BaseReward( typeof( Gold ), 10000, "The blue mage acceptence menu" ) );
			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( AddItems ) );
			NullFix = m;
		}

		private void AddItems()
		{
			if ( Utility.RandomBool() )
				new BlueSerpentMark( NullFix, 0x1180 ).MoveToWorld( new Point3D( (910 + Utility.Random( 3 )), (919 + Utility.Random( 3 )), -28 ), Map.Ilshenar );
			else
				new BlueSerpentMark( NullFix, 0x1180 ).MoveToWorld( new Point3D( (1401 + Utility.Random( 21 )), 819, -12 ), Map.Ilshenar );
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