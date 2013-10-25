using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class StaffOfTheMagi : WarMace, ITokunoDyable
	{
		public override int LabelNumber{ get{ return 1061600; } } // Staff of the Magi
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public StaffOfTheMagi()
		{
			Hue = 1150;
			WeaponAttributes.MageWeapon = 0;
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
			Attributes.WeaponDamage = 20;
		}
        #region Mondain's Legacy
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            phys = fire = cold= pois = chaos = direct = 0;
            nrgy = 100;
        }
        #endregion
		

		public StaffOfTheMagi( Serial serial ) : base( serial )
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
		public override void OnDoubleClick( Mobile from )
		{
			
			Item t = from.Backpack.FindItemByType( typeof(StaffOfTheMagi) );
			if ( t !=null )
			{
			
				if( this.ItemID == 3568) this.ItemID = 3721;
				else if( this.ItemID == 3721 ) this.ItemID = 9916;
				else if( this.ItemID == 9916 ) this.ItemID = 5040;
				else if( this.ItemID == 5040 ) this.ItemID = 5179;
				else if( this.ItemID == 5179 ) this.ItemID = 3932;
				else if( this.ItemID == 3932 ) this.ItemID = 5127;
				else if( this.ItemID == 5127 ) this.ItemID = 3568;
			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to morph it." ); 
                        }
		}
	}
}
