// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class ACreedRamondo : MondainQuester
	{	
		public override Type[] Quests
		{
			get
			{
				return new Type[]
				{
					typeof( ACreedRamondoQuest )
				};
			}
		}

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBBanker() );
		}

		[Constructable]
		public ACreedRamondo() : base( "Ramondo", "" )
		{
		}

		public override void Advertise()
		{
		}

		public override void InitBody()
		{
			InitStats( 50, 80, 120 );
			Female = false;
			CantWalk = true;
			Race = Race.Human;
			Hue = 1003;
			HairItemID = 50702;
			HairHue = 2223;
			FacialHairItemID = 50804;
			FacialHairHue = 2223;
		}

		public override void InitOutfit()
		{
		}

		public ACreedRamondo( Serial serial ) : base( serial )
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