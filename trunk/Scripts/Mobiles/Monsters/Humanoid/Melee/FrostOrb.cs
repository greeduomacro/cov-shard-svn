using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a frost orb corpse" )]
	public class FrostOrb : BaseCreature
	{
		[Constructable]
		public FrostOrb () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Frost Orb";
			Body = 778;
			BaseSoundID = 377;
            Hue = 2062;

            SetStr(767, 945);
            SetDex(66, 75);
            SetInt(46, 70);

            SetHits(476, 552);

            SetDamage(20, 25);

            SetDamageType(ResistanceType.Physical, 30);
            SetDamageType(ResistanceType.Cold, 70);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 100);
            SetResistance(ResistanceType.Energy, 40, 50);

            SetSkill(SkillName.MagicResist, 125.1, 140.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

            Fame = 15000;
            Karma = -15000;

            VirtualArmor = 50;

			PackItem( new Nightshade( Utility.RandomMinMax( 2, 3 ) ) );
		}

        public override void GenerateLoot()
        {
            //AddLoot( LootPack.FilthyRich, 3 );
            AddLoot(LootPack.Rich, 3);
        }

        public override Poison PoisonImmune { get { return Poison.Regular; } }
        public override int TreasureMapLevel { get { return 3; } }

		public FrostOrb( Serial serial ) : base( serial )
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