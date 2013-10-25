using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Shadowbane's rotted corpse" )] // ?
	public class Shadowsbane : BaseCreature
	{
		[Constructable]
        public Shadowsbane(): base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Shadowbane";
			Body = 155;
            Hue = 1109;
			BaseSoundID = 471;

			SetStr( 400, 500 );
			SetDex( 100 );
			SetInt( 25, 50 );

			SetHits( 30000 );
			SetStam( 150 );
			SetMana( 0 );

			SetDamage( 30, 35 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Fire, 65, 75 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 75 );

			SetSkill( SkillName.Poisoning, 120.0 );
			SetSkill( SkillName.MagicResist, 150.0 );
			SetSkill( SkillName.Tactics, 100 );
			SetSkill( SkillName.Wrestling, 150 );

			Fame = 26000;
			Karma = -26000;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

        public override bool OnBeforeDeath()
        {
            ShadowsbaneGate g = new ShadowsbaneGate();
            g.MoveToWorld(new Point3D(6038, 359, 44), Map.Trammel);

            return base.OnBeforeDeath();
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.25)
                c.DropItem(new ShadowToken());
        }
				
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override Poison HitPoison{ get{ return Poison.Lethal; } }

        public Shadowsbane(Serial serial)
            : base(serial)
		{
		}

        public override bool AlwaysMurderer { get { return true; } }


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