//Modifications for the Mobile Abilities Package are done and created by Peoharen.
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ore elemental corpse" )]
	public class BronzeElemental : BaseCreature
	{
		//private DateTime m_Delay = DateTime.Now;

		[Constructable]
		public BronzeElemental() : this( 2 )
		{
		}

		[Constructable]
		public BronzeElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			// TODO: Gas attack
			Name = "a bronze elemental";
			Body = 108;
			BaseSoundID = 268;

			SetStr( 226, 255 );
			SetDex( 126, 145 );
			SetInt( 71, 92 );

			SetHits( 136, 153 );

			SetDamage( 9, 16 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Fire, 70 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 29;

			PackItem( new BronzeOre( oreAmount ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, 2 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }

        private DateTime m_GasDelay;

        public override void OnActionCombat()
        {
            if (DateTime.Now > m_GasDelay)
            {
                if (Combatant != null)
                {
                    Combatant.FixedEffect(0x3709, 10, 30, 1149, 4);
                    AOS.Damage(Combatant, this, Utility.RandomMinMax(DamageMax, (DamageMax * 2)), 0, 25, 25, 50, 0);
                }

                m_GasDelay = DateTime.Now + TimeSpan.FromSeconds(Utility.Random(6, 12));
            }

            base.OnActionCombat();
        }

		public BronzeElemental( Serial serial ) : base( serial )
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