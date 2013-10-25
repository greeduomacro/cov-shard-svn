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
	[Description( "Level: 5<br>Duration: (Bonus * 8) Seconds<br>Target: Ally<br>Creates a barrier around the target enhances their defense." )]
	public class MightyGuardSpell : BlueSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "Mighty Guard", "", 230 );

		public override int PowerLevel{ get{ return 5; } }
		public override bool IsHarmful{ get{ return false; } }

		public MightyGuardSpell( Mobile from ) : base( from, m_Info )
		{
		}

		public override void OnTarget( Mobile target )
		{
			/* Effects.SendMovingEffect( 
				IEntity from, 
				IEntity to, 
				int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode );  */

			// West
			Effects.SendMovingEffect( 
				new Entity( Serial.Zero, new Point3D( target.X - 1, target.Y, target.Z - 20 ), target.Map ), 
				new Entity( Serial.Zero, new Point3D( target.X - 1, target.Y, target.Z + 20 ), target.Map ), 
				14678, 5, 1, false, false, 1, 4 );

			// North
			Effects.SendMovingEffect( 
				new Entity( Serial.Zero, new Point3D( target.X, target.Y - 1, target.Z - 20 ), target.Map ), 
				new Entity( Serial.Zero, new Point3D( target.X, target.Y - 1, target.Z + 20 ), target.Map ), 
				14662, 5, 1, false, false, 1, 4 );

			// East
			Effects.SendMovingEffect( 
				new Entity( Serial.Zero, new Point3D( target.X + 1, target.Y, target.Z - 20 ), target.Map ), 
				new Entity( Serial.Zero, new Point3D( target.X + 1, target.Y, target.Z + 20 ), target.Map ), 
				14678, 5, 1, false, false, 1, 4 );

			// South
			Effects.SendMovingEffect( 
				new Entity( Serial.Zero, new Point3D( target.X, target.Y + 1, target.Z - 20 ), target.Map ), 
				new Entity( Serial.Zero, new Point3D( target.X, target.Y + 1, target.Z + 20 ), target.Map ), 
				14662, 5, 1, false, false, 1, 4 );

			target.SendMessage( "You are under the effects of Mightyguard" );

			if ( Status.Enabled )
			{
				ShellSpell.BeginShell( target, (int)( ScaleBySkill( Caster, DamageSkill ) * 8 ) );
				ProtectSpell.BeginProtect( target, (int)( ScaleBySkill( Caster, DamageSkill ) * 8 ) );
			}
			else
			{
				int bonus = (int)( ScaleBySkill( Caster, DamageSkill ) );
				int buff = 0;
				List<ResistanceMod> mods = new List<ResistanceMod>();

				// Physical
				buff = target.GetMinResistance( ResistanceType.Physical ) + bonus;

				if ( target.PhysicalResistance < buff )
					mods.Add( new ResistanceMod( ResistanceType.Physical, buff ) );

				// Fire
				buff = target.GetMinResistance( ResistanceType.Fire ) + bonus;

				if ( target.PhysicalResistance < buff )
					mods.Add( new ResistanceMod( ResistanceType.Fire, buff ) );

				// Cold
				buff = target.GetMinResistance( ResistanceType.Cold ) + bonus;

				if ( target.PhysicalResistance < buff )
					mods.Add( new ResistanceMod( ResistanceType.Cold, buff ) );

				// Poison
				buff = target.GetMinResistance( ResistanceType.Poison ) + bonus;

				if ( target.PhysicalResistance < buff )
					mods.Add( new ResistanceMod( ResistanceType.Poison, buff ) );

				// Energy
				buff = target.GetMinResistance( ResistanceType.Energy ) + bonus;

				if ( target.PhysicalResistance < buff )
					mods.Add( new ResistanceMod( ResistanceType.Energy, buff ) );

				ResistanceMod[] modarray = mods.ToArray();

				for ( int i = 0; i < modarray.Length; i++ )
					target.AddResistanceMod( modarray[i] );

				TimedResistanceMod.AddMod( target, "Mighty Guard", modarray, TimeSpan.FromSeconds( ( ScaleBySkill( Caster, DamageSkill ) * 12 ) ) );
			}

			BlueMageControl.CheckKnown( target, this, CanTeach( target ) );
		}

	}
}