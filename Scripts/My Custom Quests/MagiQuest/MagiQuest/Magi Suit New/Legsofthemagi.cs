using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class Legsofthemagi : LeatherLegs, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public Legsofthemagi()
		{
			Hue = 1150; 
			Name = "Legs Of The Magi";
            Attributes.Luck = 100;
			Attributes.DefendChance = 5;
			Attributes.LowerRegCost = 20;
            Attributes.LowerManaCost = 2;
			Attributes.BonusInt = 2;
			Attributes.BonusDex = 2;
			Attributes.BonusHits = 2;
			Attributes.BonusMana = 2;
			Attributes.RegenHits = 1;
			Attributes.BonusHits = 2;
			Attributes.RegenMana = 3;
			Attributes.CastSpeed = 1;
			Attributes.SpellDamage = 2;
			Attributes.CastRecovery = 1;
			Attributes.RegenStam = 3;
						FireBonus = 5;
						ColdBonus = 5;
						PoisonBonus = 5;
						PhysicalBonus = 5;
                        EnergyBonus = 5;
		}

		public Legsofthemagi( Serial serial ) : base( serial )
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

            if ( Attributes.LowerRegCost == 25 )
                Attributes.LowerRegCost = 20;
		}
		public override void OnDoubleClick( Mobile from )
		{
			
			Item t = from.Backpack.FindItemByType( typeof(Legsofthemagi) );
			if ( t !=null )
			{
			
				if( this.ItemID == 5202 ) this.ItemID = 5104;
				else if( this.ItemID == 5104 ) this.ItemID = 11115;
				else if( this.ItemID == 11115 ) this.ItemID = 9799;
				else if( this.ItemID == 9799 ) this.ItemID = 11128;
				else if( this.ItemID == 11128 ) this.ItemID = 12233;
				else if( this.ItemID == 12233 ) this.ItemID = 5054;
				else if( this.ItemID == 5054 ) this.ItemID = 5137;
				else if( this.ItemID == 5137 ) this.ItemID = 10125;
				else if( this.ItemID == 10125 ) this.ItemID = 10120;
				else if( this.ItemID == 10120 ) this.ItemID = 10118;
				else if( this.ItemID == 10118 ) this.ItemID = 5067;
				else if( this.ItemID == 5067 ) this.ItemID = 10129;
				else if( this.ItemID == 10129 ) this.ItemID = 7168;
				else if( this.ItemID == 7168 ) this.ItemID = 5202;
			}
			else
			{ 
               from.SendMessage( "You must have the item in your pack to morph it." ); 
            }
		}
	}
}
