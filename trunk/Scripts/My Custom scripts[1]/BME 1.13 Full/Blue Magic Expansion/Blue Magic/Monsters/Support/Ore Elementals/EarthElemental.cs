// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class BlueEarthElemental : BaseCreature
	{
		// +50
		public override double DispelDifficulty{ get{ return 167.5; } }
		public override double DispelFocus{ get{ return 95.0; } }

		[Constructable]
		public BlueEarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an earth elemental";
			Body = 14;
			BaseSoundID = 268;

			SetStr( 126, 155 );
			SetDex( 66, 85 );
			SetInt( 71, 92 );

			// +100
			SetHits( 176, 193 );

			SetDamage( 9, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			// +20%
			SetResistance( ResistanceType.Physical, 50, 55 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 35, 45 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 34;
			ControlSlots = 3;

			PackItem( new FertileDirt( Utility.RandomMinMax( 4, 8 ) ) );
			PackItem( new MandrakeRoot() );

			// +5
			Item ore = new IronOre( 10 );
			ore.ItemID = 0x19B7;
			PackItem( ore );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

		private DateTime m_EarthGrabDelay;
		public static List<Mobile> GrabbedList = new List<Mobile>();

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_EarthGrabDelay )
			{
				/*
				if ( Combatant != null && !GrabbedList.Contains( Combatant ) )
				{
					Combatant.CantWalk = true;
					GrabbedList.Add( Combatant );
				}
				*/

				m_EarthGrabDelay = DateTime.Now + TimeSpan.FromSeconds( Utility.Random( 6, 12 ) );
			}

			base.OnActionCombat();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }

		public BlueEarthElemental( Serial serial ) : base( serial )
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