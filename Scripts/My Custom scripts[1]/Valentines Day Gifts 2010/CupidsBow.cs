using System;
using Server;

namespace Server.Items
{
	public class CupidsBow : Bow
	{
		public override int EffectID{ get{ return 6377; } }
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public CupidsBow()
		{
			Hue = 38;
			Name = "Cupid's Bow";
			Attributes.WeaponDamage = 50;
			LootType = LootType.Blessed;
			Identified = true;
		}

		public CupidsBow( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060662, "Valentines Day\t2010" );
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
