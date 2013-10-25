//Created by Peoharen
using System;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Necromancy;

namespace Server.Items
{
	public class MarkovsBardiche : Bardiche, IBlueWeapon
	{
		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 28; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash2H; } }
		public override int DefMaxRange { get { return 2; } }

		[Constructable]
		public MarkovsBardiche()
		{
			Name = "Markov Tirel's Bardiche";
			Hue = 1194;
			Attributes.WeaponSpeed = 35;
			WeaponAttributes.SelfRepair = 1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent == from )
			{
				from.CloseGump( typeof( PowerAttackGump ) );
				from.SendGump( new PowerAttackGump( this ) );
			}
			else
				base.OnDoubleClick( from );
		}

		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				Name = "<BASEFONT ALIGN='CENTER' COLOR='#007FFF'>Markov Tirel's Bardiche";
			}

			base.OnAdded( parent );
		}

		public override void OnRemoved( object parent )
		{
			Name = "Markov Tirel's Bardiche";
			base.OnRemoved( parent );
		}

		public override TimeSpan GetDelay( Mobile m )
		{
			if ( m is BlueMarkov || m.AccessLevel > AccessLevel.Player )
				return TimeSpan.FromSeconds( 1.0 );
			else
				return base.GetDelay( m );
		}

		public override bool CheckHit( Mobile attacker, Mobile defender )
		{
			if ( attacker is BlueMarkov || attacker.AccessLevel > AccessLevel.Player )
				return true;
			else
				return base.CheckHit( attacker, defender );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			if ( attacker != null && defender != null )
			{
				// No special effects 90% of the time for players
				if ( attacker.Player && attacker.AccessLevel == AccessLevel.Player && Utility.RandomDouble() < 0.90 )
					return;

				// Always bleed.
				if ( !BleedAttack.IsBleeding( defender ) )
				{
					// Necromancers under Lich or Wraith Form are immune to Bleed Attacks.
					TransformContext context = TransformationSpellHelper.GetContext( defender );

					if ( (context != null && ( context.Type == typeof( LichFormSpell ) || context.Type == typeof( WraithFormSpell ))) ||
						(defender is BaseCreature && ((BaseCreature)defender).BleedImmune) )
					{
						return;
					}
					else if ( defender is PlayerMobile )
					{
						defender.LocalOverheadMessage( MessageType.Regular, 0x21, 1060757 ); // You are bleeding profusely
						defender.NonlocalOverheadMessage( MessageType.Regular, 0x21, 1060758, defender.Name ); // ~1_NAME~ is bleeding profusely
					}

					defender.PlaySound( 0x133 );
					defender.FixedParticles( 0x377A, 244, 25, 9950, 31, 0, EffectLayer.Waist );

					BleedAttack.BeginBleed( defender, attacker, true );
				}

				// 20% chance of Mortal Strike, costs 10 stam each use but cannot be used if you have < 80 stam.
				if ( Utility.RandomDouble() > 0.80 && attacker.Stam > 79 && !MortalStrike.IsWounded( defender ) )
				{
					MortalStrike.BeginWound( defender, TimeSpan.FromSeconds( 6.0 ) );

					attacker.SendLocalizedMessage( 1060086 ); // You deliver a mortal wound!
					defender.SendLocalizedMessage( 1060087 ); // You have been mortally wounded!

					defender.PlaySound( 0x1E1 );
					defender.FixedParticles( 0x37B9, 244, 25, 9944, 31, 0, EffectLayer.Waist );

					attacker.Stam -= 15;
				}
			}
		}

		public MarkovsBardiche( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}