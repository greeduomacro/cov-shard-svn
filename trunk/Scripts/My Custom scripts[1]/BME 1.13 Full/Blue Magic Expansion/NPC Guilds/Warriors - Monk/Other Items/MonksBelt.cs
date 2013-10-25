// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class MonksBelt : BaseClothing
	{
		[Constructable]
		public MonksBelt() : base( 0x2B68, Layer.Waist )
		{
			Name = "Monk Belt";
			Hue = 2500;
			Attributes.DefendChance = 50;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );
			list.Add( "[Improves Breath Of Fire]" );
		}

		public MonksBelt( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}