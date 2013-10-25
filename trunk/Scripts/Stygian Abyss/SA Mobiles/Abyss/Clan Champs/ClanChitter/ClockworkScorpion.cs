using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a clockwork scorpion corpse" )]
	public class ClockworkScorpion : BaseCreature
	{
		[Constructable]
		public ClockworkScorpion() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Clockwork scorpion";
			Body = 717;
			BaseSoundID = 397;

			SetStr( 233, 235 );
			SetDex( 90 );
			SetInt( 31, 35 );

			SetHits( 75, 80 );
			SetMana( 1, 5 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 80, 85 );
			SetResistance( ResistanceType.Fire, 20, 25 );
			SetResistance( ResistanceType.Cold, 65, 70 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.Poisoning, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 31.6, 35.0 );
			SetSkill( SkillName.Tactics, 70.1, 75.0 );
			SetSkill( SkillName.Wrestling, 57.4, 60.0 );

			Fame = 2000;
			Karma = -2000;

			VirtualArmor = 48;

			PackItem( new LesserPoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

		public ClockworkScorpion( Serial serial ) : base( serial )
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