using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Commands; 


namespace Server.Mobiles
{
	[CorpseName( "The Evil Santa's Corpes" )]
	public class CrazySanta : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.MortalStrike : WeaponAbility.WhirlwindAttack;
		}

		public override bool IgnoreYoungProtection { get { return Core.ML; } }

		[Constructable]
		public CrazySanta() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Crazy Santa Clause";
			Title = "Of Red Christmas";
			Body = 400;
			Hue = 33770;
			BaseSoundID = 343;

			SetStr( 401, 520 );
			SetDex( 81, 90 );
			SetInt( 401, 520 );

			SetHits( 678, 695 );

			SetDamage( 50, 120 );

			SetDamageType( ResistanceType.Cold, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 80 );

			SetSkill( SkillName.EvalInt, 200.0 );
			SetSkill( SkillName.Magery, 200.0 );
			SetSkill( SkillName.Meditation, 200.0 );
			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 200.0 );

			Fame = -1500;
			Karma = 550000;

			VirtualArmor = 40;

                  PackItem( new SantasHat() );
				  
				           if (1 > Utility.RandomDouble())

                                                   switch (Utility.Random(24))
                                                   {
                                                       case 0: PackItem(new MaceOfWinter());
                                                           break;
                                                       case 1: PackItem(new ChristmasKatana());
                                                           break;
                                                       case 2: PackItem(new SantasStaff());
                                                           break;
                                                       case 3: PackItem(new ArmsOfChristmas());
                                                           break;
                                                       case 4: PackItem(new ChestOfChristmas());
                                                           break;
                                                       case 5: PackItem(new GlovesOfChristmas());
                                                           break;
                                                       case 6: PackItem(new GorgetOfChristmas());
                                                           break;
                                                       case 7: PackItem(new HelmOfChristmas());
                                                           break;
                                                       case 8: PackItem(new LegsOfChristmas());
                                                           break;
                                                       case 9: PackItem(new HelmOfWinter());
                                                           break;
                                                       case 10: PackItem(new LegsOfWinter());
                                                           break;
                                                       case 11: PackItem(new FemaleChestOfWinter());
                                                           break;
                                                       case 12: PackItem(new GlovesOfWinter());
                                                           break;
                                                       case 13: PackItem(new ArmsOfWinter());
                                                           break;
                                                       case 14: PackItem(new ChestOfWinter());
                                                           break;
                                                       case 16: PackItem(new XmasArms());
                                                           break;
                                                       case 17: PackItem(new XmasChest());
                                                           break;
                                                       case 18: PackItem(new XmasGloves());
                                                           break;
                                                       case 19: PackItem(new XmasHelm());
                                                           break;
                                                       case 20: PackItem(new XmasLegs());
                                                           break;
                                                       case 21: PackItem(new XmasHalberd());
                                                           break;
                                                       case 22: PackItem(new SwordOfChristmas());
                                                           break;
                                                       case 23: PackItem(new BowOfChristmas());
                                                           break;
                                                   }
	

                  FacialHairItemID = 8267;
                  FacialHairHue = 1153;

			LongPants legs = new LongPants();
			legs.Hue = 1157;
			legs.Movable = false;
			AddItem( legs );

			FancyShirt chest = new FancyShirt();
			chest.Hue = 1157;
			chest.Movable = false;
			AddItem( chest );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 1153;
			gloves.Movable = false;
			AddItem( gloves );

			ElvenBoots boots = new ElvenBoots();
			boots.Hue = 1153;
			boots.Movable = false;
			AddItem( boots );

                  Item hair = new Item( Utility.RandomList( 8252 ) );
			hair.Hue = 1153;
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
			
			BodySash bodysash = new BodySash();
			bodysash.Hue = 1153;
			bodysash.Movable = false;
			AddItem ( bodysash );
			
			HalfApron halfapron = new HalfApron();
			halfapron.Hue = 1153;
			halfapron.Movable = false;
			AddItem ( halfapron );

			Cloak cloak = new Cloak();
			cloak.Hue = 1153;
			cloak.Movable = false;
			AddItem ( cloak );
					
			PackGold( 60000, 100000);

                }

		public override bool BardImmune{ get{ return !Core.ML; } }
		public override bool Unprovokable{ get{ return Core.ML; } }
		public override bool Uncalmable{ get{ return Core.ML; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }
            public override bool AlwaysMurderer{ get{ return true; } }
			
			public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.Average );
		}

		private static bool m_InHere;
		
		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && from != this && !m_InHere )
			{
				m_InHere = true;
				AOS.Damage( from, this, Utility.RandomMinMax( 5, 15 ), 100, 0, 0, 0, 0 );

				MovingEffect( from, 0x232B, 10, 0, false, false, 0, 0 );
				PlaySound( 0x491 );

				if ( 0.05 > Utility.RandomDouble() )
					Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( ThrowGiftBox_Callback ), from );

				m_InHere = false;
			}
		}

		public virtual void ThrowGiftBox_Callback( object state )
		{
			Mobile from = (Mobile)state;
			Map map = from.Map;

			if ( map == null )
				return;

			int count = Utility.RandomMinMax( 1, 2 );

			for ( int i = 0; i < count; ++i )
			{
				int x = from.X + Utility.RandomMinMax( -1, 1 );
				int y = from.Y + Utility.RandomMinMax( -1, 1 );
				int z = from.Z;

				if ( !map.CanFit( x, y, z, 16, false, true ) )
				{
					z = map.GetAverageZ( x, y );

					if ( z == from.Z || !map.CanFit( x, y, z, 16, false, true ) )
						continue;
				}

				PresentBomb3 giftbox = new PresentBomb3();

				giftbox.Name = "Exploding Present From Santa";
				giftbox.ItemID = Utility.Random( 0x232B, 2 );

				giftbox.MoveToWorld( new Point3D( x, y, z ), map );
			}
		}


		public CrazySanta( Serial serial ) : base( serial )
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