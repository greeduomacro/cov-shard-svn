using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class AdvancedGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;


		[Constructable]
		public AdvancedGate() : this( true )
		{
		}

		[Constructable]
		public AdvancedGate( bool decays, Point3D loc, Map map ) : this( decays )
		{
			MoveToWorld( loc, map );
			Effects.PlaySound( loc, map, 0x20E );
		}

		[Constructable]
        public AdvancedGate(bool decays) : base(new Point3D(5219, 1292, 0), Map.Trammel)
		{
			Dispellable = false;
			ItemID = 0x1FD4;
            Name = "Vet Player Quest Gate";

			if ( decays )
			{
				m_Decays = true;
				m_DecayTime = DateTime.Now + TimeSpan.FromMinutes( 2.0 );

				m_Timer = new InternalTimer( this, m_DecayTime );
				m_Timer.Start();
			}
		}

        public override bool ValidateUse(Mobile from, bool message)
        {
            if (from is PlayerMobile)
            {
                if ((from.SkillsTotal < 10000))
                {
                    from.SendMessage("You are not skilled enough to enter this gate! Try other quests please.");
                    return false;
                }
            }
            return base.ValidateUse(from, message);
        }


		public AdvancedGate( Serial serial ) : base( serial )
		{
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			base.OnAfterDelete();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); 

			writer.Write( m_Decays );

			if ( m_Decays )
				writer.WriteDeltaTime( m_DecayTime );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Decays = reader.ReadBool();

					if ( m_Decays )
					{
						m_DecayTime = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_DecayTime );
						m_Timer.Start();
					}

					break;
				}
			}
		}

		private class InternalTimer : Timer
		{
			private Item m_Item;

			public InternalTimer( Item item, DateTime end ) : base( end - DateTime.Now )
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}
}