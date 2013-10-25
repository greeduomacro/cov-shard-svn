// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ACreedBoneArms : ACreedGarb
	{
		[Constructable]
		public ACreedBoneArms() : base( 5198, Layer.Arms )
		{
			Hue = 2101;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty( list );
			
			if ( Level > 0 )
				list.Add( 1070722, "<BASEFONT ALIGN='CENTER' COLOR='#C0C0C0'>Dual Blade</BASEFONT>" ); // ~1_NOTHING~
		}

		public ACreedBoneArms( Serial serial ) : base( serial )
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