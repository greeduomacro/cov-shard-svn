using System;
using Server;

namespace Server.Items
{
	public class ShazzysBest : SilverEarrings
	{

		public override int ArtifactRarity{ get{ return 10; } }

		[Constructable]
		public ShazzysBest()
		{
			Name ="Victoria's Best";
			Hue = 1278;
					
			Attributes.NightSight = 1;
            Attributes.Luck = 100;
			Attributes.RegenHits = 1;
			Attributes.RegenStam = 1;
			Attributes.RegenMana = 1;
            Resistances.Fire = 1;
			Resistances.Cold = 1;
			Resistances.Poison = 1;
            Resistances.Physical = 1;
            Resistances.Energy = 1;
            
		
		}

		public ShazzysBest( Serial serial ) : base( serial )
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
