/*

Scripted by Rosey1
Thought up by Ashe

Based on the Monster Contract script by Darkness_PR

*/

using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Gumps
{
	public class GargoyleContractGump : Gump
	{
		private GargoyleContract MCparent;
		
		public GargoyleContractGump( Mobile from, GargoyleContract parentMC ) : base( 0, 0 )
		{
			from.CloseGump( typeof( GargoyleContractGump ) );
			
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(125, 130, 300, 170, 5170);
			this.AddLabel(165, 165, 0, @"A Contract for: " + parentMC.AmountToKill + " " + parentMC.Monster);
			this.AddLabel(165, 185, 0, @"Amount Killed: " + parentMC.AmountKilled);
			this.AddLabel(165, 205, 0, @"Reward: A clue!" );
			if ( parentMC.AmountKilled != parentMC.AmountToKill )
			{
				this.AddButton(215, 235, 2061, 2062, 1, GumpButtonType.Reply, 0);
				this.AddLabel(229, 233, 0, @"Claim Corpse");
			}
			else
			{
				this.AddButton(215, 235, 2061, 2062, 2, GumpButtonType.Reply, 0);
				this.AddLabel(229, 233, 0, @"Claim Reward");
			}

			MCparent = parentMC;
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile m_from = state.Mobile;
			
			if ( info.ButtonID == 1 )
			{
				m_from.SendMessage("Please choose the corpse to add.");
				m_from.Target = new MonsterCorpseTarget( MCparent );
			}
			if ( info.ButtonID == 2 )
			{
				MCparent.Delete();
				m_from.SendMessage("The reward has been placed in your backpack!");
				m_from.AddToBackpack( new GargoyleClue() );
				m_from.AddToBackpack( new CharlesMarker5());
			}
		}
		
		private class MonsterCorpseTarget : Target
		{
			private GargoyleContract MCparent;
			
			public MonsterCorpseTarget( GargoyleContract parentMC ) : base( -1, true, TargetFlags.None )
			{
				MCparent = parentMC;
			}
			
			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Corpse )
				{
					Corpse MCcorpse = (Corpse)o;
					
					if ( MCcorpse.Channeled )
					{
						from.SendMessage("This corpse has been desecrated and can not be claimed!");
						return;
					}
					if ( MCcorpse.Killer == from )
					{
						string m_type = "a " + MCparent.Monster;
						m_type = m_type.ToLower();
						string m_type2 = "an " + MCparent.Monster;
						m_type2 = m_type2.ToLower();
						string m_corpse = MCcorpse.Owner.Name;
						m_corpse = m_corpse.ToLower();
						
						if ( m_type == m_corpse || m_type2 == m_corpse )
						{
							MCparent.AmountKilled += 1;
							MCcorpse.Delete();	
						}
						else
							from.SendMessage("That corpse is not of the correct type!");
					}
					else
						from.SendMessage("You cannot claim someone elses work!");
				}
				else
					from.SendMessage("That is not a corpse");
			}
		}
	}
}
