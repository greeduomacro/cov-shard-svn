using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Multis;

namespace Server.Items
{
   public class CrystalSupplicantStatueDeed : Item
   {
      [Constructable]
      public CrystalSupplicantStatueDeed() : base( 0x14F0 )
      {
         Movable = true;
         Hue = 88;
         Name = "CrystalSupplicantStatue";
         LootType = LootType.Blessed;
      }
      
      public override void OnDoubleClick( Mobile from ) // Override double click of the deed to call our target
      {
	if ( !IsChildOf( from.Backpack ) ) // Make sure its in their pack

		      {
			 from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		      }
			    else
		      {

			 from.AddToBackpack( new CrystalSupplicantStatue() );
                         this.Delete();
		      }
      }

      

      public CrystalSupplicantStatueDeed( Serial serial ) : base( serial )
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
