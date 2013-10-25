// Created by Peoharen.
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server
{
	public class TempHP
	{
		private static Dictionary<Serial, int> m_MobileList = new Dictionary<Serial, int>();
		public static Dictionary<Serial, int> MobileList
		{
			get{ return m_MobileList; }
		}

		public static int Has( Mobile m )
		{
			if ( !m_MobileList.ContainsKey( m.Serial ) )
				return m_MobileList[m.Serial];
			else
				return 0;
		}

		public static void Give( Mobile m, int amount )
		{
			Give( m, amount, false );
		}

		public static void Give( Mobile m, int amount, bool stacks )
		{
			if ( !m_MobileList.ContainsKey( m.Serial ) )
				m_MobileList.Add( m.Serial, amount );

			if ( m_MobileList[m.Serial] < amount )
			{
				m.SendMessage( "you were given {0} temporary hit points", (amount - m_MobileList[m.Serial]) );
				m_MobileList[m.Serial] = amount;
			}
		}

		public static int Damage( Mobile m, int amount )
		{
			if ( !m_MobileList.ContainsKey( m.Serial ) )
				return 0;

			if ( m_MobileList[m.Serial] > amount )
			{
				m_MobileList[m.Serial] -= amount;
				return 0;
			}
			else
			{
				amount -= m_MobileList[m.Serial];
				Remove( m );
				return amount;
			}
		}

		public static void Remove( Mobile m )
		{
			if ( !m_MobileList.ContainsKey( m.Serial ) )
				m_MobileList.Remove( m.Serial );
		}
	}
}
