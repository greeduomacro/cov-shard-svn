using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a renowned devourer of souls corpse" )]
	public class DevourerR : BaseCreature
	{
		[Constructable]
		public DevourerR() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Devourer of Souls( Renowned )";
			Body = 303;
			BaseSoundID = 357;

			SetStr( 910, 950 );
			SetDex( 130, 135 );
			SetInt( 230, 250 );

			SetHits( 4890, 5000 );

			SetDamage( 22, 26 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 50, 55 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 65, 70 );
			SetResistance( ResistanceType.Energy, 45, 50 );

			SetSkill( SkillName.EvalInt, 92.5, 100.0 );
			SetSkill( SkillName.Magery, 98.1, 100.0 );
			SetSkill( SkillName.Meditation, 91.5, 95.5 );
			SetSkill( SkillName.MagicResist, 94.1, 98.1 );
			SetSkill( SkillName.Tactics, 75.1, 85.0 );
			SetSkill( SkillName.Wrestling, 95.1, 100.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 64;

			PackNecroReg( 24, 45 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new EssenceAchievement()); break;

                    case 1: c.DropItem(new FireRuby(1)); break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new SummonersKilt()); break;

                    case 1: c.DropItem(new BlueDiamond(1)); break;
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override int Meat{ get{ return 3; } }

		public DevourerR( Serial serial ) : base( serial )
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