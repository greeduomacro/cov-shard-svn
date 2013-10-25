//System Created by Xeonlive
//Check Out http://xeonlive.com
using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Engines.Quests.Haven;
using Server.Engines.Quests.Necro;
using System.Collections.Generic;

namespace Server.Commands
{
	public class GenFactionDonateBox
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GenFactionDonateBox", AccessLevel.Administrator, new CommandEventHandler( GenFactionDonateBox_OnCommand ) );
		}

		[Usage( "GenFactionDonateBox" )]
		[Description( "Generates Faction Donation Box" )]
		private static void GenFactionDonateBox_OnCommand( CommandEventArgs e )
		{

			e.Mobile.SendMessage( "Generating Faction Donation Box's, please wait." );
			
			FactionBox altar;
			//CoM Base
			altar = new FactionBox();
			{
			altar.MoveToWorld( new Point3D( 3802, 2240, 20 ), Map.Felucca );
			}
			//Minax Base
			altar = new FactionBox();
			{
			altar.MoveToWorld( new Point3D( 1122, 2596, 23 ), Map.Felucca );
			}
			//ShadowLords Base
			altar = new FactionBox();
			{
			altar.MoveToWorld( new Point3D( 946, 713, 0 ), Map.Felucca );
			}
			//TB Base
			altar = new FactionBox();
			{
			altar.MoveToWorld( new Point3D( 1331, 1621, 50 ), Map.Felucca );
			}

			e.Mobile.SendMessage( "Generating Faction Donation Box's Done." );
		}
	}
}