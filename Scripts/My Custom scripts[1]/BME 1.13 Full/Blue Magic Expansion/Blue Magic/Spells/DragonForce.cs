// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Spells;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.BlueMagic
{
	[Description( "Level: 2<br>Duration: 5 Minutes<br>Target: Self<br>A stackable self buff that bestows melee poweress at the cost of spellcasting (you may use special moves).<br><br>Secondary Effect<br>Level: 2<br>Duration: Instantaneous<br>Target: Enemy<br>The caster breathes a ball of fire at the target.<br><basefont color='BB0000'>*Useable only after being full transformed*</basefont>" )]
	public class DragonForceSpell : BlueSpell
	{
		public static Dictionary<Mobile, DragonInfo> DragonList = new Dictionary<Mobile, DragonInfo>();

		private static SpellInfo m_Info = new SpellInfo( "DragonForce Spell", "", 230 );

		public override int PowerLevel{ get{ return 2; } }
		public override bool IsHarmful{ get{ return false; } }
		public override SpellType BlueSpellType{ get{ return SpellType.Self; } }

		public DragonForceSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void SpellEffect( Mobile target )
		{
			if ( !DragonList.ContainsKey( target ) )
			{
				DragonList.Add( target, new DragonInfo( target ) );
				target.HueMod = 1255;
			}

			if ( !DragonList[target].AddMods() )
			{
				Caster.Target = new BlueSpellTarget( this, TargetFlags.Harmful );
				return;
			}
			else
			{
				target.HueMod++;

				// effects
				target.PlaySound( 0x1F4 );
				//TempHP.Give( target, 10, true );
				Effects.SendLocationEffect( new Point3D( target.X, target.Y, target.Z ), target.Map, 0x3709, 30, 9965, 0x501, 7 );

				BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
			}
		}

		public override void OnTarget( Mobile target )
		{
			if ( CheckHSequence( target ) )
			{
				Effects.SendMovingEffect( Caster, target, 0x36D4, 5, 0, false, false, 0, 0);
				Caster.PlaySound( 0x227 );
				SpellHelper.Damage( this, target, (int)(Caster.Hits * 0.32), 0, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		public static void Initialize()
		{
			EventSink.PlayerDeath += new PlayerDeathEventHandler( EventSink_PlayerDeath );
		}
 
		public static void EventSink_PlayerDeath( PlayerDeathEventArgs e )
		{
			if ( DragonList.ContainsKey( e.Mobile ) )
				DragonList[e.Mobile].Expire();
		}
	}

	public class DragonInfo
	{
		private Mobile Owner;
		private List<StatMod> StatMods;
		private List<DefaultSkillMod> SkillMods;
		private List<ResistanceMod> ResistMods;
		private int BonusNumber;
		private static int m_StrCap = 125;
		private static int m_DexCap = 125;
		private static double m_TacticsCap = 120.0;
		private static double m_WrestlingCap = 120.0;
		private static int m_PhysicalResistCap = 65;
		private static int m_FireResistCap = 75;

		/*
		@100.0 Forensics & five castings of this spell you'll have
		+50 Str
		+50 Dex
		+25 Tactics
		+25 Wrestling
		0.0 Magic Resist
		-150.0 Magery, Necromancy, Chivalry, Bushido, Ninjitsu, Spellweaving, & Mysticism
		+25 Physical Resist
		+50 Fire Resist
		-100 Cold Resist
		-50 Energy Resist
		*/

		public DragonInfo( Mobile owner )
		{
			Owner = owner;
			StatMods = new List<StatMod>();
			SkillMods = new List<DefaultSkillMod>();
			ResistMods = new List<ResistanceMod>();
			BonusNumber = 0;
			Timer.DelayCall( TimeSpan.FromMinutes( 5 ), new TimerCallback( Expire ) );
		}

		public void Expire()
		{
			if ( Owner == null || Owner.Deleted )
				return;

			if ( !DragonForceSpell.DragonList.ContainsKey( Owner ) )
				return;

			for ( int i = 0; i < StatMods.Count / 2; i++ )
			{
				Owner.RemoveStatMod( ("DragonForceStr" + i.ToString() ) );
				Owner.RemoveStatMod( ("DragonForceDex" + i.ToString() ) );
			}

			for ( int i = 0; i < SkillMods.Count; i++ )
				Owner.RemoveSkillMod( SkillMods[i] );

			for ( int i = 0; i < ResistMods.Count; i++ )
				Owner.RemoveResistanceMod( ResistMods[i] );

			Owner.HueMod = -1;

			DragonForceSpell.DragonList.Remove( Owner );
		}

		public bool AddMods()
		{
			if ( Owner == null )
				return false;

			BonusNumber++;

			if ( BonusNumber > 5 )
				return false;

			// @100.0 Forensics bonus's value is 10.
			double bonus = (BlueSpell.ScaleBySkill( Owner, SkillName.Forensics ) / 2.0);
			StatMod stat = null;
			DefaultSkillMod skill = null;
			ResistanceMod resist = null;
			int intdiff = 0;
			double doublediff = 0.0;

			// Str (+10 @ GM)
			intdiff = (int)( m_StrCap - (Owner.RawStr + bonus) );

			if ( intdiff > 0 )
			{
				stat = new StatMod( StatType.Str, ("DragonForceStr" + BonusNumber.ToString()), intdiff, TimeSpan.FromHours( 24 ) );
				Owner.AddStatMod( stat );
				StatMods.Add( stat );
			}

			// Dex (+10 @ GM)
			intdiff = (int)( m_DexCap - (Owner.RawDex + bonus) );

			if ( intdiff > 0 )
			{
				stat = new StatMod( StatType.Dex, ("DragonForceDex" + BonusNumber.ToString()), intdiff, TimeSpan.FromHours( 24 ) );
				Owner.AddStatMod( stat );
				StatMods.Add( stat );
			}

			// Tactics (+5.0 @ GM)
			doublediff = m_TacticsCap - (Owner.Skills[SkillName.Tactics].Value + bonus);

			if ( doublediff > 0.0 )
			{
				skill = new DefaultSkillMod( SkillName.Tactics, true, (bonus / 2) );
				Owner.AddSkillMod( skill );
				SkillMods.Add( skill );
			}

			// Wrestling (+5.0 @ GM)
			doublediff = m_WrestlingCap - (Owner.Skills[SkillName.Tactics].Value + bonus);

			if ( doublediff > 0.0 )
			{
				skill = new DefaultSkillMod( SkillName.Wrestling, true, bonus );
				Owner.AddSkillMod( skill );
				SkillMods.Add( skill );
			}

			// Lose all Magic Resist in preparation of negative resistances.
			if ( Owner.Skills[SkillName.MagicResist].Value > 0 )
			{
				skill = new DefaultSkillMod( SkillName.MagicResist, true, -Owner.Skills[SkillName.MagicResist].Value );
				Owner.AddSkillMod( skill );
				SkillMods.Add( skill );
			}

			if ( !Status.Enabled )
			{
				// Lower Magery (-30 @ GM)
				if ( Owner.Skills[SkillName.Magery].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Magery, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}

				// Lower Necromancy (-30 @ GM)
				if ( Owner.Skills[SkillName.Necromancy].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Necromancy, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}

				// Lower Chivalry (-30 @ GM)
				if ( Owner.Skills[SkillName.Chivalry].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Chivalry, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}

				// Lower Bushido (-30 @ GM)
				if ( Owner.Skills[SkillName.Bushido].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Bushido, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}

				// Lower Ninjitsu (-30 @ GM)
				if ( Owner.Skills[SkillName.Ninjitsu].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Ninjitsu, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}

				// Lower Spellweaving (-30 @ GM)
				if ( Owner.Skills[SkillName.Spellweaving].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Spellweaving, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}

				// Lower Mysticism (-30 @ GM)
				if ( Owner.Skills[SkillName.Mysticism].Value > 0 )
				{
					skill = new DefaultSkillMod( SkillName.Mysticism, true, -(bonus * 3) );
					Owner.AddSkillMod( skill );
					SkillMods.Add( skill );
				}
			}

			// Physical (+5 @ GM)
			intdiff = m_PhysicalResistCap - (int)( Owner.PhysicalResistance + (bonus / 2) );
			
			if ( intdiff > 0 )
			{
				resist = new ResistanceMod( ResistanceType.Physical, intdiff );
				Owner.AddResistanceMod( resist );
				ResistMods.Add( resist );
			}

			// Fire (+10 @ GM)
			intdiff = m_FireResistCap - (int)( Owner.FireResistance + bonus );

			if ( intdiff > 0 )
			{
				resist = new ResistanceMod( ResistanceType.Fire, (int)(bonus) );
				Owner.AddResistanceMod( resist );
				ResistMods.Add( resist );
			}

			// Cold (-20 @ GM)
			resist = new ResistanceMod( ResistanceType.Cold, (int)(-(bonus * 2)) );
			Owner.AddResistanceMod( resist );
			ResistMods.Add( resist );

			// Energy (-10 @ GM)
			resist = new ResistanceMod( ResistanceType.Energy, (int)(-bonus) );
			Owner.AddResistanceMod( resist );
			ResistMods.Add( resist );

			return true;
		}
	}

}
