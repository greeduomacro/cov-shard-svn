// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class MalborosRing : GoldRing
	{
		public override int ArtifactRarity{ get{ return 12; } }

		[Constructable]
		public MalborosRing()
		{
			Name = "Malboro's Ring";
			Attributes.LowerManaCost = 10;
			Attributes.BonusMana = 15;
			Attributes.EnhancePotions = 25;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );
			list.Add( "<ALIGN='CENTER>[<BASEFONT COLOR='#007FFF'>Improves Bad Breath</BASEFONT>]" );
		}

		public MalborosRing( Serial serial ) : base( serial )
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