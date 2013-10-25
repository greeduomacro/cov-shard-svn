using System;
using System.Collections.Generic;
using Server;
using Server.Items;
//using Server.Engines.BulkOrders;

namespace Server.Mobiles
{
	public class SamuraiDealer : BaseVendor
	{
        public override bool CanTeach{ get{ return true; } }
		public override bool ClickTitle{ get{ return false; } }
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		[Constructable]
		public SamuraiDealer() : base( "the Samurai Dealer" )
		{
			SetSkill( SkillName.ArmsLore, 64.0, 80.0 );
			SetSkill( SkillName.Bushido, 64.0, 85.0 );
			SetSkill( SkillName.Parry, 64.0, 80.0 );
			SetSkill( SkillName.Swords, 64.0, 85.0 );
		}

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBSamuraiDealer());

            if (IsTokunoVendor)
            {
                m_SBInfos.Add(new SBSEWeapons());
            }

            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
            }

            switch (Utility.Random(3))
            {
                case 0: AddItem(new Lajatang()); break;
                case 1: AddItem(new Wakizashi()); break;
                case 2: AddItem(new NoDachi()); break;
            }

            switch (Utility.Random(3))
            {
                case 0: AddItem(new LeatherSuneate()); break;
                case 1: AddItem(new PlateSuneate()); break;
                case 2: AddItem(new StuddedHaidate()); break;
            }

            switch (Utility.Random(4))
            {
                case 0: AddItem(new LeatherJingasa()); break;
                case 1: AddItem(new ChainHatsuburi()); break;
                case 2: AddItem(new HeavyPlateJingasa()); break;
                case 3: AddItem(new DecorativePlateKabuto()); break;
            }

            AddItem(new LeatherDo());
            AddItem(new LeatherHiroSode());
            AddItem(new SamuraiTabi(Utility.RandomNondyedHue())); // TODO: Hue

            int hairHue = Utility.RandomNondyedHue();

            Utility.AssignRandomHair(this, hairHue);

            if (Utility.Random(7) != 0)
                Utility.AssignRandomFacialHair(this, hairHue);
        }

		/*#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextSmithBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Blacksmith].Base;

				if ( theirSkill >= 70.1 )
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 6.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 1.0 );

				if ( theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble() )
					return new LargeSmithBOD();

				return SmallSmithBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallSmithBOD || item is LargeSmithBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && Core.AOS && from.Skills[SkillName.Blacksmith].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextSmithBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderRecieve( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextSmithBulkOrder = TimeSpan.Zero;
		}
		#endregion*/

		public SamuraiDealer( Serial serial ) : base( serial )
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