using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a fire ant corpse" )]
	public class FireAnt : BaseCreature
	{
		[Constructable]
		public FireAnt() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire ant";
			Body = 738; 

			SetStr( 200, 250 );
			SetDex( 110, 115 );
			SetInt( 15, 30 );

			SetHits( 250, 290 );

			SetDamage( 15, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 60 );

			SetResistance( ResistanceType.Physical, 45, 52 );
			SetResistance( ResistanceType.Fire, 95, 97 );
			SetResistance( ResistanceType.Cold, 36, 42 );
			SetResistance( ResistanceType.Poison, 37, 45 );
			SetResistance( ResistanceType.Energy, 36, 44 );

			SetSkill( SkillName.Anatomy, 0 );
			SetSkill( SkillName.MagicResist, 46.7, 58.2 );
			SetSkill( SkillName.Tactics, 71.9, 81.8 );
			SetSkill( SkillName.Wrestling, 71.5, 83.4 );

            PackItem(new SearedFireAntGoo());

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.05)
            {
                c.DropItem(new EssencePrecision());
                    
            }
        }
            
		public override int GetIdleSound() { return 846; } 
		public override int GetAngerSound() { return 849; } 
		public override int GetHurtSound() { return 852; } 
		public override int GetDeathSound()	{ return 850; }

		public FireAnt( Serial serial ) : base( serial )
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