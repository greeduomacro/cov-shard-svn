// Created by Peoharen
using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an electric eel corpse" )]
	public class UWaterElectricEel : AuraCreature
	{
	
		[Constructable]
		public UWaterElectricEel() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			AuraType = ResistanceType.Energy;

			Name = "an electric eel";
			Body = 0x15;
			Hue = UWater.RandomHue();
			BaseSoundID = 219;

			SetStr( 236, 265 );
			SetDex( 106, 130 );
			SetInt( 116, 135 );

			SetHits( 212, 229 );
			SetMana( 0 );

			SetDamage( 12, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 40, 45 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 70, 90 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Poisoning, 70.1, 100.0 );
			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 95.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 110.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 32;

			PackItem( new Bone() );
			// TODO: Body parts
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 15; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public UWaterElectricEel( Serial serial ) : base( serial )
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