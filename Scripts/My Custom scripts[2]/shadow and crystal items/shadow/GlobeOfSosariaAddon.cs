using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class GlobeOfSosariaAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get	{	return new GlobeOfSosariaAddonDeed(); }
		}

		[ Constructable ]
		public GlobeOfSosariaAddon()
		{
			AddComponent( new AddonComponent( 13911 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 13920 ), 0, 0, 0 );
			AddonComponent ac;
			ac = new AddonComponent( 13911 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 13920 );
			AddComponent( ac, 0, 0, 0 );
		}

		public GlobeOfSosariaAddon( Serial serial ) : base( serial )
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

	public class GlobeOfSosariaAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get	{	return new GlobeOfSosariaAddon();	}
		}

		[Constructable]
		public GlobeOfSosariaAddonDeed()
		{
			Name = "Globe Of Sosaria";
			Hue = 1109;
			LootType = LootType.Blessed;
		}

		public GlobeOfSosariaAddonDeed( Serial serial ) : base( serial )
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
