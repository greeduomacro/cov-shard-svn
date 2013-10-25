// Created by Peoharen
using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Commands
{
	public class AssassinCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "ACreed", AccessLevel.Player, new CommandEventHandler( AC_OnCommand ) );
		}

		[Usage( "AC <text>" )]
		[Description( "Use \"[ACreed help\" for more information." )]
		public static void AC_OnCommand( CommandEventArgs e )
		{
			if ( !AssassinControl.IsAssassin( e.Mobile ) && e.Mobile.AccessLevel == AccessLevel.Player )
			{
				e.Mobile.SendMessage( 1194, "You must be an assassin to use this command." );
				return;
			}
			else if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing their house

			string words = e.GetString( 0 ).ToLower();

			if ( words == null || words == "" )
			{
				e.Mobile.CloseGump( typeof( AssassinSkillsGump ) );
				e.Mobile.SendGump( new AssassinSkillsGump( e.Mobile ) );
			}
			else if ( words == "help" )
			{
				e.Mobile.SendMessage( 1194, "\"[ACreed\" opens the assassin's skills menu where you can use other weapon abilities." );
				e.Mobile.SendMessage( 1194, "\"[ACreed assassinate\" sets your weapon ability to Assassinate." );
				e.Mobile.SendMessage( 1194, "\"[ACreed armorignore\" sets your weapon ability to Armor Ignore." );
				e.Mobile.SendMessage( 1194, "\"[ACreed bleedattack\" sets your weapon ability to Bleed Attack." );
				e.Mobile.SendMessage( 1194, "\"[ACreed mortalstrike\" sets your weapon ability to Mortal Strike." );
				e.Mobile.SendMessage( 1194, "\"[ACreed shadowstrike\" sets your weapon ability to Shadow Strike." );
				e.Mobile.SendMessage( 1194, "\"[ACreed heal\" Attempts to heal. In order of attempts; assassin's belt, bandage, heal potions." );
				e.Mobile.SendMessage( 1194, "\"[ACreed title\" Updates your Assassin title based on assassin gear worn." );
				//e.Mobile.SendMessage( 1194, "\"[ACreed travel\" opens a special assassin only recall/mark menu.");
			}
			else if ( words == "assassinate" )
			{
				SpecialMove.SetCurrentMove( e.Mobile, new AssassinateMove() );
				e.Mobile.SendMessage( 1194, "You prepare to use Assassinate." );
			}
			else if ( words == "armorignore" )
			{
				SpecialMove.SetCurrentMove( e.Mobile, new ArmorIgnoreMove() );
				e.Mobile.SendMessage( 1194, "You prepare to use Armor Ignore" );
			}
			else if ( words == "bleedattack" )
			{
				SpecialMove.SetCurrentMove( e.Mobile, new BleedAttackMove() );
				e.Mobile.SendMessage( 1194, "You prepare to use Bleed Attack" );
			}
			else if ( words == "mortalstrike" )
			{
				SpecialMove.SetCurrentMove( e.Mobile, new MortalStrikeMove() );
				e.Mobile.SendMessage( 1194, "You prepare to use Mortal Strike" );
			}
			else if ( words == "shadowstrike" )
			{
				SpecialMove.SetCurrentMove( e.Mobile, new ShadowStrikeMove() );
				e.Mobile.SendMessage( 1194, "You prepare to use Shadow Strike" );
			}
			else if ( words == "heal" )
			{
				if ( e.Mobile.Hits == e.Mobile.HitsMax )
				{
					e.Mobile.SendMessage( 1194, "You are already at full life." );
					return;
				}

				// Belt
				ACreedBelt belt = e.Mobile.FindItemOnLayer( Layer.Waist ) as ACreedBelt;

				if ( belt != null )
				{
					if ( DateTime.Now > belt.HealDelay )
					{
						belt.OnDoubleClick( e.Mobile );
						return;
					}
				}

				if ( e.Mobile.Backpack == null )
					return;

				// Bandage
				if ( e.Mobile.Backpack.ConsumeTotal( typeof( Bandage ), 1 ) )
				{
					if ( BandageContext.GetContext( e.Mobile ) == null )
					{
						e.Mobile.SendLocalizedMessage( 500956 ); // You begin applying the bandages.
						BandageContext.BeginHeal( e.Mobile, e.Mobile );
						return;
					}
				}

				// Heal Potions
				BaseHealPotion potion = e.Mobile.Backpack.FindItemByType( typeof( GreaterHealPotion ) ) as BaseHealPotion;

				if ( potion == null )
					potion = e.Mobile.Backpack.FindItemByType( typeof( HealPotion ) ) as BaseHealPotion;
				if ( potion == null )
					potion = e.Mobile.Backpack.FindItemByType( typeof( LesserHealPotion ) ) as BaseHealPotion;

				if ( potion != null )
				{
					potion.OnDoubleClick( e.Mobile );
					return;
				}

				e.Mobile.SendMessage( 1194, "No way to heal found." );
			}
			else if ( words == "title" )
			{
				int gear = 0;

				if ( e.Mobile.FindItemOnLayer( Layer.Helm ) is ACreedGarb ) // Chain Coif
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Neck ) is ACreedGarb ) // Mempo
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.MiddleTorso ) is ACreedGarb ) // Jin Bori
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.InnerTorso ) is ACreedGarb ) // Studded Chest
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Waist ) is ACreedGarb ) // Belt
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Pants ) is ACreedGarb ) // Thigh Boots
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Shoes ) is ACreedGarb ) // Skirt
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Arms ) is ACreedGarb ) // Bone Arms
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.OuterLegs ) is ACreedGarb ) // Kilt
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Shirt ) is ACreedGarb ) // Shirt
					++gear;
				if ( e.Mobile.FindItemOnLayer( Layer.Gloves ) is ACreedGarb ) // Gloves
					++gear;

				switch( gear )
				{
					case 0: case 1: e.Mobile.Title = "the Thief"; break;
					case 2: case 3: e.Mobile.Title = "the Rogue"; break;
					case 4: case 5: e.Mobile.Title = "the Assassin"; break;
					case 6: case 7: e.Mobile.Title = "the Skilled Assassin"; break;
					case 8: case 9: e.Mobile.Title = "the Master Assassin"; break;
					case 10: case 11: e.Mobile.Title = "the Grandmaster Assassin"; break;
				}
			}
			else if ( words == "travel" )
			{
				// Todo: Finish
				e.Mobile.CloseGump( typeof( AssassinSkillsGump ) );
				e.Mobile.SendGump( new AssassinSkillsGump( e.Mobile ) );
			}
		}
	}
}
