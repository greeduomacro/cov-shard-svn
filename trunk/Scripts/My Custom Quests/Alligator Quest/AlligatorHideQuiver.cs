using System;
using Server.Items;

namespace Server.Items
{
	public class AlligatorHideQuiver : BaseQuiver
	{
		//public override int LabelNumber{ get{ return 1073109; } } // quiver of fire
		
		[Constructable]
		public AlligatorHideQuiver() : base()
		{
			Hue = 2967;
            Name = "Alligator hide quiver";

            Attributes.WeaponDamage = 10;
			DamageModifier.Cold = 50;
			DamageModifier.Physical = 50;
            WeightReduction = 50;
		}

		public AlligatorHideQuiver( Serial serial ) : base( serial )
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