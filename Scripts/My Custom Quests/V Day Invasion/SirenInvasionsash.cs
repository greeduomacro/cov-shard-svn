using System;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class SirenInvasionSash : BodySash
	{
	
		[Constructable]
		public SirenInvasionSash() : base()
		{
			Hue = 33;
			Name = "Siren Invasion 2010";

            SkillBonuses.SetValues(0, SkillName.SpiritSpeak, 10.0);
            SkillBonuses.SetValues(0, SkillName.Necromancy, 10.0);
           
            Attributes.Luck = 100;
			
		}

        public SirenInvasionSash(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}

