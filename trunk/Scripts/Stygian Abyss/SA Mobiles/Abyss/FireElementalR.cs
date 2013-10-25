using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a renowned fire elemental corpse" )]
	public class FireElementalR : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public FireElementalR () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Fire elemental (Renowned)";
			Body = 15;
            Hue = 1161;
			BaseSoundID = 838;

			SetStr( 490, 500 );
			SetDex( 200, 205 );
			SetInt( 330, 335 );

			SetHits( 4400, 4450 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 55, 60 );
			SetResistance( ResistanceType.Fire, 80 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 40, 45 );
			SetResistance( ResistanceType.Energy, 50, 55 );

			SetSkill( SkillName.EvalInt, 108.1, 110.1 );
			SetSkill( SkillName.Magery, 106.1, 110.1 );
			SetSkill( SkillName.MagicResist, 119.1, 125.1 );
			SetSkill( SkillName.Tactics, 101.1, 105.0 );
			SetSkill( SkillName.Wrestling, 100, 110 );

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 50;
			//ControlSlots = 4;

			PackItem( new SulfurousAsh( 3 ) );
            
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.10)
            {
                switch (Utility.Random(2))
                {
                    case 0: c.DropItem(new EssencePrecision()); break;

                    case 1: c.DropItem(new WhitePearl(3)); break;
                }
            }

            if (Utility.RandomDouble() < 0.05)
            {
                
                c.DropItem( new JadeWarAxe()); 
                
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
        public override bool AlwaysMurderer { get { return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public FireElementalR( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 274 )
				BaseSoundID = 838;
		}
	}
}
