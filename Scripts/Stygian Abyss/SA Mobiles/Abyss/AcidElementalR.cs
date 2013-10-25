using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a renowned acid elemental corpse" )]
	public class AcidElementalR : BaseCreature
	{
		[Constructable]
		public AcidElementalR () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an Acid elemental (Renowned)";
			Body = 0x9E;
			BaseSoundID = 278;

			SetStr( 550, 555 );
			SetDex( 135, 140 );
			SetInt( 390, 395 );

			SetHits( 6225, 6230 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 50 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 40, 45 );
			SetResistance( ResistanceType.Cold, 30, 35 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Anatomy, 70.3, 75.0 );
			SetSkill( SkillName.EvalInt, 95.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 95.0 );
			SetSkill( SkillName.MagicResist, 70.1, 75.0 );
			SetSkill( SkillName.Tactics, 95.1, 100.0 );
			SetSkill( SkillName.Wrestling, 95, 100.0 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 70;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			//AddLoot( LootPack.Rich );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new EssenceSingularity()); break;
                    case 1: c.DropItem(new VialVitirol()); break;
                   
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }

		public override int TreasureMapLevel{ get{ return Core.AOS ? 2 : 3; } }

		public AcidElementalR( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 278;

			if ( Body == 13 )
				Body = 0x9E;

			if ( Hue == 0x4001 )
				Hue = 0;
		}
	}
}