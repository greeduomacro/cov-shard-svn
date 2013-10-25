//   RunUO script: Skill Ball
//   Copyright (c) 2003 by Wulf C. Krueger <wk@mailstation.de>
//
//   This script is free software; you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation; version 2 of the License applies.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   Please do NOT remove or change this header.

using System;
using Server.Network;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
   public class SkillBall : Item
   {
      private int m_SkillBonus = 100;
      private string m_BaseName = "a skill ball +";

      [CommandProperty( AccessLevel.Player )] 
      public int SkillBonus
      {
	get { return m_SkillBonus; }
	set { 
	  m_SkillBonus = value; 
	  this.Name = m_BaseName + Convert.ToString(m_SkillBonus); 
	}
      }

      [Constructable]
      public SkillBall( int SkillBonus ) : base( 6249 )
      {
	m_SkillBonus = SkillBonus;
	Movable = false;
	Name = m_BaseName + Convert.ToString(SkillBonus); 
      }

      [Constructable]
      public SkillBall() : base( 6249 )
      {
	Name = m_BaseName + Convert.ToString(SkillBonus); 
	Movable = false;
      }

      public SkillBall( Serial serial ) : base( serial )
      {
      }

      public override void OnDoubleClick( Mobile from )
      {
	from.CloseGump( typeof( SkillBallGump));
	if ( (this.SkillBonus == 0) && (from.AccessLevel < AccessLevel.GameMaster) ) {
	  from.SendMessage("This Skill Ball isn't charged. Please page for a GM.");
	  return;
	}
	else if ( (from.AccessLevel >= AccessLevel.GameMaster) && (this.SkillBonus == 0) ) {
	  from.SendGump( new PropertiesGump( from, this ) );
	  return;
	}

	if ( !IsChildOf( from.Backpack ) ) 
	  from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
	else
	  from.SendGump( new SkillBallGump( from, this ) );
      }

      public override void Serialize( GenericWriter writer )
      {
	base.Serialize( writer );

	writer.Write( (int) 0 ); // version
	writer.Write( m_SkillBonus );
      }

      public override void Deserialize( GenericReader reader )
      {
	base.Deserialize( reader );

	int version = reader.ReadInt();

	switch (version) {

	  case 0 : {
	    m_SkillBonus = reader.ReadInt();
	    break;
	  }
	}
      }
   }
}

namespace Server.Gumps
{
   public class SkillBallGump : Gump
   {
      private const int FieldsPerPage = 14;

      private Skill m_Skill;
      private SkillBall m_skb;

      public SkillBallGump ( Mobile from, SkillBall skb ) : base ( 20, 30 )
      {
	m_skb = skb;
	
	AddPage ( 0 );
	AddBackground( 0, 0, 260, 351, 5054 );
	
	AddImageTiled( 10, 10, 240, 23, 0x52 );
	AddImageTiled( 11, 11, 238, 21, 0xBBC );
	
	AddLabel( 65, 11, 0, "Skills you can raise" );
	
	AddPage( 1 );
	
	int page = 1;
	int index = 0;
	
	Skills skills = from.Skills;
	
	int number;
	if ( Core.AOS )
	  number = 0;
	else
	  number = 3;
	
	for ( int i = 0; i < ( skills.Length - number ); ++i ) {
	  if ( index >= FieldsPerPage ) {
	    AddButton( 231, 13, 0x15E1, 0x15E5, 0, GumpButtonType.Page, page + 1 );
	    
	    ++page;
	    index = 0;
	    
	    AddPage( page );
	    
	    AddButton( 213, 13, 0x15E3, 0x15E7, 0, GumpButtonType.Page, page - 1 );
	  }
	  
	  Skill skill = skills[i];
	  
	  if ( (skill.Base + m_skb.SkillBonus) <= 100 ) {
	    
	    AddImageTiled( 10, 32 + (index * 22), 240, 23, 0x52 );
	    AddImageTiled( 11, 33 + (index * 22), 238, 21, 0xBBC );
	    
	    AddLabelCropped( 13, 33 + (index * 22), 150, 21, 0, skill.Name );
	    AddImageTiled( 180, 34 + (index * 22), 50, 19, 0x52 );
	    AddImageTiled( 181, 35 + (index * 22), 48, 17, 0xBBC );
	    AddLabelCropped( 182, 35 + (index * 22), 234, 21, 0, skill.Base.ToString( "F1" ) );
	    
	    if ( from.AccessLevel >= AccessLevel.Player )
	      AddButton( 231, 35 + (index * 22), 0x15E1, 0x15E5, i + 1, GumpButtonType.Reply, 0 );
	    else
	      AddImage( 231, 35 + (index * 22), 0x2622 );
	    
	    ++index;
	  }
	}
      }
     
      public override void OnResponse( NetState state, RelayInfo info )
      {
	Mobile from = state.Mobile;
	
	if (from == null)
	  return;

	if ( info.ButtonID > 0 ) {
	  m_Skill = from.Skills[(info.ButtonID-1)];
	  
	  if ( m_Skill == null )
            return;
	  
          double count = 0;
	  for ( int i = 0; i < from.Skills.Length; ++i ) 
	    count += from.Skills[i].Base;
	  
          if ( (count + m_skb.SkillBonus) > (from.SkillsCap / 10) ) {
	    from.SendMessage( "You cannot exceed the skill cap." );
	    return;
	  }
	    
	  if (m_Skill.Base + m_skb.SkillBonus <= 100) {
	    m_Skill.Base += m_skb.SkillBonus;
	    from.CloseGump( typeof( SkillBallGump));
	    m_skb.Delete();
	  }
	  else 
	    from.SendMessage("You have to choose another skill.");
	}
      }
   }
}
