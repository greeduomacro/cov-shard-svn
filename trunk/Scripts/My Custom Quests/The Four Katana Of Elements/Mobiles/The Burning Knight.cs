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
	[CorpseName( "a Burnt corpse" )]
	public class TheBurningKnight : BaseCreature
	{
		[Constructable]
		public TheBurningKnight () : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "The Burning Knight";
			Body = 311;
			Hue = 38;
			BaseSoundID = 838;

			SetStr( 326, 455 );
			SetDex( 266, 285 );
			SetInt( 401, 525 );

			SetHits( 750, 1000 );

			SetDamage( 30, 40 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Fire, 80 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 120 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 90 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.EvalInt, 100 );
			SetSkill( SkillName.Magery, 100 );
			SetSkill( SkillName.MagicResist, 90 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 100 );

			Fame = 4500;
			Karma = -300;

			VirtualArmor = 30;

			AddItem( new LightSource() );

			PackItem( new SulfurousAsh( 20 ) );

			switch ( Utility.Random( 12 ) )
			{
				case 0: PackItem( new BurningKatana() ); break;
				case 1: PackItem( new FlamingKatana() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
			AddLoot( LootPack.Gems );
		}

		public TheBurningKnight( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 274 )
				BaseSoundID = 838;
		}
	}
}
