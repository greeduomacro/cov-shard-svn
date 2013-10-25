using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a human corpse" )]
	public class EvilRanger : BaseCreature
	{

		private ArrayList m_Spawns;
		private DateTime m_NextSpawn;
		private DateTime m_NextAbility;
		[Constructable]
		public EvilRanger() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			m_Spawns = new ArrayList();
			Name = NameList.RandomName( "male" );
			Title = "the Evil Ranger";
			Body = 400;
			BaseSoundID = 0x45A;
			this.Hue = Utility.RandomSkinHue();

			SetStr( 390 );
			SetDex( 160 );
			SetInt( 400 );

			SetMana( 300 );
			SetHits( 3000 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType(ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Fire, 90 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 90 );
			SetResistance( ResistanceType.Energy, 90 );

			SetSkill( SkillName.MagicResist, 120.0 );
            SetSkill( SkillName.Magery, 120.0 );
            SetSkill( SkillName.EvalInt, 120.0 );
            SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Macing, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 45;

            RangerChest chest = new RangerChest(); //add its armor and set its hue and not movable so it won't be on loot
            chest.Hue = 0x59C;
            chest.Movable = false;
            AddItem(chest);

            RangerArms arms = new RangerArms();
            arms.Hue = 0x59C;
            arms.Movable = false;
            AddItem(arms);

            RangerGloves gloves = new RangerGloves();
            gloves.Hue = 0x59C;
            gloves.Movable = false;
            AddItem(gloves);

            RangerGorget gorget = new RangerGorget();
            gorget.Hue = 0x59C;
            gorget.Movable = false;
            AddItem(gorget);

            RangerLegs legs = new RangerLegs();
            legs.Hue = 0x59C;
            legs.Movable = false;
            AddItem(legs);

            Bow weapon = new Bow(); //add its weapon and set its hue and not movable so it won't be on loot
            weapon.Name = "Evil Ranger Bow";
            weapon.Hue = 0x59C;
            weapon.Movable = false;
            AddItem(weapon);

            FurBoots boots = new FurBoots(); //add its boots and set its hue and not movable so it won't be on loot
            boots.Hue = 0x59C;
            boots.Movable = false;
            AddItem(boots);

            Item hair = new Item(8251);  //add its hair and set its hue and not movable so it won't be on loot
            hair.Hue = 0x59C;
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem(hair);

            switch (Utility.Random(25))
            {
                case 0: PackItem(new RangerGorget()); break;
                case 1: PackItem(new RangerArms()); break;
                case 2: PackItem(new RangerGloves()); break;
                case 3: PackItem(new RangerLegs()); break;
                case 5: PackItem(new RangerChest()); break;
            } 
		}

		public override void OnThink()
		{
			if ( this.m_NextSpawn <= DateTime.Now && this.m_Spawns != null && this.m_Spawns.Count < 5 )
			{
				EvilStag GreatHart  = new EvilStag();
				GreatHart.MoveToWorld( this.Location, this.Map );
				this.m_Spawns.Add( GreatHart );
				this.m_NextSpawn = DateTime.Now + TimeSpan.FromSeconds( 45.0 );
			}

			if ( this.m_NextAbility < DateTime.Now )
			{
				if ( this.Hits < this.HitsMaxSeed && this.Combatant == null && this.Mana > 10 )
				{
					this.Hits += Utility.Random( 30, 40 );
					this.Mana -= 10;
					this.m_NextAbility = DateTime.Now + TimeSpan.FromSeconds( 5.0 );
				}
				if ( this.Combatant != null )
				{
					if ( this.Hits < this.HitsMaxSeed / 2 && this.Mana >= 10 )
					{
						this.Hits += Utility.Random( 40, 50 );
						this.Mana -= 10;
						this.Say( "Spirit of the woods, ease my pain." );
						this.m_NextAbility = DateTime.Now + TimeSpan.FromSeconds( 5.0 );
					}

					else if ( this.Combatant.Hits < this.Combatant.HitsMax / 2 && this.Mana >= 15 )
					{
						this.Say( "Guardians of Gaia, bring forth your grasping hands." );
						Blood blood = new Blood();
						blood.ItemID = 3391;
						blood.Name = "Grasping Roots";
						this.Combatant.Paralyzed = true;
						this.Mana -= 15;
						this.m_NextAbility = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
					}

					else if ( this.Mana >= 30 )
					{
						this.Say( "Gaia, bring forth your wrath!" );
						ArrayList alist = new ArrayList();
						IPooledEnumerable eable = this.Map.GetMobilesInRange( this.Location, 10 );
						foreach( Mobile m in eable )
							alist.Add( m );
						eable.Free();
						this.PlaySound( 518 );
						this.m_NextAbility = DateTime.Now + TimeSpan.FromSeconds( 15.0 );
						Effects.SendLocationParticles( EffectItem.Create( this.Location, this.Map, TimeSpan.FromSeconds( 10.0 ) ), 0x37CC, 1, 50, 2101, 7, 9909, 0 );
						if ( alist.Count > 0 )
						{
							for( int i = 0; i < alist.Count; i++ )
							{
								Mobile m = (Mobile)alist[i];
								if ( m is EvilStag )
								{}
								else
								{
									AOS.Damage( m, this, Utility.Random( 15, 20 ), 100, 0, 0, 0, 0 );
									m.BoltEffect( 2 );
								}
							}
						}
					}
				}
			}
		}

		public override bool AlwaysMurderer{ get{ return true; }}

		public override void GenerateLoot()
		{
            AddLoot(LootPack.AosUltraRich, 3);
		}

		public EvilRanger( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.WriteMobileList( m_Spawns );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Spawns = reader.ReadMobileList();
		}
	}
}