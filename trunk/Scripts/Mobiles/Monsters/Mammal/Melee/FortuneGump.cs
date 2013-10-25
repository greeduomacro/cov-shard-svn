using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;
using Server.Network;

/*
1060886 - Your endurance shall protect you from your enemies blows.	+1 to +10 Phys
1060887 - A smile will be upon your lips, as you gaze into the infernos.	+1 to +10 Fire
1060888 - The ice of ages will embrace you, and you will embrace it alike.	+1 to +10 Cold
1060889 - Your blood runs pure and strong.				+1 to +10 Poison
1060890 - Your flesh shall endure the power of storms.			+1 to +10 Energy
1060891 - Seek riches and they will seek you.				+10 to +50 Luck
1060892 - The power of alchemy shall thrive within you.			+5 to +25 Enhance Potions
1060893 - Fate smiles upon you this day.				+10 to +100 Luck
1060894 - A keen mind in battle will help you avoid injury.			+1 to +10 Defense
1060895 - The flow of the ether is strong within you.			+1 to +3 Mana regan

1060901 - Your wounds in battle shall run deep.				-1 to -10 Phys
1060902 - The fires of the abyss shall tear asunder your flesh!		-1 to -10 Fire
1060903 - Winter’s touch shall be your undoing.				-1 to -10 Cold
1060904 - Your veins will freeze with poison’s chill.			-1 to -10 Poison
1060905 - The wise will seek to avoid the anger of storms.			-1 to -10 Energy
1060906 - Your dreams of wealth shall vanish like smoke.			-10 to -50 Luck
1060907 - The strength of alchemy will fail you.				-5 to -25 Enhance Potions
1060908 - Only fools take risks in fate’s shadow.			-50 to -100 Luck
1060909 - Your lack of focus in battle shall be your undoing.		-1 to -10 Defense
1060910 - Your connection with the ether is weak, take heed.		-1 to -3 Mana Regen
*/

namespace Server.Gumps
{
	public class FortuneGump : Gump
	{
		private Sphynx m_Sphynx;

		public FortuneGump( Sphynx sphynx ) : base( 150, 50 )
		{
			m_Sphynx = sphynx;

			Closable=false;
			Disposable=false;
			Dragable=true;
			Resizable=false;
			AddPage( 0 );
			AddImage( 0, 0, 3600 );
			AddImageTiled( 0, 14, 15, 200, 3603 );
			AddImageTiled( 380, 14, 14, 200, 3605 );
			AddImage( 0, 201, 3606 );
			AddImageTiled( 15, 201, 370, 16, 3607 );
			AddImageTiled( 15, 0, 370, 16, 3601 );
			AddImage( 380, 0, 3602 );
			AddImage( 380, 201, 3608 );
			AddImageTiled( 15, 15, 365, 190, 2624);
			AddRadio( 30, 140, 9727, 9730, false, 1 );
			AddHtmlLocalized( 65, 145, 300, 25, 1060863, 32767, false, false ); // Pay for the reading.
			AddRadio( 30, 175, 9727, 9730, true, 2 );
			AddHtmlLocalized( 65, 178, 300, 25, 1060862, 32767, false, false ); // No thanks. I decide my own destiny!
			AddHtmlLocalized( 30, 20, 360, 35, 1060864, 32767, false, false ); // Interested in your fortune, are you?  The ancient Sphynx can read the future for you - for a price of course...
			AddImage( 65, 72, 5605 );
			AddImageTiled( 80, 90, 200, 1, 9107 );
			AddImageTiled( 95, 92, 200, 1, 9157 );
			AddLabel( 90, 70, 140, "5000" );
			AddHtmlLocalized( 140, 70, 100, 25, 1023823, 32767, false, false ); // gold coins
			AddButton( 290, 175, 247, 248, 1, GumpButtonType.Reply, 0 );
			AddImageTiled( 15, 14, 365, 1, 9107 );
			AddImageTiled( 380, 14, 1, 190, 9105 );
			AddImageTiled( 15, 205, 365, 1, 9107 );
			AddImageTiled( 15, 14, 1, 190, 9105 );
			AddImageTiled( 0, 0, 395, 1, 9157 );
			AddImageTiled( 394, 0, 1, 217, 9155 );
			AddImageTiled( 0, 216, 395, 1, 9157 );
			AddImageTiled( 0, 0, 1, 217, 9155 );
			AddHtmlLocalized( 30, 105, 340, 40, 1060865, 0xB5CE6B, false, false ); // Do you accept this offer?  The funds will be withdrawn from your backpack.
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Sphynx == null || m_Sphynx.Deleted )
				return;

			PlayerMobile m = sender.Mobile as PlayerMobile;

			if ( info.ButtonID == 1 && info.IsSwitched( 1 ) )
			{
				Container pack = m.Backpack;

				if ( pack != null && pack.ConsumeTotal( typeof( Gold ), 5000 ) )
				{
					m.SendLocalizedMessage( 1060867 ); // You pay the fee.
					TellFortune( m );
					TellFortune( m );
					m_Told.Add( m );
					m.FortuneExpire = DateTime.Now + TimeSpan.FromHours( 24 );
				}
				else
					m.SendLocalizedMessage( 1061006 ); // You haven't got the coin to make the proper donation to the Sphynx.  Your fortune has not been read.
			}
			else
				m.SendLocalizedMessage( 1061007 ); // You decide against having your fortune told.
		}

		public void TellFortune( PlayerMobile from )
		{
			switch ( Utility.Random( 20 ) )
			{
				case 0: from.ApplyFortune( 1, Utility.RandomMinMax( 1, 10 ) ); break;
				case 1: from.ApplyFortune( 2, Utility.RandomMinMax( 1, 10 ) ); break;
				case 2: from.ApplyFortune( 3, Utility.RandomMinMax( 1, 10 ) ); break;
				case 3: from.ApplyFortune( 4, Utility.RandomMinMax( 1, 10 ) ); break;
				case 4: from.ApplyFortune( 5, Utility.RandomMinMax( 1, 10 ) ); break;
				case 5: from.ApplyFortune( 6, Utility.RandomMinMax( 10, 50 ) ); break;
				case 6: from.ApplyFortune( 7, Utility.RandomMinMax( 1, 5 ) * 5 ); break;
				case 7: from.ApplyFortune( 8, Utility.RandomMinMax( 50, 100 ) ); break;
				case 8: from.ApplyFortune( 9, Utility.RandomMinMax( 1, 10 ) ); break;
				case 9: from.ApplyFortune( 10, Utility.RandomMinMax( 1, 3 ) ); break;
				case 10: from.ApplyFortune( 11, Utility.RandomMinMax( 1, 10 ) ); break;
				case 11: from.ApplyFortune( 12, Utility.RandomMinMax( 1, 10 ) ); break;
				case 12: from.ApplyFortune( 13, Utility.RandomMinMax( 1, 10 ) ); break;
				case 13: from.ApplyFortune( 14, Utility.RandomMinMax( 1, 10 ) ); break;
				case 14: from.ApplyFortune( 15, Utility.RandomMinMax( 1, 10 ) ); break;
				case 15: from.ApplyFortune( 16, Utility.RandomMinMax( 10, 50 ) ); break;
				case 16: from.ApplyFortune( 17, Utility.RandomMinMax( 1, 5 ) * 5 ); break;
				case 17: from.ApplyFortune( 18, Utility.RandomMinMax( 50, 100 ) ); break;
				case 18: from.ApplyFortune( 19, Utility.RandomMinMax( 1, 10 ) ); break;
				case 19: from.ApplyFortune( 20, Utility.RandomMinMax( 1, 3 ) ); break;
			}
		}

		private static List<PlayerMobile> m_Told = new List<PlayerMobile>();

		public static List<PlayerMobile> Told{ get{ return m_Told; } set{ m_Told = value; } }
	}
}