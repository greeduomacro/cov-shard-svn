// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class FalseGloves : Item, IBlueWeapon
	{
		[Constructable]
		public FalseGloves() : base( 0 )
		{
			Layer = Layer.TwoHanded;
			Visible = false;
			Movable = false;
		}

		public FalseGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}