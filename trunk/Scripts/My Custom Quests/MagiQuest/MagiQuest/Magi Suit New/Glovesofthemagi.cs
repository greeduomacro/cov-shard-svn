using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class Glovesofthemagi : LeatherGloves, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public Glovesofthemagi()
		{
			Hue = 1150;
			Name = "Gloves Of The Magi";
			Attributes.LowerRegCost = 20;
			Attributes.BonusInt = 3;
			Attributes.RegenMana = 3;
			Attributes.LowerManaCost = 3;
			Attributes.RegenHits = 3;
			Attributes.BonusMana = 5;
			Attributes.CastSpeed = 1;
			Attributes.SpellDamage = 2;
            Attributes.Luck = 100;
			FireBonus = 2;
			ColdBonus = 2;
			PoisonBonus = 2;
			PhysicalBonus = 2;
			EnergyBonus = 2;
		}

		public Glovesofthemagi( Serial serial ) : base( serial )
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
				Weight = 2.0;

            if ( Attributes.LowerRegCost == 25 )
                Attributes.LowerRegCost = 20;
		}
		public override void OnDoubleClick( Mobile from )
		{
			Item w = from.Backpack.FindItemByType( typeof(Glovesofthemagi) );
			if ( w !=null )
			{
			
				if( this.ItemID == 5200 ) this.ItemID = 5099;
				else if( this.ItemID == 5099 ) this.ItemID = 9795;
				else if( this.ItemID == 9795 ) this.ItemID = 5140;
				else if( this.ItemID == 5140 ) this.ItemID = 5062;
				else if( this.ItemID == 5062 ) this.ItemID = 10130;
				else if( this.ItemID == 10130 ) this.ItemID = 5200;
			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to morph it." ); 
                        }
		}
	}
}
