using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Regions;


/*
 * PredatorAI, its an animal that can attack
 *	Dont flee but dont attack if not hurt or attacked
 * 
 */ 

namespace Server.Mobiles
{
	public class FlyingPredatorAI : BaseAI
	{
		public FlyingPredatorAI(BaseCreature m) : base (m)
		{
		}

		public override bool DoActionWander()
		{
			if ( ((BaseCreature)m_Mobile).CanFly == false )
			{
				((BaseCreature)m_Mobile).IsFlying = false;
			}
			if ( m_Mobile.Combatant != null )
			{
				m_Mobile.DebugSay( "I am hurt or being attacked, I kill him" );						
				Action = ActionType.Combat;
			}
			else if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, true, false, true))
			{
				m_Mobile.DebugSay( "There is something near, I go away" );
				Action = ActionType.Backoff;
			}
			else if ( ((BaseCreature)m_Mobile).IsFlying == true )
			{
				return false;
			}
			else
			{
				base.DoActionWander();
			}

			return true;
		}

		public override bool DoActionCombat()
		{
			if ( m_Mobile.IsFlying == true )
				m_Mobile.IsFlying = false;

			Mobile combatant = m_Mobile.Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != m_Mobile.Map )
			{
				m_Mobile.DebugSay( "My combatant is gone, so my guard is up" );
				Action = ActionType.Wander;
				return true;
			}

			if ( WalkMobileRange( combatant, 1, true, m_Mobile.RangeFight, m_Mobile.RangeFight ) )
			{
				m_Mobile.Direction = m_Mobile.GetDirectionTo( combatant );
			}
			else
			{
				if ( m_Mobile.GetDistanceToSqrt( combatant ) > m_Mobile.RangePerception + 1 )
				{
					m_Mobile.DebugSay( "I cannot find {0}", combatant.Name );

					Action = ActionType.Wander;
					return true;
				}
				else
				{
					m_Mobile.DebugSay( "I should be closer to {0}", combatant.Name );
				}
			}

			return true;
		}

		public override bool DoActionBackoff()
		{
			if ( ((BaseCreature)m_Mobile).CanFly == true && ((BaseCreature)m_Mobile).IsFlying == false )
			{
				((BaseCreature)m_Mobile).FlyStam = ((BaseCreature)m_Mobile).FlyStamMax;
			}
			if ( m_Mobile.IsHurt() || m_Mobile.Combatant != null )
			{
				Action = ActionType.Combat;
			}
			else
			{
				if (AcquireFocusMob(m_Mobile.RangePerception * 2, FightMode.Closest, true, false , true))
				{
					if ( WalkMobileRange(m_Mobile.FocusMob, 1, false, m_Mobile.RangePerception, m_Mobile.RangePerception * 2) )
					{
						m_Mobile.DebugSay( "Well, here I am safe" );
						Action = ActionType.Wander;
					}					
				}
				else
				{
					m_Mobile.DebugSay( "I have lost my focus, lets relax" );
					Action = ActionType.Wander;
				}
			}

			return true;
		}
	}
}