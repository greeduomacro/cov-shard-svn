//System Created by Xeonlive
//Check Out http://xeonlive.com
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Necromancy;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Network;
using Server.ContextMenus;
using Server.Factions;

namespace Server.Gumps
{
    public class FactionItemsGump : Gump
    {
		private Mobile m_Mobile; 
		private Item m_Deed; 
		public Faction m_Faction;

		[CommandProperty( AccessLevel.GameMaster )]
		public Faction Faction
		{
			get{ return m_Faction; }
		}

        public FactionItemsGump( Mobile from, Item deed ) : base( 30, 20 )
        {
			
			m_Mobile = from; 
			m_Deed = deed;  

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			//AddBackground(167, -14, 145, 29, 9200);
			AddBackground(20, 3, 457, 548, 9250);
			AddLabel(42, 29, 0, @"Items");
			AddLabel(42, 69, 0, @"Fey Leggings");
			AddLabel(42, 93, 0, @"Kasa Of The Raj-in");
			AddLabel(42, 117, 0, @"Rune Beetle Carapace");
			AddLabel(42, 141, 0, @"Storm Grips");
			AddLabel(42, 165, 0, @"Crimson Cincture");
			AddLabel(42, 189, 0, @"Heart of the Lion");
			AddLabel(42, 213, 0, @"Hunter's Headdress");	
			AddLabel(42, 237, 0, @"Ring of the Vile");
			AddLabel(42, 261, 0, @"Primer On Arms");
			AddLabel(42, 285, 0, @"Tome Of Lost Knowledge");
			AddLabel(42, 309, 0, @"Spirit of the Totem");
			AddLabel(42, 333, 0, @"Wizard's Crystal Glasses");
			AddLabel(42, 357, 0, @"Clainin's Spellbook");
			AddLabel(42, 381, 0, @"Crystalline Ring");
			AddLabel(42, 405, 0, @"Folded Steel Glasses");
			AddLabel(42, 429, 0, @"Museum of Vesper Replica");
			AddLabel(42, 453, 0, @"Ornament of the Magician");
			AddLabel(42, 477, 0, @"Mace and Shield Glasses");
			AddLabel(42, 501, 0, @"The Inquisitor's Resolution");
			AddLabel(217, 69, 0, @"1000 Silver");
			AddLabel(217, 93, 0, @"1000 Silver");
			AddLabel(217, 117, 0, @"1000 Silver");
			AddLabel(217, 141, 0, @"1000 Silver");
			AddLabel(217, 165, 0, @"2000 Silver");
			AddLabel(217, 189, 0, @"2000 Silver");
			AddLabel(217, 213, 0, @"2000 Silver");
			AddLabel(217, 237, 0, @"2000 Silver");
			AddLabel(217, 261, 0, @"3000 Silver");
			AddLabel(217, 285, 0, @"3000 Silver");
			AddLabel(217, 309, 0, @"3000 Silver");
			AddLabel(217, 333, 0, @"3000 Silver");
			AddLabel(217, 357, 0, @"4000 Silver");
			AddLabel(217, 261, 0, @"3000 Silver");
			AddLabel(217, 381, 0, @"4000 Silver");
			AddLabel(217, 405, 0, @"4000 Silver");
			AddLabel(217, 429, 0, @"4000 Silver");
			AddLabel(217, 453, 0, @"5000 Silver");
			AddLabel(217, 478, 0, @"5000 Silver");
			AddLabel(217, 501, 0, @"5000 Silver");
			AddLabel(368, 29, 0, @"Rank Required");
			AddLabel(434, 69, 0, @"1");
			AddLabel(434, 93, 0, @"1");
			AddLabel(434, 117, 0, @"1");
			AddLabel(434, 141, 0, @"1");
			AddLabel(434, 165, 0, @"4");
			AddLabel(434, 189, 0, @"4");
			AddLabel(434, 213, 0, @"4");
			AddLabel(434, 237, 0, @"4");
			AddLabel(434, 261, 0, @"7");
			AddLabel(434, 285, 0, @"7");
			AddLabel(434, 309, 0, @"7");
			AddLabel(434, 333, 0, @"7");
			AddLabel(434, 357, 0, @"9");
			AddLabel(434, 381, 0, @"9");
			AddLabel(434, 405, 0, @"9");
			AddLabel(434, 429, 0, @"9");
			AddLabel(434, 453, 0, @"10");
			AddLabel(434, 478, 0, @"10");
			AddLabel(434, 501, 0, @"10");
			AddLabel(217, 29, 0, @"Cost");
			AddLabel(177, 10, 33, @"Faction Vault");
			AddLabel(160, 520, 0, @"System by Tannis Elohim");
			AddButton(368, 69, 4005, 4007, 1, GumpButtonType.Reply, 1 );  
			AddButton(368, 93, 4005, 4007, 2, GumpButtonType.Reply, 2 );  
			AddButton(368, 117, 4005, 4007, 3, GumpButtonType.Reply, 3 );  
			AddButton(368, 141, 4005, 4007, 4, GumpButtonType.Reply, 4 );  
			AddButton(368, 165, 4005, 4007, 5, GumpButtonType.Reply, 5 );  
			AddButton(368, 189, 4005, 4007, 6, GumpButtonType.Reply, 6 );  
			AddButton(368, 213, 4005, 4007, 7, GumpButtonType.Reply, 7 );  
			AddButton(368, 237, 4005, 4007, 8, GumpButtonType.Reply, 8 );  
			AddButton(368, 261, 4005, 4007, 9, GumpButtonType.Reply, 9 );  
			AddButton(368, 285, 4005, 4007, 10, GumpButtonType.Reply, 10 );  
			AddButton(368, 309, 4005, 4007, 11, GumpButtonType.Reply, 11 );  
			AddButton(368, 333, 4005, 4007, 12, GumpButtonType.Reply, 12 );  
			AddButton(368, 357, 4005, 4007, 13, GumpButtonType.Reply, 13 );  
			AddButton(368, 381, 4005, 4007, 14, GumpButtonType.Reply, 14 );  
			AddButton(368, 405, 4005, 4007, 15, GumpButtonType.Reply, 15 );  
			AddButton(368, 429, 4005, 4007, 16, GumpButtonType.Reply, 16 );  
			AddButton(368, 453, 4005, 4007, 17, GumpButtonType.Reply, 17 );  
			AddButton(368, 478, 4005, 4007, 18, GumpButtonType.Reply, 18 );  
			AddButton(368, 501, 4005, 4007, 19, GumpButtonType.Reply, 19 );  

            
        }

        

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
			
			Container pack = from.Backpack;
            switch(info.ButtonID)
            {
               case 0: //Close Gump 
				{ 
					from.CloseGump( typeof( FactionItemsGump ) );	 
					break; 
				} 
			   case 1: // fey leggings
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 1000 ) )
					{
						from.AddToBackpack( new FeyLeggingsFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				}
				case 2: // KasaOfTheRajinFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 1200 ) )
					{
						from.AddToBackpack( new KasaOfTheRajinFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 3: // RuneBeetleCarapaceFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 1000 ) )
					{
						from.AddToBackpack( new RuneBeetleCarapaceFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 4: // StormGripFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 1000 ) )
					{
						from.AddToBackpack( new StormGripFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 5: // CrimsonCinctureFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 2000 ) )
					{
						from.AddToBackpack( new CrimsonCinctureFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 6: // HeartOfTheLionFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 2000 ) )
					{
						from.AddToBackpack( new HeartOfTheLionFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 7: // HuntersHeaddressFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 2000 ) )
					{
						from.AddToBackpack( new HuntersHeaddressFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 8: // RingOfTheVileFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 2000 ) )
					{
						from.AddToBackpack( new RingOfTheVileFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 9: // APrimeronArmsDamageRemovalFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 3000 ) )
					{
						from.AddToBackpack( new APrimeronArmsDamageRemovalFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 10: // TomeOfLostKnowledgeFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 3000 ) )
					{
						from.AddToBackpack( new TomeOfLostKnowledgeFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				}
				case 11: // SpiritOfTheTotemFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 3000 ) )
					{
						from.AddToBackpack( new SpiritOfTheTotemFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 12: // WizardReadingGlassesFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 3000 ) )
					{
						from.AddToBackpack( new WizardReadingGlassesFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 13: // ClaininsSpellbookFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 4000 ) )
					{
						from.AddToBackpack( new ClaininsSpellbookFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 14: // CrystallineRing
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 4000 ) )
					{
						from.AddToBackpack( new CrystallineRingFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 15: // FoldedSteelReadingGlasses
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 4000 ) )
					{
						from.AddToBackpack( new FoldedSteelReadingGlassesFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 16: // OrderShieldMuseumofVesperReplicaFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 4000 ) )
					{
						from.AddToBackpack( new OrderShieldMuseumofVesperReplicaFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 17: // OrnamentOfTheMagicianFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 5000 ) )
					{
						from.AddToBackpack( new OrnamentOfTheMagicianFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 18: // MaceAndShieldGlassesFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 5000 ) )
					{
						from.AddToBackpack( new MaceAndShieldGlassesFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
				case 19: // InquisitorsResolutionFaction
				{ 
					Faction faction = Faction.Find( from );
					if ( pack != null && pack.ConsumeTotal( typeof( Silver ), 5000 ) )
					{
						from.AddToBackpack( new InquisitorsResolutionFaction( m_Faction,  from ) );
						from.SendMessage( "You are rewared an item for your silver." );
					}
					else
					{
						from.SendMessage( "You do not have enough silver for this item." );
					}
				from.CloseGump( typeof( FactionItemsGump ) );
				break; 
				} 
            }
        }
    }
}