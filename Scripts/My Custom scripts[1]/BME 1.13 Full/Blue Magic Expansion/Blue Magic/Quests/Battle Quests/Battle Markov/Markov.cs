//Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Necromancy;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class BlueMarkov : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility() { return WeaponAbility.WhirlwindAttack; }
		protected override BaseAI ForcedAI { get { return new NecoSamuraiNinjaAI( this ); } }

		[Constructable]
		public BlueMarkov() : base( AIType.AI_Melee, FightMode.Weakest, 10, 2, 0.1, 0.4 )
		{
			Body = 400;
			Name = "Markov Tirel";
			Title = "the Midknight Necomancer";
			Hue = 1;
			SpeechHue = 1175;

			SetStr( 125 ); // +25%
			SetDex( 125 );
			SetInt( 5000 );

			SetHits( 25000 );

			SetDamageType( ResistanceType.Cold, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 120.0 );
			//SetSkill( SkillName.Hiding, 100.0 );
			//SetSkill( SkillName.Stealth, 100.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Necromancy, 100.0 );
			SetSkill( SkillName.SpiritSpeak, 100.0 );
			SetSkill( SkillName.Bushido, 100.0 );
			SetSkill( SkillName.Parry, 100.0 );
			SetSkill( SkillName.Tactics, 80.0 ); // +130%
			SetSkill( SkillName.Swords, 80.0 ); // +0%
			// 25 + 130 = 155%
			// Weapon: 15~16 = 38.25~40.8

			Fame = 30000;
			Karma = -30000;

			VirtualArmor = 150;

			#region Equipment
			Static item = new Static( 12216 ); // Glasses
			item.Name = "<BASEFONT COLOR='#880000'>Glaring Eyes";
			item.Layer = Layer.Earrings;
			Ability.GiveItem( this, 1194, item );

			item = new Static( 5201 ); // Bone Helm
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Helm;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 7933 ); // Fancy Shirt
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Shirt;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5063 ); // Leather Gorget
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Neck;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5199 ); // Bone Chest
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.InnerTorso;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5198 ); // // Bone Arms
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Arms;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5200 ); // Bone Gloves
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Gloves;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5903 ); // Shoes
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Shoes;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5397 ); // Cloak
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Cloak;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5202 ); // Bone Legs
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Waist;
			Ability.GiveItem( this, 1175, item );

			item = new Static( 5433 ); // Long Pants
			item.Name = "<BASEFONT COLOR='#444444'>Bone Armor";
			item.Layer = Layer.Pants;
			Ability.GiveItem( this, 1175, item );

			Ability.GiveItem( this, new MarkovsBardiche() );
			#endregion

			m_SpawnDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 60 ) );
			m_SoulDrainDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 7, 14 ) );
			m_NegativeBurstDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 3, 6 ) );

			m_BoneArmor = 100;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosSuperBoss, 8 );
		}

		public override void OnDeath( Container c )
		{
			if ( c != null && Utility.RandomDouble() > 0.33 )
				c.DropItem( new MarkovsBardiche() );

			for ( int i = 0; i < 5; i++ )
				c.DropItem( new BlueDraconicRune( 1 ) );

			base.OnDeath( c );
		}

		private DateTime m_SpawnDelay;
		private DateTime m_SoulDrainDelay;
		private DateTime m_NegativeBurstDelay;

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_SpawnDelay )
			{
				Freeze( TimeSpan.FromSeconds( 1.0 ) );
				Say ( "Kal An Mani Xen" ); // Summon Negate Life Creature
				Animate( 17, 6, 1, true, false, 0 );

				Corpse c = null;
				Mobile mob = null;

				foreach( Item item in GetItemsInRange( 5 ) )
				{
					c = item as Corpse;

					if ( c == null )
						continue;
					else if ( c.Channeled )
						continue;

					c.Channeled = true;

					Effects.SendLocationParticles( 
						EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 
						0x3709, 1, 30, 1, 6, 5052, 0 );

					mob = new BlueKarrnathi( Combatant );
					mob.MoveToWorld( c.Location, c.Map );
				}

				m_SpawnDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 60 ) );
			}
			else if ( DateTime.Now > m_SoulDrainDelay )
			{
				Freeze( TimeSpan.FromSeconds( 1.0 ) );
				Say ( "In Mani Ex Kal" ); // Cause Life Freedom Summon
				Animate( 17, 6, 1, false, false, 0 );
				int amount = 0;

				foreach( Mobile m in GetMobilesInRange( 30 ) )
				{
					if ( m == null )
						continue;

					Effects.SendMovingParticles( m, this, 0x36D4, 15, 0, false, false, 1/*hue*/, 0, 9502, 1, 5, (EffectLayer)255, 0x100 );
					++amount;
				}

				Hits += amount * 5;
				Stam += amount * 5;
				Mana += amount * 5;
				m_SoulDrainDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 7, 14 ) );
			}
			else if ( DateTime.Now > m_NegativeBurstDelay )
			{
				Freeze( TimeSpan.FromSeconds( 1.0 ) );
				Say ( "Vas Corp Hur Grav" ); // Great Death Wind Energy
				Animate( 17, 6, 1, true, false, 0 );
				new NegativeBurstTimer( this ).Start();

				m_NegativeBurstDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 60 ) );
			}

			base.OnActionCombat();
		}

		#region BoneArmor
		private int m_BoneArmor;

		[CommandProperty( AccessLevel.GameMaster )]
		public int BoneArmor
		{
			get{ return m_BoneArmor; }
			set{ m_BoneArmor = value; }
		}

		private bool m_SaidBrokenArmor;
		private DateTime ArmorDelay;

		public override void OnThink()
		{
			if ( DateTime.Now > ArmorDelay )
			{
				if ( m_BoneArmor > 0 )
				{
					// Discord: FixedEffect( 0x376A, 1, 32 );
					// ItemID, Speed, Duration, Hue, Render
					FixedEffect( 0x376A, 1, 32, 1, 5 );

					ArmorDelay = DateTime.Now + TimeSpan.FromSeconds( 1.25 );

					if ( Utility.RandomDouble() > 0.95 )
					{
						switch( Utility.Random( 3 ) )
						{
							case 0: Say( "With my armor you can barely hurt me!" ); break;
							case 1: Say( "I create my armor out of the corpses of those whom have failed against me." ); break;
							case 2: Say( "Do you know how many bones you have left for me to break?" ); break;
						}
					}
				}
				else
				{
					if ( !m_SaidBrokenArmor && m_BoneArmor < 1 )
					{
						Say( "Ugh, you may have broken my armor, but I will break you." );
						m_SaidBrokenArmor = true;
					}
					else
					{
						switch( Utility.Random( 5 ) )
						{
							case 0: Say( "You will die!" ); break;
							case 1: Say( "Don't make me laugh." ); break;
							case 2: Say( "Are you even trying?" ); break;
							case 3: Say( "Huha hahaha ha." ); break;
							case 4: Say( "Do you know how many bones you have left for me to break?" ); break;
						}
					}

					ArmorDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 30 ) );
				}
			}

			base.OnThink();
		}

		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			if ( m_BoneArmor > 0 )
			{
				damage = 1;

				if ( from is BaseCreature )
					--m_BoneArmor;
				else
					m_BoneArmor -= 2;
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( m_BoneArmor > 0 )
			{
				damage = 1;

				if ( from is BaseCreature )
					--m_BoneArmor;
				else
					m_BoneArmor -= 2;
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( defender == null || defender.Hits > 1 )
				return;

			if ( defender is PlayerMobile || (defender is BaseCreature && ((BaseCreature)defender).Controlled ) )
			{
				switch( Utility.Random( 5 ) )
				{
					case 0: Say( "You're death feeds my armor!" ); break;
					case 1: Say( "Your body is mine." ); break;
					case 2: Say( "Feel the power of Markov Tirel" ); break;
					case 3: Say( "That was pathetic." ); break;
					case 4: Say( "Was that your best?" ); break;
				}

				m_BoneArmor += 25;

				if ( m_BoneArmor > 0 )
				{
					Say( "My armor, it is back." );
					m_SaidBrokenArmor = false;
				}
			}
		}
		#endregion

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( willKill )
				return;
			else if ( Utility.RandomDouble() < 0.9 )
				return;

			Point3D point = new Point3D();
			point.X = from.X + Utility.RandomMinMax( -1, 1 );
			point.Y = from.Y + Utility.RandomMinMax( -1, 1 );
			point.Z = Map.GetAverageZ( point.X, point.Y );

			if ( Map.CanFit( point.X, point.Y, point.Z, 16, false, true ) )
				new UnholyBone().MoveToWorld( point, Map );

			base.OnDamage( amount, from, willKill );
		}


		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature )
				damage += (damage/2); // +50% damage to pets.
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool ClickTitle{ get{ return false; } }
		public override bool BardImmune { get { return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override bool BreathImmune { get { return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public BlueMarkov( Serial serial ) : base( serial )
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

			m_SpawnDelay = DateTime.Now;
			m_SoulDrainDelay = DateTime.Now;
			m_NegativeBurstDelay = DateTime.Now;
			m_BoneArmor = 100;
		}

		public class NegativeBurstTimer : Timer
		{
			private Mobile m_From;
			private Point3D m_StartingLocation;
			private Map m_Map;
			private int m_Count;
			private Point3D m_Point;
			private List<Mobile> Targets = new List<Mobile>();

			public NegativeBurstTimer( Mobile from ) : base( TimeSpan.FromMilliseconds( 300.0 ), TimeSpan.FromMilliseconds( 300.0 ) )
			{
				m_From = from;
				m_StartingLocation = from.Location;
				m_Map = from.Map;
				m_Count = 0;
				m_Point = new Point3D();

				foreach( Mobile m in from.GetMobilesInRange( 15 ) )
				{
					if ( m != null && Ability.CanTarget( from, m, true ) && !TrueSlayer.IsUndead( m ) && m.Alive && !m.Blessed )
						Targets.Add( m );
				}
			}

			protected override void OnTick()
			{
				double dist = 0.0;

				for ( int i = -m_Count; i < m_Count + 1; i++ )
				{
					for ( int j = -m_Count; j < m_Count + 1; j++ )
					{
						m_Point.X = m_StartingLocation.X + i;
						m_Point.Y = m_StartingLocation.Y + j;
						m_Point.Z = m_Map.GetAverageZ( m_Point.X, m_Point.Y );
						dist = GetDist( m_StartingLocation, m_Point );

						if ( dist < ((double)m_Count + 1.1) && dist > ((double)m_Count - 0.1) )
						{
							//Effects.SendLocationParticles( EffectItem.Create( m_Point, m_Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );

							Effects.SendLocationParticles( 
								EffectItem.Create( m_Point, m_Map, EffectItem.DefaultDuration ), 
								0x3709, 1108, 30, 1, 5, 5052, 0 );
						}	
					}
				}

				m_Count += 3;
				
				if ( m_Count > 15 )
				{
					if ( m_From != null )
					{
						for ( int i = 0; i < Targets.Count; i++ )
						{
							if ( Targets[i] != null )
								Ability.EnergyDrain( m_From, Targets[i], 5, 10, true );
						}
					}

					Stop();
				}
			}

			private double GetDist( Point3D start, Point3D end )
			{
				int xdiff = start.X - end.X;
				int ydiff = start.Y - end.Y;
				return Math.Sqrt( (xdiff * xdiff) + (ydiff * ydiff) );
			}
		}

	}
}

namespace Server.Mobiles
{
	public class NecoSamuraiNinjaAI : OmniAI
	{
		public override bool m_CanUseBard
		{
			get { return false; }
		}

		public override bool m_CanUseBushido
		{
			get { return true; }
		}

		public override bool m_CanUseChivalry
		{
			get { return false; }
		}

		public override bool m_CanUseMagery
		{
			get { return false; }
		}

		public override bool m_CanUseNecromancy
		{
			get { return true; }
		}

		public override bool m_CanUseNinjitsu
		{
			get { return true; }
		}

		public override bool m_CanUseSpellweaving
		{
			get { return false; }
		}

		public NecoSamuraiNinjaAI( BaseCreature bc ) : base( bc )
		{
		}
	}
}