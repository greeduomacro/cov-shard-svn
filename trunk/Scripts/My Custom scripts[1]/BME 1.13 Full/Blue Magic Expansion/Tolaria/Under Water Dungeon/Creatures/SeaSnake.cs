// Created by Peoharen
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a snake corpse" )]
	public class UWaterSeaSnake : BaseCreature
	{
		[Constructable]
		public UWaterSeaSnake() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sea snake";
			Body = 52;
			Hue = UWater.RandomHue();
			BaseSoundID = 0xDB;

			SetStr( 72, 84 );
			SetDex( 66, 75 );
			SetInt( 56, 60 );

			SetHits( 65, 69 );
			SetMana( 0 );

			SetDamage( 6, 9 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Poison, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.Poisoning, 50.1, 70.0 );
			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 49.3, 64.0 );
			SetSkill( SkillName.Wrestling, 49.3, 64.0 );

			Fame = 300;
			Karma = -300;

			VirtualArmor = 16;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Eggs; } }

		public UWaterSeaSnake( Serial serial ) : base( serial )
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