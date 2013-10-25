using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a marauding gargoyle Corpse" )]
	public class MaraudingGargoyle : BaseCreature
	{
		[Constructable]
        public MaraudingGargoyle(): base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Preylis";
            Title = "the marauding gargoyle";
			Body = 0x2F3;
			BaseSoundID = 0x174;


			SetStr( 500 );
			SetDex( 300 );
			SetInt( 200 );

			SetHits( 1250 );

			SetDamage( 23, 38 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 120.0 );
            SetSkill(SkillName.EvalInt, 120.0);
            SetSkill(SkillName.Magery, 120.0);
			SetSkill( SkillName.Tactics, 130.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 1000;
			Karma = -8000;

			VirtualArmor = 75;

			//PackItem( new MarauderTalons() );

		}

		public override void GenerateLoot()
		{
            AddLoot(LootPack.Meager);
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Potions);
		}

		public MaraudingGargoyle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
