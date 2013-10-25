// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;
using Server.Targeting;

namespace Server.Mobiles
{
	public class BlueMonster : BaseCreature
	{
		public DateTime m_LastCast;

		// Change to alter how fast it uses the blue spell. If you are using a spellcasting AI then this delay should be longer than you would for a melee based AI
		public virtual TimeSpan CastDelay{ get{ return TimeSpan.FromSeconds( 15.0 ); } }

		// Just spell out the name of the spell class, so easy to use. :)
		public virtual Type SpellToCast{ get{ return null; } }

		// Only override this if you want the creature to use it's blue spell outside of combat.
		public virtual bool UsesOnThink{ get{ return false; } }

		// Used to prevent casting, meant only for use of studying corpses to learn the spell.
		public virtual bool DontCast{ get{ return false; } }

		public BlueMonster( AIType aitype, FightMode fightmode, int spot, int meleerange, double passivespeed, double activespeed ) : base( aitype, fightmode, spot, meleerange, passivespeed, activespeed )
		{
			m_LastCast = DateTime.Now;

			// forces these skills to defualt to 100.0, just in case.
			SetSkill( SkillName.Forensics, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
		}

		public override void OnThink()
		{
			if ( !DontCast && UsesOnThink )
			{
				if ( DateTime.Now > m_LastCast )
				{
					if ( SpellToCast != null )
					{
						DebugSay( "Trying to cast {0}", SpellToCast );
						BlueSpellInfo.UseBluePower( this, SpellToCast );
					}

					m_LastCast = DateTime.Now + CastDelay;
				}
			}

			if ( this.Target != null )
				if ( AI != AIType.AI_Mage /*&& AI != AIType.AI_Necromage && AI != AIType.AI_Paladin*/ )
					if ( this.Target.Flags == TargetFlags.Harmful && Combatant != null )
						this.Target.Invoke( this, Combatant );
					else if ( this.Target.Flags == TargetFlags.Beneficial )
						this.Target.Invoke( this, this );
		}

		public override void OnActionCombat()
		{
			if ( !DontCast && !UsesOnThink ) 
			{
				if ( DateTime.Now > m_LastCast )
				{
					if ( SpellToCast != null )
					{
						DebugSay( "Trying to cast {0}", SpellToCast.ToString() );
						BlueSpellInfo.UseBluePower( this, SpellToCast );
					}

					m_LastCast = DateTime.Now + CastDelay;
				}
			}

			base.OnActionCombat();
		}

		// List<Mobile> list = BlueMonster.GetNearbyMobiles( this, 3, true );
		public static List<Mobile> GetNearbyMobiles( Mobile from, int range, bool harm )
		{
			List<Mobile> list = new List<Mobile>();

			foreach( Mobile m in from.GetMobilesInRange( range ) )
			{
				if ( harm && from == m )
					continue;
				else if ( m != null && BlueSpell.CanTarget( from, m, true ) )
					list.Add( m );
			}

			return list;
		}

		public BlueMonster( Serial serial ) : base( serial )
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

			m_LastCast = DateTime.Now;
		}
	}
}