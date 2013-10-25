using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a lava elemental corpse" )]
	public class LavaElemental : BaseCreature
	{
		[Constructable]
		public LavaElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lava elemental";
			Body = 720; 

			SetStr( 465, 470 );
			SetDex( 175, 180 );
			SetInt( 385, 390 );

			SetHits( 275, 280 );

			SetDamage( 12, 18 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Fire, 90 );

			SetResistance( ResistanceType.Physical, 60, 65 );
			SetResistance( ResistanceType.Fire, 20, 25 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40, 45 );

			SetSkill( SkillName.Anatomy, 0 );
			SetSkill( SkillName.EvalInt, 80.5, 82.1 );
			SetSkill( SkillName.Magery, 82.1, 82.5 );
			SetSkill( SkillName.Meditation, 101.1, 101.8 );
			SetSkill( SkillName.MagicResist, 102.1, 102.5 );
			SetSkill( SkillName.Tactics, 83.5, 84.1 );
			SetSkill( SkillName.Wrestling, 80 );

			PackItem( new LesserPoisonPotion() );
			PackReg( 9 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.Gems, 2 );
			AddLoot( LootPack.MedScrolls );
		}

          public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {       
               c.DropItem(new LavaSerpenCrust());        
            }
            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(3))
                {
                    case 0: c.DropItem(new EssencePrecision()); break;
                    case 1: c.DropItem(new EssencePassion()); break;
                    case 2: c.DropItem(new EssenceOrder()); break;
                }
            }
        }

		public override bool HasBreath{ get{ return true; } } // fire breath enabled

		public override int GetIdleSound() { return 1549; } 
		public override int GetAngerSound() { return 1546; } 
		public override int GetHurtSound() { return 1548; } 
		public override int GetDeathSound()	{ return 1547; }

		public LavaElemental( Serial serial ) : base( serial )
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