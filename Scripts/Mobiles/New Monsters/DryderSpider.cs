using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a dryder spider corpse" )]
	public class DryderSpider : BaseCreature
	{
		[Constructable]
		public DryderSpider () : base( AIType.AI_Necromage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Dryder spider";
			Body = 173;
			BaseSoundID = 1170;
            Hue = 516;

			SetStr( 392, 440 );
			SetDex( 252, 292 );
			SetInt( 572, 620 );

			SetHits( 1118, 1132 );

			SetDamage( 25, 27 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

            SetResistance(ResistanceType.Physical, 85);
            SetResistance(ResistanceType.Fire, 85);
            SetResistance(ResistanceType.Cold, 85);
            SetResistance(ResistanceType.Poison, 120);
            SetResistance(ResistanceType.Energy, 85);

			//SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Necromancy, 120.0 );
            SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Meditation, 100 );
			SetSkill( SkillName.MagicResist, 120 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 140 );

			Fame = 5000;
			Karma = -5000;
            Tamable = false;

			VirtualArmor = 56;

			PackItem( new SpidersSilk( 18 ) );
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosUltraRich, 3);
        }		

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 3; } }

		public DryderSpider( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;
		}
	}
}