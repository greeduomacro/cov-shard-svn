using System;
using Server.Items;
using Server.Targeting;
using System.Collections;
using Server;
using Server.Misc;
using Server.Spells;
namespace Server.Mobiles
{
	[CorpseName( "a toxic slimey corpse" )]
	public class ToxicOoze : BaseCreature
	{
		private DateTime m_Delay = DateTime.Now;

        [Constructable]
        public ToxicOoze()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a toxic ooze";
            Body = 0x33;
            Hue = 1175;
            BaseSoundID = 456;

            SetStr(185);
            SetDex(150);
            SetInt(300);

            SetStam(150);
            SetMana(300);

            SetHits(2127);

            SetDamage(18);

            SetDamageType(ResistanceType.Physical, 10);
            SetDamageType(ResistanceType.Cold, 30);
            SetDamageType(ResistanceType.Fire, 30);
            SetDamageType(ResistanceType.Energy, 30);

            SetResistance(ResistanceType.Physical, 75);
            SetResistance(ResistanceType.Fire, 55);
            SetResistance(ResistanceType.Cold, 52);
            SetResistance(ResistanceType.Poison, 51);
            SetResistance(ResistanceType.Energy, 40);

            SetSkill(SkillName.EvalInt, 100.0);
            SetSkill(SkillName.MagicResist, 61.1);
            SetSkill(SkillName.Tactics, 76.2);
            SetSkill(SkillName.Wrestling, 77.5);
            SetSkill(SkillName.Meditation, 100.0);

            //Fame = 4500;
            //Karma = -4500;

            VirtualArmor = 74;

            if (Utility.RandomDouble() < 0.10) //10% chance
            {
                switch (Utility.Random(54))
                {
                    case 0: AddItem(new ScrollofAlacrity(SkillName.Alchemy)); break;
                    case 1: AddItem(new ScrollofAlacrity(SkillName.AnimalLore)); break;
                    case 2: AddItem(new ScrollofAlacrity(SkillName.ItemID)); break;
                    case 3: AddItem(new ScrollofAlacrity(SkillName.ArmsLore)); break;
                    case 4: AddItem(new ScrollofAlacrity(SkillName.Parry)); break;
                    case 5: AddItem(new ScrollofAlacrity(SkillName.Begging)); break;
                    case 6: AddItem(new ScrollofAlacrity(SkillName.Blacksmith)); break;
                    case 7: AddItem(new ScrollofAlacrity(SkillName.Fletching)); break;
                    case 8: AddItem(new ScrollofAlacrity(SkillName.Peacemaking)); break;
                    case 9: AddItem(new ScrollofAlacrity(SkillName.Camping)); break;
                    case 10: AddItem(new ScrollofAlacrity(SkillName.Carpentry)); break;
                    case 11: AddItem(new ScrollofAlacrity(SkillName.Cartography)); break;
                    case 12: AddItem(new ScrollofAlacrity(SkillName.Cooking)); break;
                    case 13: AddItem(new ScrollofAlacrity(SkillName.DetectHidden)); break;
                    case 14: AddItem(new ScrollofAlacrity(SkillName.Discordance)); break;
                    case 15: AddItem(new ScrollofAlacrity(SkillName.EvalInt)); break;
                    case 16: AddItem(new ScrollofAlacrity(SkillName.Healing)); break;
                    case 17: AddItem(new ScrollofAlacrity(SkillName.Fishing)); break;
                    case 18: AddItem(new ScrollofAlacrity(SkillName.Forensics)); break;
                    case 19: AddItem(new ScrollofAlacrity(SkillName.Herding)); break;
                    case 20: AddItem(new ScrollofAlacrity(SkillName.Hiding)); break;
                    case 21: AddItem(new ScrollofAlacrity(SkillName.Provocation)); break;
                    case 22: AddItem(new ScrollofAlacrity(SkillName.Inscribe)); break;
                    case 23: AddItem(new ScrollofAlacrity(SkillName.Lockpicking)); break;
                    case 24: AddItem(new ScrollofAlacrity(SkillName.Magery)); break;
                    case 25: AddItem(new ScrollofAlacrity(SkillName.MagicResist)); break;
                    case 26: AddItem(new ScrollofAlacrity(SkillName.Tactics)); break;
                    case 27: AddItem(new ScrollofAlacrity(SkillName.Snooping)); break;
                    case 28: AddItem(new ScrollofAlacrity(SkillName.Musicianship)); break;
                    case 29: AddItem(new ScrollofAlacrity(SkillName.Poisoning)); break;
                    case 30: AddItem(new ScrollofAlacrity(SkillName.Archery)); break;
                    case 31: AddItem(new ScrollofAlacrity(SkillName.SpiritSpeak)); break;
                    case 32: AddItem(new ScrollofAlacrity(SkillName.Stealing)); break;
                    case 33: AddItem(new ScrollofAlacrity(SkillName.Tailoring)); break;
                    case 34: AddItem(new ScrollofAlacrity(SkillName.AnimalTaming)); break;
                    case 35: AddItem(new ScrollofAlacrity(SkillName.TasteID)); break;
                    case 36: AddItem(new ScrollofAlacrity(SkillName.Tinkering)); break;
                    case 37: AddItem(new ScrollofAlacrity(SkillName.Tracking)); break;
                    case 38: AddItem(new ScrollofAlacrity(SkillName.Veterinary)); break;
                    case 39: AddItem(new ScrollofAlacrity(SkillName.Swords)); break;
                    case 40: AddItem(new ScrollofAlacrity(SkillName.Macing)); break;
                    case 41: AddItem(new ScrollofAlacrity(SkillName.Fencing)); break;
                    case 42: AddItem(new ScrollofAlacrity(SkillName.Wrestling)); break;
                    case 43: AddItem(new ScrollofAlacrity(SkillName.Lumberjacking)); break;
                    case 44: AddItem(new ScrollofAlacrity(SkillName.Mining)); break;
                    case 45: AddItem(new ScrollofAlacrity(SkillName.Meditation)); break;
                    case 46: AddItem(new ScrollofAlacrity(SkillName.Stealth)); break;
                    case 47: AddItem(new ScrollofAlacrity(SkillName.RemoveTrap)); break;
                    case 48: AddItem(new ScrollofAlacrity(SkillName.Necromancy)); break;
                    case 49: AddItem(new ScrollofAlacrity(SkillName.Focus)); break;
                    case 50: AddItem(new ScrollofAlacrity(SkillName.Chivalry)); break;
                    case 51: AddItem(new ScrollofAlacrity(SkillName.Bushido)); break;
                    case 52: AddItem(new ScrollofAlacrity(SkillName.Ninjitsu)); break;
                    case 53: AddItem(new ScrollofAlacrity(SkillName.Spellweaving)); break;

                }
            }
        }

		public override void GenerateLoot()
		{
            AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.Rich);
		}

		private DateTime m_NextAbilityTime;

		private void DoAreaLeech()
		{
			m_NextAbilityTime += TimeSpan.FromSeconds( 2.5 );

			this.FixedParticles( 0x376A, 10, 10, 9537, 33, 0, EffectLayer.Waist );

			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( DoAreaLeech_Finish ) );
		}

		private void DoAreaLeech_Finish()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 6 ) )
			{
				if ( this.CanBeHarmful( m ) && this.IsEnemy( m ) )
					list.Add( m );
			}

			{
				double scalar;

				if ( list.Count == 1 )
					scalar = 0.90;
				else if ( list.Count == 2 )
					scalar = 0.50;
				else
					scalar = 0.30;

				for ( int i = 0; i < list.Count; ++i )
				{
					Mobile m = (Mobile)list[i];

					int damage = (int)(m.Hits * scalar);

					damage += Utility.RandomMinMax( -5, 5 );

					if ( damage < 1 )
						damage = 1;

					m.MovingParticles( this, 0x36F4, 1, 0, false, false, 32, 0, 9535,    1, 0, (EffectLayer)255, 0x100 );
					m.MovingParticles( this, 0x0001, 1, 0, false,  true, 32, 0, 9535, 9536, 0, (EffectLayer)255, 0 );

					this.DoHarmful( m );
					this.Hits += AOS.Damage( m, this, damage, 100, 0, 0, 0, 0 );
				}
			}
		}

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextAbilityTime )
			{
				Mobile combatant = this.Combatant;

				if ( combatant != null && combatant.Map == this.Map && combatant.InRange( this, 12 ) )
				{
					m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 15 ) );

					int ability = Utility.Random( 4 );

					switch ( ability )
					{
						case 1: DoAreaLeech(); break;
					}
				}
			}

			if ( DateTime.Now > m_Delay )
			{
				Ability2.Aura( this, 10, 20, 2, 3, 0, "The radiating energy emitted from the creature is damaging you!" );
				m_Delay = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 5, 10 ) );
			}

			base.OnThink();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override bool AlwaysMurderer{ get{ return true; } }
        public override bool BardImmune { get { return true; } }
        public override bool Unprovokable { get { return true; } }
        public override bool Uncalmable { get { return true; } }
        public override bool AreaPeaceImmune { get { return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null )
			{
				int hitback = damage;
				AOS.Damage( from, this, hitback, 100, 0, 0, 0, 0 );
			}
		}

		public ToxicOoze( Serial serial ) : base( serial )
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
				BaseSoundID = 655;
		}
	}
}
