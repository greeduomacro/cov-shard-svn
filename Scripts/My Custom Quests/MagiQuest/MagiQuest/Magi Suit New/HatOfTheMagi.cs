using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class HatOfTheMagi : WizardsHat, ITokunoDyable
	{
		public override int LabelNumber{ get{ return 1061597; } } // Hat of the Magi

		public override int ArtifactRarity{ get{ return 11; } }

		[Constructable]
		public HatOfTheMagi()
		{
			Hue = 1150;

			Attributes.BonusInt =2;
			Attributes.RegenMana = 1;
			Attributes.SpellDamage = 2;
			Resistances.Poison = 5;
			Resistances.Energy = 5;
			Resistances.Fire = 5;
			Resistances.Cold = 5;
		}

		public HatOfTheMagi( Serial serial ) : base( serial )
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

			Item u = from.Backpack.FindItemByType( typeof(HatOfTheMagi) );
			if ( u !=null )
			{
			
				if( this.ItemID == 5201 ) this.ItemID = 5128;
				else if( this.ItemID == 5128 ) this.ItemID = 11120;
				else if( this.ItemID == 11120 ) this.ItemID = 12216;
				else if( this.ItemID == 12216 ) this.ItemID = 9797;
				else if( this.ItemID == 9797 ) this.ItemID = 11119;
				else if( this.ItemID == 11119 ) this.ItemID = 11122;
				else if( this.ItemID == 11122 ) this.ItemID = 11121;
				else if( this.ItemID == 11121 ) this.ItemID = 11123;
				else if( this.ItemID == 11123) this.ItemID = 5130;
				else if( this.ItemID == 5130 ) this.ItemID = 5132;
				else if( this.ItemID == 5132 ) this.ItemID = 5134;
				else if( this.ItemID == 5134 ) this.ItemID = 5138;
				else if( this.ItemID == 5138 ) this.ItemID = 5051;
				else if( this.ItemID == 5051 ) this.ItemID = 10101;
				else if( this.ItemID == 10101 ) this.ItemID = 10100;
				else if( this.ItemID == 10100 ) this.ItemID = 10113;
				else if( this.ItemID == 10113 ) this.ItemID = 10116;
				else if( this.ItemID == 10116 ) this.ItemID = 10102;
				else if( this.ItemID == 10102 ) this.ItemID = 10117;
				else if( this.ItemID == 10117 ) this.ItemID = 10104;
				else if( this.ItemID == 10104 ) this.ItemID = 10126;
				else if( this.ItemID == 10126 ) this.ItemID = 5908;
				else if( this.ItemID == 5908 ) this.ItemID = 5910;
				else if( this.ItemID == 5910 ) this.ItemID = 5911;
				else if( this.ItemID == 5911 ) this.ItemID = 5912;
				else if( this.ItemID == 5912 ) this.ItemID = 5916;
				else if( this.ItemID == 5916 ) this.ItemID = 5907;
				else if( this.ItemID == 5907 ) this.ItemID = 5914;
				else if( this.ItemID == 5914 ) this.ItemID = 5915;
				else if( this.ItemID == 5915 ) this.ItemID = 5440;
				else if( this.ItemID == 5440 ) this.ItemID = 5201;

			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to morph it." ); 
						}

		}
	}
}