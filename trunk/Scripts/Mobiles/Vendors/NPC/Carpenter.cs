using System;
using System.Collections.Generic;
using Server;
using Server.Engines.BulkOrders;
using Server.ACC.CM;

namespace Server.Mobiles
{
	public class Carpenter : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.TinkersGuild; } }

		[Constructable]
		public Carpenter() : base( "the carpenter" )
		{
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBStavesWeapon() );
			m_SBInfos.Add( new SBCarpenter() );
			m_SBInfos.Add( new SBWoodenShields() );
			
			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSECarpenter() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.HalfApron() );
		}


        #region Bulk Orders
        public override Item CreateBulkOrder(Mobile from, bool fromContextMenu)
        {
            PlayerMobile pm = from as PlayerMobile;
            BODModule bod_mod = (BODModule)CentralMemory.GetModule(from.Serial, typeof(BODModule));

            if (bod_mod == null && from == null)
                return null;

            if (bod_mod != null && bod_mod.NextCarpenterBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()))
            {
                double theirSkill = pm.Skills[SkillName.Carpentry].Base;

                if (theirSkill >= 70.1)
                    bod_mod.NextCarpenterBulkOrder = TimeSpan.FromHours(3.0);
                else if (theirSkill >= 50.1)
                    bod_mod.NextCarpenterBulkOrder = TimeSpan.FromHours(2.0);
                else
                    bod_mod.NextCarpenterBulkOrder = TimeSpan.FromHours(1.0);

                if (theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble())
                    return new LargeCarpenterBOD();

                return SmallCarpenterBOD.CreateRandomFor(from);
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
            return (item is SmallCarpenterBOD || item is LargeCarpenterBOD);
        }

        public override bool SupportsBulkOrders(Mobile from)
        {
            return (from is PlayerMobile && from.Skills[SkillName.Carpentry].Base > 0);
        }

        public override TimeSpan GetNextBulkOrder(Mobile from)
        {
            BODModule bod_mod = (BODModule)CentralMemory.GetModule(from.Serial, typeof(BODModule));

            if (bod_mod != null && from != null)
                return bod_mod.NextCarpenterBulkOrder;

            //if ( from is PlayerMobile )
            //	return ((PlayerMobile)from).NextCarpenterBulkOrder;

            return TimeSpan.Zero;
        }
        #endregion

		public Carpenter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}