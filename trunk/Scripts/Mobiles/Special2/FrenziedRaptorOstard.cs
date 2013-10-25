using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an Raptor corpse" )]
	public class FrenziedRaptorOstard : BaseMount
	{
		[Constructable]
		public FrenziedRaptorOstard() : this( "a Frenzied Raptor ostard" )
		{
		}

		[Constructable]
		public FrenziedRaptorOstard( string name ) : base( name, 0xDA, 0x3EA4, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			//Hue = Utility.RandomHairHue() | 0x8000;
            Hue = 2966;

            BaseSoundID = 0x275;

			SetStr( 100, 150 );
			SetDex( 100, 150 );
			SetInt( 50, 75 );

			SetHits( 200, 250 );
			SetMana( 0 );

			SetDamage( 13, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 75, 90 );
			SetSkill( SkillName.Tactics, 50, 75 );
			SetSkill( SkillName.Wrestling, 100, 120 );

			Fame = 300;
			Karma = 0;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 93.1;
		}

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			return 1.0;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
        public override bool CanAngerOnTame { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Ostard; } }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.BleedAttack;
        }

        public FrenziedRaptorOstard(Serial serial): base(serial)
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