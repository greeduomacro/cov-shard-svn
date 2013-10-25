// Created by Peoharen
using System;
using Server;

namespace Server.Mobiles
{
	public class SpecialPet : BaseCreature, ISpecialPet
	{
		public SpecialPet( AIType aitype, FightMode fightmode, int spot, int meleerange, double passivespeed, double activespeed ) : base( aitype, fightmode, spot, meleerange, passivespeed, activespeed )
		{
			m_AbilityOneValue = 0;
			m_AbilityTwoValue = 0;
			m_AbilityThreeValue = 0;
		}

		public int m_AbilityOneValue;
		public int m_AbilityTwoValue;
		public int m_AbilityThreeValue;

		#region ISpecialPet
		public virtual string AbilityOneName{ get{ return ""; } }
		public virtual string AbilityTwoName{ get{ return ""; } }
		public virtual string AbilityThreeName{ get{ return ""; } }
		public virtual int AbilityOneLimit{ get{ return 100; } }
		public virtual int AbilityTwoLimit{ get{ return 100; } }
		public virtual int AbilityThreeLimit{ get{ return 100; } }
		public virtual int AbilityOneCost{ get{ return 1; } }
		public virtual int AbilityTwoCost{ get{ return 1; } }
		public virtual int AbilityThreeCost{ get{ return 1; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int AbilityOneValue
		{
			get{ return m_AbilityOneValue; }
			set{ AbilityOneValue = value; CheckChange( 1 );  }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int AbilityTwoValue
		{
			get{ return m_AbilityTwoValue; }
			set{ AbilityTwoValue = value; CheckChange( 2 ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int AbilityThreeValue
		{
			get{ return m_AbilityThreeValue; }
			set{ AbilityThreeValue = value; CheckChange( 3 );  }
		}

		public virtual void CheckChange( int ability )
		{
		}
		#endregion

		public SpecialPet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (int) m_AbilityOneValue );
			writer.Write( (int) m_AbilityTwoValue );
			writer.Write( (int) m_AbilityThreeValue );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_AbilityOneValue = reader.ReadInt();
			m_AbilityTwoValue = reader.ReadInt();
			m_AbilityThreeValue = reader.ReadInt();
		}
	}
}