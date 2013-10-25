//////////////////////////////////////////
//    *+ MW Admin Naturescorpse +*    ////  
// Script Name : InstrumentTrader.cs  ////
//For BaronVallyr,Additional Instruments///
//////////////////////////////////////////

using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;

namespace Server.Mobiles
{
	public class InstrumentTrader : BaseVendor
	{

        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		[Constructable]
		public InstrumentTrader() : base( "The Instrument Trader" )
		{
			SetSkill( SkillName.Poisoning, 42.0 );
			SetSkill( SkillName.Swords, 42.0 );
			
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBInstrumentTrader() );
		}

		public InstrumentTrader( Serial serial ) : base( serial )
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