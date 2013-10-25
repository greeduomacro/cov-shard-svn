// Created by Peoharen
using System;
using System.Collections.Generic;
using Server;
using Server.Engines.PartySystem;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Engines.Quests
{
	public class BattleKaysaQuest : BaseQuest
	{
		public static Point3D ArenaHome = new Point3D( 600, 75, -25 ); // [go 600 75 -25
		private Dictionary<IvyArenaAddon, List<SleepingTreeAddon>> Arenas = new Dictionary<IvyArenaAddon, List<SleepingTreeAddon>>();

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromDays( 7 ); } }

		public override object Title{ get{ return "Battle: Kaysa"; } }
		public override object Description{ get{ return "You should not see this."; } }
		public override object Refuse{ get{ return "She isn't an easy fight, I don't blame you."; } }
		public override object Uncomplete{ get{ return "You have not completed your task yet."; } }
		public override object Complete{ get{ return "Excellent, good job. Did you get an artifact?"; } }

		public BattleKaysaQuest() : base()
		{
			SlayObjective quest = new SlayObjective( typeof( BlueKaysa ), "Kaysa", 1 );
			quest.Seconds = 1800; // 30 Minutes.
			quest.Timed = true;

			AddObjective( quest );
		}

		public override void OnAccept()
		{
			base.OnAccept();
			SetupArena();

			Party p = Party.Get( Owner );

			if ( p == null )
			{
				Objectives[0].CurProgress = -1;
				Owner.SendMessage ( "You must be in a party to enter this quest." );
				return;
			}

			foreach( PartyMemberInfo pmi in p.Members )
			{
				if ( pmi.Mobile.HasGump( typeof( BattleMonsterGump ) ) )
					pmi.Mobile.CloseGump( typeof( BattleMonsterGump ) );

				pmi.Mobile.SendGump( new BattleMonsterGump( Owner, "Kaysa", ArenaHome, Map.Malas ) );
			}
		}

		private void SetupArena()
		{
			Point3D home = ArenaHome;

			if ( Arenas.Keys.Count > 0 )
			{
				home.X += (Arenas.Keys.Count * 45);
			}

			IvyArenaAddon arena = new IvyArenaAddon();
			arena.MoveToWorld( home, Map.Ilshenar );
			Arenas.Add( arena, new List<SleepingTreeAddon>() );

			for ( int i = -20; i < 22; i++ )
			{
				for ( int j = -20; j < 22; j++ )
				{
					if ( Utility.RandomDouble() > 0.8 )
						continue;

					SleepingTreeAddon sta = new SleepingTreeAddon();
					sta.MoveToWorld( new Point3D( home.X + i, home.Y + i, home.Z ), Map.Ilshenar );
					Arenas[arena].Add( sta );
				}
			}

			new BlueKaysa().MoveToWorld( new Point3D( home.X, home.Y, home.Z + 20 ), Map.Ilshenar );
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