using System;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class FallenMysticsSpellbook : Spellbook
	{
         public override int LabelNumber { get { return 1113867; } } //Fallen Mystic's Spellbook

		public override SpellbookType SpellbookType{ get{ return SpellbookType.Mystic; } }
		public override int BookOffset{ get{ return 677; } }
		public override int BookCount{ get{ return 16; } }

		[Constructable]
		public FallenMysticsSpellbook() : this( (ulong)0 )
		{
		}

		[Constructable]
		public FallenMysticsSpellbook( ulong content ) : base( content, 0x2D9D )
		{
			Layer = Layer.OneHanded;
            Hue = 1164;

            SkillBonuses.Skill_1_Name = SkillName.Mysticism;
            SkillBonuses.Skill_1_Value = 10;
            Attributes.CastSpeed = 1;
            Attributes.SpellDamage = 10;
            Attributes.CastRecovery = 1;
            Attributes.LowerManaCost = 5;
            Attributes.LowerRegCost = 10;
            Attributes.RegenMana = 1;

            Slayer = SlayerName.Fey;
            
		}

		public FallenMysticsSpellbook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}