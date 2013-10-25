
using System;
using Server;

namespace Server.Items

{
              
              public class BladeOfCrystalLake : RadiantScimitar
              {
              
                      [Constructable]
                      public BladeOfCrystalLake() 
                      {
                                        Weight = 0;
                                        Name = "Blade Of Crystal Lake";
                                        Hue = 43;
              
                                        WeaponAttributes.DurabilityBonus = 100;
                                        WeaponAttributes.HitLeechHits = 30;
                                        WeaponAttributes.HitLeechMana = 30;
                                        WeaponAttributes.HitLightning = 30;
                                        WeaponAttributes.SelfRepair = 3;
                                        WeaponAttributes.UseBestSkill = 1;
              
                                        Attributes.AttackChance = 10;
                                        Attributes.BonusDex = 10;
                                        Attributes.BonusHits = 10;
                                        Attributes.BonusInt = 10;
                                        Attributes.CastRecovery = 1;
                                        Attributes.CastSpeed = 1;
                                        Attributes.DefendChance = 15;
                                        Attributes.Luck = 200;
                                        Attributes.NightSight = 1;
                                        Attributes.ReflectPhysical = 15;
                                        Attributes.SpellChanneling = 1;
                                        Attributes.WeaponDamage = 30;
                                        Attributes.WeaponSpeed = 25;
              
                                    }
              
                      public BladeOfCrystalLake( Serial serial ) : base( serial )  
                                    {
                                    }
              
                      public override void Serialize( GenericWriter writer )
                                    {
                                                      base.Serialize( writer );
              
                                                      writer.Write( (int) 0 );
                                    }
              
                      public override void Deserialize(GenericReader reader)
                                    {
                                                      base.Deserialize( reader );
                            
                                                      int version = reader.ReadInt();
                                    }
                  }
}
