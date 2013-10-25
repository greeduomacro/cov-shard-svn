using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class TokenofHolyFavor : GoldBracelet
	{
		public override int LabelNumber{ get{ return 1113652; } } // Token of Holy Favor
		//public override int ArtifactRarity{ get{ return 11; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

		[Constructable]
		public TokenofHolyFavor()
		{
            Weight = 1.0;
			Hue = 0x554;

			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 1;
            Attributes.DefendChance = 10;
            Attributes.AttackChance = 10;
            Attributes.SpellDamage = 5;
            Attributes.BonusHits = 5;
			
			Resistances.Cold = 5;
            Resistances.Poison = 5;

		}

		public TokenofHolyFavor( Serial serial ) : base( serial )
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