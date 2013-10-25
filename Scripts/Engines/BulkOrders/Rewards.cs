using System;
using Server;
using Server.Items;

namespace Server.Engines.BulkOrders
{
	public delegate Item ConstructCallback( int type );

	public sealed class RewardType
	{
		private int m_Points;
		private Type[] m_Types;

		public int Points{ get{ return m_Points; } }
		public Type[] Types{ get{ return m_Types; } }

		public RewardType( int points, params Type[] types )
		{
			m_Points = points;
			m_Types = types;
		}

		public bool Contains( Type type )
		{
			for ( int i = 0; i < m_Types.Length; ++i )
			{
				if ( m_Types[i] == type )
					return true;
			}

			return false;
		}
	}

	public sealed class RewardItem
	{
		private int m_Weight;
		private ConstructCallback m_Constructor;
		private int m_Type;

		public int Weight{ get{ return m_Weight; } }
		public ConstructCallback Constructor{ get{ return m_Constructor; } }
		public int Type{ get{ return m_Type; } }

		public RewardItem( int weight, ConstructCallback constructor ) : this( weight, constructor, 0 )
		{
		}

		public RewardItem( int weight, ConstructCallback constructor, int type )
		{
			m_Weight = weight;
			m_Constructor = constructor;
			m_Type = type;
		}

		public Item Construct()
		{
			try{ return m_Constructor( m_Type ); }
			catch{ return null; }
		}
	}

	public sealed class RewardGroup
	{
		private int m_Points;
		private RewardItem[] m_Items;

		public int Points{ get{ return m_Points; } }
		public RewardItem[] Items{ get{ return m_Items; } }

		public RewardGroup( int points, params RewardItem[] items )
		{
			m_Points = points;
			m_Items = items;
		}

		public RewardItem AcquireItem()
		{
			if ( m_Items.Length == 0 )
				return null;
			else if ( m_Items.Length == 1 )
				return m_Items[0];

			int totalWeight = 0;

			for ( int i = 0; i < m_Items.Length; ++i )
				totalWeight += m_Items[i].Weight;

			int randomWeight = Utility.Random( totalWeight );

			for ( int i = 0; i < m_Items.Length; ++i )
			{
				RewardItem item = m_Items[i];

				if ( randomWeight < item.Weight )
					return item;

				randomWeight -= item.Weight;
			}

			return null;
		}
	}

	public abstract class RewardCalculator
	{
		private RewardGroup[] m_Groups;

		public RewardGroup[] Groups{ get{ return m_Groups; } set{ m_Groups = value; } }

		public abstract int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type );
		public abstract int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type );

		public virtual int ComputeFame( SmallBOD bod )
		{
			int points = ComputePoints( bod ) / 50;

			return points * points;
		}

		public virtual int ComputeFame( LargeBOD bod )
		{
			int points = ComputePoints( bod ) / 50;

			return points * points;
		}

		public virtual int ComputePoints( SmallBOD bod )
		{
			return ComputePoints( bod.AmountMax, bod.RequireExceptional, bod.Material, 1, bod.Type );
		}

		public virtual int ComputePoints( LargeBOD bod )
		{
			return ComputePoints( bod.AmountMax, bod.RequireExceptional, bod.Material, bod.Entries.Length, bod.Entries[0].Details.Type );
		}

		public virtual int ComputeGold( SmallBOD bod )
		{
			return ComputeGold( bod.AmountMax, bod.RequireExceptional, bod.Material, 1, bod.Type );
		}

		public virtual int ComputeGold( LargeBOD bod )
		{
			return ComputeGold( bod.AmountMax, bod.RequireExceptional, bod.Material, bod.Entries.Length, bod.Entries[0].Details.Type );
		}

		public virtual RewardGroup LookupRewards( int points )
		{
			for ( int i = m_Groups.Length - 1; i >= 1; --i )
			{
				RewardGroup group = m_Groups[i];

				if ( points >= group.Points )
					return group;
			}

			return m_Groups[0];
		}

		public virtual int LookupTypePoints( RewardType[] types, Type type )
		{
			for ( int i = 0; i < types.Length; ++i )
			{
				if ( types[i].Contains( type ) )
					return types[i].Points;
			}

			return 0;
		}

		public RewardCalculator()
		{
		}
	}

	public sealed class SmithRewardCalculator : RewardCalculator
	{
		#region Constructors
		private static readonly ConstructCallback SturdyShovel = new ConstructCallback( CreateSturdyShovel );
		private static readonly ConstructCallback SturdyPickaxe = new ConstructCallback( CreateSturdyPickaxe );
		private static readonly ConstructCallback MiningGloves = new ConstructCallback( CreateMiningGloves );
		private static readonly ConstructCallback GargoylesPickaxe = new ConstructCallback( CreateGargoylesPickaxe );
		private static readonly ConstructCallback ProspectorsTool = new ConstructCallback( CreateProspectorsTool );
		private static readonly ConstructCallback PowderOfTemperament = new ConstructCallback( CreatePowderOfTemperament );
		private static readonly ConstructCallback RunicHammer = new ConstructCallback( CreateRunicHammer );
		private static readonly ConstructCallback PowerScroll = new ConstructCallback( CreatePowerScroll );
		private static readonly ConstructCallback ColoredAnvil = new ConstructCallback( CreateColoredAnvil );
		private static readonly ConstructCallback AncientHammer = new ConstructCallback( CreateAncientHammer );
        private static readonly ConstructCallback ItemBlessDeed = new ConstructCallback( CreateItemBlessDeed );
        private static readonly ConstructCallback ArmorOfCrafting = new ConstructCallback(CreateArmorOfCrafting);

		private static Item CreateSturdyShovel( int type )
		{
			return new SturdyShovel();
		}

		private static Item CreateSturdyPickaxe( int type )
		{
			return new SturdyPickaxe();
		}

		private static Item CreateMiningGloves( int type )
		{
			if ( type == 1 )
				return new LeatherGlovesOfMining( 1 );
			else if ( type == 3 )
				return new StuddedGlovesOfMining( 3 );
			else if ( type == 5 )
				return new RingmailGlovesOfMining( 5 );

			throw new InvalidOperationException();
		}

		private static Item CreateGargoylesPickaxe( int type )
		{
			return new GargoylesPickaxe();
		}

		private static Item CreateProspectorsTool( int type )
		{
			return new ProspectorsTool();
		}

		private static Item CreatePowderOfTemperament( int type )
		{
			return new PowderOfTemperament();
		}

		private static Item CreateRunicHammer( int type )
		{
			if ( type >= 1 && type <= 11 )
				return new RunicHammer( CraftResource.Iron + type, Core.AOS ? ( 55 - (type*2) ) : 50 );

			throw new InvalidOperationException();
		}

		private static Item CreatePowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
			
			switch ( Utility.Random( 2 ) )
			{
				case 0: return new PowerScroll( SkillName.Blacksmith, 100 + type );				
				case 1: return new PowerScroll( SkillName.Mining, 100 + type );
			}				

			throw new InvalidOperationException();
		}	

		private static Item CreateColoredAnvil( int type )
		{
			// Generate an anvil deed, not an actual anvil.
			//return new ColoredAnvilDeed();

			return new ColoredAnvil();
		}

        private static Item CreateItemBlessDeed(int type)
        {
            return new ItemBlessDeed();
        }

        private static Item CreateArmorOfCrafting(int type)
        {
            switch (Utility.Random(6))
            {
                default:
                case 0: return new ArmorOfCrafting(5, 5062, Utility.Random(0));//gloves
                case 1: return new ArmorOfCrafting(5, 7609, Utility.Random(0));//cap
                case 2: return new ArmorOfCrafting(5, 5068, Utility.Random(0));//tunic
                case 3: return new ArmorOfCrafting(5, 5063, Utility.Random(0));//gorget
                case 4: return new ArmorOfCrafting(5, 5069, Utility.Random(0));//arms
                case 5: return new ArmorOfCrafting(5, 5067, Utility.Random(0));//leggings
            }
        }

		private static Item CreateAncientHammer( int type )
		{
			if ( type == 10 || type == 15 || type == 30 || type == 60 )
				return new AncientSmithyHammer( type );

			throw new InvalidOperationException();
		}
		#endregion

		public static readonly SmithRewardCalculator Instance = new SmithRewardCalculator();

		private RewardType[] m_Types = new RewardType[]
			{
				// Armors
				new RewardType( 200, typeof( RingmailGloves ), typeof( RingmailChest ), typeof( RingmailArms ), typeof( RingmailLegs ) ),
				new RewardType( 300, typeof( ChainCoif ), typeof( ChainLegs ), typeof( ChainChest ) ),
				new RewardType( 400, typeof( PlateArms ), typeof( PlateLegs ), typeof( PlateHelm ), typeof( PlateGorget ), typeof( PlateGloves ), typeof( PlateChest ) ),

				// Weapons
				new RewardType( 200, typeof( Bardiche ), typeof( Halberd ) ),
				new RewardType( 300, typeof( Dagger ), typeof( ShortSpear ), typeof( Spear ), typeof( WarFork ), typeof( Kryss ) ),	//OSI put the dagger in there.  Odd, ain't it.
				new RewardType( 350, typeof( Axe ), typeof( BattleAxe ), typeof( DoubleAxe ), typeof( ExecutionersAxe ), typeof( LargeBattleAxe ), typeof( TwoHandedAxe ) ),
				new RewardType( 350, typeof( Broadsword ), typeof( Cutlass ), typeof( Katana ), typeof( Longsword ), typeof( Scimitar ), typeof( ThinLongsword ), typeof( VikingSword ) ),
				new RewardType( 350, typeof( WarAxe ), typeof( HammerPick ), typeof( Mace ), typeof( Maul ), typeof( WarHammer ), typeof( WarMace ) )
			};

		public override int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int points = 0;

			if ( quantity == 10 )
				points += 10;
			else if ( quantity == 15 )
				points += 25;
			else if ( quantity == 20 )
				points += 50;

			if ( exceptional )
				points += 200;

			if ( itemCount > 1 )
				points += LookupTypePoints( m_Types, type );

			if ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Sunstone )
				points += 200 + (50 * (material - BulkMaterialType.DullCopper));

			return points;
		}

		private static int[][][] m_GoldTable = new int[][][]
			{
				new int[][] // 1-part (regular)
				{
				new int[]{ 100, 200, 300,  400,  500,  600,  700,  800,  900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700 },
				new int[]{ 200, 400, 600,  800, 1000, 1200, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400 },
				new int[]{ 300, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000, 3300, 3600, 3900, 4200, 4400, 4600, 4800 }
				},
				new int[][] // 1-part (exceptional)
				{
				new int[]{ 250, 500,  750, 1000, 1250, 1500, 1750, 2000,  2250, 2500, 2750, 3000, 3250, 3500, 3750, 4000, 4250 },
				new int[]{ 350, 700, 1050, 1400, 1750, 2100, 2450, 2800,  3150, 3500, 3850, 4200, 4550, 4900, 5250, 5500, 5850 },
				new int[]{ 450, 900, 1350, 1800, 2250, 2700, 3150, 3600,  4050, 4500, 4950, 5400, 5850, 6300, 6750, 7200, 7650 }
				},
				new int[][] // Ringmail (regular)
				{
				new int[]{ 2000, 4000,  6000,  8000, 10000, 12000, 14000, 16000, 18000, 20000, 22000, 24000, 26000, 28000, 30000, 32000, 34000 },
				new int[]{ 3000, 6000,  9000, 12000, 15000, 18000, 21000, 24000, 27000, 30000, 33000, 36000, 39000, 42000, 45000, 48000, 51000 },
				new int[]{ 4000, 8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000, 48000, 52000, 56000, 60000, 64000, 68000 }
				},
				new int[][] // Ringmail (exceptional)
				{
				new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000, 48000,  52000,  54000,  56000,  60000,  64000 },
				new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000, 72000,  78000,  84000,  90000,  96000, 102000 },
				new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000, 96000, 104000, 112000, 120000, 128000, 136000 }
				},
				new int[][] // Chainmail (regular)
				{
				new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000, 48000,  52000,  54000,  56000,  60000,  64000 },
				new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000, 72000,  78000,  84000,  90000,  96000, 102000 },
				new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000, 96000, 104000, 112000, 120000, 128000, 136000 }
				},
				new int[][] // Chainmail (exceptional)
				{
				new int[]{  7000, 14000, 21000, 28000, 35000, 42000,  49000,  56000,  63000,  70000,  77000,  84000,  91000,  98000, 105000, 112000, 119000 },
				new int[]{ 10000, 20000, 30000, 40000, 50000, 60000,  70000,  80000,  90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000 },
				new int[]{ 15000, 30000, 45000, 60000, 75000, 90000, 115000, 130000, 145000, 160000, 175000, 190000, 205000, 220000, 235000, 240000, 255000 }
				},
				new int[][] // Platemail (regular)
				{
				new int[]{  5000, 10000, 15000, 20000, 25000, 30000,  35000,  40000,  45000,  50000,  55000,  60000,  65000,  70000,  75000,  80000,  85000 },
				new int[]{  7500, 15000, 22500, 30000, 37500, 45000,  52500,  60000,  67500,  75000,  82500,  90000,  97500, 105000, 112500, 120000, 127500 },
				new int[]{ 10000, 20000, 30000, 40000, 50000, 60000,  70000,  80000,  90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000 }
				},
				new int[][] // Platemail (exceptional)
				{
				new int[]{ 10000, 20000, 30000, 40000,  50000,  60000,  70000,  80000,  90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000 },
				new int[]{ 15000, 30000, 45000, 60000,  75000,  90000, 115000, 130000, 145000, 160000, 175000, 190000, 205000, 220000, 235000, 240000, 255000 },
				new int[]{ 20000, 40000, 60000, 80000, 100000, 120000, 140000, 160000, 180000, 200000, 220000, 240000, 260000, 280000, 300000, 320000, 340000 }
				},
				new int[][] // 2-part weapons (regular)
				{
					new int[]{ 3000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 4500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 6000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 2-part weapons (exceptional)
				{
					new int[]{ 5000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 7500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 10000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 5-part weapons (regular)
				{
					new int[]{ 4000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 6000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 8000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 5-part weapons (exceptional)
				{
					new int[]{ 7500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 11250, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 15000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 6-part weapons (regular)
				{
					new int[]{ 4000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 6000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 10000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 6-part weapons (exceptional)
				{
					new int[]{ 7500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 11250, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 15000, 0, 0, 0, 0, 0, 0, 0, 0 }
				}
			};

		private int ComputeType( Type type, int itemCount )
		{
			// Item count of 1 means it's a small BOD.
			if ( itemCount == 1 )
				return 0;

			int typeIdx;

			// Loop through the RewardTypes defined earlier and find the correct one.
			for ( typeIdx = 0; typeIdx < 7; ++typeIdx )
			{
				if ( m_Types[typeIdx].Contains( type ) )
					break;
			}

			// Types 5, 6 and 7 are Large Weapon BODs with the same rewards.
			if ( typeIdx > 5 )
				typeIdx = 5;

			return ( typeIdx + 1 ) * 2;
		}

		public override int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int[][][] goldTable = m_GoldTable;

			int typeIndex = ComputeType( type, itemCount );
			int quanIndex = ( quantity == 20 ? 2 : quantity == 15 ? 1 : 0 );
			int mtrlIndex = ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Sunstone ) ? 1 + (int)(material - BulkMaterialType.DullCopper) : 0;

			if ( exceptional )
				typeIndex++;

			int gold = goldTable[typeIndex][quanIndex][mtrlIndex];

			int min = (gold * 9) / 10;
			int max = (gold * 10) / 9;

			return Utility.RandomMinMax( min, max );
		}

		public SmithRewardCalculator()
		{
			Groups = new RewardGroup[]
				{
					new RewardGroup(    0, new RewardItem( 1, SturdyShovel ) ),
					new RewardGroup(   25, new RewardItem( 1, SturdyPickaxe ) ),
					new RewardGroup(   50, new RewardItem( 45, SturdyShovel ), new RewardItem( 45, SturdyPickaxe ), new RewardItem( 10, MiningGloves, 1 ) ),
					new RewardGroup(  200, new RewardItem( 45, GargoylesPickaxe ), new RewardItem( 45, ProspectorsTool ), new RewardItem( 10, MiningGloves, 3 ) ),
					new RewardGroup(  400, new RewardItem( 2, GargoylesPickaxe ), new RewardItem( 2, ProspectorsTool ), new RewardItem( 1, PowderOfTemperament ) ),
					new RewardGroup(  450, new RewardItem( 9, PowderOfTemperament ), new RewardItem( 1, MiningGloves, 5 ) ),
					new RewardGroup(  500, new RewardItem( 1, RunicHammer, 1 ) ),
					new RewardGroup(  550, new RewardItem( 3, RunicHammer, 1 ), new RewardItem( 2, RunicHammer, 2 ) ),
					new RewardGroup(  600, new RewardItem( 1, RunicHammer, 2 ) ),
					new RewardGroup(  625, new RewardItem( 3, RunicHammer, 2 ), new RewardItem( 6, PowerScroll, 5 ), new RewardItem( 1, ColoredAnvil ) ),
					new RewardGroup(  650, new RewardItem( 1, RunicHammer, 3 ) ),
					new RewardGroup(  675, new RewardItem( 1, ColoredAnvil ), new RewardItem( 6, PowerScroll, 10 ), new RewardItem( 3, RunicHammer, 3 ) ),
					new RewardGroup(  700, new RewardItem( 1, RunicHammer, 4 ) ), 
					new RewardGroup(  750, new RewardItem( 1, AncientHammer, 10 ) , new RewardItem( 10, ArmorOfCrafting, Utility.RandomMinMax( 0,0 ) ) ),
					new RewardGroup(  800, new RewardItem( 1, PowerScroll, 15 ) ),
					new RewardGroup(  850, new RewardItem( 1, AncientHammer, 15 ) ),
					new RewardGroup(  900, new RewardItem( 1, PowerScroll, 20 ), new RewardItem( 6, ItemBlessDeed ) ),
					new RewardGroup(  950, new RewardItem( 1, RunicHammer, 5 ) ),
					new RewardGroup( 1000, new RewardItem( 1, AncientHammer, 30 ) ),
					new RewardGroup( 1050, new RewardItem( 1, RunicHammer, 6 ) ),
					new RewardGroup( 1100, new RewardItem( 1, AncientHammer, 60 ) ),
					new RewardGroup( 1150, new RewardItem( 1, RunicHammer, 7 ) ),
					new RewardGroup( 1200, new RewardItem( 1, RunicHammer, 8 ) ),
					new RewardGroup( 1250, new RewardItem( 1, RunicHammer, 9 ) ),
					new RewardGroup( 1300, new RewardItem( 1, RunicHammer, 10 ) ),
					new RewardGroup( 1350, new RewardItem( 1, RunicHammer, 11 ) ),
					new RewardGroup( 1400, new RewardItem( 1, RunicHammer, 12 ) ),
					new RewardGroup( 1450, new RewardItem( 1, RunicHammer, 13 ) ),
					new RewardGroup( 1500, new RewardItem( 1, RunicHammer, 14 ) ),
					new RewardGroup( 1550, new RewardItem( 1, RunicHammer, 15 ) ),
					new RewardGroup( 1600, new RewardItem( 1, RunicHammer, 16 ) )
				};
		}
	}

	public sealed class TailorRewardCalculator : RewardCalculator
	{
		#region Constructors
		private static readonly ConstructCallback Cloth = new ConstructCallback( CreateCloth );
		private static readonly ConstructCallback Sandals = new ConstructCallback( CreateSandals );
		private static readonly ConstructCallback StretchedHide = new ConstructCallback( CreateStretchedHide );
		private static readonly ConstructCallback RunicKit = new ConstructCallback( CreateRunicKit );
		private static readonly ConstructCallback Tapestry = new ConstructCallback( CreateTapestry );
		private static readonly ConstructCallback PowerScroll = new ConstructCallback( CreatePowerScroll );
		private static readonly ConstructCallback BearRug = new ConstructCallback( CreateBearRug );
		private static readonly ConstructCallback ClothingBlessDeed = new ConstructCallback( CreateCBD );
        private static readonly ConstructCallback ArmorOfCrafting = new ConstructCallback( CreateArmorOfCrafting );

		private static int[][] m_ClothHues = new int[][]
			{
				new int[]{ 0x483, 0x48C, 0x488, 0x48A },
				new int[]{ 0x495, 0x48B, 0x486, 0x485 },
				new int[]{ 0x48D, 0x490, 0x48E, 0x491 },
				new int[]{ 0x48F, 0x494, 0x484, 0x497 },
				new int[]{ 0x489, 0x47F, 0x482, 0x47E }
			};

		private static Item CreateCloth( int type )
		{
			if ( type >= 0 && type < m_ClothHues.Length )
			{
				UncutCloth cloth = new UncutCloth( 100 );
				cloth.Hue = m_ClothHues[type][Utility.Random( m_ClothHues[type].Length )];
				return cloth;
			}

			throw new InvalidOperationException();
		}

		private static int[] m_SandalHues = new int[]
			{
				0x489, 0x47F, 0x482,
				0x47E, 0x48F, 0x494,
				0x484, 0x497
			};

		private static Item CreateSandals( int type )
		{
			return new Sandals( m_SandalHues[Utility.Random( m_SandalHues.Length )] );
		}

		private static Item CreateStretchedHide( int type )
		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0:	return new SmallStretchedHideEastDeed();
				case 1: return new SmallStretchedHideSouthDeed();
				case 2: return new MediumStretchedHideEastDeed();
				case 3: return new MediumStretchedHideSouthDeed();
			}
		}

		private static Item CreateTapestry( int type )
		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0:	return new LightFlowerTapestryEastDeed();
				case 1: return new LightFlowerTapestrySouthDeed();
				case 2: return new DarkFlowerTapestryEastDeed();
				case 3: return new DarkFlowerTapestrySouthDeed();
			}
		}

		private static Item CreateBearRug( int type )
		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0:	return new BrownBearRugEastDeed();
				case 1: return new BrownBearRugSouthDeed();
				case 2: return new PolarBearRugEastDeed();
				case 3: return new PolarBearRugSouthDeed();
			}
		}

		private static Item CreateRunicKit( int type )
		{
			if ( type >= 1 && type <= 5 )
				return new RunicSewingKit( CraftResource.RegularLeather + type, 60 - (type*15) );

			throw new InvalidOperationException();
		}

		private static Item CreatePowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Tailoring, 100 + type );

			throw new InvalidOperationException();
		}

		private static Item CreateCBD( int type )
		{
			return new ClothingBlessDeed();
		}

        private static Item CreateArmorOfCrafting(int type)
        {
            switch (Utility.Random(6))
            {
                default:
                case 0: return new ArmorOfCrafting(5, 5062, Utility.Random(3));//gloves
                case 1: return new ArmorOfCrafting(5, 7609, Utility.Random(3));//cap
                case 2: return new ArmorOfCrafting(5, 5068, Utility.Random(3));//tunic
                case 3: return new ArmorOfCrafting(5, 5063, Utility.Random(3));//gorget
                case 4: return new ArmorOfCrafting(5, 5069, Utility.Random(3));//arms
                case 5: return new ArmorOfCrafting(5, 5067, Utility.Random(3));//leggings
            }
        }

		#endregion

		public static readonly TailorRewardCalculator Instance = new TailorRewardCalculator();

		public override int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int points = 0;

			if ( quantity == 10 )
				points += 10;
			else if ( quantity == 15 )
				points += 25;
			else if ( quantity == 20 )
				points += 50;

			if ( exceptional )
				points += 100;

			if ( itemCount == 4 )
				points += 300;
			else if ( itemCount == 5 )
				points += 400;
			else if ( itemCount == 6 )
				points += 500;

			if ( material == BulkMaterialType.Spined )
				points += 50;
			else if ( material == BulkMaterialType.Horned )
				points += 100;
			else if ( material == BulkMaterialType.Barbed )
				points += 150;
			else if ( material == BulkMaterialType.DragonL)
				points += 200;
			else if ( material == BulkMaterialType.Daemon)
				points += 250;

			return points;
		}

		private static int[][][] m_AosGoldTable = new int[][][]
			{
				new int[][] // 1-part (regular)
				{
					new int[]{ 100, 200, 300,  400,  500,  600,  700,  800,  900, 1000, 1100 },
					new int[]{ 200, 400, 600,  800, 1000, 1200, 1400, 1600, 1800, 2000, 2200 },
					new int[]{ 300, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000, 3300 }
				},
				new int[][] // 1-part (exceptional)
				{
					new int[]{ 250, 500,  750, 1000, 1250, 1500, 1750, 2000,  2250, 2500, 2750 },
					new int[]{ 350, 700, 1050, 1400, 1750, 2100, 2450, 2800,  3150, 3500, 3850 },
					new int[]{ 450, 900, 1350, 1800, 2250, 2700, 3150, 3600,  4050, 4500, 4950 }
				},
				new int[][] // 4-part (regular)
				{
					new int[]{ 2000, 4000,  6000,  8000, 10000, 12000, 14000, 16000, 18000, 20000, 22000 },
					new int[]{ 3000, 6000,  9000, 12000, 15000, 18000, 21000, 24000, 27000, 30000, 33000 },
					new int[]{ 4000, 8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000 }
				},
				new int[][] // 4-part (exceptional)
				{
					new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000 },
					new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000 },
					new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000 }
				},
				new int[][] // 5-part (regular)
				{
					new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000 },
					new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000 },
					new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000 }
				},
				new int[][] // 5-part (exceptional)
				{
					new int[]{  7000, 14000, 21000, 28000, 35000, 42000,  49000,  56000,  63000,  70000,  77000 },
					new int[]{ 10000, 20000, 30000, 40000, 50000, 60000,  70000,  80000,  90000, 100000, 110000 },
					new int[]{ 15000, 30000, 45000, 60000, 75000, 90000, 105000, 120000, 135000, 150000, 165000 }
				},
				new int[][] // 6-part (regular)
				{
					new int[]{  5000, 10000, 15000, 20000, 25000, 30000,  35000,  40000,  45000,  50000,  55000 },
					new int[]{  7500, 15000, 22500, 30000, 37500, 45000,  52500,  60000,  67500,  75000,  82500 },
					new int[]{ 10000, 20000, 30000, 40000, 50000, 60000,  70000,  80000,  90000, 100000, 110000 }
				},
				new int[][] // 6-part (exceptional)
				{
					new int[]{ 10000, 20000, 30000, 40000,  50000,  60000,  70000,  80000,  90000, 100000, 110000 },
					new int[]{ 15000, 30000, 45000, 60000,  75000,  90000, 105000, 120000, 135000, 150000, 165000 },
					new int[]{ 20000, 40000, 60000, 80000, 100000, 120000, 140000, 160000, 180000, 200000, 220000 }
				}
			};

		private static int[][][] m_OldGoldTable = new int[][][]
			{
				new int[][] // 1-part (regular)
				{
				new int[]{ 100, 200, 300,  400,  500,  600,  700,  800,  900, 1000, 1100 },
				new int[]{ 200, 400, 600,  800, 1000, 1200, 1400, 1600, 1800, 2000, 2200 },
				new int[]{ 300, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000, 3300 }
				},
				new int[][] // 1-part (exceptional)
				{
				new int[]{ 250, 500,  750, 1000, 1250, 1500, 1750, 2000,  2250, 2500, 2750 },
				new int[]{ 350, 700, 1050, 1400, 1750, 2100, 2450, 2800,  3150, 3500, 3850 },
				new int[]{ 450, 900, 1350, 1800, 2250, 2700, 3150, 3600,  4050, 4500, 4950 }
				},
				new int[][] // 4-part (regular)
				{
				new int[]{ 2000, 4000,  6000,  8000, 10000, 12000, 14000, 16000, 18000, 20000, 22000 },
				new int[]{ 3000, 6000,  9000, 12000, 15000, 18000, 21000, 24000, 27000, 30000, 33000 },
				new int[]{ 4000, 8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000 }
				},
				new int[][] // 4-part (exceptional)
				{
				new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000 },
				new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000 },
				new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000 }
				},
				new int[][] // 5-part (regular)
				{
				new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000 },
				new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000 },
				new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000 }
				},
				new int[][] // 5-part (exceptional)
				{
				new int[]{  7000, 14000, 21000, 28000, 35000, 42000,  49000,  56000,  63000,  70000,  77000 },
				new int[]{ 10000, 20000, 30000, 40000, 50000, 60000,  70000,  80000,  90000, 100000, 110000 },
				new int[]{ 15000, 30000, 45000, 60000, 75000, 90000, 105000, 120000, 135000, 150000, 165000 }
				},
				new int[][] // 6-part (regular)
				{
				new int[]{  5000, 10000, 15000, 20000, 25000, 30000,  35000,  40000,  45000,  50000,  55000 },
				new int[]{  7500, 15000, 22500, 30000, 37500, 45000,  52500,  60000,  67500,  75000,  82500 },
				new int[]{ 10000, 20000, 30000, 40000, 50000, 60000,  70000,  80000,  90000, 100000, 110000 }
				},
				new int[][] // 6-part (exceptional)
				{
				new int[]{ 10000, 20000, 30000, 40000,  50000,  60000,  70000,  80000,  90000, 100000, 110000 },
				new int[]{ 15000, 30000, 45000, 60000,  75000,  90000, 105000, 120000, 135000, 150000, 165000 },
				new int[]{ 20000, 40000, 60000, 80000, 100000, 120000, 140000, 160000, 180000, 200000, 220000 }
				}
			};

		public override int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int[][][] goldTable = ( Core.AOS ? m_AosGoldTable : m_OldGoldTable );

			int typeIndex = (( itemCount == 6 ? 3 : itemCount == 5 ? 2 : itemCount == 4 ? 1 : 0 ) * 2) + (exceptional ? 1 : 0);
			int quanIndex = ( quantity == 20 ? 2 : quantity == 15 ? 1 : 0 );
			int mtrlIndex = ( material == BulkMaterialType.Barbed ? 3 : material == BulkMaterialType.Horned ? 2 : material == BulkMaterialType.Spined ? 1 : 0 );

			int gold = goldTable[typeIndex][quanIndex][mtrlIndex];

			int min = (gold * 9) / 10;
			int max = (gold * 10) / 9;

			return Utility.RandomMinMax( min, max );
		}

		public TailorRewardCalculator()
		{
			Groups = new RewardGroup[]
				{
					new RewardGroup(   0, new RewardItem( 1, Cloth, 0 ) ),
					new RewardGroup(  50, new RewardItem( 1, Cloth, 1 ) ),
					new RewardGroup( 100, new RewardItem( 1, Cloth, 2 ) ),
					new RewardGroup( 150, new RewardItem( 9, Cloth, 3 ), new RewardItem( 1, Sandals ) ),
					new RewardGroup( 200, new RewardItem( 4, Cloth, 4 ), new RewardItem( 1, Sandals ) ),
					new RewardGroup( 300, new RewardItem( 1, StretchedHide ), new RewardItem( 10, ArmorOfCrafting, Utility.RandomMinMax( 3,3 ) ) ),
					new RewardGroup( 350, new RewardItem( 1, RunicKit, 1 ) ),
					new RewardGroup( 400, new RewardItem( 2, PowerScroll, 5 ), new RewardItem( 3, Tapestry ) ),
					new RewardGroup( 450, new RewardItem( 1, BearRug ) ),
					new RewardGroup( 500, new RewardItem( 1, PowerScroll, 10 ) ),
					new RewardGroup( 550, new RewardItem( 1, ClothingBlessDeed ) ),
					new RewardGroup( 575, new RewardItem( 1, PowerScroll, 15 ) ),
					new RewardGroup( 600, new RewardItem( 1, RunicKit, 2 ) ),
					new RewardGroup( 625, new RewardItem( 1, PowerScroll, 20 ) ),
					new RewardGroup( 650, new RewardItem( 1, RunicKit, 3 ) ),
					new RewardGroup( 675, new RewardItem( 1, RunicKit, 4 ) ),
					new RewardGroup( 700, new RewardItem( 1, RunicKit, 5 ) )
		};
		}
	}
	
	

	//////////////////////////////////
	// Carp & Fletch BOD Addon 1/1  //
	//////////////////////////////////
	public sealed class CarpenterRewardCalculator : RewardCalculator
	{
		#region Constructors
		private static readonly ConstructCallback RunicSaw = new ConstructCallback( CreateRunicSaw );
		private static readonly ConstructCallback SturdyLumberjackAxe = new ConstructCallback( CreateSturdyLumberjackAxe );
		private static readonly ConstructCallback SturdyAxe = new ConstructCallback( CreateSturdyAxe );
		private static readonly ConstructCallback ArmorOfCrafting = new ConstructCallback( CreateArmorOfCrafting );
		private static readonly ConstructCallback StainOfDurability = new ConstructCallback( CreateStainOfDurability );
		private static readonly ConstructCallback GargoylesAxe = new ConstructCallback( CreateGargoylesAxe );
		private static readonly ConstructCallback Engraver = new ConstructCallback( CreateEngraver );
		//private static readonly ConstructCallback LumberjackingProspectorsTool = new ConstructCallback( CreateLumberjackingProspectorsTool );
		//private static readonly ConstructCallback HousebuildingSawFacingEastAddonDeed = new ConstructCallback( CreateHousebuildingSawFacingEastAddonDeed );
		//private static readonly ConstructCallback HousebuildingSawFacingSouthAddonDeed = new ConstructCallback( CreateHousebuildingSawFacingSouthAddonDeed );
		private static readonly ConstructCallback AncientCarpenterHammer = new ConstructCallback( CreateAncientCarpenterHammer );
		private static readonly ConstructCallback LeatherGlovesOfLumberjacking = new ConstructCallback( CreateLeatherGlovesOfLumberjacking );
		private static readonly ConstructCallback CarpenterPowerScroll = new ConstructCallback( CreateCarpenterPowerScroll );
		private static readonly ConstructCallback BagOfResources = new ConstructCallback( CreateBagOfResources );
		private static readonly ConstructCallback Deco = new ConstructCallback( CreateDeco );
		private static readonly ConstructCallback LumberjackingPowerScroll = new ConstructCallback( CreateLumberjackingPowerScroll );
		
		private static Item CreateDeco( int type )
		{
			switch (type)
			{
					case 0: default: return new Deco( 6644, "Vise East" );
					case 1: return new Deco( 6648, "Vise South" );
					case 2: return new Deco( 7800, "Unfinished Chair East" );
					case 3: return new Deco( 7791, "Unfinished Chair South" );
					case 4: return new Deco( 7802, "Unfinished Chest East" );
					case 5: return new Deco( 7793, "Unfinished Chest South" );
					case 6: return new Deco( 7806, "Unfinished Shelves East" );
					case 7: return new Deco( 7798, "Unfinished Shelves South" );
			}
		}
		
		private static Item CreateRunicSaw( int type )
		{
			if ( type >= 1 && type <= 12 )
				return new RunicSaw( CraftResource.Pine + type, Core.AOS ? ( 100 - (type*5) ) : 50 );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateSturdyLumberjackAxe( int type )
		{
			return new SturdyLumberjackAxe();
		}
		
		private static Item CreateSturdyAxe( int type )
		{
			return new SturdyAxe();
		}
		
		private static Item CreateArmorOfCrafting( int type )
		{
			switch (type)
			{
					// public ArmorOfCrafting( int bonus, int itemID, int skill ) : base( itemID ) example: 3 == bonus skill, 7609 == itemid, 2 == skill (mining)
					//notes:
					//total of 10 reward points
					//cloth have 6 points out of 10 (60%)
					//armor have 1 point out of 10 (10%)
					//sandals have 3 points out of 10 (30%)
					//new RewardGroup(  200, new RewardItem( 2, Cloth, 4 ), new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(1,6) ), new RewardItem( 2, Sandals ) ),
					//3 items 5 points
					//cloth have 2/5 40%
					//armor have 1/5 20%
					//sandals 2/5 40%
					
					//cloth:
					case 1: default: return new ArmorOfCrafting( 1, 5062, Utility.Random(2)); //gloves
					case 2: return new ArmorOfCrafting( 1, 7609, Utility.Random(2)); //cap
					case 3: return new ArmorOfCrafting( 1, 5068, Utility.Random(2)); //tunic
					case 4: return new ArmorOfCrafting( 1, 5063, Utility.Random(2)); //gorget
					case 5: return new ArmorOfCrafting( 1, 5069, Utility.Random(2)); //arms
					case 6: return new ArmorOfCrafting( 1, 5067, Utility.Random(2)); //leggings
					case 7: return new ArmorOfCrafting( 3, 5062, Utility.Random(2)); //gloves
					case 8: return new ArmorOfCrafting( 3, 7609, Utility.Random(2)); //cap
					case 9: return new ArmorOfCrafting( 3, 5068, Utility.Random(2)); //tunic
					case 10: return new ArmorOfCrafting( 3, 5063, Utility.Random(2)); //gorget
					case 11: return new ArmorOfCrafting( 3, 5069, Utility.Random(2)); //arms
					case 12: return new ArmorOfCrafting( 3, 5067, Utility.Random(2)); //leggings
					case 13: return new ArmorOfCrafting( 5, 5062, Utility.Random(2)); //gloves
					case 14: return new ArmorOfCrafting( 5, 7609, Utility.Random(2)); //cap
					case 15: return new ArmorOfCrafting( 5, 5068, Utility.Random(2)); //tunic
					case 16: return new ArmorOfCrafting( 5, 5063, Utility.Random(2)); //gorget
					case 17: return new ArmorOfCrafting( 5, 5069, Utility.Random(2)); //arms
					case 18: return new ArmorOfCrafting( 5, 5067, Utility.Random(2)); //leggings
			}
		}
		
		private static Item CreateStainOfDurability( int type )
		{
			return new StainOfDurability();
		}
		
		private static Item CreateGargoylesAxe( int type )
		{
			return new GargoylesAxe();
		}
		
		private static Item CreateEngraver( int type )
		{
			return new Engraver();
		}
		
		private static Item CreateCarpenterPowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Carpentry, 100 + type );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateAncientCarpenterHammer( int type )
		{
			if ( type == 10 || type == 20 || type == 30 || type == 40 )
				return new AncientCarpenterHammer( type );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateLeatherGlovesOfLumberjacking( int type )
		{
			if ( type == 2 || type == 5 || type == 7 || type == 10 )
				return new LeatherGlovesOfLumberjacking( type );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateBagOfResources( int type )
		{
			return new BagOfResources();
		}
		
		private static Item CreateLumberjackingPowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Lumberjacking, 100 + type );
			
			throw new InvalidOperationException();
		}
		#endregion
		
		public static readonly CarpenterRewardCalculator Instance = new CarpenterRewardCalculator();
		
		
		public override int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int points = 0;
			
			if ( quantity == 10 )
				points += 10;
			else if ( quantity == 15 )
				points += 25;
			else if ( quantity == 20 )
				points += 50;
			
			if ( exceptional )
				points += 200;
			
			if ( itemCount == 2 )
				points += 200;
			else if ( itemCount == 3 )
				points += 300;
			else if ( itemCount == 4 )
				points += 500;
			
			if ( material >= BulkMaterialType.Pine && material <= BulkMaterialType.Oak )
				points += 200 + (50 * (material - BulkMaterialType.Pine));
			
			return points;
		}
		
		private static int[][][] m_GoldTable = new int[][][]
		{
			new int[][] // 1-part (regular)
			{
				new int[]{ 150, 250, 250, 400,  400,  750,  750, 1200, 1200, 1500, 1500, 1800 },
				new int[]{ 225, 375, 375, 600,  600, 1125, 1125, 1800, 1800, 2100, 2100, 2400 },
				new int[]{ 300, 500, 750, 800, 1050, 1500, 2250, 2400, 3000, 3500, 4000, 4500 }
			},
			new int[][] // 1-part (exceptional)
			{
				new int[]{ 250, 400,  400,  750,  750, 1500, 1500, 3000, 3000, 3500, 3500, 4000 },
				new int[]{ 375, 600,  600, 1125, 1125, 2250, 2250, 4500, 4500, 5000, 5000, 5500 },
				new int[]{ 500, 800, 1200, 1500, 2500, 3000, 4000, 5000, 6000, 7000, 8000, 9000 }
			},
			new int[][] // 2-part (regular)
			{
				new int[]{ 150, 250, 250, 400,  400,  750,  750, 1200, 1200, 1500, 1500, 1800 },
				new int[]{ 225, 375, 375, 600,  600, 1125, 1125, 1800, 1800, 2100, 2100, 2400 },
				new int[]{ 300, 500, 750, 800, 1050, 1500, 2250, 2400, 3000, 3500, 4000, 4500 }
			},
			new int[][] // 2-part (exceptional)
			{
				new int[]{ 250, 400,  400,  750,  750, 1500, 1500, 3000, 3000, 3500, 3500, 4000 },
				new int[]{ 375, 600,  600, 1125, 1125, 2250, 2250, 4500, 4500, 5000, 5000, 5500 },
				new int[]{ 500, 800, 1200, 1500, 2500, 3000, 4000, 5000, 6000, 7000, 8000, 9000 }
			},
			new int[][] // 3-part (regular)
			{
				new int[]{ 1500,  3000,  4500,  6000,  7500, 10000, 12000, 14000, 16000, 18000, 20000, 24000 },
				new int[]{ 3000,  4500,  6000,  7500, 10000, 12000, 14000, 16000, 18000, 20000, 24000, 28000},
				new int[]{ 4000,  6000,  8000, 10000, 12000, 14000, 16000, 18000, 20000, 24000, 28000, 32000 }
			},
			new int[][] // 3-part (exceptional)
			{
				new int[]{ 3000,  5000,  5000,  7500,  7500,  8000,  8500,  9000, 10000, 11000, 12000, 13000 },
				new int[]{ 4500,  7500,  7500, 11250, 11500, 15000, 15000, 22500, 22500, 30000, 30000, 35000 },
				new int[]{ 6000, 10000, 15000, 15000, 20000, 20000, 30000, 30000, 50000, 60000, 60000, 70000 }
			},
			new int[][] // 4-part (regular)
			{
				new int[]{ 3000,  5000,  5000,  7500,  7500,  8000,  8500,  9000, 10000, 11000, 12000, 13000 },
				new int[]{ 4500,  7500,  7500, 11250, 11500, 15000, 15000, 22500, 22500, 30000, 30000, 35000 },
				new int[]{ 6000, 10000, 15000, 15000, 20000, 20000, 30000, 30000, 50000, 60000, 60000, 70000 }
			},
			new int[][] // 4-part (exceptional)
			{
				new int[]{  5000, 10000, 15000, 20000, 25000, 30000,  35000,  40000,  45000,  50000,  60000,  70000 },
				new int[]{  7500, 15000, 15000, 22500, 22500, 37500,  37500,  75000,  75000, 100000, 100000, 120000 },
				new int[]{ 10000, 20000, 30000, 30000, 50000, 50000, 100000, 100000, 200000, 250000, 250000, 300000 }
			}
		};
		
		public override int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int[][][] goldTable = m_GoldTable;
			
			int typeIndex = (( itemCount == 4 ? 3 : itemCount == 3 ? 2 : itemCount == 2 ? 1 : 0 ) * 2) + (exceptional ? 1 : 0);
			int quanIndex = ( quantity == 20 ? 2 : quantity == 15 ? 1 : 0 );
			int mtrlIndex = ( material >= BulkMaterialType.Pine && material <= BulkMaterialType.Oak ) ? 1 + (int)(material - BulkMaterialType.Pine) : 0;
			
			int gold = goldTable[typeIndex][quanIndex][mtrlIndex];
			
			int min = (gold * 9) / 10;
			int max = (gold * 10) / 9;
			
			return Utility.RandomMinMax( min, max );
		}
		
		public CarpenterRewardCalculator()
		{
			Groups = new RewardGroup[]
			{
				new RewardGroup(    0, new RewardItem( 1, SturdyLumberjackAxe ), 			new RewardItem( 1, SturdyAxe ) ),
				new RewardGroup(   25, new RewardItem( 1, SturdyLumberjackAxe ), 			new RewardItem( 1, SturdyAxe ) ),
				new RewardGroup(   50, new RewardItem( 90, SturdyLumberjackAxe ), 			new RewardItem( 10, ArmorOfCrafting, Utility.RandomMinMax(1,6) ) ),
				new RewardGroup(  200, new RewardItem( 90, SturdyAxe ), 					new RewardItem( 10, ArmorOfCrafting, Utility.RandomMinMax(1,6) ) ),
				new RewardGroup(  400, new RewardItem( 90, StainOfDurability ), 	new RewardItem( 10, ArmorOfCrafting, Utility.RandomMinMax(1,6) ) ),
				new RewardGroup(  450, new RewardItem( 2, StainOfDurability ), 				new RewardItem( 1, GargoylesAxe ), new RewardItem( 1, Deco, Utility.Random(6) ) ),
				new RewardGroup(  500, new RewardItem( 1, RunicSaw, 1 ), 					new RewardItem( 1, GargoylesAxe ), new RewardItem( 1, Deco, Utility.Random(6) ) ),
				new RewardGroup(  550, new RewardItem( 3, RunicSaw, 1 ), 					new RewardItem( 2, RunicSaw, 2 ) ),
				new RewardGroup(  600, new RewardItem( 1, RunicSaw, 2 ), 					new RewardItem( 1, Engraver ) ),
				new RewardGroup(  625, new RewardItem( 3, RunicSaw, 2 ), 					new RewardItem( 1, Engraver ) ),
				new RewardGroup(  650, new RewardItem( 1, RunicSaw, 3 ), 					new RewardItem( 1, Deco, Utility.Random(7) ), 						new RewardItem( 6, LumberjackingPowerScroll, 5 ) ),
				new RewardGroup(  675, new RewardItem( 1, Engraver ), 						new RewardItem( 3, RunicSaw, 3 ), 									new RewardItem( 6, CarpenterPowerScroll, 5 ) ),
				new RewardGroup(  700, new RewardItem( 1, RunicSaw, 4 ), 					new RewardItem( 1, Deco, Utility.Random(7) ), 						new RewardItem( 6, LumberjackingPowerScroll, 5 ) ),
				new RewardGroup(  750, new RewardItem( 1, AncientCarpenterHammer, 10 ), 	new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(7,12) ), 	new RewardItem( 6, CarpenterPowerScroll, 5 ) ),
				new RewardGroup(  800, new RewardItem( 1, RunicSaw, 4 ), 					new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(7,12) ), 	new RewardItem( 6, LumberjackingPowerScroll, 5 ) ),
				new RewardGroup(  850, new RewardItem( 5, AncientCarpenterHammer, 20 ), 	new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(7,12) ), 	new RewardItem( 6, CarpenterPowerScroll, 5 ) ),
				new RewardGroup(  900, new RewardItem( 1, RunicSaw, 5 ), 					new RewardItem( 6, CarpenterPowerScroll, 10 ) ),
				new RewardGroup(  950, new RewardItem( 1, RunicSaw, 5 ), 					new RewardItem( 6, CarpenterPowerScroll, 10 ) ),
				new RewardGroup( 1000, new RewardItem( 5, AncientCarpenterHammer, 30 ), 	new RewardItem( 6, CarpenterPowerScroll, 10 ) ),
				new RewardGroup( 1050, new RewardItem( 1, RunicSaw, 6 ), 					new RewardItem( 1, Engraver ), 										new RewardItem( 6, LumberjackingPowerScroll, 10 ) ),
				new RewardGroup( 1100, new RewardItem( 3, AncientCarpenterHammer, 30 ), 	new RewardItem( 1, Engraver ), 										new RewardItem( 6, CarpenterPowerScroll, 10 ) ),
				new RewardGroup( 1150, new RewardItem( 1, RunicSaw, 7 ), 					new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(13,18) ), 	new RewardItem( 6, LumberjackingPowerScroll, 15 ) ),
				new RewardGroup( 1200, new RewardItem( 1, RunicSaw, 8 ), 					new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(13,18) ), 	new RewardItem( 6, CarpenterPowerScroll, 15 ) ),
				new RewardGroup( 1250, new RewardItem( 1, RunicSaw, 9 ), 					new RewardItem( 1, ArmorOfCrafting, Utility.RandomMinMax(13,18) ), 	new RewardItem( 6, LumberjackingPowerScroll, 20 ) ),
				new RewardGroup( 1300, new RewardItem( 1, RunicSaw, 10 ), 					new RewardItem( 1, BagOfResources ), 								new RewardItem( 6, CarpenterPowerScroll, 20 ) ),
				new RewardGroup( 1350, new RewardItem( 1, RunicSaw, 11 ), 					new RewardItem( 1, BagOfResources ) ),
				new RewardGroup( 1400, new RewardItem( 3, RunicSaw, 12 ), 					new RewardItem( 1, StainOfDurability ) ),
				new RewardGroup( 1450, new RewardItem( 3, AncientCarpenterHammer, 40 ), 	new RewardItem( 1, StainOfDurability ) )
			};
		}
	}
	
	public sealed class FletcherRewardCalculator : RewardCalculator
	{
		#region Constructors
		private static readonly ConstructCallback SturdyLumberjackAxe = new ConstructCallback( CreateSturdyLumberjackAxe );
		private static readonly ConstructCallback SturdyAxe = new ConstructCallback( CreateSturdyAxe );
		private static readonly ConstructCallback StainOfDurability = new ConstructCallback( CreateStainOfDurability );
		private static readonly ConstructCallback RunicFletcherTools = new ConstructCallback( CreateFletchersTools );
		private static readonly ConstructCallback FletchingPowerScroll = new ConstructCallback( CreateFletchingPowerScroll );
		private static readonly ConstructCallback Deco = new ConstructCallback( CreateDeco );
		private static readonly ConstructCallback GargoylesAxe = new ConstructCallback( CreateGargoylesAxe );
		private static readonly ConstructCallback AncientFletcherHammer = new ConstructCallback( CreateAncientFletcherHammer );
		private static readonly ConstructCallback LeatherGlovesOfLumberjacking = new ConstructCallback( CreateLeatherGlovesOfLumberjacking );
		private static readonly ConstructCallback LumberjackingPowerScroll = new ConstructCallback( CreateLumberjackingPowerScroll );
		
		private static Item CreateSturdyLumberjackAxe( int type )
		{
			return new SturdyLumberjackAxe();
		}
		
		private static Item CreateSturdyAxe( int type )
		{
			return new SturdyAxe();
		}
		
		private static Item CreateStainOfDurability( int type )
		{
			return new StainOfDurability();
		}
		
		private static Item CreateFletchersTools( int type )
		{
			if ( type >= 1 && type <= 11 )
				return new RunicFletcherTools( CraftResource.Pine + type, Core.AOS ? ( 100 - (type*5) ) : 50 );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateFletchingPowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Fletching, 100 + type );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateLumberjackingPowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Lumberjacking, 100 + type );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateDeco( int type )
		{
			switch ( Utility.Random( 7 ) )
			{
				default:
					case 0: return new Deco( 4107, "Archery Butte North" );
					case 1: return new Deco( 4106, "Archery Butte West" );
					case 2: return new Deco( 3905, "Stack of Arrows" );
					case 3: return new Deco( 7135, "Stack of Logs West" );
					case 4: return new Deco( 7138, "Stack of Logs North" );
					case 5: return new Deco( 7129, "Stack of Boards West" );
					case 6: return new Deco( 7132, "Stack of Boards North" );
			}
		}
		
		private static Item CreateGargoylesAxe( int type )
		{
			return new GargoylesAxe();
		}
		
		private static Item CreateAncientFletcherHammer( int type )
		{
			if ( type == 10 || type == 20 || type == 30 || type == 40 )
				return new AncientFletcherHammer( type );
			
			throw new InvalidOperationException();
		}
		
		private static Item CreateLeatherGlovesOfLumberjacking( int type )
		{
			if ( type == 1 || type == 3 || type == 5 )
				return new LeatherGlovesOfLumberjacking( type );
			
			throw new InvalidOperationException();
		}
		#endregion
		
		public static readonly FletcherRewardCalculator Instance = new FletcherRewardCalculator();
		
		
		public override int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int points = 0;
			
			if ( quantity == 10 )
				points += 10;
			else if ( quantity == 15 )
				points += 25;
			else if ( quantity == 20 )
				points += 50;
			
			if ( exceptional )
				points += 200;
			
			if ( itemCount == 3 )
				points += 200;
			else if ( itemCount == 6 )
				points += 400;
			
			if ( material >= BulkMaterialType.Pine && material <= BulkMaterialType.Oak )
				points += 200 + (50 * (material - BulkMaterialType.Pine));
			
			return points;
		}
		
		private static int[][][] m_GoldTable = new int[][][]
		{
			new int[][] // 1-part (regular)
			{
				new int[]{ 150, 250, 250, 400,  400,  750,  750, 1200, 1200, 1500, 1500, 1800 },
				new int[]{ 225, 375, 375, 600,  600, 1125, 1125, 1800, 1800, 2100, 2100, 2400 },
				new int[]{ 300, 500, 750, 800, 1050, 1500, 2250, 2400, 3000, 3500, 4000, 4500 }
			},
			new int[][] // 1-part (exceptional)
			{
				new int[]{ 250, 400,  400,  750,  750, 1500, 1500, 3000, 3000, 3500, 3500, 4000 },
				new int[]{ 375, 600,  600, 1125, 1125, 2250, 2250, 4500, 4500, 5000, 5000, 5500 },
				new int[]{ 500, 800, 1200, 1500, 2500, 3000, 4000, 5000, 6000, 7000, 8000, 9000 }
			},
			new int[][] // 3-part (regular)
			{
				new int[]{ 2000, 4000,  6000,  8000, 10000, 12000, 14000, 16000, 18000, 20000, 22000, 25000 },
				new int[]{ 3000, 6000,  9000, 12000, 15000, 18000, 21000, 24000, 27000, 30000, 33000, 37500 },
				new int[]{ 4000, 8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000, 50000 }
			},
			new int[][] // 3-part (exceptional)
			{
				new int[]{ 4000,  8000, 12000, 16000, 20000, 24000, 28000, 32000, 36000, 40000, 44000, 50000 },
				new int[]{ 6000, 12000, 18000, 24000, 30000, 36000, 42000, 48000, 54000, 60000, 66000, 75000 },
				new int[]{ 8000, 16000, 24000, 32000, 40000, 48000, 56000, 64000, 72000, 80000, 88000, 100000 }
			},
			new int[][] // 6-part (regular)
			{
				new int[]{ 3000,  5000,  5000,  7500,  7500,  8000,  8500,  9000, 10000, 11000, 12000, 13000 },
				new int[]{ 4500,  7500,  7500, 11250, 11500, 15000, 15000, 22500, 22500, 30000, 30000, 35000 },
				new int[]{ 6000, 10000, 15000, 15000, 20000, 20000, 30000, 30000, 50000, 60000, 60000, 70000 }
			},
			new int[][] // 6-part (exceptional)
			{
				new int[]{  5000, 10000, 15000, 20000, 25000, 30000,  35000,  40000,  45000,  50000,  60000,  70000 },
				new int[]{  7500, 15000, 15000, 22500, 22500, 37500,  37500,  75000,  75000, 100000, 100000, 120000 },
				new int[]{ 10000, 20000, 30000, 30000, 50000, 50000, 100000, 100000, 200000, 250000, 250000, 300000 }
			}
		};
		
		public override int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int[][][] goldTable = m_GoldTable;
			
			int typeIndex = (( itemCount == 6 ? 2 : itemCount == 3 ? 1 : 0 ) * 2) + (exceptional ? 1 : 0);
			int quanIndex = ( quantity == 20 ? 2 : quantity == 15 ? 1 : 0 );
			int mtrlIndex = ( material >= BulkMaterialType.Pine && material <= BulkMaterialType.Oak ) ? 1 + (int)(material - BulkMaterialType.Pine) : 0;
			
			int gold = goldTable[typeIndex][quanIndex][mtrlIndex];
			
			int min = (gold * 9) / 10;
			int max = (gold * 10) / 9;
			
			return Utility.RandomMinMax( min, max );
		}
		
		public FletcherRewardCalculator()
		{
			Groups = new RewardGroup[]
			{
				new RewardGroup(    0, new RewardItem( 1, SturdyAxe ) ),
				new RewardGroup(   50, new RewardItem( 45, SturdyAxe ), 						new RewardItem( 45, SturdyLumberjackAxe ), 					new RewardItem( 10, LeatherGlovesOfLumberjacking, 1 ) ),
				new RewardGroup(  200, new RewardItem( 1, LeatherGlovesOfLumberjacking, 3 ), 	new RewardItem( 1, GargoylesAxe ) ),
				new RewardGroup(  400, new RewardItem( 1, StainOfDurability ),					new RewardItem( 4, Deco ) ),
				new RewardGroup(  450, new RewardItem( 3, StainOfDurability ), 					new RewardItem( 1, LeatherGlovesOfLumberjacking, 5 ) ),
				new RewardGroup(  500, new RewardItem( 1, RunicFletcherTools, 1 ),				new RewardItem( 3, Deco ) ),
				new RewardGroup(  550, new RewardItem( 3, RunicFletcherTools, 1 ),				new RewardItem( 2, RunicFletcherTools, 2 ) ),
				new RewardGroup(  600, new RewardItem( 2, RunicFletcherTools, 2 ),				new RewardItem( 1, Deco ) ),
				new RewardGroup(  650, new RewardItem( 3, RunicFletcherTools, 3 ),				new RewardItem( 1, RunicFletcherTools, 4 ) ),
				new RewardGroup(  700, new RewardItem( 3, RunicFletcherTools, 4 ), 				new RewardItem( 1, LumberjackingPowerScroll, 5 ), 			new RewardItem( 1, FletchingPowerScroll, 5 ) ),
				new RewardGroup(  750, new RewardItem( 3, RunicFletcherTools, 5 ),				new RewardItem( 1, RunicFletcherTools, 6 ) ),
				new RewardGroup(  800, new RewardItem( 1, FletchingPowerScroll, 10 ), 			new RewardItem( 2, RunicFletcherTools, 6 ) ),
				new RewardGroup(  850, new RewardItem( 2, AncientFletcherHammer, 10 ) ,			new RewardItem( 1, RunicFletcherTools, 7 ) ),
				new RewardGroup(  900, new RewardItem( 1, AncientFletcherHammer, 10 ) ,			new RewardItem( 2, RunicFletcherTools, 7 ) ),
				new RewardGroup(  950, new RewardItem( 2, AncientFletcherHammer, 15 ) ,			new RewardItem( 1, RunicFletcherTools, 8 ) ),
				new RewardGroup( 1000, new RewardItem( 1, AncientFletcherHammer, 15 ) ,			new RewardItem( 2, RunicFletcherTools, 8 ) ),
				new RewardGroup( 1050, new RewardItem( 2, AncientFletcherHammer, 15 ) ,			new RewardItem( 1, RunicFletcherTools, 9 ) ),
				new RewardGroup( 1100, new RewardItem( 60, AncientFletcherHammer, 20 ) ,		new RewardItem( 30, RunicFletcherTools, 9 ),		new RewardItem( 10, FletchingPowerScroll, 15 ) ),
				new RewardGroup( 1150, new RewardItem( 1, AncientFletcherHammer, 20 ),			new RewardItem( 2, RunicFletcherTools, 9 ) ),
				new RewardGroup( 1200, new RewardItem( 1, AncientFletcherHammer, 30 ) ,			new RewardItem( 2, RunicFletcherTools, 10 ) ),
				new RewardGroup( 1250, new RewardItem( 30, AncientFletcherHammer, 40 ) ,		new RewardItem( 60, RunicFletcherTools, 11 ),		new RewardItem( 10, FletchingPowerScroll, 20 ) ),
				new RewardGroup( 1300, new RewardItem( 60, RunicFletcherTools, 11 ) ),
				new RewardGroup( 1350, new RewardItem( 60, RunicFletcherTools, 11 ) )
			};
		}
	}
}

