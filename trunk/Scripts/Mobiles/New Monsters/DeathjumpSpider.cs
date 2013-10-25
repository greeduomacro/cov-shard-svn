using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a death jump spider corpse" )]
	public class DeathJumpSpider : BaseCreature
	{
		[Constructable]
		public DeathJumpSpider() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Death Jump spider";
			Body = 28;
			BaseSoundID = 0x388;
            Hue = 2953;

			SetStr( 160, 200 );
			SetDex( 160, 200 );
			SetInt( 72, 90 );

			SetHits( 460, 600 );
			SetMana( 0 );

			SetDamage( 15, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.Poisoning, 120 );
			SetSkill( SkillName.MagicResist, 120 );
			SetSkill( SkillName.Tactics, 120 );
			SetSkill( SkillName.Wrestling, 140 );

			Fame = 600;
			Karma = -600;

			VirtualArmor = 46;

			PackItem( new SpidersSilk( 10 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.MortalStrike;
        }

		public DeathJumpSpider( Serial serial ) : base( serial )
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