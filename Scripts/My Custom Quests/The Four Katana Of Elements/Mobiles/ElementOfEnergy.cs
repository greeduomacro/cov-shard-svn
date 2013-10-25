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
	[CorpseName( "a Electric Corpse" )]
	public class ElementOfEnergy : BaseCreature
	{
		[Constructable]
		public ElementOfEnergy () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Element Of Energy";
			Body = 316;
			Hue = 420;
			BaseSoundID = 655;

			SetStr( 326, 455 );
			SetDex( 266, 285 );
			SetInt( 401, 525 );

			SetHits( 700, 1000 );

			SetDamage( 30, 50 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Energy, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 120 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0, 115.0 );
			SetSkill( SkillName.MagicResist, 90.2, 120.0 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 120 );

			Fame = 4500;
			Karma = 1000;

			VirtualArmor = 60;


			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new LightningKatana() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
		}

		public ElementOfEnergy( Serial serial ) : base( serial )
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
