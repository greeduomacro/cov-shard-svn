using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Scorched Reapers corpse" )]
	public class ScorchedReaper : BaseCreature
	{
		[Constructable]
		public ScorchedReaper() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Scorched Reaper";
			Body = 47;
			BaseSoundID = 442;
            Hue = 1109;

			SetStr( 500, 800 );
			SetDex( 200, 200 );
			SetInt( 250, 500 );

			SetHits( 100, 200 );
			SetStam( 0 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 50, 75 );
			SetResistance( ResistanceType.Fire, 10, 25 );
			SetResistance( ResistanceType.Cold, 50, 75 );
			SetResistance( ResistanceType.Poison, 80, 100 );
			SetResistance( ResistanceType.Energy, 65, 75 );

			SetSkill( SkillName.EvalInt, 100.0, 125.0 );
			SetSkill( SkillName.Magery, 100.0, 125.0 );
			SetSkill( SkillName.MagicResist, 100.1, 125.0 );
			SetSkill( SkillName.Tactics, 100.0, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;

			PackItem( new Log( 10 ) );
			PackItem( new MandrakeRoot( 5 ) );
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Rich);
          
            switch (Utility.Random(10))
            {
                case 0: PackItem(new ReaperWood()); break;
                
            }


        }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override int TreasureMapLevel{ get{ return 2; } }
		public override bool DisallowAllMoves{ get{ return true; } }

        public ScorchedReaper(Serial serial)
            : base(serial)
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