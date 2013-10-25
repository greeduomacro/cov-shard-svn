using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CrystalAltarAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get	{	return new CrystalAltarAddonDeed(); }
		}

		[ Constructable ]
		public CrystalAltarAddon()
		{
			AddComponent( new AddonComponent( 13801 ), 0, 0, 0 );
			AddonComponent ac;
			ac = new AddonComponent( 13801 );
			AddComponent( ac, 0, 0, 0 );

		}

		public CrystalAltarAddon( Serial serial ) : base( serial )
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

	public class CrystalAltarAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get	{	return new CrystalAltarAddon();	}
		}

		[Constructable]
		public CrystalAltarAddonDeed()
		{
			Name = "Crystal Altar";
			Hue = 88;
			LootType = LootType.Blessed;
		}

		public CrystalAltarAddonDeed( Serial serial ) : base( serial )
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
