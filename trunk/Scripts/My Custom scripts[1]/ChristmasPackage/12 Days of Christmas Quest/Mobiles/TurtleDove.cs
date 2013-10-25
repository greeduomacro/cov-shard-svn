using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a TurtleDove corpse" )]
	public class TurtleDove : BaseCreature
	{
		[Constructable]
		public TurtleDove() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
            Name = "A TurtleDove";
			Body = 6;
			BaseSoundID = 0x1B;
            Hue = 1873;


			SetStr( 10 );
			SetDex( 25, 35 );
			SetInt( 10 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Wrestling, 4.2, 6.4 );
			SetSkill( SkillName.Tactics, 4.0, 6.0 );
			SetSkill( SkillName.MagicResist, 4.0, 5.0 );

			SetFameLevel( 1 );
			SetKarmaLevel( 0 );

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 100.0;
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public TurtleDove(Serial serial)
            : base(serial)
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
	

	
