using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Rotting Shadow Zombie corpse" )]
	public class ShadowZombie : BaseCreature
	{
		[Constructable]
		public ShadowZombie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Shadow Zombie";
			Body = 3;
            Hue = Utility.RandomList(1109, 1108, 1107, 1104, 1103, 1102);
			BaseSoundID = 471;

			SetStr( 60, 100 );
			SetDex( 40, 70 );
			SetInt( 50, 70 );

			SetHits( 40, 60 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 15, 20 );

			SetSkill( SkillName.MagicResist, 25.1, 60.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.Wrestling, 45.1, 60.0 );

			Fame = 900;
			Karma = -900;

			VirtualArmor = 25;

			PackItem( new Bone() );
			// TODO: body parts
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

        public ShadowZombie(Serial serial)
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