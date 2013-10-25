using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Straw Elemental corpse" )]
	public class StrawElemental : BaseCreature
	{
		[Constructable]
		public StrawElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Straw Elemental";
			Body = 13;
			BaseSoundID = 278;
            Hue = 1161;

			SetStr( 526, 615 );
			SetDex( 66, 85 );
			SetInt( 226, 350 );

			SetHits( 316, 369 );

			SetDamage( 17, 27 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Poison, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.EvalInt, 85.1, 100.0 );
			SetSkill( SkillName.Magery, 85.1, 100.0 );
			SetSkill( SkillName.Meditation, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 80.1, 95.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 12500;
			Karma = -12500;

			VirtualArmor = 60;
		}
        


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );

        switch ( Utility.Random( 10 ))

			{
                case 0: PackItem(new GoldStraw()); break;
               
			}

            
		}
        public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.25; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public StrawElemental( Serial serial ) : base( serial )
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