using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class EnragedEarthElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public EnragedEarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an enraged earth elemental";
			Body = 14;
            Hue = 2117;
			BaseSoundID = 268;

			SetStr( 125, 129 );
			SetDex( 66, 86 );
			SetInt( 71, 92 );

			SetHits( 500,505 );

			SetDamage( 9, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 62 );
			SetResistance( ResistanceType.Fire, 20, 24 );
			SetResistance( ResistanceType.Cold, 20, 29 );
			SetResistance( ResistanceType.Poison, 45, 50 );
			SetResistance( ResistanceType.Energy, 15, 25 );

			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 100.1, 120.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 34;
			ControlSlots = 2;

			PackItem( new FertileDirt( Utility.RandomMinMax( 1, 4 ) ) );
			PackItem( new MandrakeRoot() );
			
			Item ore = new IronOre( 5 );
			ore.ItemID = 0x19B7;
			PackItem( ore );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.1 > Utility.RandomDouble())
            {
                /* Blood Bath
                 * Start cliloc 1070826
                 * Sound: 0x52B
                 * 2-3 blood spots
                 * Damage: 2 hps per second for 5 seconds
                 * End cliloc: 1070824
                 */

                ExpireTimer timer = (ExpireTimer)m_Table[defender];

                if (timer != null)
                {
                    timer.DoExpire();
                    defender.SendLocalizedMessage(1070825); // The creature continues to rage!
                }
                else
                    defender.SendLocalizedMessage(1070826); // The creature goes into a rage, inflicting heavy damage!

                timer = new ExpireTimer(defender, this);
                timer.Start();
                m_Table[defender] = timer;
            }
        }

        private static Hashtable m_Table = new Hashtable();

        private class ExpireTimer : Timer
        {
            private Mobile m_Mobile;
            private Mobile m_From;
            private int m_Count;

            public ExpireTimer(Mobile m, Mobile from)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
            {
                m_Mobile = m;
                m_From = from;
                Priority = TimerPriority.TwoFiftyMS;
            }

            public void DoExpire()
            {
                Stop();
                m_Table.Remove(m_Mobile);
            }

            public void DrainLife()
            {
                if (m_Mobile.Alive)
                    m_Mobile.Damage(2, m_From);
                else
                    DoExpire();
            }

            protected override void OnTick()
            {
                DrainLife();

                if (++m_Count >= 5)
                {
                    DoExpire();
                    m_Mobile.SendLocalizedMessage(1070824); // The creature's rage subsides.
                }
            }
        }

		public EnragedEarthElemental( Serial serial ) : base( serial )
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