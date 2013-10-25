// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server
{
	public class BlueSkillBall : Item
	{
		public int AllowedTotal;

		[Constructable]
		public BlueSkillBall( int total ) : base( 0x0E2D )
		{
			AllowedTotal = total;
			Name = "Skill Ball";
			Hue = 1365;
			Movable = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Container pack = from.Backpack;

			if ( !(pack != null && Parent == pack) )
			{
				from.SendLocalizedMessage( 1080058 ); // This must be in your backpack to use it.
			}
			else
			{
				from.CloseGump( typeof( BlueSkillBallGump ) );
				from.SendGump( new BlueSkillBallGump( from, this ) );
			}
		}

		public BlueSkillBall( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class BlueSkillBallGump : Gump
	{
		public int AllowedTotal;
		private BlueSkillBall _Ball;

		public BlueSkillBallGump( Mobile m, BlueSkillBall ball ) : base( 25, 25 )
		{
			_Ball = ball;
			AllowedTotal = ball.AllowedTotal;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 570, 470, 9270 ); // Main Background
			AddLabel( 15, 15, 1365, "Skill Selection" );

			AddButton( 137, 15, 247, 248, 1, GumpButtonType.Reply, 0 );

			if ( AllowedTotal == -1 )
				AddLabel( 209, 16, 1365, "Maximium total allowed via this ball: " + (m.SkillsCap / 10).ToString() );
			else
				AddLabel( 209, 16, 1365, "Maximium total allowed via this ball: " + AllowedTotal.ToString() );
				
			int x = 0, y = 0;

			for( int i = 0; i < m.Skills.Length; i++ )
			{
				x = ((i % 4) * 135) + 15;
				y = ((i / 4) * 25) + 45;

				AddBackground( x, y, 135, 25, 9200 );
				AddLabel( x + 5, y + 5, 0, Enum.GetName( typeof( SkillName ), i ) + ":" );
				AddTextEntry( x + 100, y + 2, 30, 20, 0, i, "0" );

				/*
					AddBackground( 15, 45, 135, 25, 9200 );
					AddLabel( 20, 50, 0, "Lumberjacking" );
					AddTextEntry( 115, 47, 30, 20, 0, (int)Buttons.SKILLONETextEntry, @"" );

					AddBackground( 150, 45, 135, 25, 9200 );
					AddLabel( 155, 50, 0, "Lumberjacking" );
					AddTextEntry( 250, 47, 30, 20, 0, (int)Buttons.SKILLTWOTextEntry, @"" );

					AddBackground( 15, 70, 135, 25, 9200 );
					AddLabel( 20, 75, 0, "Lumberjacking" );
					AddTextEntry( 115, 73, 30, 20, 0, (int)Buttons.SKILLTHREETextEntry, @"" );

					AddBackground( 285, 44, 135, 25, 9200 );
					AddLabel( 290, 49, 0, @"Lumberjacking" );
					AddTextEntry( 385, 46, 30, 20, 0, (int)Buttons.CopyofSKILLONETextEntry, @"" );
					AddBackground( 420, 44, 135, 25, 9200 );
					AddLabel( 425, 49, 0, @"Lumberjacking" );
					AddTextEntry( 520, 46, 30, 20, 0, (int)Buttons.CopyofSKILLTWOTextEntry, @"" );
				*/
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( _Ball == null || info.ButtonID == 0 )
				return;

			int skilltotal = 0;
			int[] newskills = new int[ sender.Mobile.Skills.Length ];

			for ( int i = 0; i < sender.Mobile.Skills.Length; i++ )
			{
				int input = 0;

				if ( !Int32.TryParse( info.TextEntries[i].Text, out input ) )
					sender.Mobile.SendMessage( 1365, "You may only enter numbers into the required fields." );
				else if ( input < 0 )
					sender.Mobile.SendMessage( 1365, "You may not enter a number below 0." );
				else if ( input > sender.Mobile.Skills[i].Cap )
					sender.Mobile.SendMessage( 1365, "You entered a value higher than your current cap for " + Enum.GetName( typeof ( SkillName ), i ) );
				else
				{
					skilltotal += input;

					if ( skilltotal > sender.Mobile.Skills.Cap )
						sender.Mobile.SendMessage( "The values you entered would exceed your skill cap, please try again." );
					else
						newskills[i] = input;
				}
			}

			if ( skilltotal < 0 )
				return;
			else if ( AllowedTotal == -1 && skilltotal > sender.Mobile.SkillsCap )
			{
				sender.Mobile.SendMessage( 1365, "The total you entered didn't match the allowed total of this ball." );
				return;
			}
			else if ( AllowedTotal > -1 && skilltotal != AllowedTotal )
			{
				sender.Mobile.SendMessage( 1365, "The total you entered didn't match the allowed total of this ball." );
				return;
			}

			for ( int i = 0; i < sender.Mobile.Skills.Length; i++ )
				sender.Mobile.Skills[i].Base = newskills[i];

			_Ball.Delete();
			sender.Mobile.CloseGump( typeof( BlueSkillBallGump ) );
			GiveQuestItems( sender.Mobile );
			sender.Mobile.SendMessage( 1365, "You adjust your skills." );
		}

		public void GiveQuestItems( Mobile m )
		{
			Container pack = m.Backpack;

			if ( pack == null )
			{
				return;
			}

			if ( m.Skills[SkillName.Mining].Value > 50.0 )
				pack.DropItem( new JacobsPickaxe() );
			if ( m.Skills[SkillName.Focus].Value > 50.0 )
				pack.DropItem( new ClaspOfConcentration() );
			if ( m.Skills[SkillName.Blacksmith].Value > 50.0 )
				pack.DropItem( new HammerOfHephaestus() );
			if ( m.Skills[SkillName.Anatomy].Value > 50.0 )
				pack.DropItem( new TunicOfGuarding() );
			if ( m.Skills[SkillName.Healing].Value > 50.0 )
				pack.DropItem( new HealersTouch() );
			if ( m.Skills[SkillName.Hiding].Value > 50.0 )
				pack.DropItem( new BagOfSmokeBombs() );
			if ( m.Skills[SkillName.Stealth].Value > 50.0 )
				pack.DropItem( new TwilightJacket() );
			if ( m.Skills[SkillName.Ninjitsu].Value > 50.0 )
				pack.DropItem( new SilverSerpentBlade() );
			if ( m.Skills[SkillName.Tracking].Value > 50.0 )
				pack.DropItem( new WalkersLeggings() );
			if ( m.Skills[SkillName.Bushido].Value > 50.0 )
				pack.DropItem( new TheDragonsTail() );
			if ( m.Skills[SkillName.MagicResist].Value > 50.0 )
				pack.DropItem( new BraceletOfResilience() );
			if ( m.Skills[SkillName.Meditation].Value > 50.0 )
				pack.DropItem( new PhilosophersHat() );
			if ( m.Skills[SkillName.Inscribe].Value > 50.0 )
				pack.DropItem( new HallowedSpellbook() );
			if ( m.Skills[SkillName.Magery].Value > 50.0 )
				pack.DropItem( new EmberStaff() );
			if ( m.Skills[SkillName.EvalInt].Value > 50.0 )
				pack.DropItem( new RingOfTheSavant() );
			if ( m.Skills[SkillName.Tactics].Value > 50.0 )
				pack.DropItem( new ArmsOfArmstrong() );
			if ( m.Skills[SkillName.Macing].Value > 50.0 )
				pack.DropItem( new ChurchillsWarMace() );
			if ( m.Skills[SkillName.Fencing].Value > 50.0 )
				pack.DropItem( new RecarosRiposte() );
			if ( m.Skills[SkillName.Archery].Value > 50.0 )
				pack.DropItem( new Heartseeker() );
			if ( m.Skills[SkillName.Parry].Value > 50.0 )
				pack.DropItem( new EscutcheonDeAriadne() );
			if ( m.Skills[SkillName.Chivalry].Value > 50.0 )
				pack.DropItem( new BulwarkLeggings() );
			if ( m.Skills[SkillName.Wrestling].Value > 50.0 )
				pack.DropItem( new GlovesOfSafeguarding() );
			if ( m.Skills[SkillName.SpiritSpeak].Value > 50.0 )
				pack.DropItem( new BagOfNecromancerReagents() );
			if ( m.Skills[SkillName.Necromancy].Value > 50.0 )
				pack.DropItem( new CompleteNecromancerSpellbook() );

			m.SendMessage( 1365, "You were given some items based on your skill choices." );
		}
	}
}