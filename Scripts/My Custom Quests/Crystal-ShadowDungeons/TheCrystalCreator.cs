///////////////////////////////////
//===============================//
//Script created by: Triple      //
//===============================//
///////////////////////////////////

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Crystal Creator corpse" )]
	public class TheCrystalCreator : BaseCreature
	{
		[Constructable]
		public TheCrystalCreator () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "The Crystal Creator";
			Body = 155;
			Hue = 1152;
			BaseSoundID = 655;

			SetStr( 326, 455 );
			SetDex( 266, 285 );
			SetInt( 401, 525 );

			SetHits( 30000 );

			SetDamage( 30, 40 );

			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 120 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.EvalInt, 100 );
			SetSkill( SkillName.Magery, 120 );
			SetSkill( SkillName.MagicResist, 100 );
			SetSkill( SkillName.Tactics, 120 );
			SetSkill( SkillName.Wrestling, 150 );

			Fame = 4500;
			Karma = 300;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems );
		}

        public override bool OnBeforeDeath()
        {
            CrystalCreatorGate g = new CrystalCreatorGate();
            g.MoveToWorld(new Point3D(6119, 358, -22), Map.Trammel);

            return base.OnBeforeDeath();
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.2)
                c.DropItem(new CrystalToken());
        }

		public TheCrystalCreator( Serial serial ) : base( serial )
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
