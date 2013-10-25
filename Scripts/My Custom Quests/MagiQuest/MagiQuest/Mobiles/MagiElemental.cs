using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an earth elemental corpse" )]
	public class MagiElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public MagiElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Elemental of the Magi";
			Body = 14;
			BaseSoundID = 268;
			Hue = 1153;

			SetStr( 900, 1250 );
			SetDex( 66, 85 );
			SetInt( 71, 92 );

			SetHits( 5000, 5500 );

			SetDamage( 29, 36 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 75 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 15, 25 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 125.1, 145.0 );
			SetSkill( SkillName.Magery, 115.1, 120.0 );
			SetSkill( SkillName.EvalInt, 90.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 64;
			ControlSlots = 2;

			PackItem( new FertileDirt() );
			PackItem( new IronOre( 3 ) ); // TODO: Five small iron ore
			PackItem( new MandrakeRoot() );
			PackItem( new MagiOre() );
			
			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new MagiOre() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.Gems );
		}

		public override int TreasureMapLevel{ get{ return 1; } }

		public MagiElemental( Serial serial ) : base( serial )
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