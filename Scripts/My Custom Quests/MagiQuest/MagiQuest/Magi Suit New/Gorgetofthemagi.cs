using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class Gorgetofthemagi : LeatherGorget, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public Gorgetofthemagi()
		{
			Hue = 1150; 
			Name = "Gorget Of The Magi";
			Attributes.Luck = 100;
            Attributes.LowerRegCost = 20;
			Attributes.BonusHits = 5;
			Attributes.BonusMana = 5;
			Attributes.RegenMana = 3;
			Attributes.BonusDex = 5;
			Attributes.RegenHits = 2;
			Attributes.RegenStam = 2;
			Attributes.CastSpeed = 1;
			Attributes.SpellDamage = 5;
			Attributes.CastRecovery = 1;
			FireBonus = 5;
			ColdBonus = 5;
			PoisonBonus = 5;
			PhysicalBonus = 5;
			EnergyBonus = 5;
		}

		public Gorgetofthemagi( Serial serial ) : base( serial )
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
			Item v = from.Backpack.FindItemByType( typeof(Gorgetofthemagi) );
			if ( v !=null )
			{
			
				if( this.ItemID == 5063 ) this.ItemID = 5139;
				else if( this.ItemID == 5139 ) this.ItemID = 11113;
				else if( this.ItemID == 11113 ) this.ItemID = 11126;
				else if( this.ItemID == 11126 ) this.ItemID = 12231;
				else if( this.ItemID == 12231) this.ItemID = 10105;
				else if( this.ItemID == 10105 ) this.ItemID = 10106;
				else if( this.ItemID == 10106 ) this.ItemID = 7944;
				else if( this.ItemID == 7944 ) this.ItemID = 4229;
				else if( this.ItemID == 4229 ) this.ItemID = 5063;
			}
			else
			{ 
                               	from.SendMessage( "You must have the item in your pack to morph it." ); 
                        } 
		}	
	}
}
