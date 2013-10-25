//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class ACreedGuard : BaseCreature
	{
		private bool m_CanFlag;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool CanFlag
		{
			get { return m_CanFlag; }
			set { m_CanFlag = value; }
		}

		[Constructable]
		public ACreedGuard() : this( true )
		{
		}

		[Constructable]
		public ACreedGuard( bool canflag ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Guard";
			Body = 400;
			CanFlag = canflag;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor, 1 );
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( AssassinControl.IsAssassin( m ) )
			{
				m.DoHarmful( this );

				if ( CanFlag )
				{
					AssassinControl.BecomeNotorious( m );
					//m.CriminalAction( false );

					switch( Utility.Random( 5 ) )
					{
						case 0: Say( "Halt!" ); break;
						case 1: Say( "Stop right there!" ); break;
						case 2: Say( "Hey you!" ); break;
						case 3: Say( "I know you." ); break;
						case 4: Say( "Stop that man!" ); break;
						case 5: Say( "Hey!" ); break;
					}
				}

				return true;
			}
			else
				return false;
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public ACreedGuard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
			writer.Write ( (bool) m_CanFlag );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version > 0 )
				m_CanFlag = reader.ReadBool();
		}
	}
}
