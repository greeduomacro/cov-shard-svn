// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a sea serpents corpse" )]
	public class UWaterSeaSerpent : SeaSerpent
	{
		[Constructable]
		public UWaterSeaSerpent() : base()
		{
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			CanSwim = true;
			CantWalk = false;
		}

		public UWaterSeaSerpent( Serial serial ) : base( serial )
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