// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class RuneBowCraftGump : Gump
	{
		public enum Buttons
		{
			Close,

			ForceRadio,
			FireRadio,
			ColdRadio,
			AcidRadio,
			EnergyRadio,

			AccurateRadio,
			BalancedRadio,
			PowerfulRadio,
			QuickRadio,
			DraconicRadio,
			ChampionRadio,
			FaithRadio,
			ParagonRadio,
			PeerlessRadio,
			Submit
		}

		public RuneBowCraftGump() : base( 0, 0 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 510, 285, 9270 );
			AddBackground( 15, 45, 150, 195, 9270 );
			AddBackground( 180, 45, 150, 195, 9270 );
			AddBackground( 345, 45, 150, 195, 9270 );

			AddItem( 15, 15, 9923, 1191 );
			AddLabel( 182, 15, 1191, "Rune Bow Crafting" );

			AddLabel( 50, 60, 1191, "Shot Type" );
			AddLabel( 60, 85, 0, "Force Shot" );
			AddCheck( 30, 85, 210, 209, false, (int)Buttons.ForceRadio );
			AddLabel( 60, 115, 0, "Fire Blast" );
			AddCheck( 30, 115, 210, 209, false, (int)Buttons.FireRadio );
			AddLabel( 60, 145, 0, "Cold Bolts" );
			AddCheck( 30, 145, 210, 209, false, (int)Buttons.ColdRadio );
			AddLabel( 60, 175, 0, "Acid Shot" );
			AddCheck( 30, 175, 210, 209, false, (int)Buttons.AcidRadio );
			AddLabel( 60, 205, 0, "Energy Storm" );
			AddCheck( 30, 205, 210, 209, false, (int)Buttons.EnergyRadio );

			AddLabel( 210, 60, 1191, "Build Style" );
			AddLabel( 225, 85, 0, "Accurate" );
			AddCheck( 195, 85, 210, 209, false, (int)Buttons.AccurateRadio );
			AddLabel( 225, 115, 0, "Balanced" );
			AddCheck( 195, 115, 210, 209, false, (int)Buttons.BalancedRadio );
			AddLabel( 225, 145, 0, "Powerful" );
			AddCheck( 195, 145, 210, 209, false, (int)Buttons.PowerfulRadio );
			AddLabel( 225, 175, 0, "Quick" );
			AddCheck( 195, 175, 210, 209, false, (int)Buttons.QuickRadio );

			AddLabel( 375, 60, 1191, "Rune Word" );
			AddLabel( 390, 85, 0, "Draconic" );
			AddCheck( 360, 85, 210, 209, false, (int)Buttons.DraconicRadio );
			AddLabel( 390, 115, 0, "Champion" );
			AddCheck( 360, 115, 210, 209, false, (int)Buttons.ChampionRadio );
			AddLabel( 390, 145, 0, "Faith" );
			AddCheck( 360, 145, 210, 209, false, (int)Buttons.FaithRadio );
			AddLabel( 390, 175, 0, "Paragon" );
			AddCheck( 360, 175, 210, 209, false, (int)Buttons.ParagonRadio );
			AddLabel( 390, 205, 0, "Peerless" );
			AddCheck( 360, 205, 210, 209, false, (int)Buttons.PeerlessRadio );

			AddButton( 220, 245, 247, 248, (int)Buttons.Submit, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 0 || sender.Mobile == null || sender.Mobile.Backpack == null )
				return;

			#region ChoiceCheck
			RuneBowShotType shot = RuneBowShotType.ForceShot;
			RuneBowBuildType build = RuneBowBuildType.Balanced;
			RuneBowRunes runes = RuneBowRunes.Draconic;
			int check = 0;
		
			if ( info.IsSwitched( (int)Buttons.ForceRadio ) )
				{ shot = RuneBowShotType.ForceShot; ++check; }
			if ( info.IsSwitched( (int)Buttons.FireRadio ) )
				{ shot = RuneBowShotType.FireBlast; ++check; }
			if ( info.IsSwitched( (int)Buttons.ColdRadio ) )
				{ shot = RuneBowShotType.ColdBolts; ++check; }
			if ( info.IsSwitched( (int)Buttons.AcidRadio ) )
				{ shot = RuneBowShotType.AcidShot; ++check; }
			if ( info.IsSwitched( (int)Buttons.EnergyRadio ) )
				{ shot = RuneBowShotType.EnergyStorm; ++check; }

			if ( check > 1 )
			{
				sender.Mobile.SendMessage( "You can only choose one type of rune word." );
				return;
			}

			check = 0;

			if ( info.IsSwitched( (int)Buttons.AccurateRadio ) )
				{ build = RuneBowBuildType.Accurate; ++check; }
			if ( info.IsSwitched( (int)Buttons.BalancedRadio ) )
				{ build = RuneBowBuildType.Balanced; ++check; }
			if ( info.IsSwitched( (int)Buttons.PowerfulRadio ) )
				{ build = RuneBowBuildType.Powerful; ++check; }
			if ( info.IsSwitched( (int)Buttons.QuickRadio ) )
				{ build = RuneBowBuildType.Quick; ++check; }

			if ( check > 1 )
			{
				sender.Mobile.SendMessage( "You can only choose one design to build your rune bow." );
				return;
			}

			check = 0;

			if ( info.IsSwitched( (int)Buttons.DraconicRadio ) )
				{ runes = RuneBowRunes.Draconic; ++check; }
			if ( info.IsSwitched( (int)Buttons.ChampionRadio ) )
				{ runes = RuneBowRunes.Champion; ++check; }
			if ( info.IsSwitched( (int)Buttons.FaithRadio ) )
				{ runes = RuneBowRunes.Faith; ++check; }
			if ( info.IsSwitched( (int)Buttons.ParagonRadio ) )
				{ runes = RuneBowRunes.Paragon; ++check; }
			if ( info.IsSwitched( (int)Buttons.PeerlessRadio ) )
				{ runes = RuneBowRunes.Peerless; ++check; }

			if ( check > 1 )
			{
				sender.Mobile.SendMessage( "You can only choose one type of rune word." );
				return;
			}
			#endregion

			int items = sender.Mobile.Backpack.ConsumeTotal(
				new Type[]
				{
					typeof( Crossbow ),
					typeof( HeavyCrossbow ),
					typeof( RepeatingCrossbow ),
					typeof( ArcaneGem ),
					typeof( PowerCrystal ),
					
					typeof( BlackPearl ),
					typeof( Bloodmoss ),
					typeof( Garlic ),
					typeof( Ginseng ),
					typeof( MandrakeRoot ),
					typeof( Nightshade ),
					typeof( SulfurousAsh ),
					typeof( SpidersSilk ),

					typeof( BatWing ),
					typeof( GraveDust ),
					typeof( DaemonBlood ),
					typeof( NoxCrystal ),
					typeof( PigIron ),

					typeof( ClockParts ),
					typeof( SextantParts ),
					typeof( Gears ),
					typeof( Springs ),
					typeof( IronIngot )
				},
				new int[]
				{
					1, 1, 1, 10, 2,
					200, 200, 200, 200, 200, 200, 200, 200,
					200, 200, 200, 200, 200,
					1, 1, 5, 5, 10
				}
			);

			if ( items != -1 )
			{
				sender.Mobile.CloseGump( typeof( FailedCraftGump ) );
				sender.Mobile.SendGump( new FailedCraftGump( m_RequiredMessage ) );
				return;
			}

			sender.Mobile.SendMessage( 1192, "You create a new Rune Bow" );
			sender.Mobile.Skills[SkillName.ItemID].Base -= 25.0;
			sender.Mobile.Backpack.DropItem( new RuneBow( shot, build, runes ) );
		}

		private const string m_RequiredMessage =
			"Weapons Required: 1 Crossbow, 1 Heavy Crossbow, 1 Repeating Crossbow.<br>" +
			"Binding Ingredents Required: 10 Arcane Gems, 2 Power Crystals.<br>" +
			"Regents Required: 200 each of the following; Black Pearl, Bloodmoss, Garlic, Ginseng, Mandrake Root, Nightshade,Sulfurous Ash, spider's Silk, Bat Wing, Grave Dust, Daemon Blood, Nox Crystal, Pig Iron.<br>" +
			"Parts Required: 1 Clock Parts, 1 Sextant Parts, 5 Gears, 5 Springs, 10 Iron Ingots.<br>" +
			"Special: Requires a personal imbuing sacrifice; 25.0 loss to ItemID (can be retrained).";

	}
}

namespace Server.Commands
{
	public class RuneBowCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "RuneBow", AccessLevel.GameMaster, new CommandEventHandler( SpellBinding_OnCommand ) );
		}

		[Description( "Opens the RuneBow crafting gump" )]
		public static void SpellBinding_OnCommand( CommandEventArgs e )
		{
			e.Mobile.CloseGump( typeof( RuneBowCraftGump ) );
			e.Mobile.SendGump( new RuneBowCraftGump() );
		}
	}
}