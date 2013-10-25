using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class InsaneDagger : Item, ICarvable
	{
		private SpawnTimer m_Timer;

		[Constructable]
		public InsaneDagger() : base( 0xF52 )
		{
			Movable = false;
			Name = "Insane Dagger";
			Hue = 1153;

			m_Timer = new SpawnTimer( this );
			m_Timer.Start();
		}

		public void Carve( Mobile from, Item item )
		{
			Effects.PlaySound( GetWorldLocation(), Map, 0x48F );
			Effects.SendLocationEffect( GetWorldLocation(), Map, 0x3728, 10, 10, 0, 0 );

			if ( 0.3 > Utility.RandomDouble() )
			{
				if ( ItemID == 0x11EA )
					from.SendMessage( "You destroy the Insane Dagger." );
				else
					from.SendMessage( "You destroy the Insane Dagger." );

				Gold gold = new Gold( 25, 100 );

				gold.MoveToWorld( GetWorldLocation(), Map );

				Delete();

				m_Timer.Stop();
			}
		}

		public InsaneDagger( Serial serial ) : base( serial )
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

			m_Timer = new SpawnTimer( this );
			m_Timer.Start();
		}

		private class SpawnTimer : Timer
		{
			private Item m_Item;

			public SpawnTimer( Item item ) : base( TimeSpan.FromSeconds( Utility.RandomMinMax( 5, 10 ) ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_Item = item;
			}

			protected override void OnTick()
			{
				if ( m_Item.Deleted )
					return;

				Mobile spawn;

				switch ( Utility.Random( 8 ) )
				{
					default:
					case 0: spawn = new ElderGazer(); break;
					case 1: spawn = new Imp(); break;
					case 2: spawn = new OrcBrute(); break;
					case 3: spawn = new Phoenix(); break;
					case 4: spawn = new Quagmire(); break;
					case 5: spawn = new WhippingVine(); break;
					case 6: spawn = new Drake(); break;
					case 7: spawn = new VorpalBunny(); break;
				}

				spawn.MoveToWorld( m_Item.Location, m_Item.Map );

				m_Item.Delete();
			}
		}
	}
}