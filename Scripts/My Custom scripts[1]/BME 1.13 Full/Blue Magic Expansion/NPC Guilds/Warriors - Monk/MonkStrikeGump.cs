// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Gumps
{
	public class MonkStrikeGump : Gump
	{
		private int[] Hues = 
		{
			// none, gold, dark brown, blaze, blue mage, white, shadow iron
			0, 1176, 1191, 1160, 1364, 1149, 1108
		};

		public MonkStrikeGump( Mobile from ) : base( 150, 600 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 325, 110, 9250 );

			#region Current
			AddLabel( 15, 20, 0, "Monk Combo:" );

			if ( MonkSystem.ComboChain.ContainsKey( from ) )
			{
				if ( MonkSystem.ComboChain[from].First != MonkElement.None )
					AddImage( 105, 15, 30055, Hues[(int)MonkSystem.ComboChain[from].First] );

				if ( MonkSystem.ComboChain[from].Second != MonkElement.None )
					AddImage( 140, 15, 30055, Hues[(int)MonkSystem.ComboChain[from].Second] );

				if ( MonkSystem.ComboChain[from].Third != MonkElement.None )
					AddImage( 175, 15, 30055, Hues[(int)MonkSystem.ComboChain[from].Third] );
			}
			#endregion

			#region Moves
			MonkElement litup = MonkElement.None;
			MonkStrike ms = SpecialMove.GetCurrentMove( from ) as MonkStrike;

			if ( ms != null )
				litup = ms.m_Element;

			if ( litup == MonkElement.Air )
				AddImage( 15, 50, 2269, 33 );
			else
				AddButton( 15, 50, 2269, 2269, (int)MonkElement.Air, GumpButtonType.Reply, 0 );

			if ( litup == MonkElement.Earth )
				AddImage( 65, 50, 2296, 33 );
			else
				AddButton( 65, 50, 2296, 2296, (int)MonkElement.Earth, GumpButtonType.Reply, 0 );

			if ( litup == MonkElement.Fire )
				AddImage( 115, 50, 2282, 33 );
			else
				AddButton( 115, 50, 2282, 2282, (int)MonkElement.Fire, GumpButtonType.Reply, 0 );

			if ( litup == MonkElement.Water )
				AddImage( 165, 50, 2291, 33 );
			else
				AddButton( 165, 50, 2291, 2291, (int)MonkElement.Water, GumpButtonType.Reply, 0 );

			if ( litup == MonkElement.Light )
				AddImage( 215, 50, 2298, 33 );
			else
				AddButton( 215, 50, 2298, 2298, (int)MonkElement.Light, GumpButtonType.Reply, 0 );

			if ( litup == MonkElement.Dark )
				AddImage( 265, 50, 2283, 33 );
			else
				AddButton( 265, 50, 2283, 2283, (int)MonkElement.Dark, GumpButtonType.Reply, 0 );

			#endregion

			#region Finisher
			MonkElement finisher = MonkSystem.GetCombo( from );

			if ( (int)finisher > 7 )
			{
				AddBackground( 325, 45, 65, 65, 9250 );
				int itemid = 0;

				switch( finisher )
				{
					case MonkElement.AirCombo: itemid = 2289; break;
					case MonkElement.EarthCombo: itemid = 2273; break;
					case MonkElement.FireCombo: itemid = 2267; break;
					case MonkElement.WaterCombo: itemid = 2286; break;
					case MonkElement.LightCombo: itemid = 23012; break;
					case MonkElement.DarkCombo: itemid = 23013; break;

					case MonkElement.LightAirCombo: itemid = 20494; break;
					case MonkElement.LightEarthCombo: itemid = 21008; break;
					case MonkElement.LightFireCombo: itemid = 20736; break;
					case MonkElement.LightWaterCombo: itemid = 21280; break;

					case MonkElement.DarkAirCombo: itemid = 23004; break;
					case MonkElement.DarkFireCombo: itemid = 24011; break;
					case MonkElement.DarkEarthCombo: itemid = 23009; break;
					case MonkElement.DarkWaterCombo: itemid = 24015; break;
				}

				if ( (int)litup > 7 )
					AddImage( 335, 55, itemid, 33 );
				else
					AddButton( 335, 55, itemid, itemid, (int)finisher, GumpButtonType.Reply, 0 );
			}
			#endregion

			MonkFists mf = from.FindItemOnLayer( Layer.Gloves ) as MonkFists;

			#region Wholeness
			if ( mf != null && mf.Teir > 1 )
			{
				AddBackground( 325, 0, 65, 45, 9250 );

				if ( from.CanBeginAction( typeof( MonkCombos.WholenessOfBodyTimer ) ) )
					AddButton( 344, 8, 30035, 30035, 999, GumpButtonType.Reply, 0 );
				else
					AddImage( 344, 8, 30035, 1000 );
			}
			#endregion

			#region Dark/Light Special
			if ( mf != null && mf.Teir > 2 )
			{
				if ( mf.LightEnergy > 95 )
				{
					AddButton( 284, 12, 30115, 30102, (int)MonkElement.LightSpecialOne, GumpButtonType.Reply, 0 );
					AddButton( 245, 12, 30105, 30105, (int)MonkElement.LightSpecialTwo, GumpButtonType.Reply, 0 );

				}
				else if ( mf.DarkEnergy > 95 )
				{
					AddButton( 284, 12, 30115, 30102, (int)MonkElement.DarkSpecialOne, GumpButtonType.Reply, 0 );
					AddButton( 245, 12, 30105, 30105, (int)MonkElement.DarkSpecialTwo, GumpButtonType.Reply, 0 );
				}
				else
				{
					AddImage( 215, 15, 9750 );
					AddImage( 215, 35, 9750 );

					AddImageTiled( 215, 15, (mf.LightEnergy), 7, 9753 );
					AddImageTiled( 215, 35, (mf.DarkEnergy), 7, 9751 );
				}
			}
			#endregion

			#region Void
			if ( mf != null && mf.Teir > 3 )
			{
			}
			#endregion
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 0 )
				return;

			MonkFists mf = sender.Mobile.FindItemOnLayer( Layer.Gloves ) as MonkFists;

			if ( mf == null )
			{
				sender.Mobile.SendMessage( "Only monks can use this strike." );
				return;
			}

			if ( info.ButtonID == 999 )
			{
				new MonkCombos.WholenessOfBodyTimer( sender.Mobile ).Start();

				if ( sender.Mobile.HasGump( typeof( MonkStrikeGump ) ) )
					sender.Mobile.CloseGump( typeof( MonkStrikeGump ) );

				sender.Mobile.SendGump( new MonkStrikeGump( sender.Mobile ) );

				return;
			}

			switch( (MonkElement)info.ButtonID )
			{
				case MonkElement.None:
				{
					sender.Mobile.Freeze( TimeSpan.FromSeconds( 1 ) );
					sender.Mobile.Animate( 17, 7, 1, true, false, 0 );

					MonkSystem.AddHit( sender.Mobile, (MonkElement)info.ButtonID );

					if ( sender.Mobile.HasGump( typeof( MonkStrikeGump ) ) )
						sender.Mobile.CloseGump( typeof( MonkStrikeGump ) );

					sender.Mobile.SendGump( new MonkStrikeGump( sender.Mobile ) );
					break;
				}
				case MonkElement.FireCombo:
				{
					MonkCombos.FireCombo( sender.Mobile );
					break;
				}
				case MonkElement.LightCombo:
				{
					MonkCombos.LightCombo( sender.Mobile );
					goto case MonkElement.None;
				}
				case MonkElement.LightAirCombo:
				{
					MonkCombos.LightAirCombo( sender.Mobile );
					goto case MonkElement.None;
				}
				case MonkElement.LightEarthCombo:
				{
					MonkCombos.LightEarthCombo( sender.Mobile );
					goto case MonkElement.None;
				}
				case MonkElement.LightFireCombo:
				{
					MonkCombos.LightFireCombo( sender.Mobile );
					goto case MonkElement.None;
				}
				case MonkElement.LightWaterCombo:
				{
					MonkCombos.LightWaterCombo( sender.Mobile );
					goto case MonkElement.None;
				}
				case MonkElement.LightVoidCombo:
				{
					// Moment of Clarity: Activate this to grant your allies a +5 Insight bonus to hit and to skill checks for a very short period of time.
					goto case MonkElement.None;
				}
				case MonkElement.LightSpecialOne:
				{
					mf.LightEnergy = mf.DarkEnergy = 0;
					break;
				}
				case MonkElement.LightSpecialTwo:
				{
					mf.LightEnergy = mf.DarkEnergy = 0;
					break;
				}
				case MonkElement.DarkSpecialOne:
				{
					mf.LightEnergy = mf.DarkEnergy = 0;
					break;
				}
				case MonkElement.DarkSpecialTwo:
				{
					mf.LightEnergy = mf.DarkEnergy = 0;
					break;
				}
				default:
				{
					if ( Enum.IsDefined( typeof( MonkElement ), info.ButtonID ) )
						SpecialMove.SetCurrentMove( sender.Mobile, new MonkStrike( (MonkElement)info.ButtonID ) );
					break;
				}
			}


		}
	}
}
			/*
			// Icon Notes
			AddImage( 15, 150, 2289 );
			AddImage( 65, 150, 2273 );
			AddImage( 115, 150, 2267 );
			AddImage( 165, 150, 2286 );
			AddImage( 215, 150, 23012 );
			AddImage( 265, 150, 23013 );

			AddImage( 15, 200, 20494 );
			AddImage( 65, 200, 21008 );
			AddImage( 115, 200, 20736 );
			AddImage( 165, 200, 21280 );

			AddImage( 15, 250, 23004 );
			AddImage( 65, 250, 24011 );
			AddImage( 115, 250, 23009 );
			AddImage( 165, 250, 24015 );
			*/