using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Misc;
using Server.Spells;
using Server.Spells.Third;
using Server.Spells.Sixth;
using Server.Spells.Spellweaving;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("a slasher of veils corpse")]
    public class SlasherOfVeils : BasePeerless
    {
        
        private DateTime m_Delay;
	    private DateTime m_DelayOne; 
        private DateTime m_FireRing;
        private DateTime m_Drain;
        private DateTime m_Tele;

        public override bool AlwaysMurderer { get { return true; } } 

        [Constructable]
        public SlasherOfVeils()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "The Slasher of Veils";
            Body = 741;

            SetStr(967, 1145);
            SetDex(129, 139);
            SetInt(967, 1145);

            SetHits(100000);
            SetMana(10000);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 20);
            SetDamageType(ResistanceType.Fire, 20);
            SetDamageType(ResistanceType.Cold, 20);
            SetDamageType(ResistanceType.Poison, 20);
            SetDamageType(ResistanceType.Energy, 20);

            SetResistance(ResistanceType.Physical, 65, 75);
            SetResistance(ResistanceType.Fire, 70, 80);
            SetResistance(ResistanceType.Cold, 70, 80);
            SetResistance(ResistanceType.Poison, 70, 80);
            SetResistance(ResistanceType.Energy, 70, 80);

            SetSkill(SkillName.Anatomy, 116.1, 120.6);
            SetSkill(SkillName.EvalInt, 113.8, 124.7);
            SetSkill(SkillName.Magery, 110.1, 123.2);
            SetSkill(SkillName.Spellweaving, 110.1, 123.2);
            SetSkill(SkillName.Meditation, 118.2, 127.8);
            SetSkill(SkillName.MagicResist, 110.0, 123.2);
            SetSkill(SkillName.Tactics, 112.2, 122.6);
            SetSkill(SkillName.Wrestling, 118.9, 128.6);
        }

        public override int GetIdleSound() { return 1589; }
        public override int GetAngerSound() { return 1586; }
        public override int GetHurtSound() { return 1588; }
        public override int GetDeathSound() { return 1587; }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosSuperBoss, 4);
            AddLoot(LootPack.Gems, 8);
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(6))
                {
                    case 0: c.DropItem(new ClawsoftheBerserker()); break;
                    case 1: c.DropItem(new Lavaliere()); break;
                    case 2: c.DropItem(new SignOfChaos()); break;
                    case 3: c.DropItem(new Mangler()); break;
                    case 4: c.DropItem(new StandardofChaosG()); break;
                    case 5: c.DropItem(new StandardofChaos()); break;
                }
            }
        }

        public override bool GivesSAArtifact { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool BardImmune { get { return true; } }

        public override void OnThink()
        {
            base.OnThink();

            if (Combatant == null)
                return;

            if (Hits > 0.6 * HitsMax && ( DateTime.Now > m_FireRing ))
                FireRing();
        }

        public override void OnActionCombat()
	{
               if ( Combatant == null || Map == null || Map == Map.Internal )
				base.OnActionCombat();

		if ( DateTime.Now > m_Delay )
		{
			double chance = Utility.RandomDouble();

			if ( DateTime.Now > m_DelayOne && chance < 0.6 ) // 40%
			{
				Ability.FlameCross2( this );
				m_DelayOne = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 25 ) );
			}
				
			m_Delay = DateTime.Now + TimeSpan.FromSeconds( 5 );
		}
             
	      base.OnActionCombat();
	}
  
        private static int[] m_North = new int[]
        {
            -1, -1, 
            1, -1,
            -1, 2,
            1, 2
        };

        private static int[] m_East = new int[]
        {
            -1, 0,
            2, 0
        };

        public virtual void FireRing()
        {
            for (int i = 0; i < m_North.Length; i += 2)
            {
                Point3D p = Location;

                p.X += m_North[i];
                p.Y += m_North[i + 1];

                IPoint3D po = p as IPoint3D;

                SpellHelper.GetSurfaceTop(ref po);

                Effects.SendLocationEffect(po, Map, 0x3E27, 50);

                m_FireRing = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 120 ) );
            }

            for (int i = 0; i < m_East.Length; i += 2)
            {
                Point3D p = Location;

                p.X += m_East[i];
                p.Y += m_East[i + 1];

                IPoint3D po = p as IPoint3D;

                SpellHelper.GetSurfaceTop(ref po);

                Effects.SendLocationEffect(po, Map, 0x3E31, 50);
 
                m_FireRing = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 120 ) );  
            }
        }
       
        public override void OnDamagedBySpell(Mobile caster)
        {
          if ( DateTime.Now > m_Tele )
	  {   

            if (this.Map != null && caster != this && 0.70 > Utility.RandomDouble())
            {
                Map = caster.Map;
                Location = caster.Location;
                Combatant = caster;
                Effects.PlaySound(this.Location, this.Map, 0x1FE);
   
                m_Tele = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 40 ) );
            }

          } 
             
            base.OnDamagedBySpell(caster);
        }

        private DateTime m_NextTerror;

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            base.OnMovement(m, oldLocation);

            if (m_NextTerror < DateTime.Now && m != null && InRange(m.Location, 10) && m.AccessLevel == AccessLevel.Player)
            {
                m.Frozen = true;
                m.SendLocalizedMessage(1080342, Name, 33); // Terror slices into your very being, destroying any chance of resisting ~1_name~ you might have had

                Timer.DelayCall(TimeSpan.FromSeconds(10), new TimerStateCallback(Terrorize), m);
            }
        }

        private void Terrorize(object o)
        {
            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.Frozen = false;
                m.SendLocalizedMessage(1005603); // You can move again!

                m_NextTerror = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 60, 120 ) );;
            }
        }


        public void DrainMana()
        {
            if (this.Map == null)
                return;

            ArrayList list = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(8))
            {
                if (m == this || !CanBeHarmful(m))
                    continue;

                if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
                    list.Add(m);
                else if (m.Player)
                    list.Add(m);
            }

            foreach (Mobile m in list)
            {
                DoHarmful(m);

                m.FixedParticles(0x374A, 10, 15, 5013, 0x496, 0, EffectLayer.Waist);
                m.PlaySound(0x231);

                m.SendMessage("You feel the mana drain out of you!");

                int toDrain = Utility.RandomMinMax(40, 60);

                Mana += toDrain;
                m.Mana -= toDrain;
                //m.Damage(toDrain, this);

                m_Drain = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 40 ) );    
            }

        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.25 >= Utility.RandomDouble() && ( DateTime.Now > m_Drain ))
                DrainMana();
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (0.25 >= Utility.RandomDouble() && ( DateTime.Now > m_Drain ))
                DrainMana();
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

        public SlasherOfVeils(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}