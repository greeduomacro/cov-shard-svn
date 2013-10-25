using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a glowing ratman corpse" )]
	public class Rakktavi : BaseCreature
	{
		//public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public Rakktavi() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Rakktavi ( Renowned )";
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 115, 120 );
			SetDex( 275, 280 );
			SetInt( 325, 330 );

			SetHits( 50000 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 20, 25 );
			SetResistance( ResistanceType.Cold, 35, 40 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 65.1, 67.0 );
			SetSkill( SkillName.Tactics, 65.1, 70.0);
			SetSkill( SkillName.Wrestling, 85.0, 90.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 64;

			PackReg( 6 );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich, 3 );
			AddLoot( LootPack.LowScrolls );
		}

         public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(4))
                {
                    case 0: c.DropItem(new AbyssalCloth()); break;
                    case 1: c.DropItem(new DelicateScales()); break;
                    case 2: c.DropItem(new EssenceBalance()); break;
                    case 3: c.DropItem(new CrushedGlass()); break;

                }
            }
             if (Utility.RandomDouble() < 0.05)
             {
                 switch (Utility.Random(4))
                 {
                     case 0: c.DropItem(new CalvarysFolly()); break;
                     case 1: c.DropItem(new TorcoftheGuardians()); break;
                 }
             }
         }

         public override bool GivesSAArtifact { get { return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public Rakktavi( Serial serial ) : base( serial )
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
