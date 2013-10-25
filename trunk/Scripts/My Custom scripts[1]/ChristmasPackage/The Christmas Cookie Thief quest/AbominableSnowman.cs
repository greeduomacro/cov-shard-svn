using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "corpse of an abominable snowman" )]
	public class AbominableSnowman : BaseCreature
	{
		[Constructable]
		public AbominableSnowman() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an Abominable Snowman";
			Body = 792;
			Hue = 1153;
			BaseSoundID = 0x165;

			SetStr( 1100 );
			SetDex( 151, 175 );
			SetInt( 171, 220 );

			SetHits( 3700 );

			SetDamage( 34, 36 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Fire, 20 );
			SetDamageType( ResistanceType.Energy, 20 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 90 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.EvalInt, 77.6, 87.5 );
			SetSkill( SkillName.Magery, 77.6, 87.5 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 44;

			PackItem( new AbominableSnowmansFur() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
		}

		public override bool Unprovokable{ get{ return true; } }
		public override bool Uncalmable{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 6; } }

		public AbominableSnowman( Serial serial ) : base( serial )
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