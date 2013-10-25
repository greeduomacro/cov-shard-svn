using System; 
using Server.Network; 
using Server.Targeting; 
using Server.Items; 

namespace Server.Items 
{ 
   public class EricRobe : BaseOuterTorso 
    
{ 
      
      public override int PhysicalResistance{ get{ return 10; } } 
      public override int FireResistance{ get{ return 8; } } 
      public override int ColdResistance{ get{ return 5; } } 
      public override int PoisonResistance{ get{ return 11; } } 
      public override int EnergyResistance{ get{ return 16; } } 

      [Constructable] 
      public EricRobe() : base( 0x1F04 ) 
      { 
              Hue = 1175; 
              Weight = 1.0; 
              Layer = Layer.OuterTorso; 
              Name = "A Robe sewn by Eric"; 
                
                } 

      public EricRobe( Serial serial ) : base( serial ) 
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