using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a glowing ratman corpse" )]
	public class TiktaviR : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public TiktaviR() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Tiktavi( Renowned )";
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 315 );
			SetDex( 135, 140 );
			SetInt( 240, 245 );

			SetHits( 50000 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 45 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 40.1, 40.5 );
			SetSkill( SkillName.Tactics, 73.1, 75.0 );
			SetSkill( SkillName.Wrestling, 66.1, 70.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 64;

			PackReg( 6 );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
			AddLoot( LootPack.LowScrolls );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(4))
                {
                    case 0: c.DropItem(new EssenceBalance()); break;
                    case 1: c.DropItem(new BlueDiamond(2)); break;
                    case 2: c.DropItem(new ArcanicRuneStone()); break;
                    case 3: c.DropItem(new ElvenFletchings()); break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
            {

                c.DropItem(new BasiliskHideBreastplate());

            }
        }
        
        public override bool GivesSAArtifact { get { return true; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public TiktaviR( Serial serial ) : base( serial )
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

			if ( Body == 42 )
			{
				Body = 0x8F;
				Hue = 0;
			}
		}
	}
}
