// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a humanoid corpse" )]
	public class BlueKaysa : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 2.0 ); } }
		public override Type SpellToCast{ get{ return typeof( PoisonClawMove ); } }

		[Constructable]
		public BlueKaysa() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Kaysa";
			Title = "the Turquoise Druid";
			Female = true;
			Race = Race.Elf;
			Body = 606;
			SpeechHue = 1436;
			Hue = 33773;

			SetStr( 500 );
			SetDex( 125 );
			SetInt( 1000 );

			SetHits( 25000 );

			SetDamage( 17, 21 );

			SetDamageType( ResistanceType.Poison, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 35 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 95 );
			SetResistance( ResistanceType.Energy, 45 );

			SetSkill( SkillName.Magery, 120.0 );
			SetSkill( SkillName.EvalInt, 100.0);
			SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 28000;
			Karma = -28000;

			VirtualArmor = 64;

			HairItemID = 0x203D;
			HairHue = 1119;

			#region Equipment
			// Chest
			BlueShirt chest = new BlueShirt();
			chest.ItemID = 0x1C0A;
			chest.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				chest.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1436, chest );

			// Legs
			BluePants legs = new BluePants();
			legs.ItemID = 0x1C00;
			legs.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				legs.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1436, legs );

			// Arms
			BlueArms arms = new BlueArms();
			arms.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				arms.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1436, arms );

			// Boots
			BlueBoots boots = new BlueBoots();
			boots.EnhanceOne = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			if ( Utility.RandomDouble() > 0.75 )
				boots.EnhanceTwo = (BlueEnhance)( Utility.Random( 9 ) + 1 );

			Ability.GiveItem( this, 1436, boots );
			#endregion
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss, 2 );
			AddLoot( LootPack.Gems, 30 );
		}

		#region KaysaAbilities
		private DateTime m_SpikeGrowthDelay = DateTime.Now;
		private DateTime m_AnimateTreeDelay = DateTime.Now;

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			// Fracken pets
			if ( to is BaseCreature )
			{
				Hits += damage / 2;
				damage *= 2;
			}
		}

		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			if ( Utility.Random( 100 ) < 25 )
			{
				Effects.SendMovingEffect( this, from, 0x0C70, (int)(Ability.GetDist( Location, from.Location )), 0, false, false, 0, 0);
				new EntangleTimer( this, from, damage / 2 ).Start();
			}
		}

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_SpikeGrowthDelay && this.Map != null )
			{
				Say( "Spiked Growth" );

				Point3D point = new Point3D( this.X, this.Y, this.Z );

				for ( int i = -5; i < 6; i++ )
				{
					for ( int j = -5; j < 6; j++ )
					{
						point.X = this.X + i;
						point.Y = this.Y + j;
						point.Z = this.Map.GetAverageZ( point.X, point.Y );

						if ( Ability.GetDist( Location, point ) <= 5 )
							if ( this.Map.CanSpawnMobile( point ) )
								new SpikeGrowth().MoveToWorld( point, this.Map );
					}
				}
					
				m_SpikeGrowthDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 45, 60 ) );
			}
			else if ( DateTime.Now > m_AnimateTreeDelay && this.Map != null )
			{
				bool summoned = false;

				Say( "Summon" );

				foreach( Item i in GetItemsInRange( 24 ) )
				{
					if ( i is SleepingTreeAddon )
					{
						((SleepingTreeAddon)i).WakeUp( Combatant );
						summoned = true;
						break;
					}
				}

				if ( summoned )
					m_AnimateTreeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 30 ) );
				else // Probably running out of trees, lets slow down the scan to save computer resources.
					m_AnimateTreeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 60, 120 ) );
			}

			base.OnActionCombat();
		}

		public override void OnThink()
		{
			base.OnThink();

			if ( DateTime.Now > CreationTime + TimeSpan.FromMinutes( 30 ) )
			{
				X -= 45;
				Y -= 45;
				Kill();
			}
		}
		#endregion

		public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			base.OnCarve( from, corpse, with );

			if ( corpse == null )
				return;

			for ( int i = 0; i < 6; i++ )
			{
				corpse.AddItem( new Server.Engines.Plants.Seed() );
				corpse.AddItem( new GreenThorns( Utility.RandomMinMax( 2, 5 ) ) );
			}

			from.SendMessage( "As you cut into her body you notice she is more plant-like than elven." );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( !Summoned && !NoKillAwards && DemonKnight.CheckArtifactChance( this ) )
			{
				switch( Utility.Random ( 5 ) )
				{
					case 0: DemonKnight.DistributeArtifact( this, new SerpentsFang() ); break;
					case 1: DemonKnight.DistributeArtifact( this, new SpiritOfTheTotem() ); break;
					case 2: DemonKnight.DistributeArtifact( this, new TheDryadBow() ); break;
					case 3: DemonKnight.DistributeArtifact( this, new RingOfTheElements() ); break;
					default: DemonKnight.DistributeArtifact( this, new OrnamentOfTheMagician() ); break;
				}
			}


			for ( int i = 0; i < 6; i++ )
				c.DropItem( new BlueDraconicRune( 1 ) );
		}

		public override bool AlwaysAttackable{ get { return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override bool BleedImmune { get { return false; } }
		public override bool ClickTitle{ get{ return false; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool ShowFameTitle { get { return false; } }

		public BlueKaysa( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
			//writer.Write( Arena );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version == 0 )
				reader.ReadStrongItemList();
		}

		private class EntangleTimer : Timer
		{
			private Mobile m_From;
			private Mobile m_To;
			private int m_Damage;

			public EntangleTimer( Mobile from, Mobile to, int damage ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_From = from;
				m_To = to;
				m_Damage = damage;
			}

			protected override void OnTick()
			{
				if ( m_From != null && m_To != null )
				{
					AOS.Damage( m_To, m_From, m_Damage, 0, 0, 0, 100, 0 );

					if ( m_To != null )
					{
						m_To.Freeze( TimeSpan.FromSeconds( 7 ) );
						m_To.SendMessage( 1436, "Vines lash out from the ground and grab you!" );
						new SelfDeletingItem( 0xCEB + Utility.Random( 8 ), "entangling vines", 7 ).MoveToWorld( m_To.Location, m_To.Map );
					}
				}

				Stop();
			}
		}

	}
}
