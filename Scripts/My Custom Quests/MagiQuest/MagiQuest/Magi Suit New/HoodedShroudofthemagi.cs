using System; 
using Server.Items; 

namespace Server.Items 
{
    public class HoodedShroudofthemagi : BaseArmor, ITokunoDyable
   { 
      public override int PhysicalResistance{ get{ return 2; } } 
                public override int FireResistance{ get{ return 2; } } 
                public override int ColdResistance{ get{ return 2; } } 
                public override int PoisonResistance{ get{ return 2; } } 
                public override int EnergyResistance{ get{ return 2; } } 

      public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

                public override int ArtifactRarity{ get{ return 10; } } 

      [Constructable] 
      public HoodedShroudofthemagi() : base( 0x2684 ) 
      { 
         Weight = 1; 
                        Hue = 1150; 
                        Name = "Hooded Shroud Of The Magi"; 
						IntRequirement = 50;
					
						Attributes.RegenMana = 2;
                        Attributes.SpellDamage = 2; 
  

      } 

	  public HoodedShroudofthemagi( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 5.0;
		}
		public override void OnDoubleClick( Mobile from )
		{

			Item u = from.Backpack.FindItemByType( typeof(HoodedShroudofthemagi) );
			if ( u !=null )
			{

				if( this.ItemID == 12218 ) this.ItemID = 12217;
				else if( this.ItemID == 12217 ) this.ItemID = 7939;
				else if( this.ItemID == 7939 ) this.ItemID = 9860;
				else if( this.ItemID == 9860 ) this.ItemID = 12218;


			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to morph it." ); 
						}

		}
	}
}
