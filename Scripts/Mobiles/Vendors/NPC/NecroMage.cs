using System;
using System.Collections.Generic;
using Server.Items;
using Server;

namespace Server.Mobiles
{
	public class NecroMage : BaseVendor
	{
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MagesGuild; } }

		[Constructable]
		public NecroMage() : base( "the Necromancer" )
		{
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Inscribe, 60.0, 83.0 );
			SetSkill( SkillName.Necromancy, 64.0, 100.0 );
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.SpiritSpeak, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBNecroMage() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new HoodedShroudOfShadows());
		}

		public NecroMage( Serial serial ) : base( serial )
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