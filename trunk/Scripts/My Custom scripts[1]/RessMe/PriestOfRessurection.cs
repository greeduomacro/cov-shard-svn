using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a human sacred body" )]
	public class PriestOfRessurection : BaseCreature
	{
        [Constructable]
        public PriestOfRessurection()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {

            Name = "Delevawn";
            Body = 400;
            Title = "The Priest of Ressurection";

            SetStr(1235, 1391);
            SetDex(128, 139);
            SetInt(537, 664);

            SetHits(20000);

            SetDamage(21, 28);

            SetDamageType(ResistanceType.Physical, 60);
            SetDamageType(ResistanceType.Fire, 20);
            SetDamageType(ResistanceType.Energy, 20);

            SetResistance(ResistanceType.Physical, 55, 65);
            SetResistance(ResistanceType.Fire, 55, 65);
            SetResistance(ResistanceType.Cold, 55, 65);
            SetResistance(ResistanceType.Poison, 80, 90);
            SetResistance(ResistanceType.Energy, 60, 75);

            SetSkill(SkillName.Anatomy, 110.6, 116.1);
            SetSkill(SkillName.EvalInt, 100.0, 114.4);
            SetSkill(SkillName.Archery, 115.0, 120.0);
            SetSkill(SkillName.Magery, 100.0);
            SetSkill(SkillName.Meditation, 118.2, 127.8);
            SetSkill(SkillName.MagicResist, 120.0);
            SetSkill(SkillName.Tactics, 111.9, 134.5);
            SetSkill(SkillName.Wrestling, 119.7, 128.9);

            HoodedShroudOfShadows shroud = new HoodedShroudOfShadows();
            shroud.Hue = 1175;
            AddItem(shroud);

            Cloak cloak = new Cloak();
            cloak.Hue = 1175;
            AddItem(cloak);

            Fame = 10000;
            Karma = -10000;

            VirtualArmor = 70;
        }
			
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public PriestOfRessurection( Serial serial ) : base( serial )
		{
		}

        public override void GenerateLoot()
		{
			AddLoot( LootPack.AosRich, 3 );
		}

           public override void OnDeath( Container c )
		{
			base.OnDeath( c );	
			
			if ( Utility.RandomDouble() < 0.25 )
				c.DropItem( new ResStone() );
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
