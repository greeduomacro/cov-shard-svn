using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;
using Server.Spells;
using Server.Spells.Fourth;

namespace Server.Mobiles
{
    [CorpseName("a stygian dragon corpse")]
    public class StygianDragon : BasePeerless
    {
        private DateTime m_Delay;
	private DateTime m_DelayOne;
	private DateTime m_DelayTwo;
	private DateTime m_DelayThree; 
 
        public override bool AlwaysMurderer { get { return true; } }

        [Constructable]
        public StygianDragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.3, 0.5)
        {
            Name = "Stygian Dragon";
            Body = 826;
            BaseSoundID = 362;

            SetStr(702);
            SetDex(250);
            SetInt(180);

            SetHits(100000);
            SetStam(431);
            SetMana(180);

            SetDamage(33, 55);

            SetDamageType(ResistanceType.Physical, 25);
            SetDamageType(ResistanceType.Fire, 50);
            SetDamageType(ResistanceType.Energy, 25);

            SetResistance(ResistanceType.Physical, 85, 89);
            SetResistance(ResistanceType.Fire, 85, 89);
            SetResistance(ResistanceType.Cold, 65, 69);
            SetResistance(ResistanceType.Poison, 80, 81);
            SetResistance(ResistanceType.Energy, 85, 87);


            SetSkill(SkillName.Anatomy, 100.0);
            SetSkill(SkillName.MagicResist, 150.0, 155.0);
            SetSkill(SkillName.Tactics, 120.7, 125.0);
            SetSkill(SkillName.Wrestling, 115.0, 117.7);

            Fame = 15000;
            Karma = -15000;

            VirtualArmor = 60;

            Tamable = false;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosSuperBoss, 4);
            AddLoot(LootPack.Gems, 8);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if ( Utility.RandomDouble() < 0.025 )
            {
                switch (Utility.Random(7))
                {
                    case 0: c.DropItem(new BurningAmber()); break;
                    case 1: c.DropItem(new DraconisWrath()); break;
                    case 2: c.DropItem(new SignOfOrder()); break;
                    case 3: c.DropItem(new VampiricEssence()); break;
                    case 4: c.DropItem(new LifeSyphon()); break;
                    case 5: c.DropItem(new FallenMysticsSpellbook()); break;
                    case 6: c.DropItem(new DragonHideShield()); break;
                }
            }
        }

        public override bool Unprovokable { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool GivesSAArtifact { get { return true; } }
        public override bool HasBreath { get { return true; } } // fire breath enabled
        public override bool AutoDispel { get { return !Controlled; } }
        public override int Meat { get { return 19; } }
        public override int Hides { get { return 30; } }
        public override HideType HideType { get { return HideType.Barbed; } }
        public override int Scales { get { return 7; } }
        public override ScaleType ScaleType { get { return (Body == 12 ? ScaleType.Yellow : ScaleType.Red); } }
        
        public override WeaponAbility GetWeaponAbility()
        {
            if (50.0 >= Utility.RandomDouble())
                return WeaponAbility.Bladeweave;
            else
                return WeaponAbility.TalonStrike;
        }

        public override void OnActionCombat()
	{
              base.OnActionCombat();
 
                if ( Combatant == null || Frozen || Paralyzed || Map == null || Map == Map.Internal )
			base.OnActionCombat();

		if ( DateTime.Now > m_Delay )
		{
			double chance = Utility.RandomDouble();

			if ( DateTime.Now > m_DelayOne && chance < 0.7 ) // 30%
			{
                Ability.SimpleFlame(this, Ability.FindRandomTarget(this));
				m_DelayOne = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 25 ) );
			}
			else if (( DateTime.Now > m_DelayTwo && chance < 0.8 ) && ( Hits > 2000 )) // 20%
			{
				Ability.CrimsonMeteor( this, 35 );
				m_DelayTwo = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 45 ) );
			}
			else if ( DateTime.Now > m_DelayThree && chance < 0.9 ) // 10%
			{
				Ability.FlameCross( this );
				m_DelayThree = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 60, 120 ) );
			}

		     m_Delay = DateTime.Now + TimeSpan.FromSeconds( 5 );
		}
                
        } 

        public override void OnAfterDelete()
        {                        
		 base.OnAfterDelete();
        }

        public override bool OnBeforeDeath()
        {        
		return base.OnBeforeDeath();

        }  
                
        public override void OnDelete() 
        { 
                base.OnDelete(); 
        } 
 
        public StygianDragon(Serial serial)
            : base(serial)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}


		