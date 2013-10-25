using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class BloodwebSilk : Item, ICarvable
	{
		private SpawnTimer m_Timer;

		public override string DefaultName
		{
			get { return "Bloodweb Silk"; }
		}

		[Constructable]
		public BloodwebSilk() : base( 0xF8D )
		{
			Movable = false;
			Hue = 2949;

			m_Timer = new SpawnTimer( this );
			m_Timer.Start();
		}

		public void Carve( Mobile from, Item item )
		{
			Effects.PlaySound( GetWorldLocation(), Map, 0x48F );
			Effects.SendLocationEffect( GetWorldLocation(), Map, 0x3728, 10, 10, 0, 0 );

			if ( 0.3 > Utility.RandomDouble() )
			{
				if ( ItemID == 0xF8D )
					from.SendMessage( "You destroy the Bloodweb silk." );
				else
					from.SendMessage( "You destroy the Bloodweb silk pile." );

				Gold gold = new Gold( 25, 100 );

				gold.MoveToWorld( GetWorldLocation(), Map );

				Delete();

				m_Timer.Stop();
			}
			else
			{
				if ( ItemID == 0xF8D )
					from.SendMessage( "You damage the Bloodweb silk." );
				else
					from.SendMessage( "You damage the Bloodweb silk pile." );
			}
		}

		public BloodwebSilk( Serial serial ) : base( serial )
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

				switch ( Utility.Random( 2 ) )
				{
					default:
					case 0: spawn = new GiantSpider(); break;
					case 1: spawn = new GiantBlackWidow(); break;
					//case 2: spawn = new Wraith(); break;
					
				}

				spawn.MoveToWorld( m_Item.Location, m_Item.Map );

				m_Item.Delete();
			}
		}
	}
}