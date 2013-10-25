//Created by Peoharen for the Mobile Abilities Package.
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class SolenEggSack : Item, ICarvable
	{
		private int m_Type;

		[Constructable]
		public SolenEggSack( int type ) : base( 0x10D9 )
		{
			Movable = false;
			m_Type = type;
			Timer.DelayCall( TimeSpan.FromSeconds( 5 ), new TimerCallback( Hatch ) );
		}

		public void Carve( Mobile from, Item item )
		{
			from.SendMessage( "You destroy the egg sack." );
			Delete();
		}

		private void Hatch()
		{
			if ( Deleted )
				return;

			BaseCreature hatch;

			if ( m_Type == 1 )
			{
				if ( Utility.RandomBool() )
					hatch = new RedSolenWarrior();
				else
					hatch = new RedSolenWorker();
			}
			else
			{
				if ( Utility.RandomBool() )
					hatch = new BlackSolenWarrior();
				else
					hatch = new BlackSolenWorker();
			}

			hatch.MoveToWorld( this.Location, this.Map );
			Delete();
		}

		public SolenEggSack( Serial serial ) : base( serial )
		{
			Timer.DelayCall( TimeSpan.FromSeconds( 5 ), new TimerCallback( Hatch ) );
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
