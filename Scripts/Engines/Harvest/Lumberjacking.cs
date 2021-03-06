using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
	public class Lumberjacking : HarvestSystem
	{
		private static Lumberjacking m_System;

		public static Lumberjacking System
		{
			get
			{
				if ( m_System == null )
					m_System = new Lumberjacking();

				return m_System;
			}
		}

		private HarvestDefinition m_Definition;

		public HarvestDefinition Definition
		{
			get{ return m_Definition; }
		}

		private Lumberjacking()
		{
			HarvestResource[] res;
			HarvestVein[] veins;

			#region Lumberjacking
			HarvestDefinition lumber = new HarvestDefinition();

			// Resource banks are every 4x3 tiles
			lumber.BankWidth = 4;
			lumber.BankHeight = 3;

			// Every bank holds from 20 to 176 logs
			lumber.MinTotal = 20;
			lumber.MaxTotal = 176;

			// A resource bank will respawn its content every 20 to 30 minutes
			lumber.MinRespawn = TimeSpan.FromMinutes( 20.0 );
			lumber.MaxRespawn = TimeSpan.FromMinutes( 30.0 );

			// Skill checking is done on the Lumberjacking skill
			lumber.Skill = SkillName.Lumberjacking;

			// Set the list of harvestable tiles
			lumber.Tiles = m_TreeTiles;

			// Players must be within 2 tiles to harvest
			lumber.MaxRange = 2;

			// Ten logs per harvest action
			lumber.ConsumedPerHarvest = 10;
			lumber.ConsumedPerFeluccaHarvest = 20;

			// The chopping effect
			lumber.EffectActions = new int[]{ 13 };
			lumber.EffectSounds = new int[]{ 0x13E };
			lumber.EffectCounts = (Core.AOS ? new int[]{ 1 } : new int[]{ 1, 2, 2, 2, 3 });
			lumber.EffectDelay = TimeSpan.FromSeconds( 1.6 );
			lumber.EffectSoundDelay = TimeSpan.FromSeconds( 0.9 );

			lumber.NoResourcesMessage = 500493; // There's not enough wood here to harvest.
			lumber.FailMessage = 500495; // You hack at the tree for a while, but fail to produce any useable wood.
			lumber.OutOfRangeMessage = 500446; // That is too far away.
			lumber.PackFullMessage = 500497; // You can't place any wood into your backpack!
			lumber.ToolBrokeMessage = 500499; // You broke your axe.

			if ( Core.ML )
			{
				res = new HarvestResource[]
				{
					new HarvestResource( 00.0, 00.0, 25.0, 500498, typeof( Log ) ),
					new HarvestResource( 20.0, 15.0, 60.0, "You put some Pine logs in your backpack", typeof( PineLog ) ),
					new HarvestResource( 30.0, 25.0, 70.0, "You put some Cedar logs in your backpack", typeof( CedarLog ) ),
					new HarvestResource( 40.0, 35.0, 80.0, "You put some Cherry logs in your backpack", typeof( CherryLog ) ),
					new HarvestResource( 50.0, 45.0, 90.0, "You put some Mahogony logs in your backpack", typeof( MahoganyLog ) ),
					new HarvestResource( 60.0, 55.0, 100.0, "You put some Oak logs in your backpack", typeof( OakLog ) ),
					new HarvestResource( 70.0, 65.0, 110.0, "You put some Ash logs in your backpack", typeof( AshLog ) ),
					new HarvestResource( 80.0, 75.0, 120.0, "You put some Yew logs in your backpack", typeof( YewLog ) ),
					new HarvestResource( 90.0, 85.0, 130.0, "You put some Heartwood logs in your backpack", typeof( HeartwoodLog ) ),
					new HarvestResource( 100.0, 95.0, 140.0, "You put some Bloodwood logs in your backpack", typeof( BloodwoodLog ) ),
					new HarvestResource( 100.0, 95.0, 140.0, "You put some Frostwood logs in your backpack", typeof( FrostwoodLog ) )
				};

			veins = new HarvestVein[]
				{
					new HarvestVein( 20.0, 0.0, res[0], null ),
					new HarvestVein( 16.0, 0.5, res[1], res[0] ), // Pine
					new HarvestVein( 14.0, 0.5, res[2], res[0] ), // Cedar
					new HarvestVein( 11.5, 0.5, res[3], res[0] ), // Cherry
					new HarvestVein( 8.5, 0.5, res[4], res[0] ), // Mahogony
					new HarvestVein( 7.5, 0.5, res[5], res[0] ), // Oak
					new HarvestVein( 6.5, 0.5, res[6], res[0] ), // Ash
					new HarvestVein( 5.5, 0.5, res[7], res[0] ), // Yew
					new HarvestVein( 4.5, 0.5, res[8], res[0] ), // Heartwood
					new HarvestVein( 3.5, 0.5, res[9], res[0] ), // Bloodwood
					new HarvestVein( 2.5, 0.5, res[10], res[0] ), // Frostwood
				};

				lumber.BonusResources = new BonusHarvestResource[]
				{
					new BonusHarvestResource( 0, 83.9, null, null ),	//Nothing
					new BonusHarvestResource( 100, 10.0, 1072548, typeof( BarkFragment ) ),
					new BonusHarvestResource( 100, 03.0, 1072550, typeof( LuminescentFungi ) ),
					new BonusHarvestResource( 100, 02.0, 1072547, typeof( SwitchItem ) ),
					new BonusHarvestResource( 100, 01.0, 1072549, typeof( ParasiticPlant ) ),
					new BonusHarvestResource( 100, 00.1, 1072551, typeof( BrilliantAmber ) )
				};
			}
			else
			{
				res = new HarvestResource[]
				{
					new HarvestResource( 00.0, 00.0, 100.0, 500498, typeof( Log ) )
				};

				veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};
			}

			lumber.Resources = res;
			lumber.Veins = veins;

			lumber.RaceBonus = Core.SA;
			lumber.RandomizeVeins = Core.SA;

			m_Definition = lumber;
			Definitions.Add( lumber );
			#endregion
		}

		public override bool CheckHarvest( Mobile from, Item tool )
		{
			if ( !base.CheckHarvest( from, tool ) )
				return false;

			if ( tool.Parent != from )
			{
				from.SendLocalizedMessage( 500487 ); // The axe must be equipped for any serious wood chopping.
				return false;
			}

			return true;
		}

		public override bool CheckHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			if ( !base.CheckHarvest( from, tool, def, toHarvest ) )
				return false;

			if ( tool.Parent != from )
			{
				from.SendLocalizedMessage( 500487 ); // The axe must be equipped for any serious wood chopping.
				return false;
			}

			return true;
		}
		
		#region Mondain's Legacy
		public override bool Give( Mobile m, Item item, bool placeAtFeet )
		{
			if ( m.Skills.Lumberjacking.Value >= 100 )
			{				
				if ( Utility.RandomDouble() < 0.15 )
				{					
					Item sitem = null;
					int message = 0;
					double chance = Utility.RandomDouble();
					
					if ( chance < 0.0025 ) // not completely sure
					{
						sitem = new BrilliantAmber();
						message = 1072551; // You found a brilliant amber!
					}
					else if ( chance < 0.05 )
					{
						sitem = new ParasiticPlant();
						message = 1072549; // You found a parasitic plant!
					}
					else if ( chance < 0.35 )		
					{
						if ( Utility.RandomBool() )
						{
							sitem = new SwitchItem();
							message = 1072547; // You found a switch!
						}
						else
						{
							sitem = new LuminescentFungi();
							message = 1072550; // You found a luminescent fungi!
						}
					}			
					else
					{
						sitem = new BarkFragment();
						message = 1072548; // You found a bark fragment!
					}	
					
					if ( !m.PlaceInBackpack( sitem ) )
					{						
						if ( placeAtFeet )
						{
							List<Item> atFeet = new List<Item>();
		
							foreach ( Item obj in m.GetItemsInRange( 0 ) )
								atFeet.Add( obj );
				
							for ( int i = 0; i < atFeet.Count; ++i )
							{
								Item check = atFeet[i];
				
								if ( check.StackWith( m, sitem, false ) )
								{
									m.SendLocalizedMessage( message );
									return base.Give( m, item, placeAtFeet );
								}
							}
				
							sitem.MoveToWorld( m.Location, m.Map );
							m.SendLocalizedMessage( message );
						}
						else
							sitem.Delete();
					}
					else	
						m.SendLocalizedMessage( message );
				}				
			}			
			
			return base.Give( m, item, placeAtFeet );
		}
		#endregion

		public override void OnBadHarvestTarget( Mobile from, Item tool, object toHarvest )
		{
			if ( toHarvest is Mobile )
			{
				Mobile obj = (Mobile)toHarvest;
				obj.PublicOverheadMessage( Server.Network.MessageType.Regular, 0x3E9, 500450 ); // You can only skin dead creatures.
			}
			else if ( toHarvest is Item )
			{
				Item obj = (Item)toHarvest;
				obj.PublicOverheadMessage( Server.Network.MessageType.Regular, 0x3E9, 500464 ); // Use this on corpses to carve away meat and hide
			}
			else if ( toHarvest is Targeting.StaticTarget || toHarvest is Targeting.LandTarget )
				from.SendLocalizedMessage( 500489 ); // You can't use an axe on that.
			else
				from.SendLocalizedMessage( 1005213 ); // You can't do that
		}

		public override void OnHarvestStarted( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			base.OnHarvestStarted( from, tool, def, toHarvest );
			
			if( Core.ML )
				from.RevealingAction();
		}

		public static void Initialize()
		{
			Array.Sort( m_TreeTiles );
		}

		#region Tile lists
		private static int[] m_TreeTiles = new int[]
			{
                0x4CCA, 0x4CCB, 0x4CCC, 0x4CCD, 0x4CD0, 0x4CD3, 0x4CD6, 0x4CD8,
				0x4CDA, 0x4CDD, 0x4CE0, 0x4CE3, 0x4CE6, 0x4CF8, 0x4CFB, 0x4CFE,
				0x4D01, 0x4D41, 0x4D42, 0x4D43, 0x4D44, 0x4D57, 0x4D58, 0x4D59,
				0x4D5A, 0x4D5B, 0x4D6E, 0x4D6F, 0x4D70, 0x4D71, 0x4D72, 0x4D84,
				0x4D85, 0x4D86, 0x52B5, 0x52B6, 0x52B7, 0x52B8, 0x52B9, 0x52BA,
				0x52BB, 0x52BC, 0x52BD,

				0x4CCE, 0x4CCF, 0x4CD1, 0x4CD2, 0x4CD4, 0x4CD5, 0x4CD7, 0x4CD9,
				0x4CDB, 0x4CDC, 0x4CDE, 0x4CDF, 0x4CE1, 0x4CE2, 0x4CE4, 0x4CE5,
				0x4CE7, 0x4CE8, 0x4CF9, 0x4CFA, 0x4CFC, 0x4CFD, 0x4CFF, 0x4D00,
				0x4D02, 0x4D03, 0x4D45, 0x4D46, 0x4D47, 0x4D48, 0x4D49, 0x4D4A,
				0x4D4B, 0x4D4C, 0x4D4D, 0x4D4E, 0x4D4F, 0x4D50, 0x4D51, 0x4D52,
				0x4D53, 0x4D5C, 0x4D5D, 0x4D5E, 0x4D5F, 0x4D60, 0x4D61, 0x4D62,
				0x4D63, 0x4D64, 0x4D65, 0x4D66, 0x4D67, 0x4D68, 0x4D69, 0x4D73,
				0x4D74, 0x4D75, 0x4D76, 0x4D77, 0x4D78, 0x4D79, 0x4D7A, 0x4D7B,
				0x4D7C, 0x4D7D, 0x4D7E, 0x4D7F, 0x4D87, 0x4D88, 0x4D89, 0x4D8A,
				0x4D8B, 0x4D8C, 0x4D8D, 0x4D8E, 0x4D8F, 0x4D90, 0x4D95, 0x4D96,
				0x4D97, 0x4D99, 0x4D9A, 0x4D9B, 0x4D9D, 0x4D9E, 0x4D9F, 0x4DA1,
				0x4DA2, 0x4DA3, 0x4DA5, 0x4DA6, 0x4DA7, 0x4DA9, 0x4DAA, 0x4DAB,
				0x52BE, 0x52BF, 0x52C0, 0x52C1, 0x52C2, 0x52C3, 0x52C4, 0x52C5,
				0x52C6, 0x52C7,
				#region SA
			// Static Targets fix for SA
			// Adding 0x8000 instead of 0x4000 for static harvest targets
				0x8CCA, 0x8CCB, 0x8CCC, 0x8CCD, 0x8CD0, 0x8CD3, 0x8CD6, 0x8CD8,
				0x8CDA, 0x8CDD, 0x8CE0, 0x8CE3, 0x8CE6, 0x8CF8, 0x8CFB, 0x8CFE,
				0x8D01, 0x8D41, 0x8D42, 0x8D43, 0x8D44, 0x8D57, 0x8D58, 0x8D59,
				0x8D5A, 0x8D5B, 0x8D6E, 0x8D6F, 0x8D70, 0x8D71, 0x8D72, 0x8D84,
				0x8D85, 0x8D86, 0x92B5, 0x92B6, 0x92B7, 0x92B8, 0x92B9, 0x92BA,
				0x92BB, 0x92BC, 0x92BD,

				0x8CCE, 0x8CCF, 0x8CD1, 0x8CD2, 0x8CD4, 0x8CD5, 0x8CD7, 0x8CD9,
				0x8CDB, 0x8CDC, 0x8CDE, 0x8CDF, 0x8CE1, 0x8CE2, 0x8CE4, 0x8CE5,
				0x8CE7, 0x8CE8, 0x8CF9, 0x8CFA, 0x8CFC, 0x8CFD, 0x8CFF, 0x8D00,
				0x8D02, 0x8D03, 0x8D45, 0x8D46, 0x8D47, 0x8D48, 0x8D49, 0x8D4A,
				0x8D4B, 0x8D4C, 0x8D4D, 0x8D4E, 0x8D4F, 0x8D50, 0x8D51, 0x8D52,
				0x8D53, 0x8D5C, 0x8D5D, 0x8D5E, 0x8D5F, 0x8D60, 0x8D61, 0x8D62,
				0x8D63, 0x8D64, 0x8D65, 0x8D66, 0x8D67, 0x8D68, 0x8D69, 0x8D73,
				0x8D74, 0x8D75, 0x8D76, 0x8D77, 0x8D78, 0x8D79, 0x8D7A, 0x8D7B,
				0x8D7C, 0x8D7D, 0x8D7E, 0x8D7F, 0x8D87, 0x8D88, 0x8D89, 0x8D8A,
				0x8D8B, 0x8D8C, 0x8D8D, 0x8D8E, 0x8D8F, 0x8D90, 0x8D95, 0x8D96,
				0x8D97, 0x8D99, 0x8D9A, 0x8D9B, 0x8D9D, 0x8D9E, 0x8D9F, 0x8DA1,
				0x8DA2, 0x8DA3, 0x8DA5, 0x8DA6, 0x8DA7, 0x8DA9, 0x8DAA, 0x8DAB,
				0x92BE, 0x92BF, 0x92C0, 0x92C1, 0x92C2, 0x92C3, 0x92C4, 0x92C5,
				0x92C6, 0x92C7
				
				#endregion
			};
		#endregion
	}
}