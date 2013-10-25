// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	[CorpseName( "a skittering hopper corpse" )]
	public class BlueSkitteringHopper : BlueMonster
	{
		public override TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 5.0 ); } }
		public override Type SpellToCast{ get{ return typeof( ThrustKickMove ); } }

		[Constructable]
		public BlueSkitteringHopper() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a skittering hopper";
			Body = 302;
			BaseSoundID = 959;

			SetStr( 61, 85 );
			SetDex( 111, 135 );
			SetInt( 46, 70 );

			SetHits( 131, 145 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 30.1, 45.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.Wrestling, 70.1, 90.0 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 12;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int TreasureMapLevel{ get{ return 1; } }

		public BlueSkitteringHopper( Serial serial ) : base( serial )
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