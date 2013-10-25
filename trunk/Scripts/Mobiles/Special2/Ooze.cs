using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a strange ooze corpse" )]
	public class Ooze : BaseCreature
	{
		[Constructable]
		public Ooze() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a strange ooze";
			Body = 51;
			BaseSoundID = 456;

			Hue = Utility.RandomSlimeHue();

			SetStr( 22, 34 );
			SetDex( 16, 21 );
			SetInt( 16, 20 );

			SetHits( 15, 19 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 10 );
			SetResistance( ResistanceType.Poison, 10, 20 );

			SetSkill( SkillName.Poisoning, 30.1, 50.0 );
			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 19.3, 34.0 );
			SetSkill( SkillName.Wrestling, 19.3, 34.0 );

			Fame = 300;
			Karma = -300;

			VirtualArmor = 28;
		}

		//public override void GenerateLoot()
		//{
		//}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		        public override void OnGotMeleeAttack(Mobile attacker)
        {
            if( attacker != null && attacker.Alive && attacker.Weapon is BaseMeleeWeapon)
			{
				BaseWeapon item = attacker.Weapon as BaseWeapon;
				item.Delete();
                attacker.SendAsciiMessage( "The creatures acidic nature has destroyed your weapon." );
            }

            base.OnGotMeleeAttack(attacker);
        }
		
		public Ooze( Serial serial ) : base( serial )
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
