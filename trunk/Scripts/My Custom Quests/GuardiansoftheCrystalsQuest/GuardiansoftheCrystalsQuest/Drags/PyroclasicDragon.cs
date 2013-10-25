using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Spells;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a pyroclastic dragon corpse" )]
	public class PyroclasticDragon : BasePeerless
	{
        public override bool AlwaysMurderer { get { return true; } }

		[Constructable]
		public PyroclasticDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{

			Body = 197;
			Name = "a Pyroclastic Dragon";
			BaseSoundID = 362;
            Hue = 2209;

			SetStr( 2250, 2500 );
			SetDex( 200, 250 );
			SetInt( 580, 625 );

			SetHits( 7250, 7500 );

			SetDamage( 17, 25 );

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

            PackItem(new PyroclasticCrystallineFragments());
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 4 );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

        public override void AlterMeleeDamageTo(Mobile to, ref int damage)
        {
            if (Utility.RandomBool() && (this.Mana > 14) && to != null)
            {
                damage = (damage + (damage / 2));
                to.SendLocalizedMessage(1060091); // You take extra damage from the crushing attack!
                to.PlaySound(0x1E1);
                to.FixedParticles(0x377A, 1, 32, 0x26da, 0, 0, 0);
                Mana -= 15;
            }
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            Mobile combatant = Combatant;

            if (combatant == null || combatant.Deleted || combatant.Map != Map || !InRange(combatant, 12) || !CanBeHarmful(combatant) || !InLOS(combatant))
                return;

            if (Utility.Random(10) == 0)
                PoisonAttack(combatant);

            if (Utility.RandomDouble() < 0.7)
                DropOoze();

            base.OnDamage(amount, from, willKill);
        }

        public void PoisonAttack(Mobile m)
        {
            DoHarmful(m);
            this.MovingParticles(m, 0x36D4, 1, 0, false, false, 0x3F, 0, 0x1F73, 1, 0, (EffectLayer)255, 0x100);
            m.ApplyPoison(this, Poison.Lethal);
            m.SendLocalizedMessage(1070821, this.Name); // %s spits a poisonous substance at you!
        }

        #region Breath
        public override int BreathFireDamage { get { return 0; } }
        public override int BreathEnergyDamage { get { return 100; } }
        public override int BreathEffectHue { get { return 2209; } }
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
		//public override bool CanAngerOnTame { get { return true; } }
        //public override bool EnableMasterHeal { get { return (this.Controlled == true) && (this.Skills[SkillName.Magery].Value >= 90); } }

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
                /* Counterattack with Hit Poison Area
                 * 20-25 damage, unresistable
                 * Lethal poison, 100% of the time
                 * Particle effect: Type: "2" From: "0x4061A107" To: "0x0" ItemId: "0x36BD" ItemIdName: "explosion" FromLocation: "(296 615, 17)" ToLocation: "(296 615, 17)" Speed: "1" Duration: "10" FixedDirection: "True" Explode: "False" Hue: "0xA6" RenderMode: "0x0" Effect: "0x1F78" ExplodeEffect: "0x1" ExplodeSound: "0x0" Serial: "0x4061A107" Layer: "255" Unknown: "0x0"
                 * Doesn't work on provoked monsters
                 */

                Mobile target = null;

                if (attacker is BaseCreature)
                {
                    Mobile m = ((BaseCreature)attacker).GetMaster();

                    if (m != null)
                        target = m;
                }

                if (target == null || !target.InRange(this, 18))
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

                    AOS.Damage(m, this, Utility.RandomMinMax(50, 55), true, 0, 0, 0, 100, 0);

                    m.FixedParticles(0x36BD, 1, 10, 0x1F78, 0xA6, 0, (EffectLayer)255);
                    m.ApplyPoison(this, Poison.Lethal);
                }
            }
        }

        public PyroclasticDragon(Serial serial)
            : base(serial)
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

        private DateTime m_NextDrop = DateTime.Now;
		
		public virtual void DropOoze()
		{
			int amount = Utility.RandomMinMax( 1, 3 );
			bool corrosive = Utility.RandomBool();
			
			for ( int i = 0; i < amount; i ++ )
			{
				Item ooze = new PoisonOoze( corrosive );				
				Point3D p = new Point3D( Location );
				
				for ( int j = 0; j < 5; j ++ )
				{
					p = GetSpawnPosition( 2 );
					bool found = false;
				
					foreach( Item item in Map.GetItemsInRange( p, 0 ) )
                        if (item is PoisonOoze)
						{
							found = true;
							break;
						}
						
					if ( !found )
						break;			
				}
				
				ooze.MoveToWorld( p, Map );
			}
			
			if ( Combatant != null )
			{
				if ( corrosive )
					Combatant.SendLocalizedMessage( 1072071 ); // A corrosive gas seeps out of your enemy's skin!
				else
					Combatant.SendLocalizedMessage( 1072072 ); // A poisonous gas seeps out of your enemy's skin!
			}
		}
	}
	
	public class PoisonOoze : Item
	{		
		private bool m_Corrosive;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Corrosive
		{
			get{ return m_Corrosive; }
			set{ m_Corrosive = value; }
		}
		
		[Constructable]
		public PoisonOoze() : this ( false )
		{
		}
		
		[Constructable]
		public PoisonOoze( bool corrosive ) : base( 0x122A )
		{
			Movable = false;
			Hue = 2209;
			
			m_Corrosive = corrosive;			
			Timer.DelayCall( TimeSpan.FromSeconds( 30 ), new TimerCallback( Morph ) );
		}
		
		private Hashtable m_Table;
		
		public override bool OnMoveOver( Mobile m )
		{
			if ( m_Table == null )
				m_Table = new Hashtable();
			
			if ( ( m is BaseCreature && ((BaseCreature) m).Controlled ) || m.Player )
				m_Table[ m ] = Timer.DelayCall( TimeSpan.FromSeconds( 1 ), TimeSpan.FromSeconds( 1 ), new TimerStateCallback( Damage_Callback ), m );
			
			return base.OnMoveOver( m );
		}
		
		public override bool OnMoveOff( Mobile m )
		{			
			if ( m_Table == null )
				m_Table = new Hashtable();
				
			if ( m_Table[ m ] is Timer )
			{
				Timer timer = (Timer) m_Table[ m ];
				
				timer.Stop();
				
				m_Table[ m ] = null;
			}
			
			return base.OnMoveOff( m );
		}

        public PoisonOoze(Serial serial)
            : base(serial)
		{
		}		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
			
			writer.Write( (bool) m_Corrosive );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
			
			m_Corrosive = reader.ReadBool();
		}		
		
		private void Damage_Callback( object state )
		{
			if ( state is Mobile )
				Damage( (Mobile) state );
		}
		
		public virtual void Damage( Mobile m )
		{			
			if ( !m.Alive )
				StopTimer( m );
			
			if ( m_Corrosive )
			{
				for ( int i = 0; i < m.Items.Count; i ++ )
				{
					IDurability item = m.Items[ i ] as IDurability;
	
					if ( item != null && Utility.RandomDouble() < 0.25 )
					{						
						if ( item.HitPoints > 10 )
							item.HitPoints -= 10;
						else
							item.HitPoints -= 1;
					}
				}
			}
			else
				AOS.Damage( m, 40, 0, 0, 0, 100, 0 );
		}		
		
		public virtual void Morph()
		{
			ItemID += 1;
			
			Timer.DelayCall( TimeSpan.FromSeconds( 5 ), new TimerCallback( Decay ) );
		}
		
		public virtual void StopTimer( Mobile m )
		{
			if ( m_Table[ m ] is Timer )
			{
				Timer timer = (Timer) m_Table[ m ];				
				timer.Stop();			
				m_Table[ m ] = null;	
			}
		}
		
		public virtual void Decay()
		{			
			if ( m_Table == null )
				m_Table = new Hashtable();
				
			foreach ( DictionaryEntry entry in m_Table )
				if ( entry.Value is Timer )
					((Timer) entry.Value).Stop();
			
			m_Table.Clear();
			
			Delete();
		}
	}
}

	
