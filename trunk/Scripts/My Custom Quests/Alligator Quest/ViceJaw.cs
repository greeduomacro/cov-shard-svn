using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Vice Jaw corpse" )]
	public class ViceJaw : BaseCreature
	{
		[Constructable]
		public ViceJaw () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.2 )
		{
			Name = "Vice Jaw";
			Body = 0xCE;
			Hue = 2967;
			BaseSoundID = 0x294;

			SetStr( 323, 327 );
			SetDex( 200, 201 );
			SetInt( 115, 117 );

			SetHits( 2960, 3000 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 73, 75 );
			SetResistance( ResistanceType.Fire, 75, 79 );
			SetResistance( ResistanceType.Poison, 75, 78 );

			SetSkill( SkillName.Wrestling, 111.2, 118.3 );
			SetSkill( SkillName.Tactics, 115.0, 117.3 );
			SetSkill( SkillName.MagicResist, 112.4, 118.6 );

            Fame = 20000;
            Karma = -20000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich, 3 );
		}		
		
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

            if (Utility.RandomDouble() < 0.25)
                c.DropItem(new AlligatorHide());
		}

		//public override bool GivesMinorArtifact{ get{ return true; } }
		//public override int Hides{ get{ return 48; } }
		public override int Meat{ get{ return 2; } }

		public ViceJaw( Serial serial ) : base( serial )
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
