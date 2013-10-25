// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a deep sea serpents corpse" )]
	public class UWaterDeepSeaSerpent : DeepSeaSerpent
	{
		[Constructable]
		public UWaterDeepSeaSerpent() : base()
		{
			SetResistance( ResistanceType.Fire, 100 );

			CanSwim = true;
			CantWalk = false;
		}

		public UWaterDeepSeaSerpent( Serial serial ) : base( serial )
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