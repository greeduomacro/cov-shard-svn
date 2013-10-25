using System;
using Server.Items;

namespace Server.Items
{
	public class IronwoodCompositeBow : ElvenCompositeLongbow
	{
		public override int LabelNumber{ get{ return 1072908; } } // 

		[Constructable]
		public IronwoodCompositeBow() : base()
		{
            Weight = 5.0;
            Hue = 0x8AB;
            Balanced = true;
			
			Attributes.BonusDex = 5;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 45;
			
			WeaponAttributes.HitFireball = 40;
            WeaponAttributes.HitLowerDefend = 30;

            Slayer = SlayerName.Fey;

            Velocity = 30;
		}

		public IronwoodCompositeBow( Serial serial ) : base( serial )
		{
        }

		#region Mondain's Legacy
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = cold = pois = nrgy = chaos = direct = 0;
			phys = 100;
		}
		#endregion

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}