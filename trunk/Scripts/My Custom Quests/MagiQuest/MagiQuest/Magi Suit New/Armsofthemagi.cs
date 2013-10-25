using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Armsofthemagi : LeatherArms, ITokunoDyable
	{
		public override int ArtifactRarity{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public Armsofthemagi()
		{
			Hue = 1153;
			Name = " Arms Of The Magi";
			SkillBonuses.SetValues( 0, SkillName.Magery, 5.0 );
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 20;
			Attributes.BonusHits = 5;
			Attributes.BonusMana = 5;
			Attributes.CastSpeed = 1;
			//Attributes.SpellDamage = 10;
			Attributes.RegenMana = 3;
			Attributes.CastRecovery = 1;
			Attributes.Luck = 100;
		    FireBonus = 2;
			ColdBonus = 2;
			PoisonBonus = 2;
			PhysicalBonus = 2;
			EnergyBonus = 2;
		}

		public Armsofthemagi( Serial serial ) : base( serial )
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
				Weight = 15.0;

            if ( Attributes.LowerRegCost == 25 )
                Attributes.LowerRegCost = 20;
		}
		public override void OnDoubleClick( Mobile from )
		{
			Item z = from.Backpack.FindItemByType( typeof(Armsofthemagi) );
			if ( z !=null )
			{
			
				if( this.ItemID == 5198 ) this.ItemID = 5102;
				else if( this.ItemID == 5102 ) this.ItemID = 11127;
				else if( this.ItemID == 11127 ) this.ItemID = 9815;
				else if( this.ItemID == 9815 ) this.ItemID = 12232;
				else if( this.ItemID == 12232 ) this.ItemID = 11116;
				else if( this.ItemID == 11116 ) this.ItemID = 5136;
				else if( this.ItemID == 5136 ) this.ItemID = 10112;
				else if( this.ItemID == 10112 ) this.ItemID = 10110;
				else if( this.ItemID == 10110 ) this.ItemID = 5069;
				else if( this.ItemID == 5069 ) this.ItemID = 5198;
			}
			else
			{ 
                from.SendMessage( "You must have the item in your pack to morph it." ); 
            } 
		}
	}
}
