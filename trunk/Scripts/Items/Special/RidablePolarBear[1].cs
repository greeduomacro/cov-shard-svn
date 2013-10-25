
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a polar bear corpse" )]
	public class RidablePolar : BaseMount
	{
		[Constructable]
		public RidablePolar() : this( "a rideable polar bear" )
		{
		}

		[Constructable]
		public RidablePolar( string name ) : base( name, 0xD5 , 16069 , AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0xA3;
            Hue = 1153;

			SetStr( 210, 300 );
			SetDex( 75, 120 );
			SetInt( 20, 40 );

			SetHits( 400, 470 );
			SetMana( 0 );

			SetDamage( 20, 50 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 30.0 );
			SetSkill( SkillName.Tactics, 30.0 );
			SetSkill( SkillName.Wrestling, 30.0 );

			//Fame = 300;
			//Karma = 0;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 100;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 10; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public RidablePolar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}