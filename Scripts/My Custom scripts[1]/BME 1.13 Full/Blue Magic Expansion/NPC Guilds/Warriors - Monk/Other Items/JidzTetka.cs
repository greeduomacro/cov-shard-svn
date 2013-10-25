// Created by Peoharen
using System;
using Server;

namespace Server.Items
{
	public class JidzTetka : BaseClothing
	{
		[Constructable]
		public JidzTetka() : base( 0x144E, Layer.Arms )
		{
			Name = "Jidz-Tet'ka";
			Hue = 2500;
			Attributes.AttackChance = 50;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );
			list.Add( "[Improves Monk Stances]" );
		}

		public JidzTetka( Serial serial ) : base( serial )
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