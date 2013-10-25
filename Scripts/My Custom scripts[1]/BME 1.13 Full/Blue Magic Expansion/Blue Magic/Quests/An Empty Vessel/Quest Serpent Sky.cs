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
	public class BlueMageSkySerpentQuest : BaseQuest
	{
		private BlueSerpentMark m_Mark;
		private Mobile NullFix;

		public override object Title{ get{ return "Search for your Mark"; } }
		public override object Description{ get{ return "I see the symbol of the Skyserpent. It suggests spending sometime away from battle. For a change of pace, why not try enlighting your self?"; } }
		public override object Refuse{ get{ return "Then I shall remove your memories of this."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Amazing. One final test awaits you, do you accept being a Blue Mage?"; } }

		public BlueMageSkySerpentQuest( Mobile m ) : base()
		{
			AddObjective( new ObtainObjective( typeof( BlueSerpentMark ), "Scroll that speaks of the Skyserpent", 1 ) );
			AddReward( new BaseReward( typeof( Gold ), 10000, "The blue mage acceptence menu" ) );
			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( AddItems ) );
			NullFix = m;
		}

		private void AddItems()
		{
			new BlueSerpentMark( NullFix, 0x0EF6 ).MoveToWorld( new Point3D( (1347 + Utility.Random( 3 )), (1031 + Utility.Random( 18 )), -13 ), Map.Ilshenar );
		}

		public override void GiveRewards()
		{
			base.GiveRewards();

			if ( Owner.HasGump( typeof( BlueAcceptGump ) ) )
				Owner.CloseGump( typeof( BlueAcceptGump ) );
				
			Owner.SendGump( new BlueAcceptGump( Owner ) );
			ClearMarks( Owner );
		}

		public static void ClearMarks( Mobile m )
		{
			// Clean up the marks in case they opened this quest multiple times.
			List<BlueSerpentMark> list = new List<BlueSerpentMark>();

			foreach ( Item item in World.Items.Values )
			{
				if ( item is BlueSerpentMark )
				{
					BlueSerpentMark bsk = (BlueSerpentMark)item;

					if ( bsk.Owner == m )
						list.Add( bsk );
				}
			}

			for ( int i = list.Count - 1; i > -1; i-- )
				list[i].Delete();
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