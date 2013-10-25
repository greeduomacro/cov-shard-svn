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
	public class BlueMageGaleSerpentQuest : BaseQuest
	{
		private BlueSerpentMark m_Mark;
		private Mobile NullFix;

		public override object Title{ get{ return "Search for your Mark"; } }
		public override object Description{ get{ return "I see the symbol of the Galeserpent. It suggests a loss in the near future... Even I cannot predict what this loss may entail. You would do well to pay close attention to your possessions as the acid elementals near Nox Terg will surely consume your equipment."; } }
		public override object Refuse{ get{ return "Then I shall remove your memories of this."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Amazing. One final test awaits you, do you accept being a Blue Mage?"; } }

		public BlueMageGaleSerpentQuest( Mobile m ) : base()
		{
			AddObjective( new ObtainObjective( typeof( BlueSerpentMark ), "A staglamite worn by the Galeserpent", 1 ) );
			AddReward( new BaseReward( typeof( Gold ), 10000, "The blue mage acceptence menu" ) );
			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( AddItems ) );
			NullFix = m;
		}

		private void AddItems()
		{
			switch( Utility.Random( 4 ) )
			{
				case 0: new BlueSerpentMark( NullFix, 0x08E3 ).MoveToWorld( new Point3D( 40, 1020, -28 ), Map.Ilshenar ); break;
				case 1: new BlueSerpentMark( NullFix, 0x08E3 ).MoveToWorld( new Point3D( 21, 1043, -29 ), Map.Ilshenar ); break;
				case 2: new BlueSerpentMark( NullFix, 0x08E3 ).MoveToWorld( new Point3D( 29, 1031, -28 ), Map.Ilshenar ); break;
				case 3: new BlueSerpentMark( NullFix, 0x08E3 ).MoveToWorld( new Point3D( 28, 1034, -29 ), Map.Ilshenar ); break;
			}
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