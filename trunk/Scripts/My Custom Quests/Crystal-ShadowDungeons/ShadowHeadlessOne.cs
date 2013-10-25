using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("a Headless One's Shadow corpse")]
    public class ShadowHeadlessOne : BaseCreature
	{
		[Constructable]
		public ShadowHeadlessOne() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "a Shadow Headless One";
			Body = 31;
            Hue = Utility.RandomList(1109, 1108, 1107, 1104, 1103, 1102);
			BaseSoundID = 0x39D;

			SetStr( 50, 80 );
			SetDex( 56, 75 );
			SetInt( 26, 50 );

			SetHits( 36, 60 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 40 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 35.1, 60.0 );
			SetSkill( SkillName.Wrestling, 35.1, 60.0 );

			Fame = 450;
			Karma = -450;

			VirtualArmor = 25;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
			// TODO: body parts
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public ShadowHeadlessOne( Serial serial ) : base( serial )
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