using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class LeprechaunCloak : BaseCloak
   {

      [Constructable]
      public LeprechaunCloak() : base( 0x1515 )
      {

         Weight = 5.0;
         Name = "A Leprechaun Cloak";
         Hue = 0x23D;
         
        
      }
      
            public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }

      public LeprechaunCloak( Serial serial ) : base( serial )
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
      public class LeprechaunPants : BasePants
      {

      [Constructable]
      public LeprechaunPants() : base( 0x1539 )
      {

         Weight = 5.0;
         Name = "A pair of Leprechaun Pants";
         Hue = 0x23D;
         
         
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunPants( Serial serial ) : base( serial )
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
      public class LeprechaunBoots : BaseShoes
      {

      [Constructable]
      public LeprechaunBoots() : base( 0x170B )
      {

         Weight = 5.0;
         Name = "A pair of Leprechaun Boots";
         Hue = 1; 
         
         
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunBoots( Serial serial ) : base( serial )
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
      public class LeprechaunShirt : BaseShirt
      {

      [Constructable]
      public LeprechaunShirt() : base( 0x1EFD )
      {

         Weight = 5.0;
         Name = "A Leprechaun Shirt";
         Hue = 0x23D;
         
         
      }
      public override bool Dye ( Mobile from, DyeTub sender )
                  {
                  return false;
      }

      public LeprechaunShirt( Serial serial ) : base( serial )
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
      public class LeprechaunHat1 : BaseHat
      {

      [Constructable]
      public LeprechaunHat1() : base( 0x171A )
      {

         Weight = 5.0;
         Name = "A Leprechaun hat";
         Hue = 0x23D;
         
        
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunHat1( Serial serial ) : base( serial )
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
      public class LeprechaunHat2 : BaseHat
      {

      [Constructable]
      public LeprechaunHat2() : base( 0x1718 )
      {

         Weight = 5.0;
         Name = "A Leprechaun hat";
         Hue = 0x23D;
         
         
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunHat2( Serial serial ) : base( serial )
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
