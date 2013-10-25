using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a Minotaur King corpse" )]
	public class MinotaurKing : BasePeerless
	{
        public override bool AlwaysMurderer { get { return true; } }
          
		[Constructable]
		public MinotaurKing () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{         
			Body = 1071;
			Name = "Careel -- The Minotaur King";
			BaseSoundID = 362;
           

			SetStr( 2250, 2500 );
			SetDex( 200, 250 );
			SetInt( 580, 625 );

			SetHits( 7250, 7500 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 55, 75 );
			SetResistance( ResistanceType.Cold, 55, 75 );
			SetResistance( ResistanceType.Poison, 50, 75 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Magery, 140.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 85;
            PackTalismans(5);
            PackResources(8);

			Tamable = false;
			
		}

        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosSuperBoss, 6);
        }		

        public override int GetAttackSound()
        {
            return 682;
        }

        public override int GetAngerSound()
        {
            return 681;
        }

        public override int GetDeathSound()
        {
            return 684;
        }

        public override int GetHurtSound()
        {
            return 683;
        }

        public override int GetIdleSound()
        {
            return 680;
        }

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathEnergyDamage { get { return 50; } }
        public override int BreathEffectHue { get { return 2413; } }//////////////////////////////////
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion
       
		public override bool ReacquireOnMovement{ get{ return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
        public override bool GivesSAArtifact { get { return true; } }

        public override void OnDamagedBySpell(Mobile attacker)
        {
            base.OnDamagedBySpell(attacker);

            DoCounter(attacker);
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            DoCounter(attacker);
        }

        private void DoCounter(Mobile attacker)
        {
            if (this.Map == null)
                return;

            if (attacker is BaseCreature && ((BaseCreature)attacker).BardProvoked)
                return;

            if (0.2 > Utility.RandomDouble())
            {
                Mobile target = null;

                if (attacker is BaseCreature)
                {
                    Mobile m = ((BaseCreature)attacker).GetMaster();

                    if (m != null)
                        target = m;
                }

                if (target == null || !target.InRange(this, 8))
                    target = attacker;

                this.Animate(10, 4, 1, true, false, 0);

                ArrayList targets = new ArrayList();

                foreach (Mobile m in target.GetMobilesInRange(8))
                {
                    if (m == this || !CanBeHarmful(m))
                        continue;

                    if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
                        targets.Add(m);
                    else if (m.Player && m.Alive)
                        targets.Add(m);
                }

                for (int i = 0; i < targets.Count; ++i)
                {
                    Mobile m = (Mobile)targets[i];

                    DoHarmful(m);

                    AOS.Damage(m, this, Utility.RandomMinMax(50, 60), true, 0, 0, 0, 100, 0);

                    m.FixedParticles(0x36B0, 10, 25, 9540, 33, 0, EffectLayer.Waist);

                }
            }
        }

		public MinotaurKing ( Serial serial ) : base( serial )
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