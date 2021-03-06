/////////////////////////////////////////////////
//                                             //
// Automatically generated by the              //
// AddonGenerator script by Arya               //
//                                             //
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class AG_1x1_plotAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new AG_1x1_plotAddonDeed();
			}
		}

		[ Constructable ]
		public AG_1x1_plotAddon()
		{
			AddComponent( new AddonComponent( 13001 ), 0, 0, 0 );
			AddonComponent ac;
			ac = new AddonComponent( 13001 );
			AddComponent( ac, 0, 0, 0 );

		}

		public AG_1x1_plotAddon( Serial serial ) : base( serial )
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

	public class AG_1x1_plotAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new AG_1x1_plotAddon();
			}
		}

		[Constructable]
		public AG_1x1_plotAddonDeed()
		{
			Name = "AG_1x1_plot";
		}

		public AG_1x1_plotAddonDeed( Serial serial ) : base( serial )
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