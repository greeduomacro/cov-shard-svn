using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dread mare corpse" )]
	public class DreadMare : BaseMount
	{

		[Constructable]
		public DreadMare() : this( "a dread mare" )
		{
		}

		[Constructable]
        public DreadMare(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4)
		{

			BodyValue = 179;
			BaseSoundID = 0xA8;
			Hue = 1175;

            SetStr(721, 760);
            SetDex(101, 130);
            SetInt(386, 425);

			SetHits( 555, 648 );

			SetDamage( 20, 26 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Poison, 20 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 20, 40 );
			SetResistance( ResistanceType.Cold, 20, 40 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 80, 90 );

			SetSkill( SkillName.EvalInt, 30.5, 50.0 );
			SetSkill( SkillName.Magery, 42.4, 50.0 );
			SetSkill( SkillName.MagicResist, 92.6, 96.4 );
			SetSkill( SkillName.Tactics, 97.6, 109.1 );
			SetSkill( SkillName.Wrestling, 80.5, 95.8 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 105.0;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override Poison HitPoison { get { return Poison.Lethal; } }
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DreadMare( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
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