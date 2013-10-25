 //Created by Mitty

using System;
using Server;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of a Ripper" )]
              public class TheRipper : BaseCreature
              {
                  [Constructable]
                  public TheRipper()
                      : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
                  {
                      Name = "The Ripper";
                      Hue = 302;
                      Body = 35;
                      BaseSoundID = 417;
                      SetStr(400);
                      SetDex(750);
                      SetInt(450);
                      SetHits(6000);
                      SetDamage( 25, 35 );
                      SetDamageType(ResistanceType.Physical, 50);
                      SetDamageType(ResistanceType.Poison, 50);

                      SetResistance(ResistanceType.Physical, 100);
                      SetResistance(ResistanceType.Cold, 50);
                      SetResistance(ResistanceType.Fire, 50);
                      SetResistance(ResistanceType.Energy, 100);
                      SetResistance(ResistanceType.Poison, 100);

                      SetSkill(SkillName.Wrestling, 122.7, 130.5);
                      SetSkill(SkillName.Tactics, 109.3, 118.5);
                      SetSkill(SkillName.MagicResist, 72.9, 87.6);
                      SetSkill(SkillName.Anatomy, 110.5, 124.0);
                      
                      Fame = 15000;
                      Karma = -15000;
                      VirtualArmor = 80;

                      PackGold(2000, 2500);
                      switch (Utility.Random(100))
                      {
                          case 0: PackItem(new GorgetoftheForsaken()); break;
                          case 1: PackItem(new ArmsoftheForsaken()); break;
                          case 2: PackItem(new GlovesoftheForsaken()); break;
                          case 3: PackItem(new HelmoftheForsaken()); break;
                          case 4: PackItem(new LegsoftheForsaken()); break;
                          case 5: PackItem(new ChestoftheForsaken()); break;
                          case 6: PackItem(new ForsakenRobe()); break;
                      } 
                      }
                          public override Poison PoisonImmune { get { return Poison.Lethal; } }                             
                          public override bool BardImmune{ get{ return true; } }
                          public override bool Unprovokable{ get{ return true; } }
                          public override Poison HitPoison{ get{ return Poison. Lethal ; } }

                      public TheRipper( Serial serial ) : base( serial )
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
