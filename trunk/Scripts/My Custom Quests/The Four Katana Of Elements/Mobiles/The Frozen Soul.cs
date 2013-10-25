///////////////////////////////////
//===============================//
//Script created by: Triple      //
//===============================//
///////////////////////////////////

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a melted corpse" )]
	public class TheFrozenSoul : BaseCreature
	{
		[Constructable]
		public TheFrozenSoul () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "The Frozen Soul";
			Body = 155;
			Hue = 1152;
			BaseSoundID = 655;

			SetStr( 326, 455 );
			SetDex( 266, 285 );
			SetInt( 401, 525 );

			SetHits( 700, 1000 );

			SetDamage( 30, 40 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 80 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 120 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 100 );
			SetSkill( SkillName.Magery, 100 );
			SetSkill( SkillName.MagicResist, 90 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 100 );

			Fame = 4500;
			Karma = 300;

			VirtualArmor = 40;


			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new FrozenKatana() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
			AddLoot( LootPack.Gems );
		}

		public TheFrozenSoul( Serial serial ) : base( serial )
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
