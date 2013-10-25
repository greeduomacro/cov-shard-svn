//Based on the regular loom. Loom graphics changed to alternate view, and a gold belt is added.
//Cloth on loom re-hued to a golden color. Is _not_ classed as a loom (will not make cloth).
//Modification is needed to the defCarpentry.cs to make this loom player craftable.
//Instructions for mods are listed on the text instruction page.
//Script mutilation provided by AndriaRose


using System;
using Server;

namespace Server.Items
{
	public class CarpetLoomEastAddon : BaseAddon 
	{
		public override BaseAddonDeed Deed{ get{ return new CarpetLoomEastDeed(); } }

		[Constructable]
		public CarpetLoomEastAddon()
		{
		
			
			AddComponent( new AddonComponent( 0x1064 ), 0, 0, 0 ); 
			AddComponent( new AddonComponent( 0x1063 ), 0, 1, 0 );
			AddComponent( new AddonComponent( 0x1536 ), 0, 0, 0 );//goldbelt - to make unique from RegularLoom
		
			Hue = 1169;	
		}	


		public CarpetLoomEastAddon( Serial serial ) : base( serial )
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

	public class CarpetLoomEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new CarpetLoomEastAddon(); } }

		
		[Constructable]
		public CarpetLoomEastDeed()
		{
		Name = "Carpet Loom (east)";
		}

		public CarpetLoomEastDeed( Serial serial ) : base( serial )
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