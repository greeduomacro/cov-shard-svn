using System; 
using Server;
using Server.Items; 

namespace Server.Items 
{
    public class ShieldofGwenno : HeaterShield, ITokunoDyable 
   { 
      public override int LabelNumber{ get{ return 1061602; } } 
      public override int ArtifactRarity{ get{ return 12; } } 

      public override int InitMinHits{ get{ return 255; } } 
      public override int InitMaxHits{ get{ return 255; } } 

      [Constructable] 
      public ShieldofGwenno()  
      {      Weight = 6.0; 
            Name = "Shield of Gwenno"; 
            Hue = 2118; 
                  ArmorAttributes.SelfRepair = 5; 
				  	Attributes.SpellChanneling = 1;
   Attributes.ReflectPhysical = 30; 
   Attributes.DefendChance = 35; 
   Attributes.LowerManaCost = 10; 
   PhysicalBonus = 20; 
   Attributes.BonusStr = 10;
   Attributes.BonusDex = 10;
   Attributes.BonusInt = 10;
       } 

      public ShieldofGwenno( Serial serial ) : base( serial ) 
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