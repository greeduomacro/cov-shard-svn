using System;
using Server;

namespace Server.Items
{
	public class EnhancedRubyRedSlippers : Shoes
	{
		[Constructable]
		public EnhancedRubyRedSlippers()
		{
			Hue = 1200;
            SkillBonuses.SetValues(0, SkillName.AnimalTaming, 10.0);
            SkillBonuses.SetValues(0, SkillName.AnimalLore, 10.0);
			Attributes.RegenMana = 8;
			Attributes.LowerManaCost = 10;
            Attributes.SpellDamage = 10;
            LootType = LootType.Blessed;
		}

		public EnhancedRubyRedSlippers( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}