using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a gray goblin mage corpse" )]
	public class GrayGoblinMage : BaseCreature
	{
		//public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public GrayGoblinMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Gray goblin mage";
			Body = 334;
            Hue = 641;
			BaseSoundID = 0x45A;

			SetStr( 225, 285 );
			SetDex( 70, 90 );
			SetInt( 450, 500 );

			SetHits( 129, 151 );
			SetStam( 60, 80 );
			SetMana( 450, 500 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 22, 29 );
			SetResistance( ResistanceType.Fire, 37, 44 );
			SetResistance( ResistanceType.Cold, 31, 36 );
			SetResistance( ResistanceType.Poison, 38, 45 );
			SetResistance( ResistanceType.Energy, 10, 18 );

			SetSkill( SkillName.MagicResist, 124.7, 129.8 );
			SetSkill( SkillName.Tactics, 80.7, 86.9 );
			SetSkill( SkillName.Anatomy, 81.9, 89.4 );
			SetSkill( SkillName.Wrestling, 90.5, 104.2 );
            SetSkill(SkillName.Magery, 105.5, 119.1);
            SetSkill(SkillName.EvalInt, 94.9, 101.4);
            SetSkill(SkillName.Meditation, 91.7, 99);

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;

			AddItem(new Gold(295, 315));

			PackItem( new ThighBoots() );

			if ( 0.2 > Utility.RandomDouble() )
				PackItem( new BolaBall() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.1)
                c.DropItem(new GoblinBlood());
        }

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public GrayGoblinMage( Serial serial ) : base( serial )
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
