using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a monster corpse" )]
	public class Monster1 : BaseCreature
	{
		[Constructable]
		public Monster1 () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a monster";
			Body = 99;
			BaseSoundID = 357;

            SetStr(113, 135);
            SetDex(421, 477);
            SetInt(69, 86);

            SetHits(1500, 2000);
            SetStam(421, 477);
            SetMana(11, 14);

            SetDamage(20, 30);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 80, 90);
            SetResistance(ResistanceType.Fire, 60, 77);
            SetResistance(ResistanceType.Cold, 75, 85);
            SetResistance(ResistanceType.Poison, 55, 85);
            SetResistance(ResistanceType.Energy, 50, 60);

            SetSkill(SkillName.Wrestling, 120.0, 140.0);
            SetSkill(SkillName.Tactics, 120.0, 140.0);
            SetSkill(SkillName.MagicResist, 95.4, 105.0);

            Fame = 20000;
            Karma = -20000;

			VirtualArmor = 38;

			AddItem( new LightSource() );

			PackItem( new Bone( 20 ) );
            PackItem( new CasToy( 1 ) );
			
		}

		public override int GetIdleSound()
		{
			return 338;
		}

		public override int GetAngerSound()
		{
			return 338;
		}

		public override int GetDeathSound()
		{
			return 338;
		}

		public override int GetAttackSound()
		{
			return 406;
		}

		public override int GetHurtSound()
		{
			return 194;
		}

		public Monster1( Serial serial ) : base( serial )
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