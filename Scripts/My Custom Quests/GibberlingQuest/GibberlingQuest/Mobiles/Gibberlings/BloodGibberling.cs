using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gibberling corpse" )]
	public class BloodGibberling : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public BloodGibberling() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a blood gibberling";
			Body = 307;
			BaseSoundID = 422;
                        Hue = 1157;

			SetStr( 241, 265 );
			SetDex( 101, 125 );
			SetInt( 6, 8 );

			SetHits( 285, 399 );

			SetDamage( 12, 17 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 60 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 45, 55 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Energy, 70, 80 );

			SetSkill( SkillName.MagicResist, 95.1, 100.0 );
			SetSkill( SkillName.Tactics, 107.6, 110.5 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 70;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int TreasureMapLevel{ get{ return 2; } }

		public BloodGibberling( Serial serial ) : base( serial )
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