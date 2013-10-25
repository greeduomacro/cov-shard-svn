using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a firefly corpse" )]
	public class FireflyFamiliar : BaseCreature
	{
		public FireflyFamiliar(): base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a firefly";
			Body = 0x80;
			Hue = 56;
			BaseSoundID = 466;

			SetStr( 5 );
			SetDex( 6 );
			SetInt( 10 );

			SetHits( 5 );
			SetStam( 60 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 99 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10,15 );

			SetSkill( SkillName.Wrestling, 10.0 );
			SetSkill( SkillName.Tactics, 10.0 );
            AddItem( new LightSource() );
			ControlSlots = 0;
		}


		public FireflyFamiliar( Serial serial ) : base( serial )
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
