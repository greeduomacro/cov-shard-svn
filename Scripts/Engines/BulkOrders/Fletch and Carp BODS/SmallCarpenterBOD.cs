using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Engines.Craft;
using System.Collections.Generic;


namespace Server.Engines.BulkOrders
{
	[TypeAlias( "Scripts.Engines.BulkOrders.SmallCarpenterBOD" )]
	public class SmallCarpenterBOD : SmallBOD
	{
		public static double[] m_CarpenterMaterialChances = new double[]
			{
				0.500, // None
				0.250, // Pine
				0.15, // Ash
				0.110, // Mahogany
				0.100, // Yew
				0.090, // Oak
			
			};

		public override int ComputeFame()
		{
			return CarpenterRewardCalculator.Instance.ComputeFame( this );
		}

		public override int ComputeGold()
		{
			return CarpenterRewardCalculator.Instance.ComputeGold( this );
		}

		public override List<Item> ComputeRewards( bool full )
		{
			List<Item> list = new List<Item>();

			RewardGroup rewardGroup = CarpenterRewardCalculator.Instance.LookupRewards( CarpenterRewardCalculator.Instance.ComputePoints( this ) );

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

		public static SmallCarpenterBOD CreateRandomFor( Mobile m )
		{
			SmallBulkEntry[] entries;
			bool useMaterials;

			if ( useMaterials = Utility.RandomBool() )
				entries = SmallBulkEntry.CarpenterStaff;
			else
				entries = SmallBulkEntry.CarpenterInstrument;

			if ( entries.Length > 0 )
			{
				double theirSkill = m.Skills[SkillName.Carpentry].Base;
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
						BulkMaterialType check = GetRandomMaterial( BulkMaterialType.Pine, m_CarpenterMaterialChances );
						double skillReq = 0.0;

						switch ( check )
						{
							//case BulkMaterialType.DullCopper: skillReq = 40.0; break;
							//case BulkMaterialType.ShadowIron: skillReq = 45.0; break;
							//case BulkMaterialType.Copper: skillReq = 50.0; break;
							//case BulkMaterialType.Bronze: skillReq = 55.0; break;
							//case BulkMaterialType.Gold: skillReq = 60.0; break;
							//case BulkMaterialType.Agapite: skillReq = 65.0; break;
							//case BulkMaterialType.Verite: skillReq = 70.0; break;
							//case BulkMaterialType.Valorite: skillReq = 75.0; break;
							//case BulkMaterialType.Silver: skillReq = 80.0; break;
							//case BulkMaterialType.Platinum: skillReq = 85.0; break;
							//case BulkMaterialType.Mythril: skillReq = 90.0; break;
							//case BulkMaterialType.Obsidian: skillReq = 95.0; break;
							//case BulkMaterialType.Jade: skillReq = 100.0; break;
							//case BulkMaterialType.Moonstone: skillReq = 105.0; break;
							//case BulkMaterialType.Sunstone: skillReq = 110.0; break;
							//case BulkMaterialType.Bloodstone: skillReq = 115.0; break;
							//case BulkMaterialType.Spined: skillReq = 65.0; break;
							//case BulkMaterialType.Horned: skillReq = 80.0; break;
							//case BulkMaterialType.Barbed: skillReq = 100.0; break;
							//case BulkMaterialType.DragonL: skillReq = 105.0; break;
							//case BulkMaterialType.Daemon: skillReq = 115.0; break;
							case BulkMaterialType.Pine:			skillReq = 60.0; break;
							case BulkMaterialType.Ash:			skillReq = 64.0; break;
							case BulkMaterialType.Mahogany:		skillReq = 68.0; break;
							case BulkMaterialType.Yew:			skillReq = 72.0; break;
							case BulkMaterialType.Oak:			skillReq = 76.0; break;
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

				SmallBulkEntry entry = null;

				CraftSystem system = DefCarpentry.CraftSystem;

				for ( int i = 0; i < 150; ++i )
				{
					SmallBulkEntry check = entries[Utility.Random( entries.Length )];

					CraftItem item = system.CraftItems.SearchFor( check.Type );

					if ( item != null )
					{
						bool allRequiredSkills = true;
						double chance = item.GetSuccessChance( m, null, system, false, ref allRequiredSkills );

						if ( allRequiredSkills && chance >= 0.0 )
						{
							if ( reqExceptional )
								chance = item.GetExceptionalChance( system, chance, m );

							if ( chance > 0.0 )
							{
								entry = check;
								break;
							}
						}
					}
				}

				if ( entry != null )
					return new SmallCarpenterBOD( entry, material, amountMax, reqExceptional );
			}

			return null;
		}

		private SmallCarpenterBOD( SmallBulkEntry entry, BulkMaterialType material, int amountMax, bool reqExceptional )
		{
			this.Hue = 0x30;
			this.AmountMax = amountMax;
			this.Type = entry.Type;
			this.Number = entry.Number;
			this.Graphic = entry.Graphic;
			this.RequireExceptional = reqExceptional;
			this.Material = material;
		}

		[Constructable]
		public SmallCarpenterBOD()
		{
			SmallBulkEntry[] entries;
			bool useMaterials;

			if ( useMaterials = Utility.RandomBool() )
				entries = SmallBulkEntry.CarpenterStaff;
			else
				entries = SmallBulkEntry.CarpenterInstrument;

			if ( entries.Length > 0 )
			{
				int hue = 0x30;
				int amountMax = Utility.RandomList( 10, 15, 20 );

				BulkMaterialType material;

				if ( useMaterials )
					material = GetRandomMaterial( BulkMaterialType.Pine, m_CarpenterMaterialChances );
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

		public SmallCarpenterBOD( int amountCur, int amountMax, Type type, int number, int graphic, bool reqExceptional, BulkMaterialType mat )
		{
			this.Hue = 0x30;
			this.AmountMax = amountMax;
			this.AmountCur = amountCur;
			this.Type = type;
			this.Number = number;
			this.Graphic = graphic;
			this.RequireExceptional = reqExceptional;
			this.Material = mat;
		}

		public SmallCarpenterBOD( Serial serial ) : base( serial )
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
