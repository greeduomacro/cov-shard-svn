// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class UWaterTidalForceElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 147.5; } }
		public override double DispelFocus{ get{ return 75.0; } }

		public override WeaponAbility GetWeaponAbility(){ return WeaponAbility.CrushingBlow; }

		[Constructable]
		public UWaterTidalForceElemental() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an air elemental";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 176, 205 );
			SetDex( 216, 235 );
			SetInt( 151, 175 );

			SetHits( 276, 293 );

			SetDamage( 13, 15 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 40 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, -50 );

			SetSkill( SkillName.EvalInt, 90.1, 105.0 );
			SetSkill( SkillName.Magery, 90.1, 105.0 );
			SetSkill( SkillName.MagicResist, 90.1, 105.0 );
			SetSkill( SkillName.Tactics, 90.1, 130.0 );
			SetSkill( SkillName.Wrestling, 90.1, 130.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 40;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.MedScrolls );
		}

		public DateTime m_AbilityDelay;

		public override void OnThink()
		{
			if ( DateTime.Now > m_AbilityDelay )
			{
				List<Mobile> list = BlueMonster.GetNearbyMobiles( this, 1, true );

				for( int i = list.Count - 1; i > -1; i-- )
				{
					if ( list[i] != null )
					{
						list[i].Direction = (Direction)(((int)list[i].Direction + 4) % 8);
						AOS.Damage( list[i], this, Utility.RandomMinMax( 20, 30 ), 60, 0, 40, 0, 0 );
					}
				}

				m_AbilityDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 30 ) );
			}

			base.OnThink();
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to.Direction == this.Direction )
				damage *= 4;
			else if ( (((int)to.Direction + 4) % 8) != (int)this.Direction )
				damage *= 2;
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public UWaterTidalForceElemental( Serial serial ) : base( serial )
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
