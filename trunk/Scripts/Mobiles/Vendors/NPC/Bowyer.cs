using System;
using System.Collections.Generic;
using Server;
using Server.Engines.BulkOrders;
using Server.ACC.CM;

namespace Server.Mobiles
{
	[TypeAlias( "Server.Mobiles.Bower" )]
	public class Bowyer : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Bowyer() : base( "the bowyer" )
		{
			SetSkill( SkillName.Fletching, 80.0, 100.0 );
			SetSkill( SkillName.Archery, 80.0, 100.0 );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Female ? VendorShoeType.ThighBoots : VendorShoeType.Boots; }
		}

		public override int GetShoeHue()
		{
			return 0;
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Bow() );
			AddItem( new Server.Items.LeatherGorget() );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBBowyer() );
			m_SBInfos.Add( new SBRangedWeapon() );
			
			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSEBowyer() );	
		}

        #region Bulk Orders
        public override Item CreateBulkOrder(Mobile from, bool fromContextMenu)
        {
            PlayerMobile pm = from as PlayerMobile;
            BODModule bod_mod = (BODModule)CentralMemory.GetModule(from.Serial, typeof(BODModule));

            if (bod_mod == null && from == null)
                return null;

            if (bod_mod != null && bod_mod.NextFletcherBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()))
            {
                double theirSkill = pm.Skills[SkillName.Fletching].Base;

                if (theirSkill >= 70.1)
                    bod_mod.NextFletcherBulkOrder = TimeSpan.FromHours(3.0);
                else if (theirSkill >= 50.1)
                    bod_mod.NextFletcherBulkOrder = TimeSpan.FromHours(2.0);
                else
                    bod_mod.NextFletcherBulkOrder = TimeSpan.FromHours(1.0);

                if (theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble())
                    return new LargeFletcherBOD();

                return SmallFletcherBOD.CreateRandomFor(from);
            }
            else
            {
                CentralMemory.AppendModule(from.Serial, new BODModule(from.Serial), true);
                from.SendMessage("Please try again");
            }

            return null;
        }

        public override bool IsValidBulkOrder(Item item)
        {
            return (item is SmallFletcherBOD || item is LargeFletcherBOD);
        }

        public override bool SupportsBulkOrders(Mobile from)
        {
            return (from is PlayerMobile && from.Skills[SkillName.Fletching].Base > 0);
        }

        public override TimeSpan GetNextBulkOrder(Mobile from)
        {
            BODModule bod_mod = (BODModule)CentralMemory.GetModule(from.Serial, typeof(BODModule));

            if (bod_mod != null && from != null)
                return bod_mod.NextFletcherBulkOrder;

            //if ( from is PlayerMobile )
            //	return ((PlayerMobile)from).NextFletcherBulkOrder;

            return TimeSpan.Zero;
        }
        #endregion

		public Bowyer( Serial serial ) : base( serial )
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