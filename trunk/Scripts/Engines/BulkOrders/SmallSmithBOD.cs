using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Engines.Craft;
using Mat = Server.Engines.BulkOrders.BulkMaterialType;
using System.Collections.Generic;

namespace Server.Engines.BulkOrders
{
	[TypeAlias( "Scripts.Engines.BulkOrders.SmallSmithBOD" )]
	public class SmallSmithBOD : SmallBOD
	{
		public static double[] m_BlacksmithMaterialChances = new double[]
			{
				0.190, // None
				0.120, // Dull Copper
				0.110, // Shadow Iron
				0.100, // Copper
				0.090, // Bronze
				0.080, // Gold
				0.070, // Agapite
				0.060, // Verite
				0.050, // Valorite
				0.040, // Silver
				//0.030, // Platinum
				//0.020, // Mythril
				//0.010, // Obsidian
				0.030, // Jade
				0.020, // Moonstone
				0.010, // Sunstone
				//0.006  // Bloodstone
			};

		public override int ComputeFame()
		{
			return SmithRewardCalculator.Instance.ComputeFame( this );
		}

		public override int ComputeGold()
		{
			return SmithRewardCalculator.Instance.ComputeGold( this );
		}

		public override List<Item> ComputeRewards( bool full )
		{
			List<Item> list = new List<Item>();

			RewardGroup rewardGroup = SmithRewardCalculator.Instance.LookupRewards( SmithRewardCalculator.Instance.ComputePoints( this ) );

			if ( rewardGroup != null )
			{
				if ( full )
				{
					for ( int i = 0; i < rewardGroup.Items.Length; ++i )
					{
						Item item = rewardGroup.Items[i].Construct();

						if ( item != null )
							list.Add( item );
					}
				}
				else
				{
					RewardItem rewardItem = rewardGroup.AcquireItem();

					if ( rewardItem != null )
					{
						Item item = rewardItem.Construct();

						if ( item != null )
							list.Add( item );
					}
				}
			}

			return list;
		}

		public static SmallSmithBOD CreateRandomFor( Mobile m )
		{
			SmallBulkEntry[] entries;
			bool useMaterials = true;

			switch ( Utility.Random( 2 ) )
			{
				default:
				case  0: entries = SmallBulkEntry.BlacksmithArmor;  break;
				case  1: entries = SmallBulkEntry.BlacksmithWeapons; break;
			}
			/*bool useMaterials;

			if ( useMaterials = Utility.RandomBool() )
				entries = SmallBulkEntry.BlacksmithArmor;
			else
				entries = SmallBulkEntry.BlacksmithWeapons;*/

			if ( entries.Length > 0 )
			{
				double theirSkill = m.Skills[SkillName.Blacksmith].Base;
				int amountMax;

				if ( theirSkill >= 70.1 )
					amountMax = Utility.RandomList( 10, 15, 20, 20 );
				else if ( theirSkill >= 50.1 )
					amountMax = Utility.RandomList( 10, 15, 15, 20 );
				else
					amountMax = Utility.RandomList( 10, 10, 15, 20 );

				BulkMaterialType material = BulkMaterialType.None;

				if ( useMaterials && theirSkill >= 70.1 )
				{
					for ( int i = 0; i < 20; ++i )
					{
						BulkMaterialType check = GetRandomMaterial( BulkMaterialType.DullCopper, m_BlacksmithMaterialChances );
						double skillReq = 0.0;

						switch ( check )
						{
							case BulkMaterialType.DullCopper: skillReq = 40.0; break;
							case BulkMaterialType.ShadowIron: skillReq = 45.0; break;
							case BulkMaterialType.Copper: skillReq = 50.0; break;
							case BulkMaterialType.Bronze: skillReq = 55.0; break;
							case BulkMaterialType.Gold: skillReq = 60.0; break;
							case BulkMaterialType.Agapite: skillReq = 65.0; break;
							case BulkMaterialType.Verite: skillReq = 70.0; break;
							case BulkMaterialType.Valorite: skillReq = 75.0; break;
							case BulkMaterialType.Silver: skillReq = 80.0; break;
							//case BulkMaterialType.Platinum: skillReq = 85.0; break;
							//case BulkMaterialType.Mythril: skillReq = 90.0; break;
							//case BulkMaterialType.Obsidian: skillReq = 95.0; break;
							case BulkMaterialType.Jade: skillReq = 100.0; break;
							case BulkMaterialType.Moonstone: skillReq = 105.0; break;
							case BulkMaterialType.Sunstone: skillReq = 110.0; break;
							//case BulkMaterialType.Bloodstone: skillReq = 115.0; break;
							//case BulkMaterialType.Spined: skillReq = 65.0; break;
							//case BulkMaterialType.Horned: skillReq = 80.0; break;
							//case BulkMaterialType.Barbed: skillReq = 100.0; break;
							//case BulkMaterialType.DragonL: skillReq = 105.0; break;
							//case BulkMaterialType.Daemon: skillReq = 115.0; break;
						}

						if ( theirSkill >= skillReq )
						{
							material = check;
							break;
						}
					}
				}

				double excChance = 0.0;

				if ( theirSkill >= 70.1 )
					excChance = (theirSkill + 80.0) / 200.0;

				bool reqExceptional = ( excChance > Utility.RandomDouble() );

				CraftSystem system = DefBlacksmithy.CraftSystem;

				ArrayList validEntries = new ArrayList();

				for ( int i = 0; i < entries.Length; ++i )
				{
					CraftItem item = system.CraftItems.SearchFor( entries[i].Type );

					if ( item != null )
					{
						bool allRequiredSkills = true;
						double chance = item.GetSuccessChance( m, null, system, false, ref allRequiredSkills );

						if ( allRequiredSkills && chance >= 0.0 )
						{
							if ( reqExceptional )
								chance = item.GetExceptionalChance( system, chance, m );

							if ( chance > 0.0 )
								validEntries.Add( entries[i] );
						}
					}
				}

				if ( validEntries.Count > 0 )
				{
					SmallBulkEntry entry = (SmallBulkEntry)validEntries[Utility.Random( validEntries.Count )];
					return new SmallSmithBOD( entry, material, amountMax, reqExceptional );
			}
			}

			return null;
		}

		private SmallSmithBOD( SmallBulkEntry entry, BulkMaterialType material, int amountMax, bool reqExceptional )
		{
			this.Hue = 0x44E;
			this.AmountMax = amountMax;
			this.Type = entry.Type;
			this.Number = entry.Number;
			this.Graphic = entry.Graphic;
			this.RequireExceptional = reqExceptional;
			this.Material = material;
		}

		[Constructable]
		public SmallSmithBOD()
		{
			SmallBulkEntry[] entries;
			bool useMaterials = true;

			switch ( Utility.Random( 2 ) )
			{
				default:
				case  0: entries = SmallBulkEntry.BlacksmithArmor;  break;
				case  1: entries = SmallBulkEntry.BlacksmithWeapons; break;
			}
			/*bool useMaterials;

			if ( useMaterials = Utility.RandomBool() )
				entries = SmallBulkEntry.BlacksmithArmor;
			else
				entries = SmallBulkEntry.BlacksmithWeapons;*/

			if ( entries.Length > 0 )
			{
				int hue = 0x44E;
				int amountMax = Utility.RandomList( 10, 15, 20 );

				BulkMaterialType material;

				if ( useMaterials )
					material = GetRandomMaterial( BulkMaterialType.DullCopper, m_BlacksmithMaterialChances );
				else
					material = BulkMaterialType.None;

				bool reqExceptional = Utility.RandomBool() || (material == BulkMaterialType.None);

				SmallBulkEntry entry = entries[Utility.Random( entries.Length )];

				this.Hue = hue;
				this.AmountMax = amountMax;
				this.Type = entry.Type;
				this.Number = entry.Number;
				this.Graphic = entry.Graphic;
				this.RequireExceptional = reqExceptional;
				this.Material = material;
			}
		}

		public SmallSmithBOD( int amountCur, int amountMax, Type type, int number, int graphic, bool reqExceptional, BulkMaterialType mat )
		{
			this.Hue = 0x44E;
			this.AmountMax = amountMax;
			this.AmountCur = amountCur;
			this.Type = type;
			this.Number = number;
			this.Graphic = graphic;
			this.RequireExceptional = reqExceptional;
			this.Material = mat;
		}

		public SmallSmithBOD( Serial serial ) : base( serial )
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
}