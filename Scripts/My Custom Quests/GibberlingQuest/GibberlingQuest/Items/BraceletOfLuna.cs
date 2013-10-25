using System;
using Server;

namespace Server.Items
{
	public class BraceletOfLuna : GoldBracelet
	{

		public override int ArtifactRarity{ get{ return 15; } }

		[Constructable]
		public BraceletOfLuna()
		{
			Name = "Bracelet Of Luna";
			Hue = 1152;
			
		
			Attributes.WeaponDamage = 5;
            Attributes.Luck = 250;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 5;
			Attributes.WeaponSpeed = 5;

			Resistances.Energy = 5;
            Resistances.Fire = 5;
			Resistances.Cold = 5;
			Resistances.Poison = 5;
            Resistances.Physical = 5;
		
		}

		public BraceletOfLuna( Serial serial ) : base( serial )
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
	}
}