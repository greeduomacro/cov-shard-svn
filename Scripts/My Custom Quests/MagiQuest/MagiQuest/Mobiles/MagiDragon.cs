using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class MagiDragon : BaseCreature
	{
		[Constructable]
		public MagiDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Dragon of The Magi";
			Body = Utility.RandomList( 12, 59 );
			BaseSoundID = 362;
			Hue = 1153;

			SetStr( 900, 1250 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 5000, 5500 );

			SetDamage( 35, 45 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 55, 65 );

			SetSkill( SkillName.EvalInt, 79.2, 94.9 );
			SetSkill( SkillName.Magery, 115.1, 120.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 100, 120 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 70;
			
			PackItem( new MagiScroll() );
			
			Tamable = false;
										
		}

		public override void GenerateLoot()
		{
			PackItem( new Longsword() );
			PackGold( 1000 );
			PackScroll( 1 );
			PackArmor( 2, 5 );
			PackWeapon( 3, 5 );
			PackWeapon( 5, 5 );
			PackSlayer();
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Yellow : ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public MagiDragon( Serial serial ) : base( serial )
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