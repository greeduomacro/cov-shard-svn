using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a necro steed corpse" )]
	public class NecroSteed : BaseMount
	{
		[Constructable]
		public NecroSteed() : this( "a Necro steed" )
		{
		}

		[Constructable]
        public NecroSteed(string name) : base(name, 0x74, 0x3EA7, AIType.AI_Necromage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			BaseSoundID = 0xA8;
			Hue = 1194;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Energy, 70 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 55 );
			SetResistance( ResistanceType.Energy, 80, 90 );

            SetSkill(SkillName.Wrestling, 70, 80);
            SetSkill(SkillName.Tactics, 97.6, 100);
            SetSkill(SkillName.MagicResist, 85.3, 90);
            SetSkill(SkillName.Magery, 20.0, 50);
            SetSkill(SkillName.EvalInt, 20.0, 50);
            SetSkill(SkillName.Necromancy, 80, 90);
            SetSkill(SkillName.SpiritSpeak, 80, 90);

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 101.1;
            SkillsCap = 9000;


			switch ( Utility.Random( 3 ) )
			{
				case 0:
				{
					BodyValue = 116;
					ItemID = 16039;
					break;
				}
				case 1:
				{
					BodyValue = 178;
					ItemID = 16041;
					break;
				}
				case 2:
				{
					BodyValue = 179;
					ItemID = 16055;
					break;
				}
			}

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 3, 5 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			//AddLoot( LootPack.VampiricEmbraceScroll );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
            if (!Controlled)
				return 0x16A;

			return base.GetAngerSound();
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override bool CanAngerOnTame { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public override void OnThink()
        {
            base.OnThink();

            if (Combatant == null)
                return;

            if (Hits < HitsMax * 0.50)
            {
                Hue = 16385;
            }
            else if (Hits > HitsMax * 0.80)
            {
                Hue = 1194;
            }
        
                return;
        }


		public NecroSteed( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}