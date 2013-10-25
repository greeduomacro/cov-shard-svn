// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Items
{
	public class SpikeGrowth : Item
	{
		[Constructable]
		public SpikeGrowth() : base( 0x0D40 ) // 0x187E + Utility.Random( 4 )
		{
			Name = "spiked growth";
			Hue = 1436;
			Timer.DelayCall( TimeSpan.FromSeconds( 15 ), new TimerCallback( Expire ) );
		}

		private void Expire()
		{
			if ( Deleted )
				return;

			Delete();
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m != null )
			{
				if ( m is BlueKaysa || m is BlueTreeGuardian || m.AccessLevel != AccessLevel.Player )
					return true;

				Slow.SlowWalk( m, 15 );
				m.SendMessage( "The thorns pierce your shoes and injure your feet." );
				m.Damage( Utility.RandomMinMax( 1, 4 ) );
				
			}

			return true;
		}

		public SpikeGrowth( Serial serial ) : base( serial )
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