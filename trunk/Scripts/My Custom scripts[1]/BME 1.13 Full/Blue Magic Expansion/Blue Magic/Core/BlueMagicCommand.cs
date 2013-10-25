// Created by Peoharen
using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Commands
{
	public class BlueMagicCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "BM", AccessLevel.Player, new CommandEventHandler( BM_OnCommand ) );
		}

		[Usage( "BM <spell>" )]
		[Description( "Use \"[bm help\" for more information." )]
		public static void BM_OnCommand( CommandEventArgs e )
		{
			if ( e.Mobile.AccessLevel == AccessLevel.Counselor )
			{
				e.Mobile.SendMessage( 1365, "Counselors are not allowed to use Blue Magic" );
				return;
			}
			else if ( !BlueMageControl.IsBlueMage( e.Mobile ) && e.Mobile.AccessLevel == AccessLevel.Player )
			{
				e.Mobile.SendMessage( "You must be a blue mage to use this command." );
				return;
			}
			else if ( !Multis.DesignContext.Check( e.Mobile ) )
				return; // They are customizing their house

			string spellstring = e.GetString( 0 ).ToLower();

			if ( spellstring == null || spellstring == "" )
			{
				if ( e.Mobile.HasGump( typeof( BlueSpellsKnownGump ) ) )
					e.Mobile.CloseGump( typeof( BlueSpellsKnownGump ) );

				e.Mobile.SendGump( new BlueSpellsKnownGump( e.Mobile ) );
			}
			else if ( spellstring == "help" )
			{
				e.Mobile.SendMessage( 1365, "\"[bm\" + spellname (lower or upper case, it don't matter) to cast the spell.");
				e.Mobile.SendMessage( 1365, "\"[bm\" opens a menu listing details on the spells you know.");
				e.Mobile.SendMessage( 1365, "\"[bm study\" Allows you to try and study a corpse to learn a blue spell [requires high forensics]");

				if ( e.Mobile.AccessLevel >= AccessLevel.GameMaster )
				{
					e.Mobile.SendMessage( 1365, "[Seer+] \"[bm get\" allows you to target a player and get their list of spell's known.");
					e.Mobile.SendMessage( 1365, "[Seer+] \"[bm giveitem\" Gives you most of the items a blue mage would use.");
				}

				if ( e.Mobile.AccessLevel > AccessLevel.Seer )
					e.Mobile.SendMessage( 1365, "[Admin+] \"[bm log\" opens a gump containing the information of all registered blue mages and spells known by them.");
			}
			else if ( spellstring == "get" && e.Mobile.AccessLevel >= AccessLevel.GameMaster )
			{
				e.Mobile.SendMessage( 1365, "Target a player you get their list of spells known." );
				e.Mobile.Target = new SpellKnownTarget();
			}
			else if ( spellstring == "log" && e.Mobile.AccessLevel > AccessLevel.Seer )
			{
				if ( e.Mobile.HasGump( typeof( BlueMageLogGump ) ) )
					e.Mobile.CloseGump( typeof( BlueMageLogGump ) );

				e.Mobile.SendGump( new BlueMageLogGump() );
			}
			else if ( spellstring == "learnall" && e.Mobile.AccessLevel > AccessLevel.GameMaster )
			{
				BlueMageControl.LearnAll( e.Mobile );
				e.Mobile.SendMessage( 1365, "Learning all blue spells" );
			}
			else if ( spellstring == "giveitems" && e.Mobile.AccessLevel > AccessLevel.GameMaster )
			{
				GiveItems( e.Mobile );
				e.Mobile.SendMessage( 1365, "Giving Items" );
			}
			else if ( spellstring == "cave" /*&& e.Mobile.AccessLevel > AccessLevel.Player*/ )
			{
				e.Mobile.MoveToWorld( new Point3D( 1704, 591, 9 ), Map.Ilshenar );
			}
			else if ( spellstring == "study" )
			{
				if ( e.Mobile.Skills[SkillName.Forensics].Value < 100.0 )
					e.Mobile.SendMessage( 1365, "Your Forensics isn't high enough to use this." );
				else
				{
					e.Mobile.Target = new StudyTarget();
					e.Mobile.SendMessage( 1365, "Target the corpse of a monster you killed to study it." );
				}
			}
			else if ( spellstring == "giveall" && e.Mobile.AccessLevel > AccessLevel.Counselor )
			{
				BlueMageControl.LearnAll( e.Mobile );
				e.Mobile.SendMessage( 1365, "Learning all blue spells" );

				string prams = e.ArgString;

				if ( prams.Contains( "skills" ) )
				{
					if ( e.Mobile.Backpack != null )
					{
						e.Mobile.Backpack.DropItem( new BlueSkillBall( -1 ) );
					}
				}
				if ( prams.Contains( "items" ) )
				{
					GiveItems( e.Mobile );
				}
			}

			else
			{
				int number = 100;
				try { number = Convert.ToInt32( spellstring ); }
				catch {}

				if ( number != 100 )
				{
					BlueSpellInfo.UseBluePower( e.Mobile, number );
				}
				else
				{
					if ( BlueSpellInfo.UseBluePower( e.Mobile, spellstring ) == false )
						e.Mobile.SendMessage( "No such spell can be found." );
				}
			}
		}

		private static void GiveItems( Mobile m )
		{
			Container pack = m.Backpack;

			if ( pack == null )
			{
				return;
			}

			// Frog Drop
			/*
			MetalBox box = new MetalBox();
			box.Name = "<BASEFONT COLOR='#007FFF'>Frog Drop Collection";
			box.LootType = LootType.Blessed;
			box.Locked = true;
			box.RequiredSkill = box.LockLevel = 1000;
			box.DropItem( new WorldMap() );
			box.DropItem( new RedLeaves() );
			box.DropItem( new Sand() );
			box.DropItem( new SpecialHairDye() );
			box.DropItem( new Rope() );
			box.DropItem( new Vines() );
			box.DropItem( new TribalPaint() );
			box.DropItem( new RockArtifact() );
			box.DropItem( new Runebook() );
			box.DropItem( new Gold( 500 ) );
			*/
			pack.DropItem( new FrogDropBag( true ) );

			// Angel's Snack
			Pouch pouch = new Pouch();
			pouch.DropItem( new HealPotion( 25 ) );
			pouch.DropItem( new CurePotion( 25 ) );
			pouch.DropItem( new RefreshPotion( 25 ) );
			pack.DropItem( pouch );

			// Forks
			Bag bag = new Bag();
			bag.Name = "Forks";
			bag.DropItem( new BistroFork() );
			bag.DropItem( new GastroFork() );
			bag.DropItem( new SilverFork() );
			pack.DropItem( bag );

			// Spellcasting Stuff
			bag = new Bag();
			bag.Name = "Spell Casting Stuff";
			TomeOfLostKnowledge tome = new TomeOfLostKnowledge();
			tome.Name = "Tome Of Lost Knowledge [Replica]";
			tome.Content = 18446744073709551615;
			bag.DropItem( tome );
			bag.DropItem( new CompleteNecromancerSpellbook() );
			bag.DropItem( new BagOfAllReagents() );
			CrystallineRing ring = new CrystallineRing();
			ring.Name = "Crystalline Ring [Replica]";
			bag.DropItem( ring );
			OrnamentOfTheMagician brace = new OrnamentOfTheMagician();
			brace.Name = "Ornament Of The Magician [Replica]";
			bag.DropItem( brace );
			pack.DropItem( bag );

			// Blue Clothing
			MetalBox box = new MetalBox();
			box.Name = "Blue Clothing";
			box.DropItem( new BlueHat() );
			box.DropItem( new BlueArms() );
			box.DropItem( new BlueShirt() );
			box.DropItem( new BluePants() );
			box.DropItem( new BlueBoots() );
			box.DropItem( new BlueCloak() );
			box.DropItem( new BlueSash() );
			box.DropItem( new BlueBelt() );

			WoodenBox wood = new WoodenBox();
			wood.Name = "Tier One Deeds";
			for ( int i = 0; i < 4; i++ )
			{
				for ( int j = 0; j < 9; j++ )
					wood.DropItem( new BlueEnhanceDeed( (BlueEnhance)( i + 1 ), 1 ) );
			}
			box.DropItem( wood );

			wood = new WoodenBox();
			wood.Name = "Tier Two Deeds";
			for ( int i = 0; i < 4; i++ )
			{
				for ( int j = 0; j < 9; j++ )
					wood.DropItem( new BlueEnhanceDeed( (BlueEnhance)( j + 1 ), 2 ) );
			}
			box.DropItem( wood );
			pack.DropItem( box );
		}

		private class SpellKnownTarget : Target
		{
			public SpellKnownTarget() : base( 30, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is PlayerMobile )
				{
					PlayerMobile pm = (PlayerMobile)o;

					if ( BlueMageControl.IsBlueMage( pm ) )
					{
						if ( from.HasGump( typeof( BlueSpellsKnownGump ) ) )
							from.CloseGump( typeof( BlueSpellsKnownGump ) );

						from.SendGump( new BlueSpellsKnownGump( pm ) );
					}
					else
					{
						from.SendMessage( 1365, "They are not a blue mage." );
					}
				}
				else
					from.SendMessage( 1365, "You can only get a Player's list of spells known." );
			}
		}

		private class StudyTarget : Target
		{
			public StudyTarget() : base( 12, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object o )
			{
				Corpse c = o as Corpse;

				if ( c == null )
				{
					from.SendMessage( 1365, "You cannot study that." );
					return;
				}
				else if ( c.Channeled )
					from.SendMessage( 1365, "The creature's body no longer has anything left in it." );
				else
				{
					c.Channeled = true;
					c.Hue = 0x835;
					BlueMonster b = c.Owner as BlueMonster;

					if ( b == null )
						from.SendMessage( 1365, "Upon further inspection, it would seem this monster knew little of use to you." );
					else if ( (from.Skills[SkillName.Forensics].Base * 0.01) > Utility.RandomDouble() )
						BlueMageControl.CheckKnown( from, b.SpellToCast, true );
					else
						from.SendMessage( 1365, "You failed to learn anything about this creature's abilities." );
				}
			}
		}

	}
}
