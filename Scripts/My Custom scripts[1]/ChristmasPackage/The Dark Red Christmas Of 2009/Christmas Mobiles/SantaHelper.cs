using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Commands; 


namespace Server.Mobiles
{
	[CorpseName( "The Evil Santa's Corpes" )]
	public class SantaHelper : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.MortalStrike : WeaponAbility.WhirlwindAttack;
		}

		public override bool IgnoreYoungProtection { get { return Core.ML; } }

		[Constructable]
		public SantaHelper() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Santa's Evil Little Helper";
			Body = 400;
			Hue = 33770;
			BaseSoundID = 343;

			SetStr( 301, 420 );
			SetDex( 81, 90 );
			SetInt( 301, 320 );

			SetHits( 478, 595 );

			SetDamage( 40, 120 );

			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 80 );

			SetSkill( SkillName.EvalInt, 200.0 );
			SetSkill( SkillName.Magery, 200.0 );
			SetSkill( SkillName.Meditation, 200.0 );
			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 200.0 );

			Fame = -1500;
			Karma = 50000;

			VirtualArmor = 40;
       
				  PackItem( new BowOfChristmas() );

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
	

            JesterHat hat = new JesterHat();
			hat.Name = "Elf Hat";
			hat.Hue = 64;
			hat.Movable = false;
			AddItem( hat );

			ElvenPants legs = new ElvenPants();
			legs.Hue = 64;
			legs.Movable = false;
			AddItem( legs );

			FancyShirt chest = new FancyShirt();
			chest.Hue = 64;
			chest.Movable = false;
			AddItem( chest );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 64;
			gloves.Movable = false;
			AddItem( gloves );

			ElvenBoots boots = new ElvenBoots();
			boots.Hue = 64;
			boots.Movable = false;
			AddItem( boots );

			
			BodySash bodysash = new BodySash();
			bodysash.Hue = 64;
			bodysash.Movable = false;
			AddItem ( bodysash );
			
			HalfApron halfapron = new HalfApron();
			halfapron.Hue = 64;
			halfapron.Movable = false;
			AddItem ( halfapron );

			Cloak cloak = new Cloak();
			cloak.Hue = 64;
			cloak.Movable = false;
			AddItem ( cloak );
			
			PackGold( 60000, 100000);

                }

		public override void OnDeath( Container c )
		{
		if(5 > Utility.Random( 100 ) )
		c.DropItem( new LegacyOfTheDreadLord() );
		base.OnDeath( c );		

		}
		public override bool BardImmune{ get{ return !Core.ML; } }
		public override bool Unprovokable{ get{ return Core.ML; } }
		public override bool Uncalmable{ get{ return Core.ML; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }
            public override bool AlwaysMurderer{ get{ return true; } }


		public SantaHelper( Serial serial ) : base( serial )
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