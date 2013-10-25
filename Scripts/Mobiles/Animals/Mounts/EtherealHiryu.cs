using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class EtherealHiryu : EtherealMount
    {
        public override int LabelNumber { get { return 1113813; } } // Ethereal Hiryu Statuette

        [Constructable]
        public EtherealHiryu()
            : base(0x276A, 0x3E94)
        {
            //Name = "an ethereal hiryu";
        }

        public EtherealHiryu(Serial serial)
            : base(serial)
        {
        }
        
        public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			
			if ( IsRewardItem )
				list.Add( 1080457 ); // 10th Year Veteran Reward
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}
            
        public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}	
}