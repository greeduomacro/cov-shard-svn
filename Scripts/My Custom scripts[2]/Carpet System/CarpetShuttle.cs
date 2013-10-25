// Based on wood plane tool. Tool for crafting carpets, must be used near a CarpetLoom to function.
// Modification is need to the defTinkering.cs to make this player craftable.
// Instructions for mods are listed on the text instruction page.
// Script mutilation provided by AndriaRose


using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable( 0x1032, 0x1033 )]
	public class CarpetShuttle : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpetMaking.CraftSystem; } }

		[Constructable]
		public CarpetShuttle() : base( 0x1032 )
		{
			Weight = 1.0;
			Name = "Carpet Shuttle";
		}

		[Constructable]
		public CarpetShuttle( int uses ) : base( uses, 0x1032 )
		{
			Weight = 1.0;
		}

		public CarpetShuttle( Serial serial ) : base( serial )
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