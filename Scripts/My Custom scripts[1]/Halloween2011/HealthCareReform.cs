using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "HealthCareReform corpse" )]
	public class HealthCareReform : BaseCreature
	{
		[Constructable]
		public HealthCareReform () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a HealthCareReform";
			Hue = 1284;
            Body = 155;
			BaseSoundID = 263;

			SetStr( 726, 715 );
			SetDex( 166, 185 );
			SetInt( 361, 435 );

			SetHits( 13256, 13309 );

			SetDamage( 12, 18 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Poison, 90 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.EvalInt, 80.1, 95.0 );
			SetSkill( SkillName.Magery, 80.1, 95.0 );
			SetSkill( SkillName.Meditation, 80.2, 120.0 );
			SetSkill( SkillName.Poisoning, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 85.2, 115.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 70.1, 90.0 );

			Fame = 12500;
			Karma = -12500;

			VirtualArmor = 70;

			PackItem( new Nightshade( 4 ) );
			PackItem( new SmellyPumpkinBombS() );
            PackItem(new SmellyPumpkinBombM());
            PackItem(new SmellyPumpkinBombL());
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.75; } }

		//public override int TreasureMapLevel{ get{ return 5; } }

        public HealthCareReform(Serial serial)
            : base(serial)
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