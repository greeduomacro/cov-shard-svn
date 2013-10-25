//                                          `..`     
//  `NNm`     .mNd   Mo  /M-     oM`     `odhssyms`  
//  `Mohd    `msym   Ms  /M-     oM`    `dd`    `dm` 
//  `Mo`ms   hh ym   Ms  /M-     oM`    :M/      +M: 
//  `Mo -M+ sm` ym   Ms  /M-     oM`    :M/      +M- 
//  `Mo  +MsN.  ym   Ms  /M-     oM`     dm.    :Ny  
//  `d+   sm:   sh   d+  -mhyyyo +mhyyy/ `+hhyyhy:   
//
// Scripting for Ultima Online Freeshard Absogeno: http://absogeno.de
                                                  
using System;
using Server;
using System.Collections;
using Server.Items; 
using Server.Items.Crops;
using Server.Commands;
using Server.Scripts.Commands;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Multis.Deeds;
using Server.Regions;
using Server.Network;
using Server.Targeting;
using Server.Accounting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Guilds;
using Server.Engines.BulkOrders;
using Server.Multis;

namespace Server.Misc
{

	public class Changehouse
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Changehouse", AccessLevel.Administrator, new CommandEventHandler( Changehouse_OnCommand ) );
		}

		[Usage( "Changehouse" )]
		[Description( "Change the ItemID of Housefoundations over 0x147B." )]
		public static void Changehouse_OnCommand( CommandEventArgs e )
		{			
			try
			{
				foreach ( Item item in World.Items.Values )
				{
					if ( item is HouseFoundation && item.ItemID > 0x147B )
					{
                item.ItemID -= 0x4000;
					}
				}

			}
			catch (Exception err)
			{
				e.Mobile.SendMessage( "Exception: " + err.Message );
			}
		}
	}
}
