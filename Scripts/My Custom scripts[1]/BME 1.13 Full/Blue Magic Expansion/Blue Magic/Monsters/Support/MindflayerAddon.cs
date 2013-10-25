
// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Regions;

namespace Server.Items
{
	public class MindflayerAddon : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new MindflayerAddonDeed(); } }

		[ Constructable ]
		public MindflayerAddon()
		{
			AddComponent( new HuedAddonComponent( 0, 128 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 298 ), 3, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 3, 4, 18 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 3, 5, 18 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 298 ), 3, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 3, 6, 18 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 4, 3, 18 );
			AddComponent( new HuedAddonComponent( 991, 2807 ), 4, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 5645 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 5646 ), 4, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 5034 ), 4, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 4, 4, 1 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 5015 ), 4, 5, 2 );
			AddComponent( new HuedAddonComponent( 991, 5037 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 5692 ), 4, 5, 4 );
			AddComponent( new HuedAddonComponent( 991, 5031 ), 4, 5, 3 );
			AddComponent( new HuedAddonComponent( 991, 5030 ), 4, 5, 1 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 4, 5, 1 );
			AddComponent( new HuedAddonComponent( 991, 5645 ), 4, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 4, 6, 18 );
			AddComponent( new HuedAddonComponent( 991, 5645 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 5037 ), 4, 6, 1 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 4, 6, 1 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 4, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 4, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 2809 ), 4, 7, 1 );
			AddComponent( new HuedAddonComponent( 991, 5646 ), 4, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 4, 8, 0 );
			AddComponent( new HuedAddonComponent( 991, 3712 ), 4, 8, 10 );
			AddComponent( new HuedAddonComponent( 991, 3712 ), 4, 8, 2 );
			AddComponent( new HuedAddonComponent( 991, 3712 ), 4, 8, 6 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 8, 11 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 8, 7 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 8, 0 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 8, 3 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 5, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 5, 3, 18 );
			AddComponent( new HuedAddonComponent( 991, 2807 ), 5, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 5646 ), 5, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 5035 ), 5, 4, 2 );
			AddComponent( new HuedAddonComponent( 991, 5037 ), 5, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 5, 4, 1 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 5, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 5, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 5692 ), 5, 5, 5 );
			AddComponent( new HuedAddonComponent( 991, 5038 ), 5, 5, 1 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 5, 5, 1 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 5, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 5, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 5, 6, 18 );
			AddComponent( new HuedAddonComponent( 991, 5036 ), 5, 6, 1 );
			AddComponent( new HuedAddonComponent( 991, 5028 ), 5, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 5, 6, 1 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 5, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 5, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 2809 ), 5, 7, 1 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 5, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 6, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 6, 3, 18 );
			AddComponent( new HuedAddonComponent( 991, 298 ), 6, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 2807 ), 6, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 6, 4, 18 );
			AddComponent( new HuedAddonComponent( 991, 5646 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 5033 ), 6, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 6, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 6, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 6, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 6, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 6, 5, 18 );
			AddComponent( new HuedAddonComponent( 991, 5032 ), 6, 5, 1 );
			AddComponent( new HuedAddonComponent( 991, 5029 ), 6, 5, 1 );
			AddComponent( new HuedAddonComponent( 991, 5692 ), 6, 5, 4 );
			AddComponent( new HuedAddonComponent( 991, 5031 ), 6, 5, 7 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 6, 5, 1 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 6, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 6, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2750 ), 6, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 298 ), 6, 6, 1 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 6, 6, 18 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 6, 6, 18 );
			AddComponent( new HuedAddonComponent( 991, 3530 ), 6, 6, 1 );
			AddComponent( new HuedAddonComponent( 991, 322 ), 6, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 323 ), 6, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 6, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 2809 ), 6, 7, 1 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 6, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 7, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 2757 ), 7, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 7, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 2808 ), 7, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 5645 ), 7, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 7, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2808 ), 7, 5, 1 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 7, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2808 ), 7, 6, 1 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 7, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 2754 ), 7, 7, 1 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 7, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 8, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 8, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 8, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 8, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 8, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 8, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 9, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 10, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 10, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 11, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 11, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 12, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 12, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 12, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 12, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 12, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 12, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 3, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 3, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 4, 9, 0 );
			AddComponent( new HuedAddonComponent( 991, 2641 ), 4, 9, 1 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 4, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 5432 ), 4, 10, 10 );
			AddComponent( new HuedAddonComponent( 991, 10219 ), 4, 10, 6 );
			AddComponent( new HuedAddonComponent( 991, 5907 ), 4, 10, 15 );
			AddComponent( new HuedAddonComponent( 991, 3651 ), 4, 10, 1 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 10, 11 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 10, 5 );
			AddComponent( new HuedAddonComponent( 991, 2860 ), 4, 10, 8 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 4, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 2641 ), 4, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 4, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 4, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 4, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 5, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 5, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 5, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 5, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 5, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 5, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 6, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 6, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 6, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 3782 ), 6, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 6, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 6, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 6, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 7, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 7, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 7, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 7, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 7, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 7, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 8, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 8, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 8, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 8, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 8, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 8, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 9, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 9, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 10, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 10, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 11, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 11, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 12, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 12, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 12, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 12, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 12, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 12, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 13, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 13, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3844 ), 13, 4, 15 );
			AddComponent( new HuedAddonComponent( 991, 2459 ), 13, 4, 15 );
			AddComponent( new HuedAddonComponent( 991, 9444 ), 13, 4, 19 );
			AddComponent( new HuedAddonComponent( 991, 9444 ), 13, 4, 14 );
			AddComponent( new HuedAddonComponent( 991, 3854 ), 13, 4, 11 );
			AddComponent( new HuedAddonComponent( 991, 3739 ), 13, 4, 21 );
			AddComponent( new HuedAddonComponent( 991, 9444 ), 13, 4, 9 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 13, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2713 ), 13, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 13, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 2 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 3 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 7 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 4 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 5 );
			AddComponent( new HuedAddonComponent( 991, 7026 ), 13, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 7026 ), 13, 6, 10 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 9 );
			AddComponent( new HuedAddonComponent( 991, 3576 ), 13, 6, 8 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 13, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 13, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 14, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 14, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3834 ), 14, 4, 9 );
			AddComponent( new HuedAddonComponent( 2101, 2861 ), 14, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 14, 4, 10 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 14, 4, 7 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 14, 4, 4 );
			AddComponent( new HuedAddonComponent( 991, 2637 ), 14, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3834 ), 14, 4, 6 );
			AddComponent( new HuedAddonComponent( 991, 3834 ), 14, 4, 3 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 14, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 14, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 14, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 7407 ), 14, 7, 13 );
			AddComponent( new HuedAddonComponent( 991, 7405 ), 14, 7, 16 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 14, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 15, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 15, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3630 ), 15, 4, 6 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 15, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 15, 4, 10 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 15, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 15, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 15, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 15, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 16, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 16, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3834 ), 16, 4, 9 );
			AddComponent( new HuedAddonComponent( 991, 3834 ), 16, 4, 6 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 16, 4, 7 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 16, 4, 4 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 16, 4, 10 );
			AddComponent( new HuedAddonComponent( 991, 2861 ), 16, 4, 1 );
			AddComponent( new HuedAddonComponent( 991, 2637 ), 16, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3834 ), 16, 4, 3 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 16, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 16, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 16, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 16, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 17, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 17, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 17, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 17, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 17, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 17, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 18, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 19, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 19, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 20, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 20, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 21, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 21, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 21, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 21, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 22, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 22, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 9230 ), 22, 4, 5 );
			AddComponent( new HuedAddonComponent( 991, 11748 ), 22, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 22, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 3602 ), 22, 5, 9 );
			AddComponent( new HuedAddonComponent( 991, 4008 ), 22, 5, 9 );
			AddComponent( new HuedAddonComponent( 991, 4006 ), 22, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 2869 ), 22, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 22, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 9234 ), 22, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 11750 ), 22, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 22, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 22, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 23, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 23, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 7742 ), 23, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 23, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 7737 ), 23, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 23, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 7736 ), 23, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 23, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 23, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 24, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 24, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3744 ), 24, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 7741 ), 24, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 24, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 7738 ), 24, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 24, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 7735 ), 24, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 24, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 24, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 25, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 1311 ), 25, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 7740 ), 25, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 25, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 7739 ), 25, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 25, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 7734 ), 25, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 25, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 25, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 26, 3, 0 );
			AddComponent( new HuedAddonComponent( 991, 1311 ), 26, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 26, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 26, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 26, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 26, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 27, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 28, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 28, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 13, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 13, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 1824 ), 13, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 6238 ), 13, 10, 5 );
			AddComponent( new HuedAddonComponent( 991, 6186 ), 13, 10, 6 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 13, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 1824 ), 13, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 6238 ), 13, 11, 11 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 13, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 1824 ), 13, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 7714 ), 13, 12, 5 );
			AddComponent( new HuedAddonComponent( 991, 4030 ), 13, 12, 5 );
			AddComponent( new HuedAddonComponent( 991, 6190 ), 13, 12, 6 );
			AddComponent( new HuedAddonComponent( 991, 6200 ), 13, 12, 6 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 13, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 13, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 14, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 14, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 1824 ), 14, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 6226 ), 14, 10, 5 );
			AddComponent( new HuedAddonComponent( 991, 6194 ), 14, 10, 6 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 14, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 14, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 1824 ), 14, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 6376 ), 14, 12, 5 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 14, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 14, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 15, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 15, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 15, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 15, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 15, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 15, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 16, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 16, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 16, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 16, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 16, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 16, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 17, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 17, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 17, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 17, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 17, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 17, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 18, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 18, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 19, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 19, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 20, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 20, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 21, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 21, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 22, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 22, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 6377 ), 22, 10, 12 );
			AddComponent( new HuedAddonComponent( 991, 2886 ), 22, 10, 7 );
			AddComponent( new HuedAddonComponent( 991, 7608 ), 22, 10, 6 );
			AddComponent( new HuedAddonComponent( 991, 3772 ), 22, 10, 1 );
			AddComponent( new HuedAddonComponent( 991, 2799 ), 22, 10, 1 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 22, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 2802 ), 22, 11, 1 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 22, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 2800 ), 22, 12, 1 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 22, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 22, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 23, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 23, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 2803 ), 23, 10, 1 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 23, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 2796 ), 23, 11, 1 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 23, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 2805 ), 23, 12, 1 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 23, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 23, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 24, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 24, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 2801 ), 24, 10, 1 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 24, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 2804 ), 24, 11, 1 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 24, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 2798 ), 24, 12, 1 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 24, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 24, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 25, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 25, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 25, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 25, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 25, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 25, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 26, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 26, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 26, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 26, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 26, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 26, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 27, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 27, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 28, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 28, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 29, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 29, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 30, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 30, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 30, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 30, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 30, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 30, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 31, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 31, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 4632 ), 31, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 31, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 4613 ), 31, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2519 ), 31, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 2505 ), 31, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 2548 ), 31, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 2550 ), 31, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 4095 ), 31, 5, 7 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 31, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 4613 ), 31, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2519 ), 31, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 4095 ), 31, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 2487 ), 31, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 2548 ), 31, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 2550 ), 31, 6, 6 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 31, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 4634 ), 31, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 31, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 32, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 32, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 3750 ), 32, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 32, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 4614 ), 32, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2519 ), 32, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 4161 ), 32, 5, 7 );
			AddComponent( new HuedAddonComponent( 991, 2503 ), 32, 5, 10 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 32, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2504 ), 32, 6, 12 );
			AddComponent( new HuedAddonComponent( 991, 2430 ), 32, 6, 5 );
			AddComponent( new HuedAddonComponent( 991, 4614 ), 32, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 32, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 32, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 33, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 33, 4, 0 );
			AddComponent( new HuedAddonComponent( 991, 4632 ), 33, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 33, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 4612 ), 33, 5, 0 );
			AddComponent( new HuedAddonComponent( 991, 2519 ), 33, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 5642 ), 33, 5, 7 );
			AddComponent( new HuedAddonComponent( 991, 2548 ), 33, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 2550 ), 33, 5, 6 );
			AddComponent( new HuedAddonComponent( 991, 4095 ), 33, 5, 7 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 33, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 4612 ), 33, 6, 0 );
			AddComponent( new HuedAddonComponent( 991, 2519 ), 33, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 4095 ), 33, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 2425 ), 33, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 2548 ), 33, 6, 6 );
			AddComponent( new HuedAddonComponent( 991, 2550 ), 33, 6, 6 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 33, 7, 0 );
			AddComponent( new HuedAddonComponent( 991, 8087 ), 33, 7, 21 );
			AddComponent( new HuedAddonComponent( 991, 4634 ), 33, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 33, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 34, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 34, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 34, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 34, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 34, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 34, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 142 ), 35, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 35, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 35, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 35, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 35, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 35, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 3, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 4, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 5, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 6, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 36, 8, 0 );
			AddComponent( new HuedAddonComponent( 991, 11632 ), 36, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 37, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 37, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 38, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 38, 8, 0 );
			AddComponent( new HuedAddonComponent( 991, 5481 ), 38, 8, 1 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 39, 7, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 39, 8, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 29, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 29, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 30, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 30, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 30, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 30, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 140 ), 30, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 30, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 31, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 31, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 10332 ), 31, 10, 0 );
			AddComponent( new HuedAddonComponent( 991, 2519 ), 31, 10, 8 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 31, 11, 0 );
			AddComponent( new HuedAddonComponent( 991, 8093 ), 31, 11, 14 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 31, 12, 0 );
			AddComponent( new HuedAddonComponent( 991, 3784 ), 31, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 31, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 31, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 32, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 32, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 32, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 32, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 32, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 32, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 33, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 33, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 33, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 33, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 33, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 33, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 34, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 34, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 34, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 34, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 34, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 34, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 35, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 1312 ), 35, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 35, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 35, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 35, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 35, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1309 ), 36, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 11, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 12, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 13, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 36, 14, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 37, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 37, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1310 ), 38, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 38, 10, 0 );
			AddComponent( new HuedAddonComponent( 0, 1311 ), 39, 9, 0 );
			AddComponent( new HuedAddonComponent( 0, 128 ), 39, 10, 0 );

			//Doors
			DoorAddonComponent doorone = new DoorAddonComponent( new Point3D(1, -1, 0), 1711, 1712, 241, 234, false, 991 );
			DoorAddonComponent doortwo = new DoorAddonComponent( new Point3D(1, 1, 0), 1709, 1710, 241, 234, false, 991 );
			doorone.Linked = doortwo;
			doortwo.Linked = doorone;
			AddComponent( doorone, 10, 8, 0 );
			AddComponent( doortwo, 10, 9, 0 );

			doorone = new DoorAddonComponent( new Point3D(1, -1, 0), 1759, 1760, 241, 234, false, 991 );
			doortwo = new DoorAddonComponent( new Point3D(1, 1, 0), 1757, 1758, 241, 234, false, 991 );
			doorone.Linked = doortwo;
			doortwo.Linked = doorone;
			AddComponent( doorone, 19, 8, 0 );
			AddComponent( doortwo, 19, 9, 0 );

			doorone = new DoorAddonComponent( new Point3D(1, -1, 0), 1759, 1760, 241, 234, false, 991 );
			doortwo = new DoorAddonComponent( new Point3D(1, 1, 0), 1757, 1758, 241, 234, false, 991 );
			doorone.Linked = doortwo;
			doortwo.Linked = doorone;
			AddComponent( doorone, 28, 8, 0 );
			AddComponent( doortwo, 28, 9, 0 );

			doorone = new DoorAddonComponent( new Point3D(1, -1, 0), 1775, 1776, 241, 234, false, 991 );
			doortwo = new DoorAddonComponent( new Point3D(1, 1, 0), 1773, 1774, 241, 234, false, 991 );
			doorone.Linked = doortwo;
			doortwo.Linked = doorone;
			AddComponent( doorone, 36, 8, 0 );
			AddComponent( doortwo, 36, 9, 0 );
		}

		public MindflayerAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class MindflayerAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new MindflayerAddon(); } }

		[Constructable]
		public MindflayerAddonDeed()
		{
		}

		public MindflayerAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class MindflayerRegion : BaseRegion
	{
		public static Rectangle2D[] TheArea =
		{
			new Rectangle2D( 326, 661, 36, 11 )
		};

		public MindflayerRegion() : base( "A place in time", Map.Ilshenar, 25, TheArea )
		{
			Register();
		}

		public override void OnEnter( Mobile m )
		{
			m.SolidHueOverride = 991;

			base.OnEnter( m );
		}

		public override void OnExit( Mobile m )
		{
			m.SolidHueOverride = -1;

			base.OnEnter( m );
		}
	}
}