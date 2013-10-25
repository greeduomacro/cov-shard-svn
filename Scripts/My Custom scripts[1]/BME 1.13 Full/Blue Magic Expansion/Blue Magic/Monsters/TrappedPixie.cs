//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class BlueTrappedPixie : BaseCreature
	{
		public Mobile AlwaysFollow;

		[Constructable]
		public BlueTrappedPixie() : base( AIType.AI_Mage, FightMode.None, 10, 1, 0.4, 0.8 )
		{
			Name = "a trapped pixie";
			Body = 128;
			Hue = 1153;
			BaseSoundID = 0x467;

			SetStr( 41, 50 );
			SetDex( 321, 420 );
			SetInt( 221, 270 );

			SetHits( 113, 118 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 95 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 45, 55 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 60.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 62.5 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 100;

		}

		private DateTime m_Delay;

		public override void OnThink()
		{
			CantWalk = !Controlled;

			if ( AlwaysFollow != null )
			{
				ControlOrder = OrderType.Follow;
				ControlTarget = AlwaysFollow;
			}

			if ( DateTime.Now > m_Delay )
			{
				if ( !Controlled )
				{
					switch( Utility.Random( 6 ) )
					{
						case 0: Say( "Please help me." ); break;
						case 1: Say( "I want to go home." ); break;
						case 2: Say( "*cries*" ); break;
						case 3: Say( "Help me" ); break;
						case 4: Say( "Wait, come over here." ); break;
						case 5: Say( "I don't want to die." ); break;
					}
				}
				else if ( X > 1960 && X < 1965 && Y > 490 && Y < 500 )
				{
					// Tele helper
					MoveToWorld( new Point3D( 1960, 643, -26 ), Map.Ilshenar );
				}
				else if ( X > 2020 && X < 2030 && Y > 695 && Y < 705 )
				{
					// Tele helper
					MoveToWorld( new Point3D( 1963, 685, -21 ), Map.Ilshenar );
				}
				else if ( X > 1970 && X < 1980 && Y > 825 && Y < 830 )
				{
					// Auto Life's animation
					PlaySound( 0x214 );

					Effects.SendLocationParticles( 
						EffectItem.Create( new Point3D( X - 1, Y - 1, Z ), Map, EffectItem.DefaultDuration ), 
						0x3709, 10, 30, 1153, 4, 0, 0);
					Effects.SendLocationParticles( 
						EffectItem.Create( new Point3D( X - 1, Y + 1, Z ), Map, EffectItem.DefaultDuration ), 
						0x3709, 10, 30, 1153, 4, 0, 0);
					Effects.SendLocationParticles( 
						EffectItem.Create( new Point3D( X + 1, Y - 1, Z ), Map, EffectItem.DefaultDuration ), 
						0x3709, 10, 30, 1153, 4, 0, 0);
					Effects.SendLocationParticles( 
						EffectItem.Create( new Point3D( X + 1, Y + 1, Z ), Map, EffectItem.DefaultDuration ), 
						0x3709, 10, 30, 1153, 4, 0, 0);

					if ( ControlTarget is PlayerMobile ) // Did it somehow switch?
					{
						ControlTarget.SendMessage( "As a reward for freeing the pixie she teaches you Auto Life!" );
						BlueMageControl.CheckKnown( ControlTarget, typeof( AutoLifeSpell ), true );
					}

					Delete();
				}

				m_Delay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 7, 14 ) );
			}

			base.OnThink();
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive )
			{
				list.Add( new TakeMeEntry( this, from ) );
			}
		}

		private class TakeMeEntry : ContextMenuEntry
		{
			private BlueTrappedPixie m_Pixie;
			private Mobile m_From;

			public TakeMeEntry( BlueTrappedPixie pixie, Mobile from ) : base( 6101 ) // Accept Escort
			{
				m_Pixie = pixie;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Pixie.Controlled = true;
				m_Pixie.ControlOrder = OrderType.Follow;
				m_Pixie.ControlTarget = m_From;
				m_Pixie.AlwaysFollow = m_From;
				m_Pixie.Say( "Take me outside if you can." );
			}
		}

		public override bool InitialInnocent{ get{ return true; } }

		public BlueTrappedPixie( Serial serial ) : base( serial )
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

			m_Delay = DateTime.Now;
		}
	}
}
