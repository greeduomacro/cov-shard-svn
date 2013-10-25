//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class BlueCatoblepas : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 3.0 ); } }
		public override Type SpellToCast{ get{ return typeof( LimitGloveMove ); } }

		[Constructable]
		public BlueCatoblepas() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 715;
			Name = "Catoblepas";

			SetStr( 120, 130 );
			SetDex( 90, 110 );
			SetInt( 80, 90 );

			SetMana( 50000 );

			SetHits( 1750, 2500 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 10, 20 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 65, 75 );

			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 50;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
		}

		private DateTime m_EarthQuakeDelay;
		private DateTime m_PetrifyDelay;
		private DateTime m_ThundaraDelay;

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_EarthQuakeDelay )
			{
				PlaySound( 0x220 );

				List<Mobile> list = GetNearbyMobiles( this, 12, true );

				for ( int i = list.Count - 1; i > -1; i-- )
				{
					if ( list[i] != null )
					{
						list[i].SendMessage( "You were hit by a powerful earthquake!" );
						AOS.Damage( list[i], this, list[i].Hits, 33, 0, 0, 33, 33 );
					}
				}

				m_EarthQuakeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 20, 40 ) );
			}
			else if ( DateTime.Now > m_PetrifyDelay )
			{
				m_PetrifyDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 60, 120 ) );
			}
			else if ( DateTime.Now > m_ThundaraDelay )
			{
				List<Mobile> list = GetNearbyMobiles( this, 12, true );

				for ( int i = list.Count - 1; i > -1; i-- )
				{
					if ( list[i] != null )
					{
						list[i].BoltEffect( 0 );
						list[i].SendMessage( "You were hit by a powerful lightning bolt!" );

						// 80-70%=24, 250-70%=75
						AOS.Damage( list[i], this, Utility.RandomMinMax( 80, 250 ), 0, 0, 0, 0, 100 );
					}
				}

				m_ThundaraDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 7, 14 ) );
			}

			base.OnActionCombat();
		}

		public BlueCatoblepas( Serial serial ) : base( serial )
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
