using System;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a Blue dragon corpse" )]
	public class BlueDragoon : BaseSpecialCreature
	{
        public override bool AlwaysMurderer { get { return true; } }

        private bool m_FieldActive;
        public bool FieldActive { get { return m_FieldActive; } }
        public bool CanUseField { get { return Hits >= HitsMax * 9 / 10; } } // TODO: an OSI bug prevents to verify this

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }
          
		[Constructable]
		public BlueDragoon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{     
			Body = 197;
			Name = "a Blue Dragon";
			BaseSoundID = 362;
            Hue = 2124;

			SetStr( 2250, 2500 );
			SetDex( 200, 250 );
			SetInt( 580, 625 );

			SetHits( 7250, 7500 );

			SetDamage( 25, 30 );

			//SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Energy, 100 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, 75 );
			SetResistance( ResistanceType.Cold, 75 );
			SetResistance( ResistanceType.Poison, 75 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Magery, 140.0 );
			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 85;

			Tamable = false;

            m_FieldActive = CanUseField;

            PackItem(new BlueCrystallineFragments());
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathEnergyDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 2124; } }
        public override int BreathEffectSound { get { return 0x56D; } }
        public override bool HasBreath { get { return true; } }
        #endregion

        
		public override bool ReacquireOnMovement{ get{ return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }
       // public override bool EnableMasterHeal { get { return (this.Controlled == true) && (this.Skills[SkillName.Magery].Value >= 90); } }

        public override void AlterMeleeDamageFrom(Mobile from, ref int damage)
        {
            if (m_FieldActive)
                damage = 0; // no melee damage when the field is up
        }

        public override void AlterSpellDamageFrom(Mobile caster, ref int damage)
        {
            if (!m_FieldActive)
                damage = 0; // no spell damage when the field is down
        }

        public override void OnDamagedBySpell(Mobile from)
        {
            if (from != null && from.Alive && 0.7 > Utility.RandomDouble())
            {
                SendEBolt(from);
            }

            if (!m_FieldActive)
            {
                // should there be an effect when spells nullifying is on?
                this.FixedParticles(0, 10, 0, 0x2522, EffectLayer.Waist);
            }
            else if (m_FieldActive && !CanUseField)
            {
                m_FieldActive = false;

                // TODO: message and effect when field turns down; cannot be verified on OSI due to a bug
                this.FixedParticles(0x3735, 1, 30, 0x251F, EffectLayer.Waist);
            }
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (m_FieldActive)
            {
                this.FixedParticles(0x376A, 20, 10, 0x2530, EffectLayer.Waist);

                PlaySound(0x2F4);

                attacker.SendAsciiMessage("Your weapon cannot penetrate the creature's magical barrier");
            }

            if (attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.7 > Utility.RandomDouble())
            {
                SendEBolt(attacker);
            }
        }

        public override void OnThink()
        {
            base.OnThink();

            // TODO: an OSI bug prevents to verify if the field can regenerate or not
            if (!m_FieldActive && !IsHurt())
                m_FieldActive = true;
        }

        public override bool Move(Direction d)
        {
            bool move = base.Move(d);

            if (move && m_FieldActive && this.Combatant != null)
                this.FixedParticles(0, 10, 0, 0x2530, EffectLayer.Waist);

            return move;
        }

        public void SendEBolt(Mobile to)
        {
            this.MovingParticles(to, 0x379F, 7, 0, false, true, 0xBE3, 0xFCB, 0x211);
            to.PlaySound(0x229);
            this.DoHarmful(to);
            AOS.Damage(to, this, 50, 0, 0, 0, 0, 100);
        }


		public BlueDragoon( Serial serial ) : base( serial )
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

            m_FieldActive = CanUseField;
		}
	}
}