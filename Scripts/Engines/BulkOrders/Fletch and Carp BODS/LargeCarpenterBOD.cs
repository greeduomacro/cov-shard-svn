using System;
using System.Collections;
using Server;
using Server.Items;
using Mat = Server.Engines.BulkOrders.BulkMaterialType;
using System.Collections.Generic;


namespace Server.Engines.BulkOrders
{
	[TypeAlias( "Scripts.Engines.BulkOrders.LargeCarpenterBOD" )]
	public class LargeCarpenterBOD : LargeBOD
	{
		public static double[] m_CarpenterMaterialChances = new double[]
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
			return CarpenterRewardCalculator.Instance.ComputeFame( this );
		}

		public override int ComputeGold()
		{
			return CarpenterRewardCalculator.Instance.ComputeGold( this );
		}

		[Constructable]
		public LargeCarpenterBOD()
		{
			LargeBulkEntry[] entries;
			bool useMaterials = true;

			switch ( Utility.Random( 4 ) )
			{
				default:
				case  0: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.AllInstrument );  break;
				case  1: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.Percussion ); break;
				case  2: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.Staff );  break;
				case  3: entries = LargeBulkEntry.ConvertEntries( this, LargeBulkEntry.String ); break;
				
			}

			int hue = 0x30;
			string name = "Large Carpenter Bulk Order";
			int amountMax = Utility.RandomList( 10, 15, 20, 20 );
			bool reqExceptional = ( 0.825 > Utility.RandomDouble() );

			BulkMaterialType material;

			if ( useMaterials )
				material = GetRandomMaterial( BulkMaterialType.Pine, m_CarpenterMaterialChances );
			else
				material = BulkMaterialType.None;

			this.Hue = hue;
			this.Name += name;
			this.AmountMax = amountMax;
			this.Entries = entries;
			this.RequireExceptional = reqExceptional;
			this.Material = material;
		}

		public LargeCarpenterBOD( int amountMax, bool reqExceptional, BulkMaterialType mat, LargeBulkEntry[] entries )
		{
			this.Hue = 0x30;
			this.AmountMax = amountMax;
			this.Entries = entries;
			this.RequireExceptional = reqExceptional;
			this.Material = mat;
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

		public LargeCarpenterBOD( Serial serial ) : base( serial )
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
