using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire bat corpse" )]
	public class FireBat : BaseCreature
	{
		[Constructable]
		public FireBat() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Fire bat";
			Body = 317;
			BaseSoundID = 0x270;
            Hue = 1259;

			SetStr( 182, 220 );
			SetDex( 182, 220 );
			SetInt( 52, 80 );

			SetHits( 600, 660 );

			SetDamage( 17, 19 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 80 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 120 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 20000;
			Karma = -20000;
            Tamable = false;

            VirtualArmor = 36;
		}

       

        public override bool HasBreath { get { return true; } } // fire breath enabled
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Daemon; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override int GetIdleSound()
		{
			return 0x29B;
		}

		public FireBat( Serial serial ) : base( serial )
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