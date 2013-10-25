using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a renowned pixie corpse" )]
	public class PixieR : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public PixieR() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a Pixie ( renowned )";
			Body = 176;
			BaseSoundID = 0x467;

			SetStr( 360, 375 );
			SetDex( 580, 585 );
			SetInt( 740, 745 );

			SetHits( 9000, 9100 );

			SetDamage( 27, 38 );

			SetDamageType( ResistanceType.Physical, 75 );
            SetDamageType( ResistanceType.Cold, 25);

			SetResistance( ResistanceType.Physical, 70, 75 );
			SetResistance( ResistanceType.Fire, 65, 70 );
			SetResistance( ResistanceType.Cold, 70, 75 );
			SetResistance( ResistanceType.Poison, 60, 65 );
			SetResistance( ResistanceType.Energy, 55, 60 );

            SetSkill( SkillName.Anatomy, 2, 3 );
			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 107.1, 110.0 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 114.1, 115 );
			SetSkill( SkillName.Tactics, 119.1, 120.0 );
			SetSkill( SkillName.Wrestling, 112.1, 112.7 );

			Fame = 20000;
			Karma = 20000;

			VirtualArmor = 100;

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();

            PackItem( new FireRuby(2));
            PackItem( new FaeryDust(2));
		}
		
		public override void GenerateLoot()
		{
            AddLoot(LootPack.FilthyRich, 4);
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Gems, 2 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(2))
                {

                    case 1: c.DropItem(new DemonHuntersStandard()); break;
                    case 2: c.DropItem(new DragonJadeEarrings()); break;
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public PixieR( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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