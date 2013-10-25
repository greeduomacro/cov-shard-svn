using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a Pack wolf corpse" )]
	
	public class PackWolf : BaseCreature
	{
		[Constructable]
		public PackWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Pack wolf";
			Body = 23;
			Hue = 1104;
			BaseSoundID = 0xE5;

			SetStr( 300, 400 );
			SetDex( 81, 105 );
			SetInt( 80, 120 );

			SetHits( 400, 600 );
			SetMana( 50 );

			SetDamage( 18, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 93.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 7; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public PackWolf(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}