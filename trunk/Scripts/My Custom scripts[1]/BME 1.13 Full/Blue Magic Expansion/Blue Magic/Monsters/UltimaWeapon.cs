// Created by Peoharen
using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a weapons corpse" )]
	public class BlueUltimaWeapon : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 10.0 ); } }
		public override Type SpellToCast{ get{ return typeof( ShadowFlareSpell ); } }

		private DateTime m_BullRushDelay;
		private DateTime m_EchoStrikeDelay;
		private DateTime m_RallyDelay;
		private DateTime m_Delay;
		private DateTime m_EtherealDrainDelay;

		[Constructable]
		public BlueUltimaWeapon() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.4 )
		{
			Name = "Ultima Weapon";
			Body = 400;
			Hue = 1175;

			SetStr( 1000 );
			SetDex( 150 );
			SetInt( 1500 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.Anatomy, 120.0 );
			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Forensics, 120.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Swords, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );

			Fame = 32000;
			Karma = -32000;

			VirtualArmor = 80;

			int hue = 1175;
			GiveItem( this, hue, new DragonHelm() );
			GiveItem( this, hue, new PlateGorget() );
			GiveItem( this, hue, new DragonChest() );
			GiveItem( this, hue, new DragonLegs() );
			GiveItem( this, hue, new DragonArms() );
			GiveItem( this, hue, new DragonGloves() );

			Longsword sword = new Longsword();
			sword.ItemID = 9934;
			GiveItem( this, hue, sword );

			BaseMount pet = null;

			pet = new Reptalon();
			pet.Hue = 1175;
			pet.Rider = this;

			m_BullRushDelay = DateTime.Now;
			m_EchoStrikeDelay = DateTime.Now;
			m_RallyDelay = DateTime.Now;
			m_Delay = DateTime.Now;
			m_EtherealDrainDelay = DateTime.Now;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 35 );
			AddLoot( LootPack.Gems, 15 );
		}

		public override bool OnBeforeDeath()
		{
			IMount mount = this.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( mount is Mobile )
				((Mobile)mount).Delete();

			return base.OnBeforeDeath();
		}

		public override void OnThink()
		{
			if ( DateTime.Now > m_RallyDelay && Hits < (HitsMax/2) )
			{
				Say( "Do you really think you stand a chance?" );
				Ability.Rally( this, 3 );
				m_RallyDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 45 ) );
			}
			else if ( DateTime.Now > m_EchoStrikeDelay && Combatant != null )
			{
				Say("Die!!!");
				Ability.EchoStrike( this, 30, 45 );
				m_EchoStrikeDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 45 ) );
			}

			base.OnThink();
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			if ( DateTime.Now > m_BullRushDelay )
			{
				Say("I'll crush you!!!");
				Ability.BullRush( this );
				m_BullRushDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 25 ) );
			}

			if ( Utility.Random( 5 ) == 0 )
				Ability.EnergyDrain( this, defender );

			if ( DateTime.Now > m_EtherealDrainDelay )
			{
				Ability.EtherealDrain( this, defender, Utility.RandomMinMax( 1, 3 ) );
				m_EtherealDrainDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 25 ) );
			}

			base.OnGaveMeleeAttack( defender );
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature )
				damage *= 2;
		}

		public static void GiveItem( Mobile to, int hue, Item item )
		{
			if ( to == null && item == null )
				return;

			if ( hue != 0 )
				item.Hue = hue;

			item.Movable = false;
			to.EquipItem( item );
			return;
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }
		//public override bool HasBreath{ get{ return true; } }

		public BlueUltimaWeapon( Serial serial ) : base( serial )
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

			m_BullRushDelay = DateTime.Now;
			m_EchoStrikeDelay = DateTime.Now;
			m_RallyDelay = DateTime.Now;
			m_Delay = DateTime.Now;
			m_EtherealDrainDelay = DateTime.Now;
		}
	}
}