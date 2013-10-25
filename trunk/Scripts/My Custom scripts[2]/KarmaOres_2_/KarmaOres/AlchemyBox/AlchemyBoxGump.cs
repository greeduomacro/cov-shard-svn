
using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Targeting;
using Server.Prompts;

namespace Server.Items
{
	public class AlchemyBoxGump : Gump
	{
		private Mobile m_From;
		private AlchemyBox m_Box;
		private Pages m_Page;
		private Type[] m_Types;

		public enum Pages
		{
			Start,
			Bottles,
			PotionKeg,
            NightSightPotion,
			CurePotion,
            AgilityPotion,
            StrengthPotion,
            PoisonPotion,
            RefreshPotion,
            HealPotion,
            ExplosionPotion,

            MoreBottle,
            MorePotionKeg,
            MoreNightSightPotion,
            MoreCurePotion,
            MoreAgilityPotion,
            MoreStrengthPotion,
            MorePoisonPotion,
            MoreRefreshPotion,
            MoreHealPotion,
            MoreExplosionPotion
		}

        public AlchemyBoxGump(Mobile from, AlchemyBox box, Pages page) : base(25, 25)            
		{
			m_From = from;
			m_Box = box;
			m_Page = page;

			AddPage( 0 );

			AddBackground( 50, 10, 455, 325, 83 );
			AddImageTiled( 58, 20, 438, 317, 2624 );
			AddAlphaRegion( 58, 20, 438, 317 );

			AddButton( 75, 25, 4026, 4027, 1, GumpButtonType.Reply, 0 );
			AddLabel( 110, 25, 0x8AB, "Add Resource" );

			AddPage( 1 );

			if( m_Page == Pages.Start )
			{
				AddLabel( 225, 25, 191, "COV Alchemy Box" );
                AddLabel(225, 50, 191, "DO NOT PUT FULL POTION KEGS IN HERE!");
				AddLabel( 110, 75, 191, "Empty Bottles" );
				AddButton( 75, 75, 4005, 4007, 10, GumpButtonType.Reply, 0 );
				AddLabel( 110, 100, 191, "Empty Potion Kegs" );
				AddButton( 75, 100, 4005, 4007, 11, GumpButtonType.Reply, 0 );
				AddLabel( 110, 125, 191, "NightSight Potions" );
				AddButton( 75, 125, 4005, 4007, 12, GumpButtonType.Reply, 0 );
				AddLabel( 110, 150, 191, "Cure Potions" );
				AddButton( 75, 150, 4005, 4007, 13, GumpButtonType.Reply, 0 );
				AddLabel( 110, 175, 191, "Agility Potions" );
				AddButton( 75, 175, 4005, 4007, 14, GumpButtonType.Reply, 0 );
				AddLabel( 110, 200, 191, "Strength Potions" );
				AddButton( 75, 200, 4005, 4007, 15, GumpButtonType.Reply, 0 );
				AddLabel( 110, 225, 191, "Poison Potions" );
				AddButton( 75, 225, 4005, 4007, 16, GumpButtonType.Reply, 0 );
                AddLabel( 110, 250, 191, "Refresh Potions" );
                AddButton( 75, 250, 4005, 4007, 17, GumpButtonType.Reply, 0 );
                AddLabel( 110, 275, 191, "Heal Potions");
                AddButton( 75, 275, 4005, 4007, 18, GumpButtonType.Reply, 0);
                AddLabel( 110, 300, 191, "Explosion Potions");
                AddButton( 75, 300, 4005, 4007, 19, GumpButtonType.Reply, 0);
				

                if (AlchemyBoxTypes.Bottle.Length > 19)
				{
					AddLabel( 310, 75, 33, "More Empty Bottles" );
					AddButton( 275, 75, 4005, 4007, 20, GumpButtonType.Reply, 0 );
				}
                if (AlchemyBoxTypes.PotionKeg.Length > 19)
				{
					AddLabel( 310, 100, 33, "More Empty Potion Kegs" );
					AddButton( 275, 100, 4005, 4007, 21, GumpButtonType.Reply, 0 );
				}
                if (AlchemyBoxTypes.NightSightPotion.Length > 19)
				{
					AddLabel( 310, 125, 33, "More NightSight Potions" );
					AddButton( 275, 125, 4005, 4007, 22, GumpButtonType.Reply, 0 );
				}
                if (AlchemyBoxTypes.CurePotion.Length > 19)
                {
                    AddLabel(310, 150, 33, "More Cure Potions");
                    AddButton(275, 150, 4005, 4007, 23, GumpButtonType.Reply, 0);
                }
                if (AlchemyBoxTypes.AgilityPotion.Length > 19)
                {
                    AddLabel(310, 175, 33, "More Agility Potions");
                    AddButton(275, 175, 4005, 4007, 24, GumpButtonType.Reply, 0);
                }
                if (AlchemyBoxTypes.StrengthPotion.Length > 19)
                {
                    AddLabel(310, 200, 33, "More Strength Potions");
                    AddButton(275, 200, 4005, 4007, 25, GumpButtonType.Reply, 0);
                }
                if (AlchemyBoxTypes.PoisonPotion.Length > 19)
                {
                    AddLabel(310, 225, 33, "More Poison Potions");
                    AddButton(275, 225, 4005, 4007, 26, GumpButtonType.Reply, 0);
                }
                if (AlchemyBoxTypes.RefreshPotion.Length > 19)
                {
                    AddLabel(310, 250, 33, "More Refresh Potions");
                    AddButton(275, 250, 4005, 4007, 27, GumpButtonType.Reply, 0);
                }
                if (AlchemyBoxTypes.HealPotion.Length > 19)
                {
                    AddLabel(310, 275, 33, "More Heal Potions Potions");
                    AddButton(275, 275, 4005, 4007, 28, GumpButtonType.Reply, 0);
                }
                if (AlchemyBoxTypes.ExplosionPotion.Length > 19)
                {
                    AddLabel(310, 300, 33, "More Explosion Potions");
                    AddButton(275, 300, 4005, 4007, 29, GumpButtonType.Reply, 0);
                }
			}
			else
			{
				AddLabel( 225, 25, 0x480, AddLabelsButtonsAmounts() );
				AddButton( 425, 25, 4014, 4015, 2, GumpButtonType.Reply, 0 );
				AddLabel( 460, 25, 0x8AB, "Back" );
			}
		}
		private string AddLabelsButtonsAmounts()
		{
			string Label = "";
			int Offset = 0;
			switch( (int)m_Page )
			{
                case (int)Pages.Bottles:            { m_Types = AlchemyBoxTypes.Bottle;                Label = "Empty Bottles"; Offset = 0; break; }
                case (int)Pages.PotionKeg:         { m_Types = AlchemyBoxTypes.PotionKeg;             Label = "Empty Potion Kegs"; Offset = 0; break; }
                case (int)Pages.NightSightPotion: { m_Types = AlchemyBoxTypes.NightSightPotion;      Label = "NightSight Potions"; Offset = 0; break; }

                case (int)Pages.CurePotion:       { m_Types = AlchemyBoxTypes.CurePotion;           Label = "Cure Potions"; Offset = 0; break; }
                case (int)Pages.AgilityPotion:    { m_Types = AlchemyBoxTypes.AgilityPotion;        Label = "Agility Potions"; Offset = 0; break; }
                case (int)Pages.StrengthPotion:   { m_Types = AlchemyBoxTypes.StrengthPotion;       Label = "Strength Potions"; Offset = 0; break; }
                case (int)Pages.PoisonPotion:     { m_Types = AlchemyBoxTypes.PoisonPotion;         Label = "Poison Potions"; Offset = 0; break; }
                case (int)Pages.RefreshPotion:    { m_Types = AlchemyBoxTypes.RefreshPotion;        Label = "Refresh Potions"; Offset = 0; break; }
                case (int)Pages.HealPotion:       { m_Types = AlchemyBoxTypes.HealPotion;           Label = "Heal Potions"; Offset = 0; break; }
                case (int)Pages.ExplosionPotion:  { m_Types = AlchemyBoxTypes.ExplosionPotion;      Label = "Explosion Potions"; Offset = 0; break; }


                case (int)Pages.MoreBottle:             { m_Types = AlchemyBoxTypes.Bottle;                 Label = "More Empty Bottles"; Offset = 19; break; }
                case (int)Pages.MorePotionKeg:          { m_Types = AlchemyBoxTypes.PotionKeg;              Label = "More Empty Potion Kegs"; Offset = 19; break; }
				case (int)Pages.MoreNightSightPotion:  { m_Types = AlchemyBoxTypes.NightSightPotion;		Label = "More NightSight Potions"; Offset = 19;	break;}
                case (int)Pages.MoreCurePotion:        { m_Types = AlchemyBoxTypes.CurePotion;            Label = "More Cure Potions"; Offset = 19; break; }
                case (int)Pages.MoreAgilityPotion:     { m_Types = AlchemyBoxTypes.AgilityPotion;         Label = "More Agility Potions"; Offset = 19; break; }
                case (int)Pages.MoreStrengthPotion:    { m_Types = AlchemyBoxTypes.StrengthPotion;        Label = "More Strength Potions"; Offset = 19; break; }
                case (int)Pages.MorePoisonPotion:      { m_Types = AlchemyBoxTypes.PoisonPotion;          Label = "More Poison Potions"; Offset = 19; break; }
                case (int)Pages.MoreRefreshPotion:     { m_Types = AlchemyBoxTypes.RefreshPotion;         Label = "More Refresh Potions"; Offset = 19; break; }
                case (int)Pages.MoreHealPotion:        { m_Types = AlchemyBoxTypes.HealPotion;            Label = "More Heal Potions"; Offset = 19; break; }
                case (int)Pages.MoreExplosionPotion:   { m_Types = AlchemyBoxTypes.ExplosionPotion;       Label = "More Explosion Potions"; Offset = 19; break; }

			}

			for( int i = Offset; i < m_Types.Length && i < 19 + Offset; i++ )
			{
				Type type = m_Types[i];

				if( !m_Box.Resources.ContainsKey( type ) )
					continue;

				if( (i - Offset) <= 7 )
				{
					AddLabel( 110, 75+((i-Offset)*25), 1152, type.Name );
					if( (int)m_Box.Resources[type] >= 100000 )
						AddLabel( 225, 75+((i-Offset)*25), 1152, "99999" );
					else
						AddLabel( 225, 75+((i-Offset)*25), 1152, ((int)m_Box.Resources[type]).ToString() );
					AddButton( 75, 75+((i-Offset)*25), 4029, 4030, i+100, GumpButtonType.Reply, 0 );
				}
				else
				{
					AddLabel( 310, 75+((i-8-Offset)*25), 1152, type.Name );
					if( (int)m_Box.Resources[type] >= 100000 )
						AddLabel( 225, 75+((i-8-Offset)*25), 1152, "99999" );
					else
						AddLabel( 425, 75+((i-8-Offset)*25), 1152, ((int)m_Box.Resources[type]).ToString() );
					AddButton( 275, 75+((i-8-Offset)*25), 4029, 4030, i+100, GumpButtonType.Reply, 0 );
				}
			}
			return Label;
		}

      private class AlchemyBoxTarget : Target
      {
			private AlchemyBox m_Box;
			private Pages m_Page;

            public AlchemyBoxTarget(AlchemyBox box, Pages page) : base(18, false, TargetFlags.None)
			{
					m_Box = box;
					m_Page = page;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Box.Deleted )
					return;
				if( targeted is Item )
				{
					if( m_Box.TryAdd( targeted as Item ) )
						from.SendMessage( "Resource added, please choose another." );
					else
						from.SendMessage( "Resource could not be added, please try another." );

					from.Target = new AlchemyBoxTarget( m_Box, m_Page );
				}
			}

			protected override void OnTargetCancel( Mobile from, TargetCancelType cancelType )
			{
				from.SendGump( new AlchemyBoxGump( from, m_Box, m_Page ) );
			}
      }

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			int BID = info.ButtonID;

			if( BID == 1 )
			{
				if ( from.InRange( m_Box.GetWorldLocation(), 3 ) )
				{
					from.SendMessage( "Target a resource to add" );
					from.Target = new AlchemyBoxTarget( m_Box, m_Page );
				}
				else
				{
					from.SendMessage( "You are not in range of your Resource Box!" );
					from.CloseGump( typeof (AlchemyBoxGump) );
				}
			}

			else if( BID == 2 )
			{
                from.SendGump( new AlchemyBoxGump(from, m_Box, Pages.Start));
			}

			else if( BID >= 10 && BID < 29 )
			{
				from.SendGump( new AlchemyBoxGump( from, m_Box, (Pages)(BID-9) ) );
			}

			else if( BID >= 100 && BID < 132 )
			{
				Type type = m_Types[BID-100];
				if ( from.InRange( m_Box.GetWorldLocation(), 3 ) )
				{
					from.SendMessage( "Enter Amount, you wish to remove from the box" );
					from.Prompt = new ExtractPrompt( type, m_Box, m_Page );
				}    
				 else
				{
					from.SendMessage( "You are not in range of the Alchemy box!" );
					from.CloseGump( typeof (AlchemyBoxGump) );
				}   
			}
		}	
		private class ExtractPrompt : Prompt
		{
			private Type m_type;
			private AlchemyBox m_Box;
			private Pages m_Page;

            public ExtractPrompt( Type type, AlchemyBox box, Pages page)
			{
				m_type = type;
				m_Box = box;
				m_Page = page;
			}
			
			public override void OnResponse( Mobile typer, string text )
			{	
				int amount = Utility.ToInt32( text );
				if ( amount < 10000 )
					m_Box.ExtractResource( typer, m_type, amount );
				else
					typer.SendMessage( "You may only take a max of 10,000 items at once." );
			
				typer.SendGump( new AlchemyBoxGump( typer, m_Box, m_Page ) );			
				
			}
		}
	}
}
