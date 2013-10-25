using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gibberling corpse" )]
	public class GibberlingLord : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}

		[Constructable]
		public GibberlingLord() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gibberling lord";
			Body = 307;
			BaseSoundID = 422;
                        Hue = 1360;

			SetStr( 141, 265 );
			SetDex( 101, 225 );
			SetInt( 156, 180 );

			SetHits( 85, 99 );

			SetDamage( 13, 20 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 30 );

			SetResistance( ResistanceType.Physical, 85, 95 );
			SetResistance( ResistanceType.Fire, 85, 95 );
			SetResistance( ResistanceType.Cold, 85, 95 );
			SetResistance( ResistanceType.Poison, 85, 95 );
			SetResistance( ResistanceType.Energy, 85, 95 );

			SetSkill( SkillName.MagicResist, 115.1, 120.0 );
			SetSkill( SkillName.Tactics, 107.6, 120.5 );
			SetSkill( SkillName.Wrestling, 110.1, 120.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
                        AddLoot( LootPack.Average );
                        AddLoot( LootPack.UltraRich );
		}

		public override int TreasureMapLevel{ get{ return 5; } }

		public GibberlingLord( Serial serial ) : base( serial )
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