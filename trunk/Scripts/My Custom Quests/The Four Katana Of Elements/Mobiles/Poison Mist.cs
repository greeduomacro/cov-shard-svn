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
	[CorpseName( "a poison liquid" )]
	public class PoisonMist : BaseCreature
	{
		[Constructable]
		public PoisonMist () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "A Poison Mist";
			Body = 58;
			Hue = 367;
			BaseSoundID = 655;

			SetStr( 326, 455 );
			SetDex( 266, 285 );
			SetInt( 401, 525 );

			SetHits( 700, 1000 );

			SetDamage( 30, 40 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 100 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 120 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0 );
			SetSkill( SkillName.MagicResist, 100 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 4500;
			Karma = 1000;

			VirtualArmor = 5;


			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new PoisonKatana() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
			AddLoot( LootPack.Gems );
		}

		public PoisonMist( Serial serial ) : base( serial )
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
