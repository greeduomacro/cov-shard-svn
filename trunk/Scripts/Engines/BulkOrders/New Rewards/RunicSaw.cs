/*    
-<>>--<<>>--<0>>--<< <<2005>> >>--<<0>--<<>>--<<>-
|        ____________________________            |
|     -=(_)__________________________)=-         |
|          \_    All Crafts 1.0.0    _\          |
|           \_  -------------------   _\         |
|            )       Created By:        )        |
|           /_  Sirsly & Lucid Nagual _/         |
|         _/__________________________/          |
|      -=(_)__________________________)=-        |
|                                                |
-<>>-<< Based off of Daat99's OWLTR system >>-<<>-
*/
using System; 
using Server; 
using Server.Engines.Craft; 


namespace Server.Items 
{ 
   [FlipableAttribute( 0x1034, 0x1035 )] 
   public class RunicSaw : BaseRunicTool 
   { 
      public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } } 

      public override int LabelNumber 
      { 
         get 
         { 
            int index = CraftResources.GetIndex( Resource ); 

            if ( index >= 10 && index <= 18 ) 
               return 1042598 + index; 

            return 1011197;
          
          } 
      } 

      public override void AddNameProperties( ObjectPropertyList list ) 
      { 
         base.AddNameProperties( list ); 

         int index = CraftResources.GetIndex( Resource ); 

         if ( index >= 10 && index <= 18 ) 
            return; 

         if ( !CraftResources.IsStandard( Resource ) ) 
         { 
            int num = CraftResources.GetLocalizationNumber( Resource ); 

            if ( num > 0 ) 
               list.Add( num ); 
            else 
               list.Add( CraftResources.GetName( Resource ) ); 
         } 
      } 

      [Constructable] 
      public RunicSaw( CraftResource resource ) : base( resource, 0x1022 ) 
      {
         Name = "Runic Saw";
         Weight = 2.0;
         Hue = CraftResources.GetHue( resource );
                                   
       
      } 

      [Constructable] 
      public RunicSaw( CraftResource resource, int uses ) : base( resource, uses, 0x1034 ) 
      { 
         Weight = 2.0;
         Hue = CraftResources.GetHue( resource );
                                              
       
      } 

      public RunicSaw( Serial serial ) : base( serial ) 
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