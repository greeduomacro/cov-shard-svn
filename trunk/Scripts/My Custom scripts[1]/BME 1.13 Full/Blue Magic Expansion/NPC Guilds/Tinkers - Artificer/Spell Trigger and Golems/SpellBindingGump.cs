using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class SpellBindingGump : Gump
	{
		public enum Buttons
		{
			Close,
			MainMenu,
			Magery,
			Necromancy,
			Chivalry,
			Golems,
			// Magery
			Clumsy,
			Feeble,
			Fireball,
			GreaterHeal,
			Harm,
			Identification,
			Lightning,
			MagicArrow,
			ManaDrain,
			Weakness,
			MarkRune,
			ArcaneGem,
			// Necromancy
			PainSpike,
			BloodOath,
			CorpseSkin,
			EvilOmen,
			// Chivarly
			AnimateDead,
			CleanseByFire,
			CloseWounds,
			ConsecrateWeapon,
			RemoveCurse,
			DivineFury,
			// Golems
			BloodGolem,
			ClayGolem,
			IronGolem,
			FireGolem
		}

		public SpellBindingGump() : this( Buttons.MainMenu )
		{
		}

		public SpellBindingGump( Buttons page ) : base( 0, 0 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			// Main Menu
			AddImage( 0, 0, 1250 );
			AddLabel( 115, 40, 1191, "Spell Binding" );
			AddLabel( 60, 70, 1191, "Magery" );
			AddButton( 35, 70, 1896, 1895, (int)Buttons.Magery, GumpButtonType.Reply, 0 );
			AddLabel( 180, 70, 1191, "Necromancy" );
			AddButton( 260, 70, 1896, 1895, (int)Buttons.Necromancy, GumpButtonType.Reply, 0 );
			AddLabel( 60, 100, 1191, "Chivalry" );
			AddButton( 35, 100, 1896, 1895, (int)Buttons.Chivalry, GumpButtonType.Reply, 0 );
			AddLabel( 210, 100, 1191, "Golems" );
			AddButton( 260, 100, 1896, 1895, (int)Buttons.Golems, GumpButtonType.Reply, 0 );
			AddImage( 50, 130, 2091 );

			switch( page )
			{
				case Buttons.MainMenu:
				{
					// Stupid Pentigram
					AddItem( 158, 158, 7419, 1192 );
					AddItem( 136, 158, 7418, 1192 );
					AddItem( 114, 175, 7433, 1192 );
					AddItem( 90, 197, 7432, 1192 );
					AddItem( 70, 226, 7431, 1192 );
					AddItem( 48, 241, 7412, 1192 );
					AddItem( 114, 156, 7417, 1192 );
					AddItem( 92, 163, 7416, 1192 );
					AddItem( 69, 177, 7415, 1192 );
					AddItem( 47, 197, 7414, 1192 );
					AddItem( 25, 232, 7413, 1192 );
					AddItem( 177, 163, 7420, 1192 );
					AddItem( 155, 175, 7434, 1192 );
					AddItem( 133, 199, 7441, 1192 );
					AddItem( 113, 219, 7440, 1192 );
					AddItem( 93, 247, 7430, 1192 );
					AddItem( 70, 263, 7411, 1192 );
					AddItem( 200, 184, 7421, 1192 );
					AddItem( 177, 196, 7435, 1192 );
					AddItem( 155, 222, 7442, 1192 );
					AddItem( 133, 253, 7439, 1192 );
					AddItem( 114, 263, 7429, 1192 );
					AddItem( 92, 293, 7410, 1192 );
					AddItem( 222, 198, 7422, 1192 );
					AddItem( 200, 224, 7436, 1192 );
					AddItem( 178, 241, 7437, 1192 );
					AddItem( 155, 264, 7438, 1192 );
					AddItem( 136, 288, 7428, 1192 );
					AddItem( 113, 307, 7409, 1192 );
					AddItem( 245, 233, 7423, 1192 );
					AddItem( 223, 242, 7424, 1192 );
					AddItem( 200, 267, 7425, 1192 );
					AddItem( 178, 285, 7426, 1192 );
					AddItem( 158, 307, 7427, 1192 );

					AddItem( 132, 186, 3546, 1192 );
					AddItem( 116, 164, 14145, 1192 );
					AddItem( 113, 166, 14193, 1192 );
					break;
				}
				case Buttons.Magery:
				{
					AddLabel( 60, 150, 1191, "Clumsy ");
					AddButton( 35, 150, 1896, 1895, (int)Buttons.Clumsy, GumpButtonType.Reply, 0 );
					AddLabel( 215, 150, 1191, "Feeble ");
					AddButton( 260, 150, 1896, 1895, (int)Buttons.Feeble, GumpButtonType.Reply, 0 );
					AddLabel( 60, 180, 1191, "Fireball ");
					AddButton( 35, 180, 1896, 1895, (int)Buttons.Fireball, GumpButtonType.Reply, 0 );
					AddLabel( 175, 180, 1191, "Greater Heal ");
					AddButton( 260, 180, 1896, 1895, (int)Buttons.GreaterHeal, GumpButtonType.Reply, 0 );
					AddLabel( 60, 210, 1191, "Harm ");
					AddButton( 35, 210, 1896, 1895, (int)Buttons.Harm, GumpButtonType.Reply, 0 );
					AddLabel( 170, 210, 1191, "Identification ");
					AddButton( 260, 210, 1896, 1895, (int)Buttons.Identification, GumpButtonType.Reply, 0 );
					AddLabel( 60, 240, 1191, "Lightning" );
					AddButton( 35, 240, 1896, 1895, (int)Buttons.Lightning, GumpButtonType.Reply, 0 );
					AddLabel( 175, 240, 1191, "Magic Arrow" );
					AddButton( 260, 240, 1896, 1895, (int)Buttons.MagicArrow, GumpButtonType.Reply, 0 );
					AddLabel( 60, 270, 1191, "Mana Drain" );
					AddButton( 35, 270, 1896, 1895, (int)Buttons.ManaDrain, GumpButtonType.Reply, 0 );
					AddLabel( 190, 270, 1191, "Weakness" );
					AddButton( 260, 270, 1896, 1895, (int)Buttons.Weakness, GumpButtonType.Reply, 0 );
					//AddLabel( 60, 300, 1191, "Rune of Mark" );
					//AddButton( 35, 300, 1896, 1895, (int)Buttons.MarkRune, GumpButtonType.Reply, 0 );
					AddLabel( 180, 300, 1191, "Arcane Gem" );
					AddButton( 260, 300, 1896, 1895, (int)Buttons.ArcaneGem, GumpButtonType.Reply, 0 );
					break;
				}
				case Buttons.Necromancy:
				{
					AddImage( 35, 150, 20488 );
					AddButton( 83, 170, 1896, 1895, (int)Buttons.PainSpike, GumpButtonType.Reply, 0 );
					AddLabel( 35, 200, 1191, "Pain Spike" );
					AddImage( 225, 150, 20481 );
					AddButton( 200, 170, 1896, 1895, (int)Buttons.BloodOath, GumpButtonType.Reply, 0 );
					AddLabel( 200, 200, 1191, "Blood Oath" );
					AddImage( 35, 225, 20482 );
					AddButton( 83, 245, 1896, 1895, (int)Buttons.CorpseSkin, GumpButtonType.Reply, 0 );
					AddLabel( 35, 275, 1191, "Corpse Skin" );
					AddImage( 225, 225, 20484 );
					AddButton( 200, 245, 1896, 1895, (int)Buttons.EvilOmen, GumpButtonType.Reply, 0 );
					AddLabel( 200, 275, 1191, "Evil Omen" );
					AddImage( 115, 185, 20480 );
					AddButton( 163, 205, 1896, 1895, (int)Buttons.AnimateDead, GumpButtonType.Reply, 0);
					AddLabel( 110, 235, 1191, "Animate Dead" );
					break;
				}
				case Buttons.Chivalry:
				{
					AddImage( 35, 150, 20736 );
					AddButton( 83, 170, 1896, 1895, (int)Buttons.CleanseByFire, GumpButtonType.Reply, 0 );
					AddLabel( 35, 200, 1191, "Cleanse" );
					AddImage( 225, 150, 20737 );
					AddButton( 200, 170, 1896, 1895, (int)Buttons.CloseWounds, GumpButtonType.Reply, 0 );
					AddLabel( 200, 200, 1191, "Close" );
					AddImage( 35, 225, 20738 );
					AddButton( 83, 245, 1896, 1895, (int)Buttons.ConsecrateWeapon, GumpButtonType.Reply, 0 );
					AddLabel( 35, 275, 1191, "Consecrate" );
					AddImage( 225, 225, 20739 );
					AddButton( 200, 245, 1896, 1895, (int)Buttons.RemoveCurse, GumpButtonType.Reply, 0 );
					AddLabel( 200, 275, 1191, "Remove" );
					AddImage( 115, 185, 20740 );
					AddButton( 163, 205, 1896, 1895, (int)Buttons.DivineFury, GumpButtonType.Reply, 0 );
					AddLabel( 110, 235, 1191, "Fury" );
					break;
				}
				case Buttons.Golems:
				{
					AddImage( 50, 150, 2328 );
					AddItem( 65, 155, 9764, 1157 );
					AddLabel( 52, 210, 1191, "Blood Golem" );
					AddButton( 80, 230, 1896, 1895, (int)Buttons.BloodGolem, GumpButtonType.Reply, 0 );
					AddImage( 184, 150, 2328 );
					AddItem( 200, 155, 9763, 1192 );
					AddLabel( 190, 210, 1191, "Clay Golem" );
					AddButton( 215, 230, 1896, 1895, (int)Buttons.ClayGolem, GumpButtonType.Reply, 0 );
					AddImage( 50, 255, 2328 );
					AddItem( 65, 260, 9724, 1102 );
					AddLabel( 60, 315, 1191, "Iron Golem" );
					AddButton( 80, 335, 1896, 1895, (int)Buttons.IronGolem, GumpButtonType.Reply, 0 );
					AddImage( 184, 255, 2328 );
					AddItem( 200, 257, 10089, 1161 );
					AddLabel( 190, 315, 1191, "Fire Golem" );
					AddButton( 215, 335, 1896, 1895, (int)Buttons.FireGolem, GumpButtonType.Reply, 0 );
					break;
				}
			}
		}
		
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Container pack = sender.Mobile.Backpack;

			if ( pack == null )
			{
				sender.Mobile.SendMessage( 1192, "You need a backpack." );
				return;
			}

			int items = 0;
			BaseCustomWand wand = null;
			BaseWand magewand = null;

			switch( (Buttons)info.ButtonID )
			{
				case Buttons.MainMenu:
				{
					if ( sender.Mobile.HasGump( typeof( SpellBindingGump ) ) )
						sender.Mobile.CloseGump( typeof( SpellBindingGump ) );

					sender.Mobile.SendGump( new SpellBindingGump() );
					break;
				}
				case Buttons.Magery:
				{
					if ( sender.Mobile.HasGump( typeof( SpellBindingGump ) ) )
						sender.Mobile.CloseGump( typeof( SpellBindingGump ) );

					sender.Mobile.SendGump( new SpellBindingGump( Buttons.Magery ) );
					break;
				}
				case Buttons.Necromancy:
				{
					if ( sender.Mobile.HasGump( typeof( SpellBindingGump ) ) )
						sender.Mobile.CloseGump( typeof( SpellBindingGump ) );

					sender.Mobile.SendGump( new SpellBindingGump( Buttons.Necromancy ) );
					break;
				}
				case Buttons.Chivalry:
				{
					if ( sender.Mobile.HasGump( typeof( SpellBindingGump ) ) )
						sender.Mobile.CloseGump( typeof( SpellBindingGump ) );

					sender.Mobile.SendGump( new SpellBindingGump( Buttons.Chivalry ) );
					break;
				}
				case Buttons.Golems:
				{
					if ( sender.Mobile.HasGump( typeof( SpellBindingGump ) ) )
						sender.Mobile.CloseGump( typeof( SpellBindingGump ) );

					sender.Mobile.SendGump( new SpellBindingGump( Buttons.Golems ) );
					break;
				}

				#region Magery
				case Buttons.Clumsy:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( Bloodmoss ),
							typeof( Nightshade ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new ClumsyWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.Feeble:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( Ginseng ),
							typeof( Nightshade ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new FeebleWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.Fireball:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( BlackPearl ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new FireballWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.GreaterHeal:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( Garlic ),
							typeof( Ginseng ),
							typeof( MandrakeRoot ),
							typeof( SpidersSilk ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new GreaterHealWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.Harm:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( Nightshade ),
							typeof( SpidersSilk ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new HarmWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.Identification:
				{
					sender.Mobile.SendMessage( 1192, "The Spell Binders of Tolaria have not concentrated on this area of work yet." );
					goto case Buttons.Magery;
				}
				case Buttons.Lightning:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( MandrakeRoot ),
							typeof( SulfurousAsh ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new LightningWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.MagicArrow:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( SulfurousAsh ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand= new MagicArrowWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.ManaDrain:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( BlackPearl ),
							typeof( MandrakeRoot ),
							typeof( SpidersSilk ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new ManaDrainWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.Weakness:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( Garlic ),
							typeof( Nightshade ),
							typeof( ArcaneGem )
						},
						new int[]{ 50, 50, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || items != -1 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & 100 mana.<br>" + 
							"Items: An Arcane Gem." + 
							"Regents: 50 of the regents the spell requires." );
						goto case Buttons.Magery;
					}

					magewand = new WeaknessWand();
					magewand.Crafter = sender.Mobile;
					pack.DropItem( magewand );
					goto case Buttons.Magery;
				}
				case Buttons.MarkRune:
				{
					sender.Mobile.SendMessage( 1192, "The Spell Binders of Tolaria have not concentrated on this area of work yet." );
					goto case Buttons.Magery;
				}
				case Buttons.ArcaneGem: 
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( BlackPearl ),
							typeof( Bloodmoss ),
							typeof( Garlic ),
							typeof( Ginseng ),
							typeof( MandrakeRoot ),
							typeof( Nightshade ),
							typeof( SpidersSilk ),
							typeof( SulfurousAsh )
						},
						new int[]{ 10, 10, 10, 10, 10, 10, 10, 10 } );

					if ( sender.Mobile.Skills[SkillName.ItemID].Base < 100.0 || items != -1 || sender.Mobile.Mana < 25 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: ItemID 100.0+ & 25 mana.<br>" + 
							"Regents: 10 of all magery regents." );
						goto case Buttons.Magery;
					}
					sender.Mobile.SendMessage( 1192, "The Spell Binders of Tolaria have not concentrated on this area of work yet." );
					goto case Buttons.Magery;
				}
				#endregion

				#region Necromancy
				case Buttons.PainSpike:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( GnarledStaff ),
							typeof( ArcaneGem ),
							typeof( GraveDust ),
							typeof( PigIron )
						},
						new int[]{ 1, 1, 20, 20 } );

					if ( sender.Mobile.Skills[SkillName.Necromancy].Base < 40.0 || items != -1 || sender.Mobile.Mana < 24 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Necromancy 40.0+ & 25 mana.<br>" + 
							"Items: An Arcane Gem, a Gnarled Staff (enchantments will be removed).<br>" + 
							"Regents: 20 each of Grave Dust, Pig Iron." );
						goto case Buttons.Necromancy;
					}

					sender.Mobile.Mana -= 25;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new PainSpikeStaff();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Necromancy;
				}
				case Buttons.BloodOath:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( GnarledStaff ),
							typeof( ArcaneGem ),
							typeof( DaemonBlood )
						},
						new int[]{ 1, 1, 20 } );

					if ( sender.Mobile.Skills[SkillName.Necromancy].Base < 40.0 || items != -1 || sender.Mobile.Mana < 64 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Necromancy 40.0+ & 25 mana.<br>" + 
							"Items: An Arcane Gem, a Gnarled Staff (enchantments will be removed).<br>" + 
							"Regents: 20 Daemon Blood." );
						goto case Buttons.Necromancy;
					}

					sender.Mobile.Mana -= 65;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new BloodOathStaff();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Necromancy;
				}
				case Buttons.CorpseSkin:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( GnarledStaff ),
							typeof( ArcaneGem ),
							typeof( BatWing ),
							typeof( GraveDust )
						},
						new int[]{ 1, 1, 20, 20 } );

					if ( sender.Mobile.Skills[SkillName.Necromancy].Base < 40.0 || items != -1 || sender.Mobile.Mana < 54 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Necromancy 40.0+ & 25 mana.<br>" + 
							"Items: An Arcane Gem, a Gnarled Staff (enchantments will be removed).<br>" + 
							"Regents: 20 each of Bat Wing, Grave Dust." );
						goto case Buttons.Necromancy;
					}

					sender.Mobile.Mana -= 55;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new CorpseSkinStaff();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Necromancy;
				}
				case Buttons.EvilOmen:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( GnarledStaff ),
							typeof( ArcaneGem ),
							typeof( BatWing ),
							typeof( NoxCrystal )
						},
						new int[]{ 1, 1, 20, 20 } );

					if ( sender.Mobile.Skills[SkillName.Necromancy].Base < 40.0 || items != -1 || sender.Mobile.Mana < 54 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Necromancy 40.0+ & 25 mana.<br>" + 
							"Items: An Arcane Gem, a Gnarled Staff (enchantments will be removed).<br>" + 
							"Regents: 20 of each Bat Wing, Nox Crystal." );
						goto case Buttons.Necromancy;
					}

					sender.Mobile.Mana -= 55;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new EvilOmenStaff();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Necromancy;
				}
				case Buttons.AnimateDead:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( GnarledStaff ),
							typeof( ArcaneGem ),
							typeof( GraveDust ),
							typeof( DaemonBlood )
						},
						new int[]{ 1, 2, 20, 20 } );

					if ( sender.Mobile.Skills[SkillName.Necromancy].Base < 60.0 || items != -1 || sender.Mobile.Mana < 114 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Necromancy 40.0+ & 25 mana.<br>" + 
							"Items: 2 Arcane Gems, a Gnarled Staff (enchantments will be removed).<br>" + 
							"Regents: 20 of each Grave Dust, Daemon Blood." );
						goto case Buttons.Necromancy;
					}

					sender.Mobile.Mana -= 115;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new AnimateDeadStaff();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Necromancy;
				}
				#endregion

				#region Chivalry
				case Buttons.CleanseByFire:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( Mace ),
						},
						new int[]{ 1, 1 } );

					if ( sender.Mobile.Skills[SkillName.Chivalry].Base < 25.0 || items != -1 || sender.Mobile.TithingPoints < 50 || sender.Mobile.Mana < 50 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Chivalry 25.0+ & 50 mana.<br>" + 
							"Items: Arcane Gem, a Mace (enchantments will be removed).<br>" + 
							"Tithing: 50." );
						goto case Buttons.Chivalry;
					}

					sender.Mobile.Mana -= 50;
					sender.Mobile.TithingPoints -= 50;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new CleanseByFireMace();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Chivalry;
				}
				case Buttons.CloseWounds:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( WarMace ),
						},
						new int[]{ 1, 1 } );

					if ( sender.Mobile.Skills[SkillName.Chivalry].Base < 20.0 || items != -1 || sender.Mobile.TithingPoints < 50 || sender.Mobile.Mana < 50 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Chivalry 20.0+ & 50 mana.<br>" + 
							"Items: Arcane Gem, a War Mace (enchantments will be removed).<br>" + 
							"Tithing: 50." );
						goto case Buttons.Chivalry;
					}

					sender.Mobile.Mana -= 50;
					sender.Mobile.TithingPoints -= 50;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new CloseWoundsWarMace();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Chivalry;
				}
				case Buttons.ConsecrateWeapon:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( HammerPick ),
						},
						new int[]{ 1, 1 } );

					if ( sender.Mobile.Skills[SkillName.Chivalry].Base < 35.0 || items != -1 || sender.Mobile.TithingPoints < 50 || sender.Mobile.Mana < 50 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Chivalry 35.0+ & 50 mana.<br>" + 
							"Items: Arcane Gem, a Hammer Pick (enchantments will be removed).<br>" + 
							"Tithing: 50." );
						goto case Buttons.Chivalry;
					}

					sender.Mobile.Mana -= 50;
					sender.Mobile.TithingPoints -= 50;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new ConsecrateWeaponHammerPick();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Chivalry;
				}
				case Buttons.RemoveCurse:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( Scepter ),
						},
						new int[]{ 1, 1 } );

					if ( sender.Mobile.Skills[SkillName.Chivalry].Base < 25.0 || items != -1 || sender.Mobile.TithingPoints < 50 || sender.Mobile.Mana < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Chivalry 25.0+ & 100 mana.<br>" + 
							"Items: Arcane Gem, a Sceptor (enchantments will be removed).<br>" + 
							"Tithing: 50." );
						goto case Buttons.Chivalry;
					}

					sender.Mobile.Mana -= 100;
					sender.Mobile.TithingPoints -= 50;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new RemoveCurseScepter();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Chivalry;
				}
				case Buttons.DivineFury:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( WarHammer ),
						},
						new int[]{ 1, 1 } );

					if ( sender.Mobile.Skills[SkillName.Chivalry].Base < 45.0 || 
						items != -1 || 
						sender.Mobile.TithingPoints < 50 || 
						sender.Mobile.Mana < 75 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Chivalry 45.0+ & 75 mana.<br>" +
							"Items: Arcane Gem, a War Hammer (enchantments will be removed).<br>" + 
							"Tithing: 50." );
						goto case Buttons.Chivalry;
					}

					sender.Mobile.Mana -= 75;
					sender.Mobile.TithingPoints -= 50;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					wand = new DivineFuryWarHammer();
					wand.Crafter = sender.Mobile;
					pack.DropItem( wand );
					goto case Buttons.Chivalry;
				}
				#endregion

				#region Golems
				case Buttons.BloodGolem:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( PowerCrystal ),
							typeof( Garlic ),
							typeof( Ginseng ),
							typeof( MandrakeRoot ),
							typeof( SpidersSilk ),
							typeof( Head ),
							typeof( LeftArm ),
							typeof( RightArm ),
							typeof( LeftLeg ),
							typeof( RightLeg )
						},
						new int[]{ 3, 1, 50, 50, 50, 50, 1, 1, 1, 1, 1 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 50.0 || sender.Mobile.Skills[SkillName.Necromancy].Base < 50.0 || items != -1 || sender.Mobile.Mana < 74 || sender.Mobile.Hits < 100 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 50.0+ & Necromancy 50.0+ & 75 mana.<br>" + 
							"Items: 3 Arcane Gems, Power Crystal, All the flesh parts from a humanoid corpse.<br>" + 
							"Regents: 50 each of Garlic, Ginsing, Mandrake Root, Spider's Silk." + 
							"Special: 100 Hit Points." );
						goto case Buttons.Golems;
					}

					sender.Mobile.Hits -= 100;
					sender.Mobile.Mana -= 75;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					pack.DropItem( new GolemItem( GolemType.Blood ) );
					goto case Buttons.Golems;
				}
				case Buttons.ClayGolem:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( PowerCrystal ),
							typeof( FertileDirt ),
							typeof( Bloodmoss ),
							typeof( GraveDust ),
							typeof( NoxCrystal ),
							typeof( SpidersSilk ),
						},
						new int[]{ 2, 1, 4, 50, 50, 50, 50 } );

					if ( items == -1 )
					{
						Item[] itemlist = pack.FindItemsByType( typeof( Pitcher ) );

						if ( itemlist.Length == 0 )
							items = 0;

						Pitcher p = null;
						int found = 0;

						for ( int i = 0; i < itemlist.Length; i++ )
						{
							p = (Pitcher)itemlist[i];

							if ( p.IsFull && p.Content == BeverageType.Water )
								found++;
						}

						if ( found < 4 )
							items = 0;
					}

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 75.0 || sender.Mobile.Skills[SkillName.Necromancy].Base < 75.0 || items != -1 || sender.Mobile.Mana < 99 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 75.0+ & Necromancy 75.0+ & 100 mana<br>" + 
							"Items: 2 Arcane Gems, Power Crystal, 4 Fertile Dirt, 4 Pitchers full of water.<br>" + 
							"Regents: 50 each of Bloodmoss, Grave Dust, Nox Crystal, Spider's Silk." );
						goto case Buttons.Golems;
					}

					sender.Mobile.Mana -= 100;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					pack.DropItem( new GolemItem( GolemType.Clay ) );
					goto case Buttons.Golems;
				}
				case Buttons.IronGolem:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( PowerCrystal ),
							typeof( BatWing ),
							typeof( Nightshade ),
							typeof( PigIron )
						},
						new int[]{ 4, 2, 50, 50, 100 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 100.0 || sender.Mobile.Skills[SkillName.Necromancy].Base < 100.0 || items != -1 || sender.Mobile.Mana < 124 )
					{
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 100.0+ & Necromancy 100.0+ & 125 mana.<br>" + 
							"Items: 4 Arcane Gems, 2 Power Crystals.<br>" + 
							"Regents: 50 each of Bat Wing, Nightshade & 100 Pig Iron.<br>" + 
							"Special: Armor or Weapon (consumed on use)" );
						goto case Buttons.Golems;
					}

					sender.Mobile.Mana -= 125;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					pack.DropItem( new GolemItem( GolemType.Iron ) );
					goto case Buttons.Golems;
				}
				case Buttons.FireGolem:
				{
					items = pack.ConsumeTotal(
						new Type[]
						{
							typeof( ArcaneGem ),
							typeof( PowerCrystal ),
							typeof( BlackPearl ),
							typeof( DaemonBlood ),
							typeof( MandrakeRoot ),
							typeof( SulfurousAsh ),
						},
						new int[]{ 5, 2, 50, 50, 50, 200 } );

					if ( sender.Mobile.Skills[SkillName.Magery].Base < 115.0 || sender.Mobile.Skills[SkillName.Necromancy].Base < 115.0 || items != -1 || sender.Mobile.Mana < 149 )
					{
						
						SendFailedGump( sender.Mobile, 
							"Skill Required: Magery 115.0+ & Necromancy 115.0+ & 150 mana." + 
							"Items: 5 Arcane Gems, 2 Power Crystals, 200 Sulfurous Ash" + 
							"Regents: 50 each of Black Peral, Daemon Blood, Mandrake Root & 200 Sulfurous Ash" + 
							"Special: Armor or Weapon" );
						goto case Buttons.Golems;
					}

					sender.Mobile.Mana -= 150;
					sender.Mobile.SendMessage( 1192, "You bound the spell to the item." );
					pack.DropItem( new GolemItem( GolemType.Fire ) );
					goto case Buttons.Golems;
				}
				#endregion
			}
		}

		public void SendFailedGump( Mobile m, string message )
		{
			m.CloseGump( typeof( FailedCraftGump ) );
			m.SendGump( new FailedCraftGump( message ) );
		}
	}
}

namespace Server.Commands
{
	public class SpellBindingCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "SpellBinding", AccessLevel.GameMaster, new CommandEventHandler( SpellBinding_OnCommand ) );
		}

		[Description( "Opens the SpellBinding gump" )]
		public static void SpellBinding_OnCommand( CommandEventArgs e )
		{
			if ( e.Mobile.HasGump( typeof( SpellBindingGump ) ) )
				e.Mobile.CloseGump( typeof( SpellBindingGump ) );

			e.Mobile.SendGump( new SpellBindingGump() );
		}
	}
}