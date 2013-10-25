using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Aramagool's Corpse" )]
	public class Aramagool : Titan
	{
		[Constructable]
		public Aramagool()
		{
			Name = "Aramagool";
			Body = 76;
			BaseSoundID = 609;


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
			SetSkill( SkillName.Tactics, 130.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 1000;
			Karma = -8000;

			VirtualArmor = 65;

			PackItem( new AncientTitanHelm() );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 6 );
		}

		public Aramagool( Serial serial ) : base( serial )
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
