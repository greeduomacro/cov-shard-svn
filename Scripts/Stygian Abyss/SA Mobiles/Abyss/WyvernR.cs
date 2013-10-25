using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a renowned wyvern corpse" )]
	public class WyvernR : BaseCreature
	{
		[Constructable]
		public WyvernR () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Wyvern( Renowned )";
			Body = 62;
            Hue = 1258;
			BaseSoundID = 362;

			SetStr( 1370, 1425 );
			SetDex( 103, 155 );
			SetInt( 835, 1005 );

			SetHits( 4700, 4750 );

			SetDamage( 29, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 70 );
			SetResistance( ResistanceType.Fire, 81, 90 );
			SetResistance( ResistanceType.Cold, 72, 80 );
			SetResistance( ResistanceType.Poison, 65, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

            SetSkill(SkillName.EvalInt, 106.5, 111.5);
            SetSkill(SkillName.Magery, 107.5, 109.5);
			SetSkill( SkillName.Meditation, 63.1, 80.0 );
			SetSkill( SkillName.MagicResist, 125.8, 130.5 );
			SetSkill( SkillName.Tactics, 112.1, 125.0 );
			SetSkill( SkillName.Wrestling, 108.5, 110.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 70;
			
			//PackItem( new LesserPoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.MedScrolls );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new EssenceDiligence()); break;

                    case 1: c.DropItem(new FairyDragonWing()); break;
                }

                if (Utility.RandomDouble() < 0.10)
                {
                    switch (Utility.Random(2))
                    {
                        case 0: c.DropItem(new DraconicOrbKey()); break;

                        case 1: c.DropItem(new UntransTome()); break;
                    }
                }

                if (Utility.RandomDouble() < 0.05)
                {
                   
                        c.DropItem(new AnimatedLegsoftheInsaneTinker()); 
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override bool HasBreath { get { return true; } } // fire breath enabled
        public override bool AutoDispel { get { return !Controlled; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		public override int GetAttackSound()
		{
			return 713;
		}

		public override int GetAngerSound()
		{
			return 718;
		}

		public override int GetDeathSound()
		{
			return 716;
		}

		public override int GetHurtSound()
		{
			return 721;
		}

		public override int GetIdleSound()
		{
			return 725;
		}

		public WyvernR( Serial serial ) : base( serial )
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