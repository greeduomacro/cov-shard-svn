using System; 
using Server.Items; 

namespace Server.Items 
{ 
   public class ResStone : Item 
   { 
      [Constructable] 
      public ResStone() : base( 0xF8B ) 
      { 
         Hue = 33; 
         Name = "Ressurection Stone";
	     Stackable = true;
         Weight = 0;
      } 


      public ResStone( Serial serial ) : base( serial ) 
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