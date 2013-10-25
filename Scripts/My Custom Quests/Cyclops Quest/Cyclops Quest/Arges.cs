using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cyclops leaders corpse" )]
	public class Arges : BaseCreature
	{
		[Constructable]
		public Arges() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Arges";
			Body = 75;
			BaseSoundID = 604;
            Hue = 1159;

			SetStr( 536, 585 );
			SetDex( 196, 215 );
			SetInt( 31, 55 );

			SetHits( 1202, 1231 );
			SetMana( 0 );

			SetDamage( 17, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 100 );
			SetResistance( ResistanceType.Energy, 80, 100 );

			SetSkill( SkillName.MagicResist, 105.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 180.1, 190.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 68;

            PackItem(new BrightTridentP());
            PackItem(new GoldIngot(25));
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.Average );
		}

		public override int Meat{ get{ return 4; } }
		public override int TreasureMapLevel{ get{ return 3; } }

		public Arges( Serial serial ) : base( serial )
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