// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	/*
	public enum DoorFacing
	{
		WestCW,
		EastCCW,
		WestCCW,
		EastCW,
		SouthCW,
		NorthCCW,
		SouthCCW,
		NorthCW,
		//Sliding Doors
		SouthSW,
		SouthSE,
		WestSS,
		WestSN
	}
	*/

	public class PickableDarkWoodDoor : DarkWoodDoor, ILockpickable
	{
		#region ILockpickable
		private int m_LockLevel, m_MaxLockLevel, m_RequiredSkill;
		private Mobile m_Picker;

		[CommandProperty( AccessLevel.GameMaster )]
		new public virtual bool Locked
		{
			get { return base.Locked; }
			set
			{
				base.Locked = value;

				if ( base.Locked )
					m_Picker = null;

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int LockLevel
		{
			get { return m_LockLevel; }
			set { m_LockLevel = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int MaxLockLevel
		{
			get { return m_MaxLockLevel; }
			set { m_MaxLockLevel = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int RequiredSkill
		{
			get { return m_RequiredSkill; }
			set { m_RequiredSkill = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Picker
		{
			get { return m_Picker; }
			set { m_Picker = value; }
		}

		public void LockPick( Mobile from )
		{
			Locked = false;
			Picker = from;
			Timer.DelayCall( TimeSpan.FromMinutes( 3 ), new TimerCallback( Relock ) );
		}

		private void Relock()
		{
			Locked = true;
		}
		#endregion

		[Constructable]
		public PickableDarkWoodDoor( DoorFacing facing ) : base( facing )
		{
		}

		public PickableDarkWoodDoor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_LockLevel );
			writer.Write( (int) m_MaxLockLevel );
			writer.Write( (int) m_RequiredSkill );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_LockLevel = reader.ReadInt();
			m_MaxLockLevel = reader.ReadInt();
			m_RequiredSkill = reader.ReadInt();
		}
	}
}