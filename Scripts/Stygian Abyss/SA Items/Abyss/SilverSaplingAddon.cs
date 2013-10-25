
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class SilverSaplingAddon : BaseAddon
	{      
		public override BaseAddonDeed Deed {get{return new SilverSaplingAddonDeed();}}

        #region Mondain's Legacy
		public override bool RetainDeedHue{ get{ return true; }	}
		#endregion

		[ Constructable ]
		public SilverSaplingAddon()
		{
            AddComponent(new AddonComponent(0x0DB7), 0, 0, 0);
            AddComponent(new AddonComponent(0x0CE3), 0, 0, 0);
            Hue = 1153;
            Name = "The Silver Sapling";
		}
		public SilverSaplingAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class SilverSaplingAddonDeed : BaseAddonDeed
    {
		public override BaseAddon Addon{ get{ return new SilverSaplingAddon();}}
        public override int LabelNumber { get{ return 1113052; } } // The Silver Sapling

		[Constructable]
		public SilverSaplingAddonDeed()
		{
		}

		public SilverSaplingAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}