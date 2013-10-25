// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class AngelSnack : Item
	{
		[Constructable]
		public AngelSnack() : base( 0x0CAC )
		{
			Name = "Angel's Snack";
			ItemID += Utility.Random( 12 );
			Hue = 1150;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Hue != 1150 )
			{
				base.OnDoubleClick( from );
				return;
			}

			Container pack = from.Backpack;

			if ( !(pack != null && Parent == pack) )
			{
				from.SendLocalizedMessage( 1080058 ); // This must be in your backpack to use it.
				return;
			}

			from.Animate( 34, 5, 1, true, false, 0 );
			from.PlaySound( Utility.Random( 0x3A, 3 ) );

			if ( BlueMageControl.IsBlueMage( from ) )
				BlueMageControl.CheckKnown( from, typeof( AngelsSnackSpell ), true );

			Hue = Utility.RandomList( 0, 0x66D, 0x53D, 0x8A5, 0x21, 0x5, 0x38, 0xD, 0x59B, 0x46F, 0x10, 0x42, 0x2B );
			Name = "grasses";
		}

		public AngelSnack( Serial serial ) : base( serial )
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