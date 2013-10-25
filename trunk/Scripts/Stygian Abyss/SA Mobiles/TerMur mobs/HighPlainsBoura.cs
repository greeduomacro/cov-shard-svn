using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Targeting;
using System.Collections;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a boura corpse" )]
	public class HighPlainsBoura: BaseCreature, ICarvable
	{
        private bool m_Stunning;
        private DateTime m_NextFurTime;

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextFurTime
        {
            get { return m_NextFurTime; }
            set { m_NextFurTime = value; Body = (DateTime.Now >= m_NextFurTime) ? 715 : 715; }
        }

        public void Carve(Mobile from, Item item)
        {
            if (DateTime.Now < m_NextFurTime)
            {
                PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1112354, from.NetState);
                return;
            }

            from.SendLocalizedMessage(1112353);
            from.AddToBackpack(new Fur(Map == Map.Felucca ? 2 : 1));

            NextFurTime = DateTime.Now + TimeSpan.FromHours(3.0);
        }

		[Constructable]
		public HighPlainsBoura() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a High plains boura";
			Body = 715;

			SetStr( 400, 435 );
			SetDex( 90, 96 );
			SetInt( 25, 30 );

			SetHits( 555, 618 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 35, 40 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Anatomy, 95.2, 105.4 );
			SetSkill( SkillName.MagicResist, 60.7, 70.0 );
			SetSkill( SkillName.Tactics, 95.4, 105.7 );
			SetSkill( SkillName.Wrestling, 105.1, 115.3 );

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 47.1;
		}

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Horned; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetIdleSound() { return 1507; } 
		public override int GetAngerSound() { return 1504; } 
		public override int GetHurtSound() { return 1506; } 
		public override int GetDeathSound()	{ return 1505; }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !m_Stunning && 0.3 > Utility.RandomDouble() )
			{
				m_Stunning = true;

				defender.Animate( 21, 6, 1, true, false, 0 );
				this.PlaySound( 0xEE );
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You have been stunned by a colossal blow!" );

				BaseWeapon weapon = this.Weapon as BaseWeapon;
				if ( weapon != null )
					weapon.OnHit( this, defender );

				if ( defender.Alive )
				{
					defender.Frozen = true;
					Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( Recover_Callback ), defender );
				}
			}
		}

		private void Recover_Callback( object state )
		{
			Mobile defender = state as Mobile;

			if ( defender != null )
			{
				defender.Frozen = false;
				defender.Combatant = null;
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You recover your senses." );
			}

			m_Stunning = false;
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            c.DropItem(new BouraPelt());


            if (Utility.RandomDouble() < 0.10)
            {
                c.DropItem(new BouraSkin());
            }
            if (Utility.RandomDouble() < 0.05)
            {
                c.DropItem(new BouraTailShield());
            }
        }

		public HighPlainsBoura( Serial serial ) : base( serial )
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