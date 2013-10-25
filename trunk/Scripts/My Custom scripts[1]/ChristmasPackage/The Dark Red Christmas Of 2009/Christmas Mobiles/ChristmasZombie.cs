using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of a ChristmasZombie" )]
              public class ChristmasZombie : Zombie
              {
                                 [Constructable]
                                    public ChristmasZombie() : base()
                            {
                                               Name = "ChristmasZombie";
                                               Hue = 64;
                                               //Body = 3; // Uncomment these lines and input values
                                               //BaseSoundID = 471; // To use your own custom body and sound.
                                               SetStr(400, 450);
                                               SetDex(210, 250);
                                               SetInt(310, 330);

                                               SetHits(2800, 3000);

                                               SetDamage(20, 25);

                                               SetDamageType(ResistanceType.Physical, 100);
                                               SetDamageType(ResistanceType.Energy, 25);
                                               SetDamageType(ResistanceType.Poison, 20);
                                               SetDamageType(ResistanceType.Energy, 20);

                                               SetResistance(ResistanceType.Physical, 100);
                                               SetResistance(ResistanceType.Fire, 70);
                                               SetResistance(ResistanceType.Cold, 70);
                                               SetResistance(ResistanceType.Poison, 70);
                                               SetResistance(ResistanceType.Energy, 70);

                                               SetSkill(SkillName.Magery, 100.0);
                                               SetSkill(SkillName.MagicResist, 120.0);
                                               SetSkill(SkillName.Tactics, 100.0);
                                               SetSkill(SkillName.Wrestling, 100.0);

                                               Fame = 20000;
                                               Karma = -20000;

                                               VirtualArmor = 65;


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
	

                            }
                                 public override Poison HitPoison{ get{ return Poison. Regular ; } }
                                 public override bool AlwaysMurderer{ get{ return true; } }

public ChristmasZombie( Serial serial ) : base( serial )
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
