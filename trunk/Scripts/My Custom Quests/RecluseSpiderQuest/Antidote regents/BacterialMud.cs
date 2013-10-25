using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BacterialMud : BaseReagent, ICommodity
	{

		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} Bacterial Mud", Amount );
			}
		}

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

		[Constructable]
		public BacterialMud() : this( 1 )
		{
            Name = "Bacterial Mud";
            Hue = 1890;
                
		}

		[Constructable]
		public BacterialMud( int amount ) : base( 0x913, amount )
		{
            Name = "Bacterial Mud";
            Hue = 1890;
		}

		public BacterialMud( Serial serial ) : base( serial )
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