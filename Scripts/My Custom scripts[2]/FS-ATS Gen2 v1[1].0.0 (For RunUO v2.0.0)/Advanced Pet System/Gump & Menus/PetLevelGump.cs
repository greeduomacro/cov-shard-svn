using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System.Collections;
using Server.Targeting;

namespace Server.Gumps
{
	public class PetLevelGump : Gump
	{
		public enum Buttons
		{
			Close, PageOne, PageTwo,

			// Lv0
			Hits, Stam, Mana,

			// Lv10
			Physical, Fire, Cold, Energy, Poison,

			// Lv20
			DamageMin, DamageMax,

			// Lv30
			PreAOSArmor, // AOS+ doesn't use this value at all.

			// Lv40
			Str, Dex, Int,

			// Page 2, level 25+
			RoarAttack, FireBreathAttack, IcyWindAttack, ShockAttack, PoisonAttack,

			// Page 2, ISpecialPet Reserves
			AbilityOne, AbilityTwo, AbilityThree
		}

		private Mobile m_Pet;

		public PetLevelGump( Mobile pet ) : this( pet, 1 )
		{
		}

		public PetLevelGump( Mobile pet, int page ) : base( 0, 0 )
		{
			m_Pet = pet;

			BaseCreature bc = (BaseCreature)m_Pet;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 12, 9, 394, 526, 2620 );
			AddImageTiled( 17, 15, 384, 113, 9274 );
			AddImageTiled( 17, 136, 302, 27, 9274 );
			AddImageTiled( 17, 171, 302, 356, 9274 );
			AddImageTiled( 326, 136, 76, 27, 9274 );
			AddImageTiled( 326, 171, 76, 354, 9274 );
			AddAlphaRegion( 16, 15, 384, 511 );
			AddLabel(22, 20, 1149, @"Ability Points:");
			AddLabel(22, 40, 1149, @"Pets Current Level:");
			AddLabel(22, 60, 1149, @"Pets Maxium Level:");
			AddLabel(22, 80, 1149, @"Pets Gender:");
			AddLabel(22, 100, 1149, @"Pets Name:");

			AddLabel(116, 20, 64, bc.AbilityPoints.ToString() );
			AddLabel(149, 40, 64, bc.Level.ToString() );
			AddLabel(144, 60, 64, bc.MaxLevel.ToString() );

			AddImage( 336, 20, 5549 );

			AddButton(300, 100, 2117, 2118, (int)Buttons.PageOne, GumpButtonType.Reply, 0 );
			AddButton(320, 100, 2117, 2118, (int)Buttons.PageTwo, GumpButtonType.Reply, 0 );
			
			if ( bc.Female == true )
				AddLabel(107, 80, 64, @"Female");
			else
				AddLabel(107, 80, 64, @"Male");
			AddLabel(96, 100, 64, bc.Name.ToString() );

			AddLabel(22, 140, 1149, @"Property Name");
			AddLabel(330, 140, 1149, @"Amount");

			if ( page == 1 )
			{
				if ( bc.Level != 0 )
				{
					AddLabel(60, 175, 1149, @"Hit Points");
					AddLabel(60, 200, 1149, @"Stamina");
					AddLabel(60, 225, 1149, @"Mana");

					AddLabel(330, 175, 1149, bc.HitsMax.ToString() + "/" + FSATS.NormalHITS.ToString() );
					AddLabel(330, 200, 1149, bc.StamMax.ToString() + "/" + FSATS.NormalSTAM.ToString() );
					AddLabel(330, 225, 1149, bc.ManaMax.ToString() + "/" + FSATS.NormalMANA.ToString() );

					AddButton(24, 175, 4005, 4006, (int)Buttons.Hits, GumpButtonType.Reply, 0);
					AddButton(24, 200, 4005, 4006, (int)Buttons.Stam, GumpButtonType.Reply, 0);
					AddButton(24, 225, 4005, 4006, (int)Buttons.Mana, GumpButtonType.Reply, 0);
				}
				else
				{
					AddLabel(60, 175, 38, @"-Locked-");
					AddLabel(60, 200, 38, @"-Locked-");
					AddLabel(60, 225, 38, @"-Locked-");

					AddLabel(330, 175, 38, @"???");
					AddLabel(330, 200, 38, @"???");
					AddLabel(330, 225, 38, @"???");
				}

				if ( bc.Level >= 10 )
				{
					AddLabel(60, 250, 1149, @"Physical Resistance");
					AddLabel(60, 275, 1149, @"Fire Resistance");
					AddLabel(60, 300, 1149, @"Cold Resistance");
					AddLabel(60, 325, 1149, @"Energy Resistance");
					AddLabel(60, 350, 1149, @"Poison Resistance");

					AddLabel(330, 250, 1149, bc.PhysicalResistance.ToString() + "/" + FSATS.NormalPhys.ToString() );
					AddLabel(330, 275, 1149, bc.FireResistance.ToString() + "/" + FSATS.NormalFire.ToString() );
					AddLabel(330, 300, 1149, bc.ColdResistance.ToString() + "/" + FSATS.NormalCold.ToString() );
					AddLabel(330, 325, 1149, bc.EnergyResistance.ToString() + "/" + FSATS.NormalEnergy.ToString() );
					AddLabel(330, 350, 1149, bc.PoisonResistance.ToString() + "/" + FSATS.NormalPoison.ToString() );

					AddButton(24, 250, 4005, 4006, (int)Buttons.Physical, GumpButtonType.Reply, 0);
					AddButton(24, 275, 4005, 4006, (int)Buttons.Fire, GumpButtonType.Reply, 0);
					AddButton(24, 300, 4005, 4006, (int)Buttons.Cold, GumpButtonType.Reply, 0);
					AddButton(24, 325, 4005, 4006, (int)Buttons.Energy, GumpButtonType.Reply, 0);
					AddButton(24, 350, 4005, 4006, (int)Buttons.Poison, GumpButtonType.Reply, 0);
				}
				else
				{
					AddLabel(60, 250, 38, @"-Locked-");
					AddLabel(60, 275, 38, @"-Locked-");
					AddLabel(60, 300, 38, @"-Locked-");
					AddLabel(60, 325, 38, @"-Locked-");
					AddLabel(60, 350, 38, @"-Locked-");

					AddLabel(330, 250, 38, @"???");
					AddLabel(330, 275, 38, @"???");
					AddLabel(330, 300, 38, @"???");
					AddLabel(330, 325, 38, @"???");
					AddLabel(330, 350, 38, @"???");
				}

				if ( bc.Level >= 20 )
				{
					AddLabel(60, 375, 1149, @"Min Damage");
					AddLabel(60, 400, 1149, @"Max Damage");

					AddLabel(330, 375, 1149, bc.DamageMin.ToString() + "/"  + FSATS.NormalMinDam.ToString() );
					AddLabel(330, 400, 1149, bc.DamageMax.ToString() + "/"  + FSATS.NormalMaxDam.ToString() );

					AddButton(24, 375, 4005, 4006, (int)Buttons.DamageMin, GumpButtonType.Reply, 0);
					AddButton(24, 400, 4005, 4006, (int)Buttons.DamageMax, GumpButtonType.Reply, 0);
				}
				else
				{
					AddLabel(60, 375, 38, @"-Locked-");
					AddLabel(60, 400, 38, @"-Locked-");

					AddLabel(330, 375, 38, @"???");
					AddLabel(330, 400, 38, @"???");
				}
			
				if ( bc.Level >= 30 )
				{
					AddLabel( 60, 425, 1149, @"Deprecated" );
					AddLabel(330, 425, 38, @"---");
					//AddLabel(60, 425, 1149, @"Armor Rating");
					//AddLabel(330, 425, 1149, bc.VirtualArmor.ToString() + "/" + FSATS.NormalVArmor.ToString() );
					//AddButton(24, 425, 4005, 4006, (int)Buttons.PreAOSArmor, GumpButtonType.Reply, 0);
				}
				else
				{
					AddLabel(60, 425, 38, @"-Locked-");
					AddLabel(330, 425, 38, @"???");
				}

				if ( bc.Level >= 40 )
				{
					AddLabel(60, 450, 1149, @"Strength");
					AddLabel(60, 475, 1149, @"Dexterity");
					AddLabel(60, 500, 1149, @"Intelligence");

					AddLabel(330, 450, 1149, bc.RawStr.ToString() + "/" + FSATS.NormalSTR.ToString() );
					AddLabel(330, 475, 1149, bc.RawDex.ToString() + "/" + FSATS.NormalDEX.ToString() );
					AddLabel(330, 500, 1149, bc.RawInt.ToString() + "/" + FSATS.NormalINT.ToString() );

					AddButton(24, 450, 4005, 4006, (int)Buttons.Str, GumpButtonType.Reply, 0);
					AddButton(24, 475, 4005, 4006, (int)Buttons.Dex, GumpButtonType.Reply, 0);
					AddButton(24, 500, 4005, 4006, (int)Buttons.Int, GumpButtonType.Reply, 0);
				}
				else
				{
					AddLabel(60, 450, 38, @"-Locked-");
					AddLabel(60, 475, 38, @"-Locked-");
					AddLabel(60, 500, 38, @"-Locked-");

					AddLabel(330, 450, 38, @"???");
					AddLabel(330, 475, 38, @"???");
					AddLabel(330, 500, 38, @"???");
				}
			}
			else if ( page == 2 )
			{
				if ( bc.Level >= 25 )
				{
					AddLabel( 60, 175, 1149, @"Roar Attack" );
					AddLabel( 60, 200, 1149, @"Fire Breath Attack" );
					AddLabel( 60, 225, 1149, @"Icy Wind Attack" );
					AddLabel( 60, 250, 1149, @"Shock Attack" );
					AddLabel( 60, 275, 1149, @"Poison Attack" );

					AddLabel( 330, 175, 1149, bc.RoarAttack.ToString() + "/" + "100" );
					AddLabel( 330, 200, 1149, bc.FireBreathAttack.ToString() + "/" + "100" );
					AddLabel( 330, 225, 1149, bc.IcyWindAttack.ToString() + "/" + "100" );
					AddLabel( 330, 250, 1149, bc.ShockAttack.ToString() + "/" + "100" );
					AddLabel( 330, 275, 1149, bc.PetPoisonAttack.ToString() + "/" + "100" );

					AddButton( 24, 175, 4005, 4006, (int)Buttons.RoarAttack, GumpButtonType.Reply, 0 );
					AddButton( 24, 200, 4005, 4006, (int)Buttons.FireBreathAttack, GumpButtonType.Reply, 0 );
					AddButton( 24, 225, 4005, 4006, (int)Buttons.IcyWindAttack, GumpButtonType.Reply, 0 );
					AddButton( 24, 250, 4005, 4006, (int)Buttons.ShockAttack, GumpButtonType.Reply, 0 );
					AddButton( 24, 275, 4005, 4006, (int)Buttons.PoisonAttack, GumpButtonType.Reply, 0 );
				}
				else
				{
					AddLabel( 60, 175, 38, @"-Locked-" );
					AddLabel( 60, 200, 38, @"-Locked-" );
					AddLabel( 60, 225, 38, @"-Locked-" );
					AddLabel( 60, 250, 38, @"-Locked-" );
					AddLabel( 60, 275, 38, @"-Locked-" );

					AddLabel( 330, 175, 38, @"???" );
					AddLabel( 330, 200, 38, @"???" );
					AddLabel( 330, 225, 38, @"???" );
					AddLabel( 330, 250, 38, @"???" );
					AddLabel( 330, 275, 38, @"???" );
				}

				if ( bc is ISpecialPet )
				{
					ISpecialPet special = (ISpecialPet)bc;

					if ( special.AbilityOneName != "" )
					{
						AddLabel( 60, 300, 1149, special.AbilityOneName );
						AddLabel( 330, 300, 1149, special.AbilityOneValue.ToString() + "/" + special.AbilityOneLimit.ToString() );
						AddButton( 24, 300, 4005, 4006, (int)Buttons.AbilityOne, GumpButtonType.Reply, 0 );
					}
					else
					{
						AddLabel( 60, 300, 38, @"-Locked-" );
						AddLabel( 330, 300, 38, @"???" );
					}

					if ( special.AbilityTwoName != "" )
					{
						AddLabel( 60, 325, 1149, special.AbilityTwoName );
						AddLabel( 330, 325, 1149, special.AbilityTwoValue.ToString() + "/" + special.AbilityTwoLimit.ToString() );
						AddButton( 24, 325, 4005, 4006, (int)Buttons.AbilityTwo, GumpButtonType.Reply, 0 );
					}
					else
					{
						AddLabel( 60, 325, 38, @"-Locked-" );
						AddLabel( 330, 325, 38, @"???" );
					}

					if ( special.AbilityThreeName != "" )
					{
						AddLabel( 60, 350, 1149, special.AbilityThreeName );
						AddLabel( 330, 350, 1149, special.AbilityThreeValue.ToString() + "/" + special.AbilityThreeLimit.ToString() );
						AddButton( 24, 350, 4005, 4006, (int)Buttons.AbilityThree, GumpButtonType.Reply, 0 );
					}
					else
					{
						AddLabel( 60, 350, 38, @"-Locked-" );
						AddLabel( 330, 350, 38, @"???" );
					}
				}
				else
				{
					AddLabel( 60, 300, 38, @"-No Unique Traits-" );
					AddLabel( 330, 300, 38, @"???" );
					AddLabel( 60, 325, 38, @"-No Unique Traits-" );
					AddLabel( 330, 325, 38, @"???" );
					AddLabel( 60, 350, 38, @"-No Unique Traits-" );
					AddLabel( 330, 350, 38, @"???" );
				}
			}

		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile; 

			BaseCreature bc = (BaseCreature)m_Pet;

			if ( from == null || bc == null || info.ButtonID == 0 )
				return;
			else if ( bc.AbilityPoints < 1 )
			{
				from.SendMessage( "Your pet lacks the ability points to do that." );
				return;
			}

			switch( (Buttons)info.ButtonID )
			{
				case Buttons.Hits:
				{
					if ( bc.HitsMax >= FSATS.NormalHITS )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;

						if ( bc.HitsMaxSeed != -1 )
							++bc.HitsMaxSeed;
						else
							bc.HitsMaxSeed = bc.HitsMax + 1;
					}
					break;
				}
				case Buttons.Stam:
				{
					if ( bc.StamMax >= FSATS.NormalSTAM )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;

						if ( bc.StamMaxSeed != -1 )
							++bc.StamMaxSeed;
						else
							bc.StamMaxSeed = bc.StamMax + 1;
					}
					break;
				}
				case Buttons.Mana:
				{
					if ( bc.ManaMax >= FSATS.NormalMANA )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
					
						if ( bc.ManaMaxSeed != -1 )
							++bc.ManaMaxSeed;
						else
							bc.ManaMaxSeed = bc.ManaMax + 1;
					}
					break;
				}
				case Buttons.Physical:
				{
					int resist = bc.PhysicalResistance;

                    if (bc.ResistanceMods != null && bc.ResistanceMods.Count > 0)
					{
						for ( int i = 0; i < bc.ResistanceMods.Count; i++ )
						{
							if ( bc.ResistanceMods[i] != null && bc.ResistanceMods[i].Type == ResistanceType.Physical && bc.ResistanceMods[i].Offset < 0 )
								resist += Math.Abs( bc.ResistanceMods[i].Offset );
						}
					}

					if ( resist >= FSATS.NormalPhys )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.PhysicalResistanceSeed;
					}
					break;
				}
				case Buttons.Fire:
				{
					int resist = bc.FireResistance;

                    if (bc.ResistanceMods != null && bc.ResistanceMods.Count > 0)
					{
						for ( int i = 0; i < bc.ResistanceMods.Count; i++ )
						{
							if ( bc.ResistanceMods[i] != null && bc.ResistanceMods[i].Type == ResistanceType.Fire && bc.ResistanceMods[i].Offset < 0 )
								resist += Math.Abs( bc.ResistanceMods[i].Offset );
						}
					}

					if ( resist >= FSATS.NormalFire )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.FireResistSeed;
					}
					break;
				}
				case Buttons.Cold:
				{
					int resist = bc.ColdResistance;

                    if (bc.ResistanceMods != null && bc.ResistanceMods.Count > 0)
					{
						for ( int i = 0; i < bc.ResistanceMods.Count; i++ )
						{
							if ( bc.ResistanceMods[i] != null && bc.ResistanceMods[i].Type == ResistanceType.Cold && bc.ResistanceMods[i].Offset < 0 )
								resist += Math.Abs( bc.ResistanceMods[i].Offset );
						}
					}

					if ( resist >= FSATS.NormalCold )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.ColdResistSeed;
					}
					break;
				}
				case Buttons.Energy:
				{
					int resist = bc.EnergyResistance;

                    if (bc.ResistanceMods != null && bc.ResistanceMods.Count > 0)
					{
						for ( int i = 0; i < bc.ResistanceMods.Count; i++ )
						{
							if ( bc.ResistanceMods[i] != null && bc.ResistanceMods[i].Type == ResistanceType.Energy && bc.ResistanceMods[i].Offset < 0 )
								resist += Math.Abs( bc.ResistanceMods[i].Offset );
						}
					}

					if ( resist >= FSATS.NormalEnergy )
						from.SendMessage( "This cannot gain any farther." );
					else 
					{
						--bc.AbilityPoints;
						++bc.EnergyResistSeed;
					}
					break;
				}
				case Buttons.Poison:
				{
					int resist = bc.PoisonResistance;

                    if (bc.ResistanceMods != null && bc.ResistanceMods.Count > 0)
					{
						if ( bc.ResistanceMods.Count > 0 )
						{
							for ( int i = 0; i < bc.ResistanceMods.Count; i++ )
							{
								if ( bc.ResistanceMods[i] != null && bc.ResistanceMods[i].Type == ResistanceType.Poison && bc.ResistanceMods[i].Offset < 0 )
									resist += Math.Abs( bc.ResistanceMods[i].Offset );
							}
						}
					}

					if ( resist >= FSATS.NormalPoison )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.PoisonResistSeed;
					}
					break;
				}
				case Buttons.DamageMin:
				{
					if ( bc.DamageMin >= FSATS.NormalMinDam )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.DamageMin;
					}
					break;
				}
				case Buttons.DamageMax:
				{
					if ( bc.DamageMax >= FSATS.NormalMaxDam )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.DamageMax;
					}
					break;
				}
				case Buttons.PreAOSArmor:
				{
					if ( bc.VirtualArmor >= FSATS.NormalVArmor )
						from.SendMessage( "This cannot gain any farther." );
					else if ( bc.AbilityPoints != 0 )
					{
						--bc.AbilityPoints;
						++bc.VirtualArmor;
					}
					break;
				}
				case Buttons.Str:
				{
					if ( bc.RawStr >= FSATS.NormalSTR )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.Str;
					}
					break;
				}
				case Buttons.Dex:
				{
					if ( bc.RawDex >= FSATS.NormalDEX )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.Dex;
					}
					break;
				}
				case Buttons.Int:
				{
					if ( bc.RawInt >= FSATS.NormalINT )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.Int;
					}
					break;
				}
				case Buttons.RoarAttack:
				{
					if ( bc.RoarAttack >= 100 )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.RoarAttack;
					}
					break;
				}
				case Buttons.FireBreathAttack:
				{
					if ( bc.FireBreathAttack >= 100 )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.FireBreathAttack;
					}
					break;
				}
				case Buttons.IcyWindAttack:
				{
					if ( bc.IcyWindAttack >= 100 )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.IcyWindAttack;
					}
					break;
				}
				case Buttons.ShockAttack:
				{
					if ( bc.ShockAttack >= 100 )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.ShockAttack;
					}
					break;
				}
				case Buttons.PoisonAttack:
				{
					if ( bc.PetPoisonAttack >= 100 )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						--bc.AbilityPoints;
						++bc.PetPoisonAttack;
					}
					break;
				}
				case Buttons.AbilityOne:
				{
					ISpecialPet specialone = bc as ISpecialPet;

					if ( specialone == null )
						return;

					if ( (bc.AbilityPoints - specialone.AbilityOneCost) < 0 )
						from.SendMessage( "This trait requires " + specialone.AbilityOneCost.ToString() + " ability points to increase." );
					else if ( specialone.AbilityOneValue >= specialone.AbilityOneLimit )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						bc.AbilityPoints -= specialone.AbilityOneCost;
						++specialone.AbilityOneValue;
					}
					break;
				}
				case Buttons.AbilityTwo:
				{
					ISpecialPet specialtwo = bc as ISpecialPet;

					if ( specialtwo == null )
						return;

					if ( (bc.AbilityPoints - specialtwo.AbilityTwoCost) < 0 )
						from.SendMessage( "This trait requires " + specialtwo.AbilityTwoCost.ToString() + " ability points to increase." );
					if ( specialtwo.AbilityTwoValue >= specialtwo.AbilityTwoLimit )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						bc.AbilityPoints -= specialtwo.AbilityTwoCost;
						++specialtwo.AbilityTwoValue;
					}
					break;
				}
				case Buttons.AbilityThree:
				{
					ISpecialPet specialthree = bc as ISpecialPet;

					if ( specialthree == null )
						return;

					if ( (bc.AbilityPoints - specialthree.AbilityThreeCost) < 0 )
						from.SendMessage( "This trait requires " + specialthree.AbilityThreeCost.ToString() + " ability points to increase." );
					if ( specialthree.AbilityThreeValue >= specialthree.AbilityThreeLimit )
						from.SendMessage( "This cannot gain any farther." );
					else
					{
						bc.AbilityPoints -= specialthree.AbilityThreeCost;
						++specialthree.AbilityThreeValue;
					}
					break;
				}
			}

			if ( info.ButtonID >= ((int)Buttons.RoarAttack) || info.ButtonID == ((int)Buttons.PageTwo) )
				from.SendGump( new PetLevelGump( bc, 2 ) );
			else
				from.SendGump( new PetLevelGump( bc, 1 ) );
		}
	}
}