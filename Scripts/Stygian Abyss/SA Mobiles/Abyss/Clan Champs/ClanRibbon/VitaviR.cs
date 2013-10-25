using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a glowing ratman corpse" )]
	public class VitaviR : BaseCreature
	{
		//public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public VitaviR() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Vitavi( Renowned )";
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 309, 345 );
			SetDex( 270, 287 );
			SetInt( 311, 343 );

			SetHits( 50000 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 80 );
            SetDamageType( ResistanceType.Cold, 20);

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 30, 45 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 89.1, 100.0 );
			SetSkill( SkillName.Tactics, 50.1, 75.0 );
			SetSkill( SkillName.Wrestling, 70.1, 72.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 64;

			PackReg( 6 );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosUltraRich, 3);
        }		

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new EssenceBalance()); break;

                    case 1: c.DropItem(new PowderedIron()); break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
            {
               
                    c.DropItem(new DemonBridleRing());
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public VitaviR( Serial serial ) : base( serial )
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
