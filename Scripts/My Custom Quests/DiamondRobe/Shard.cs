using System; 
using Server; 

namespace Server.Items 
{ 
   public class Shard : Item 
   { 
      [Constructable] 
      public Shard() : this( 1 ) 
      { 
      } 

      [Constructable] 
      public Shard( int amount ) : base( 0xF6B ) 
      {
	 Name = "Shard";
	 Stackable = true;
	 Hue = 0x79;
         Weight = 0.1; 
         Amount = amount; 
      } 

      public Shard( Serial serial ) : base( serial ) 
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