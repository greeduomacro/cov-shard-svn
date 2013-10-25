using System;
using System.Collections;
using Server;
using Server.Items;
using Mat = Server.Engines.BulkOrders.BulkMaterialType;
using System.Collections.Generic;


namespace Server.Engines.BulkOrders
{
	[TypeAlias( "Scripts.Engines.BulkOrders.LargeFletcherBOD" )]
	public class LargeFletcherBOD : LargeBOD
	{
		public static double[] m_FletcherMaterialChances = new double[]
			{
				0.140, // None
				0.130, // Pine
				0.120, // Ash
				0.110, // Mohogany
				0.100, // Yew
				0.090, // Oak
				
			};

		public override int ComputeFame()
		{
			return FletcherRewardCalculator.Instance.ComputeFame( this );
		}

		public override int ComputeGold()
		{
			return FletcherRewardCalculator.Instance.ComputeGold( this );
		}

		[Constructable]
		public LargeFletcherBOD()
		{
			LargeBulkEntry[] entries;
			bool useMaterials = true;

			switch ( Utility.Random( 3 ) )
			{
				default:
				case  0: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.AllBow );  break;
				case  1: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.Bow ); break;
				case  2: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.CrossBow ); break;
				
			}

			int hue = 0x58;
			string name = "Large Fletcher Bulk Order";
			int amountMax = Utility.RandomList( 10, 15, 20, 20 );
			bool reqExceptional = ( 0.825 > Utility.RandomDouble() );

			BulkMaterialType material;

			if ( useMaterials )
				material = GetRandomMaterial( BulkMaterialType.Pine, m_FletcherMaterialChances );
			else
				material = BulkMaterialType.None;

			this.Hue = hue;
			this.Name += name;
			this.AmountMax = amountMax;
			this.Entries = entries;
			this.RequireExceptional = reqExceptional;
			this.Material = material;
		}

		public LargeFletcherBOD( int amountMax, bool reqExceptional, BulkMaterialType mat, LargeBulkEntry[] entries )
		{
			this.Hue = 0x58;
			this.AmountMax = amountMax;
			this.Entries = entries;
			this.RequireExceptional = reqExceptional;
			this.Material = mat;
		}

		public override List<Item> ComputeRewards( bool full )
		{
			List<Item> list = new List<Item>();

			RewardGroup rewardGroup = FletcherRewardCalculator.Instance.LookupRewards( FletcherRewardCalculator.Instance.ComputePoints( this ) );

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

		public LargeFletcherBOD( Serial serial ) : base( serial )
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
