using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gibberling corpse" )]
	public class GibberlingMage : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}

		[Constructable]
		public GibberlingMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gibberling mage";
			Body = 307;
			BaseSoundID = 422;
                        Hue = 1109;

			SetStr( 141, 165 );
			SetDex( 101, 125 );
			SetInt( 156, 280 );

			SetHits( 85, 99 );
                        SetMana( 1000, 2000 );

			SetDamage( 12, 17 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 60 );

			SetResistance( ResistanceType.Physical, 85, 95 );
			SetResistance( ResistanceType.Fire, 85, 95 );
			SetResistance( ResistanceType.Cold, 85, 95 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 90, 110 );

			SetSkill( SkillName.MagicResist, 115.1, 120.0 );
                        SetSkill( SkillName.EvalInt, 90.0 );
			SetSkill( SkillName.Magery, 92.6, 97.5 );
			SetSkill( SkillName.Meditation, 200.0 );
			SetSkill( SkillName.Tactics, 67.6, 92.5 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 75;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
		}

		public override int TreasureMapLevel{ get{ return 1; } }

		public GibberlingMage( Serial serial ) : base( serial )
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