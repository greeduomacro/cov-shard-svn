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
	public class AG_3x3daisyvaseAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new AG_3x3daisyvaseAddonDeed();
			}
		}

		[ Constructable ]
		public AG_3x3daisyvaseAddon()
		{
			AddonComponent ac;
			ac = new AddonComponent( 3151 );
			AddComponent( ac, 1, 1, 18 );
			ac = new AddonComponent( 3171 );
			AddComponent( ac, 1, 1, 14 );
			ac = new AddonComponent( 3198 );
			AddComponent( ac, 1, 1, 24 );
			ac = new AddonComponent( 15639 );
			AddComponent( ac, 1, 1, 18 );
			ac = new AddonComponent( 2887 );
			ac.Hue = 1150;
			AddComponent( ac, 1, 1, 11 );
			ac = new AddonComponent( 3170 );
			AddComponent( ac, 1, 1, 18 );
			ac = new AddonComponent( 6378 );
			ac.Name = "Whispering Rose";
			AddComponent( ac, 1, 1, 24 );
			ac = new AddonComponent( 3234 );
			AddComponent( ac, 0, 1, 12 );
			ac = new AddonComponent( 6809 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 16144 );
			AddComponent( ac, 1, 1, 8 );

		}

		public AG_3x3daisyvaseAddon( Serial serial ) : base( serial )
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

	public class AG_3x3daisyvaseAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new AG_3x3daisyvaseAddon();
			}
		}

		[Constructable]
		public AG_3x3daisyvaseAddonDeed()
		{
			Name = "AG_3x3daisyvase";
		}

		public AG_3x3daisyvaseAddonDeed( Serial serial ) : base( serial )
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