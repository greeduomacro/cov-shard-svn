using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SerpentEggs : BaseReagent, ICommodity
	{

		string ICommodity.Description
		{
			get
			{
				return String.Format( "{0} Serpent Eggs", Amount );
			}
		}

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

		[Constructable]
		public SerpentEggs() : this( 1 )
		{
            Name = "Serpent Eggs";
            Hue = 1165;
		}

		[Constructable]
		public SerpentEggs( int amount ) : base( 0x9B5, amount )
		{
            Name = "Serpent Eggs";
            Hue = 1165;
		}

		public SerpentEggs( Serial serial ) : base( serial )
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