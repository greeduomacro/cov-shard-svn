using System; 
using System.Collections.Generic; 
using Server; 

namespace Server.Mobiles 
{ 
	public class GargishCobbler : BaseVendor 
	{
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		[Constructable]
		public GargishCobbler() : base( "the cobbler" ) 
		{ 
			SetSkill( SkillName.Tailoring, 60.0, 83.0 );
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBGargishCobbler() ); 
		} 

		public GargishCobbler( Serial serial ) : base( serial ) 
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