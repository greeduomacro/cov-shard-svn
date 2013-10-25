using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ChestoftheFemaleMagi : FemalePlateChest, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public ChestoftheFemaleMagi()
		{
			Hue = 1150; 
            Name = "Chest of the Female Magi";
            Attributes.Luck = 100;
			Attributes.DefendChance = 5;
			Attributes.LowerRegCost = 20;
			Attributes.BonusMana = 2;
			Attributes.BonusHits = 2;
			Attributes.RegenMana = 3;
			Attributes.LowerManaCost = 5;
			ArmorAttributes.MageArmor = 1;
			Attributes.CastSpeed = 1;
			Attributes.SpellDamage = 5;
			Attributes.CastRecovery = 1;
			FireBonus = 10;
			ColdBonus = 10;
			PoisonBonus = 10;
			PhysicalBonus = 10;
			EnergyBonus = 10;
		}

		public ChestoftheFemaleMagi( Serial serial ) : base( serial )
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

            if (Attributes.LowerRegCost == 25)
                Attributes.LowerRegCost = 20;
		}
		public override void OnDoubleClick( Mobile from )
		{
			Item y = from.Backpack.FindItemByType( typeof(ChestoftheFemaleMagi) );
			if ( y !=null )
			{	
			
				if( this.ItemID == 5199 ) this.ItemID = 5100;
				else if( this.ItemID == 5100 ) this.ItemID = 11111;
				else if( this.ItemID == 11111 ) this.ItemID = 9793;
				else if( this.ItemID == 9793 ) this.ItemID = 11117;
				else if( this.ItemID == 11117 ) this.ItemID = 11129;
				else if( this.ItemID == 11129 ) this.ItemID = 11124;
				else if( this.ItemID == 11124 ) this.ItemID = 12235;
				else if( this.ItemID == 12235 ) this.ItemID = 12229;
				else if( this.ItemID == 12229 ) this.ItemID = 5055;
				else if( this.ItemID == 5055 ) this.ItemID = 5141;
				else if( this.ItemID == 5141 ) this.ItemID = 7172;
				else if( this.ItemID == 7172 ) this.ItemID = 10109;
				else if( this.ItemID == 10109 ) this.ItemID = 10182;
				else if( this.ItemID == 10182 ) this.ItemID = 5068;
				else if( this.ItemID == 5068 ) this.ItemID = 10131;
				else if( this.ItemID == 10131 ) this.ItemID = 7170;
				else if( this.ItemID == 7170 ) this.ItemID = 5199;
			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to morph it." ); 
                        }
		}
	}
}
