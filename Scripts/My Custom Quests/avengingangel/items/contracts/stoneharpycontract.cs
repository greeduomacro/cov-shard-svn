/*

Scripted by Rosey1
Thought up by Ashe

Based on the Monster Contract script by Darkness_PR

*/

using System; 
using Server;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable( 0x14EF, 0x14F0 )]
	public class StoneHarpyContract : Item
	{
		private string m_type;
		private int m_amount;
		private int m_killed;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string Monster
		{
			get{ return m_type; }
			set{ m_type = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int AmountToKill
		{
			get{ return m_amount; }
			set{ m_amount = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int AmountKilled
		{
			get{ return m_killed; }
			set{ m_killed = value; }
		}
		
		[Constructable]
		public StoneHarpyContract() : base( 0x14EF )
		{
			Movable = true;
			LootType = LootType.Blessed;
			Monster = GetRandomMonster( 1 );
			AmountToKill = 5;
			Name = "a Contract: " + AmountToKill + " " + Monster + "s";
			AmountKilled = 0;
		}
		
		[Constructable]
		public StoneHarpyContract( string type, int atk) : base( 0x14F0 )
		{
			Movable = true;
			LootType = LootType.Blessed;
			Monster = type;
			AmountToKill = atk;
			Name = "a Contract: " + AmountToKill + " " + Monster + "s";
			AmountKilled = 0;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if( IsChildOf( from.Backpack ) )
			{
				from.SendGump( new StoneHarpyContractGump( from, this ) );
			} 
			else 
		    {
		    	from.SendLocalizedMessage( 1047012 ); // This contract must be in your backpack to use it
		    }
		}
		
		public StoneHarpyContract( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		
			writer.Write( m_type );
			writer.Write( m_amount );
			writer.Write( m_killed );
		}

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
			
			m_type = reader.ReadString();
			m_amount = reader.ReadInt();
			m_killed = reader.ReadInt();
			LootType = LootType.Blessed;
		}
		
	public string GetRandomMonster(int genre)
	{
		switch (Utility.Random(1))
		{
          default:
          case 0: return "Stone Harpy"; 
		}
	}
  }
}
