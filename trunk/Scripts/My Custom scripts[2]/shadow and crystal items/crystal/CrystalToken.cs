using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Multis;

namespace Server.Items
{
   public class CrystalToken : Item
   {
      private string m_Title;

      [Constructable]
      public CrystalToken() : base( 0x3678 )
      {
         m_Title = "Use This To Redeem Your Crystal Items";
         Movable = true;
         LootType = LootType.Blessed;
      }
      public override int LabelNumber{ get{ return 1076592; } }
      
      public override void GetProperties( ObjectPropertyList list )
      {
		base.GetProperties( list );

                 if ( m_Title != null )
			list.Add( m_Title );

      }
      
      public override void OnDoubleClick( Mobile from ) // Override double click of the deed to call our target
      {
	if ( !IsChildOf( from.Backpack ) ) // Make sure its in their pack

		      {
			 from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		      }
			    else
		      {
			
			 from.AddToBackpack( new CrystalBox() );
                         this.Delete();
		      }
      }

      

      public CrystalToken( Serial serial ) : base( serial )
      {
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 1 ); // version
         
         writer.Write( (string)  m_Title );
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
         
         	switch ( version )
			{
				case 1:
				{
					m_Title = reader.ReadString();
					break;
				}
			}
      }
   }
}
