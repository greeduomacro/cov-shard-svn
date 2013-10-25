/*
 * Created by SharpDevelop.
 * User: Sharon
 * Date: 12/2/2006
 * Time: 9:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	
	public class SantasGiftBag2009 : Bag
	{
		public int offset;
		
		[Constructable]
		public SantasGiftBag2009() 
		{
			Name = "A Gift from Santa - 2009";
			Hue = 32;
			offset = Utility.Random( 0, 10 );
			
             switch ( Utility.Random( 6 ) )
             {
             	case 0:
             		DropItem( new RudolphStatue() );break;
             	case 1:
             		DropItem( new SantasTimepiece()  );break;
             	case 2:
             		DropItem( new SantasBoots() );break;
             	case 3:
             		DropItem( new SantasChairAddonDeed() ); break;
                case 4:
                    DropItem(new SantasElfBoots()); break;
                case 5:
                    DropItem(new SantasCoal()); break;
                
			}

		}

		public SantasGiftBag2009( Serial serial ) : base( serial )
		{
		}
		
		public override void GetProperties( ObjectPropertyList list )
	         {
	  	    base.GetProperties( list );

		    list.Add( 1007149 + offset ); 
    	     }

		public override void Serialize( GenericWriter writer ) 
	         {
	            base.Serialize( writer ); 

	            writer.Write( (int) 0 ); 
	            
	            writer.Write( (int) offset );
	         }
	
	         public override void Deserialize( GenericReader reader ) 
	         {
	            base.Deserialize( reader ); 

	            int version = reader.ReadInt(); 

		        offset = reader.ReadInt();
	         }
	}
}
