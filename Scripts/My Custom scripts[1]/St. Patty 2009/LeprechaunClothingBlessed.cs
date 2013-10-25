using System;
using Server;
using Server.Items;

namespace Server.Items
{
   public class LeprechaunCloakBL : BaseCloak
   {

      [Constructable]
      public LeprechaunCloakBL() : base( 0x1515 )
      {

         Weight = 5.0;
         Name = "A Leprechaun Cloak";
         Hue = 0x23D;
         Attributes.Luck = 150;
         LootType=LootType.Blessed;
        
      }
      
            public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }

      public LeprechaunCloakBL( Serial serial ) : base( serial )
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
      public class LeprechaunPantsBL : BasePants
      {

      [Constructable]
      public LeprechaunPantsBL() : base( 0x1539 )
      {

         Weight = 5.0;
         Name = "A pair of Leprechaun Pants";
         Hue = 0x23D;
         Attributes.Luck = 150;
         LootType=LootType.Blessed;
         
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunPantsBL( Serial serial ) : base( serial )
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
      public class LeprechaunBootsBL : BaseShoes
      {

      [Constructable]
      public LeprechaunBootsBL() : base( 0x170B )
      {

         Weight = 5.0;
         Name = "A pair of Leprechaun Boots";
         Hue = 1; 
         Attributes.Luck = 150;
         LootType=LootType.Blessed;
         
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunBootsBL( Serial serial ) : base( serial )
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
      public class LeprechaunShirtBL : BaseShirt
      {

      [Constructable]
      public LeprechaunShirtBL() : base( 0x1EFD )
      {

         Weight = 5.0;
         Name = "A Leprechaun Shirt";
         Attributes.Luck = 150;
         Hue = 0x23D;
         LootType=LootType.Blessed;
         
      }
      public override bool Dye ( Mobile from, DyeTub sender )
                  {
                  return false;
      }

      public LeprechaunShirtBL( Serial serial ) : base( serial )
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
      public class LeprechaunHat1BL : BaseHat
      {

      [Constructable]
      public LeprechaunHat1BL() : base( 0x171A )
      {

         Weight = 5.0;
         Name = "A Leprechaun hat";
         Hue = 0x23D;
         Attributes.Luck = 150;
         LootType=LootType.Blessed;
        
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunHat1BL( Serial serial ) : base( serial )
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
      public class LeprechaunHat2BL : BaseHat
      {

      [Constructable]
      public LeprechaunHat2BL() : base( 0x1718 )
      {

         Weight = 5.0;
         Name = "A Leprechaun hat";
         Hue = 0x23D;
         Attributes.Luck = 150;
         LootType=LootType.Blessed;
         
      }
      
public override bool Dye ( Mobile from, DyeTub sender )
            {
            return false;
      }
      public LeprechaunHat2BL( Serial serial ) : base( serial )
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
