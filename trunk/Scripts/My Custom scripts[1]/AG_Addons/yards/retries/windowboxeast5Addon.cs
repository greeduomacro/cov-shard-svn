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
	public class AG_windowboxeast5Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new AG_windowboxeast5AddonDeed();
			}
		}

		[ Constructable ]
		public AG_windowboxeast5Addon()
		{
			AddonComponent ac;
			ac = new AddonComponent( 3204 );
			AddComponent( ac, 0, 0, 9 );
			ac = new AddonComponent( 2825 );
			ac.Name = "windowbox";
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 3208 );
			AddComponent( ac, 0, 0, 4 );

		}

		public AG_windowboxeast5Addon( Serial serial ) : base( serial )
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

	public class AG_windowboxeast5AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new AG_windowboxeast5Addon();
			}
		}

		[Constructable]
		public AG_windowboxeast5AddonDeed()
		{
			Name = "AG_windowboxeast5";
		}

		public AG_windowboxeast5AddonDeed( Serial serial ) : base( serial )
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