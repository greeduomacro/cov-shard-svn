// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a deep sea elemental corpse" )]
	public class UWaterDeepSeaElemental: BaseCreature
	{
		public override double DispelDifficulty{ get{ return 147.5; } }
		public override double DispelFocus{ get{ return 75.0; } }

		public override WeaponAbility GetWeaponAbility(){ return WeaponAbility.CrushingBlow; }

		[Constructable]
		public  UWaterDeepSeaElemental() : base( AIType.AI_Mage, FightMode.Weakest, 10, 1, 0.1, 0.2 )
		{
			Name = "a deep sea elemental";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 176, 205 );
			SetDex( 116, 135 );
			SetInt( 151, 175 );

			SetHits( 276, 293 );

			SetDamage( 12, 14 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, -50 );

			SetSkill( SkillName.EvalInt, 90.1, 105.0 );
			SetSkill( SkillName.Magery, 90.1, 105.0 );
			SetSkill( SkillName.MagicResist, 130.1, 145.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 40;
			CanSwim = true;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Potions );
		}

		public DateTime m_AuraDelay;

		public override void OnThink()
		{
			if ( DateTime.Now > m_AuraDelay )
			{
				Animate( 12, 10, 1, false, true, 0 );

				List<Mobile> list = BlueMonster.GetNearbyMobiles( this, 3, true );

				for( int i = list.Count - 1; i > -1; i-- )
				{
					if ( list[i] != null )
						AOS.Damage( list[i], this, Utility.RandomMinMax( 40, 60 ), 0, 0, 100, 0, 0 );

					if ( list[i] != null )
						AOS.Damage( list[i], this, Utility.RandomMinMax( 20, 40 ), 100, 0, 0, 0, 0 );					
				}

				m_AuraDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 30 ) );
			}

			base.OnThink();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public  UWaterDeepSeaElemental( Serial serial ) : base( serial )
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