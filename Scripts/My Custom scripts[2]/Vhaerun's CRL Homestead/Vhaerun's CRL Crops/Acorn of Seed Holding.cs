/* Created by Shai'Tan Malkier.
 * This is based off of Daat99's containers.
 * This will hold all 80 of the seeds for [RunUO 2.0 RC1] Vhaerun's CRL Homestead System.
 * Please feel free to modify this as you see fit.
 * But Please leave this header to show where credit is due*/


using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Items.Crops;
using Server.Network;
using Server.Targeting;


namespace Server.Items
{
    [FlipableAttribute(0x2D4A, 0x2D4A)]
    public class SeedContainer : Item
    {
        private int m_AlmondTreeSeed;
		private int m_AppleTreeSeed;
		private int m_ApricotTreeSeed;
		private int m_AsparagusSeed;
		private int m_AvocadoTreeSeed;
		private int m_BananaTreeSeed;
		private int m_BeetSeed;
		private int m_BitterHopsSeed;
		private int m_BlackberryTreeSeed;
		private int m_BlackRaspberryTreeSeed;
		private int m_BlueberryTreeSeed;
		private int m_BroccoliSeed;
		private int m_CabbageSeed;
		private int m_CantaloupeSeed;
		private int m_CarrotSeed;
		private int m_CauliflowerSeed;
		private int m_CelerySeed;
		private int m_CherryTreeSeed;
		private int m_ChiliPepperSeed;
		private int m_CocoaTreeSeed;
		private int m_CoconutPalmSeed;
		private int m_CoffeeSeed;
		private int m_CornSeed;
		private int m_CottonSeed;
		private int m_CranberryTreeSeed;
		private int m_CucumberSeed;
		private int m_DatePalmSeed;
		private int m_EggplantSeed;
		private int m_ElvenHopsSeed;
		private int m_FieldCornSeed;
		private int m_FlaxSeed;
		private int m_GarlicSeed;
		private int m_GingerSeed;
		private int m_GinsengSeed;
		private int m_GrapefruitTreeSeed;
		private int m_GreenBeanSeed;
		private int m_GreenPepperSeed;
		private int m_GreenSquashSeed;
		private int m_HaySeed;
		private int m_HoneydewMelonSeed;
		private int m_KiwiSeed;
		private int m_LemonTreeSeed;
		private int m_LettuceSeed;
		private int m_LimeTreeSeed;
		private int m_MandrakeSeed;
		private int m_MangoTreeSeed;
		private int m_NightshadeSeed;
		private int m_OatsSeed;
		private int m_OnionSeed;
		private int m_OrangePepperSeed;
		private int m_OrangeTreeSeed;
		private int m_PeachTreeSeed;
		private int m_PeanutSeed;
		private int m_PearTreeSeed;
		private int m_PeasSeed;
		private int m_PineappleTreeSeed;
		private int m_PistacioTreeSeed;
		private int m_PlumTreeSeed;
		private int m_PomegranateTreeSeed;
		private int m_PotatoSeed;
		private int m_PumpkinSeed;
		private int m_RadishSeed;
		private int m_RedPepperSeed;
		private int m_RedRaspberryTreeSeed;
		private int m_RiceSeed;
		private int m_SnowHopsSeed;
		private int m_SnowPeasSeed;
		private int m_SoySeed;
		private int m_SpinachSeed;
		private int m_SquashSeed;
		private int m_StrawberrySeed;
		private int m_SugarSeed;
		private int m_SunFlowerSeed;
		private int m_SweetHopsSeed;
		private int m_SweetPotatoSeed;
		private int m_TeaSeed;
		private int m_TomatoSeed;
		private int m_TurnipSeed;
		private int m_WatermelonSeed;
		private int m_WheatSeed;
		private int m_StorageLimit;
        private int m_WithdrawIncrement;

        [CommandProperty(AccessLevel.GameMaster)]
        public int StorageLimit { get { return m_StorageLimit; } set { m_StorageLimit = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int WithdrawIncrement { get { return m_WithdrawIncrement; } set { m_WithdrawIncrement = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int AlmondTreeSeed { get { return m_AlmondTreeSeed; } set { m_AlmondTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int AppleTreeSeed { get { return m_AppleTreeSeed; } set { m_AppleTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ApricotTreeSeed { get { return m_ApricotTreeSeed; } set { m_ApricotTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int AsparagusSeed { get { return m_AsparagusSeed; } set { m_AsparagusSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int AvocadoTreeSeed { get { return m_AvocadoTreeSeed; } set { m_AvocadoTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BananaTreeSeed { get { return m_BananaTreeSeed; } set { m_BananaTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BeetSeed { get { return m_BeetSeed; } set { m_BeetSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BitterHopsSeed { get { return m_BitterHopsSeed; } set { m_BitterHopsSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BlackberryTreeSeed { get { return m_BlackberryTreeSeed; } set { m_BlackberryTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BlackRaspberryTreeSeed { get { return m_BlackRaspberryTreeSeed; } set { m_BlackRaspberryTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BroccoliSeed { get { return m_BroccoliSeed; } set { m_BroccoliSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int BlueberryTreeSeed { get { return m_BlueberryTreeSeed; } set { m_BlueberryTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CabbageSeed { get { return m_CabbageSeed; } set { m_CabbageSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CantaloupeSeed { get { return m_CantaloupeSeed; } set { m_CantaloupeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CarrotSeed { get { return m_CarrotSeed; } set { m_CarrotSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CauliflowerSeed { get { return m_CauliflowerSeed; } set { m_CauliflowerSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CelerySeed { get { return m_CelerySeed; } set { m_CelerySeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CherryTreeSeed { get { return m_CherryTreeSeed; } set { m_CherryTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int ChiliPepperSeed { get { return m_ChiliPepperSeed; } set {m_ChiliPepperSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CocoaTreeSeed { get { return m_CocoaTreeSeed; } set { m_CocoaTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CoconutPalmSeed { get { return m_CoconutPalmSeed; } set { m_CoconutPalmSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int CoffeeSeed { get { return m_CoffeeSeed; } set { m_CoffeeSeed = value; InvalidateProperties(); } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int CornSeed { get { return m_CornSeed; } set { m_CornSeed = value; InvalidateProperties(); } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int CottonSeed { get { return m_CottonSeed; } set { m_CottonSeed = value; InvalidateProperties(); } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int CranberryTreeSeed { get { return m_CranberryTreeSeed; } set { m_CranberryTreeSeed = value; InvalidateProperties(); } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int CucumberSeed { get { return m_CucumberSeed; } set { m_CucumberSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int DatePalmSeed { get { return m_DatePalmSeed; } set { m_DatePalmSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int EggplantSeed { get { return m_EggplantSeed; } set { m_EggplantSeed = value; InvalidateProperties(); } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int ElvenHopsSeed { get { return m_ElvenHopsSeed; } set { m_ElvenHopsSeed = value; InvalidateProperties(); } }
		
		[CommandProperty(AccessLevel.GameMaster)]
		public int FieldCornSeed { get { return m_FieldCornSeed; } set { m_FieldCornSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int FlaxSeed { get { return m_FlaxSeed; } set { m_FlaxSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GarlicSeed { get { return m_GarlicSeed; } set { m_GarlicSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GingerSeed { get { return m_GingerSeed; } set { m_GingerSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GinsengSeed { get { return m_GinsengSeed; } set { m_GinsengSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GrapefruitTreeSeed { get { return m_GrapefruitTreeSeed; } set { m_GrapefruitTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GreenBeanSeed { get { return m_GreenBeanSeed; } set { m_GreenBeanSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GreenPepperSeed { get { return m_GreenPepperSeed; } set { m_GreenPepperSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int GreenSquashSeed { get { return m_GreenSquashSeed; } set { m_GreenSquashSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HaySeed { get { return m_HaySeed; } set { m_HaySeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int HoneydewMelonSeed { get { return m_HoneydewMelonSeed; } set { m_HoneydewMelonSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int KiwiSeed { get { return m_KiwiSeed; } set { m_KiwiSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int LemonTreeSeed { get { return m_LemonTreeSeed; } set { m_LemonTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int LettuceSeed { get { return m_LettuceSeed; } set { m_LettuceSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int LimeTreeSeed { get { return m_LimeTreeSeed; } set { m_LimeTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int MandrakeSeed { get { return m_MandrakeSeed; } set { m_MandrakeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int MangoTreeSeed { get { return m_MangoTreeSeed; } set { m_MangoTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int NightshadeSeed { get { return m_NightshadeSeed; } set { m_NightshadeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int OatsSeed { get { return m_OatsSeed; } set { m_OatsSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int OnionSeed { get { return m_OnionSeed; } set { m_OnionSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int OrangePepperSeed { get { return m_OrangePepperSeed; } set { m_OrangePepperSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int OrangeTreeSeed { get { return m_OrangeTreeSeed; } set { m_OrangeTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PeachTreeSeed { get { return m_PeachTreeSeed; } set { m_PeachTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PeanutSeed { get { return m_PeanutSeed; } set { m_PeanutSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PearTreeSeed { get { return m_PearTreeSeed; } set { m_PearTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PeasSeed { get { return m_PeasSeed; } set { m_PeasSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PineappleTreeSeed { get { return m_PineappleTreeSeed; } set { m_PineappleTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PistacioTreeSeed { get { return m_PistacioTreeSeed; } set { m_PistacioTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PlumTreeSeed { get { return m_PlumTreeSeed; } set { m_PlumTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PomegranateTreeSeed { get { return m_PomegranateTreeSeed; } set { m_PomegranateTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PotatoSeed { get { return m_PotatoSeed; } set { m_PotatoSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int PumpkinSeed { get { return m_PumpkinSeed; } set { m_PumpkinSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RadishSeed { get { return m_RadishSeed; } set { m_RadishSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RedPepperSeed { get { return m_RedPepperSeed; } set { m_RedPepperSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RedRaspberryTreeSeed { get { return m_RedRaspberryTreeSeed; } set { m_RedRaspberryTreeSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RiceSeed { get { return m_RiceSeed; } set { m_RiceSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SnowHopsSeed { get { return m_SnowHopsSeed; } set { m_SnowHopsSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SnowPeasSeed { get { return m_SnowPeasSeed; } set { m_SnowPeasSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SoySeed { get { return m_SoySeed; } set { m_SoySeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SpinachSeed { get { return m_SpinachSeed; } set { m_SpinachSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SquashSeed { get { return m_SquashSeed; } set { m_SquashSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int StrawberrySeed { get { return m_StrawberrySeed; } set { m_StrawberrySeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SugarSeed { get { return m_SugarSeed; } set { m_SugarSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SunFlowerSeed { get { return m_SunFlowerSeed; } set { m_SunFlowerSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SweetHopsSeed { get { return m_SweetHopsSeed; } set { m_SweetHopsSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int SweetPotatoSeed { get { return m_SweetPotatoSeed; } set { m_SweetPotatoSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int TeaSeed { get { return m_TeaSeed; } set { m_TeaSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int TomatoSeed { get { return m_TomatoSeed; } set { m_TomatoSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int TurnipSeed { get { return m_TurnipSeed; } set { m_TurnipSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int WatermelonSeed { get { return m_WatermelonSeed; } set { m_WatermelonSeed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int WheatSeed { get { return m_WheatSeed; } set { m_WheatSeed = value; InvalidateProperties(); } }

        [Constructable]
        public SeedContainer() : base( 0x2D4A )
        {
            Movable = true;
            Weight = 5.0;
            Name = "Garden Seed Container";
            StorageLimit = 60000;
            WithdrawIncrement = 1;
        }

        [Constructable]
        public SeedContainer(int storageLimit, int withdrawIncrement) : base( 0x2D4A )
        {
            Movable = true;
            Weight = 5.0;
            Name = "Garden Seed Container";
            StorageLimit = storageLimit;
            WithdrawIncrement = withdrawIncrement;
        }

        public override void OnDoubleClick(Mobile from)
        {
			if (!(from is PlayerMobile))
				return;
			if (IsChildOf(from.Backpack))
				from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
			else
				from.SendMessage("This must be in your backpack.");
        }

        public void BeginCombine(Mobile from)
        {
            from.Target = new SeedContainerTarget(this);
        }

        public void EndCombine(Mobile from, object o)
        {
			if (o is Item && (((Item)o).IsChildOf(from.Backpack) || ((Item)o).IsChildOf(from.BankBox)))
            {
                Item curItem = o as Item;
				if (curItem is AlmondTreeSeed)
				{
					if (AlmondTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (AlmondTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this Item.");
					else
					{
						AlmondTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is AppleTreeSeed)
				{
					if (AppleTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (AppleTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this Item.");
					else
					{
						AppleTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is ApricotTreeSeed)
				{
					if (ApricotTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (ApricotTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this Item.");
					else
					{
						ApricotTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is AsparagusSeed)
				{
					if (AsparagusSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (AsparagusSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this Item.");
					else
					{
						AsparagusSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is AvocadoTreeSeed)
				{
					if (AvocadoTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (AvocadoTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						AvocadoTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is BananaTreeSeed)
				{
					if (BananaTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BananaTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BananaTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (o is BeetSeed)
				{
					if (BeetSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BeetSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BeetSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is BitterHopsSeed)
				{
					if (BitterHopsSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BitterHopsSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BitterHopsSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is BlackberryTreeSeed)
				{
					if (BlackberryTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BlackberryTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BlackberryTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is BlackRaspberryTreeSeed)
				{
					if (BlackRaspberryTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BlackRaspberryTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BlackRaspberryTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is BlueberryTreeSeed)
				{
					if (BlueberryTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BlueberryTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BlueberryTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is BroccoliSeed)
				{
					if (BroccoliSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (BroccoliSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						BroccoliSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CabbageSeed)
				{
					if (CabbageSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CabbageSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CabbageSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CantaloupeSeed)
				{
					if (CantaloupeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CantaloupeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CantaloupeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CarrotSeed)
				{
					if (CarrotSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CarrotSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CarrotSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CauliflowerSeed )
				{
					if (CauliflowerSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CauliflowerSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CauliflowerSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CelerySeed)
				{
					if (CelerySeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CelerySeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CelerySeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is ChiliPepperSeed)
				{
					if (ChiliPepperSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (ChiliPepperSeed + (curItem.Amount * 2)) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						ChiliPepperSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CherryTreeSeed)
				{
					if (CherryTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CherryTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CherryTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}				
				else if (curItem is CocoaTreeSeed)
				{
					if (CocoaTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CocoaTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CocoaTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CoconutPalmSeed)
				{
					if (CoconutPalmSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CoconutPalmSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CoconutPalmSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CoffeeSeed)
				{
					if (CoffeeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CoffeeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CoffeeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CornSeed)
				{
					if (CornSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CornSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CornSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CottonSeed)
				{
					if (CottonSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CottonSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CottonSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CranberryTreeSeed)
				{
					if (CranberryTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CranberryTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CranberryTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is CucumberSeed)
				{
					if (CucumberSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (CucumberSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						CucumberSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is DatePalmSeed)
				{
					if (DatePalmSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (DatePalmSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						DatePalmSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is EggplantSeed)
				{
					if (EggplantSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (EggplantSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						EggplantSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is ElvenHopsSeed)
				{
					if (ElvenHopsSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (ElvenHopsSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						ElvenHopsSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (curItem is FieldCornSeed)
				{
					if (FieldCornSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (FieldCornSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						FieldCornSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if (o is FlaxSeed)
				{
					if (FlaxSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (FlaxSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						FlaxSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GarlicSeed)
				{
					if (GarlicSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GarlicSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GarlicSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GingerSeed)
				{
					if (GingerSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GingerSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GingerSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GinsengSeed)
				{
					if (GinsengSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GinsengSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GinsengSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GrapefruitTreeSeed)
				{
					if (GrapefruitTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GrapefruitTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GrapefruitTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GreenBeanSeed)
				{
					if (GreenBeanSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GreenBeanSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GreenBeanSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GreenPepperSeed)
				{
					if (GreenPepperSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GreenPepperSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GreenPepperSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is GreenSquashSeed)
				{
					if (GreenSquashSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (GreenSquashSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						GreenSquashSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is HaySeed)
				{
					if (HaySeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (HaySeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						HaySeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is HoneydewMelonSeed)
				{
					if (HoneydewMelonSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (HoneydewMelonSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						HoneydewMelonSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is KiwiSeed)
				{
					if (KiwiSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (KiwiSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						KiwiSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is LemonTreeSeed)
				{
					if (LemonTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (LemonTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						LemonTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is LettuceSeed)
				{
					if (LettuceSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (LettuceSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						LettuceSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is LimeTreeSeed)
				{
					if (LimeTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (LimeTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						LimeTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is MandrakeSeed)
				{
					if (MandrakeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (MandrakeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						MandrakeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is MangoTreeSeed)
				{
					if (MangoTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (MangoTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						MangoTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is NightshadeSeed)
				{
					if (NightshadeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (NightshadeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						NightshadeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is OatsSeed)
				{
					if (OatsSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (OatsSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						OatsSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is OnionSeed)
				{
					if (OnionSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (OnionSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						OnionSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is OrangePepperSeed)
				{
					if (OrangePepperSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (OrangePepperSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						OrangePepperSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is OrangeTreeSeed)
				{
					if (OrangeTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (OrangeTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						OrangeTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PeachTreeSeed)
				{
					if (PeachTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PeachTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PeachTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PeanutSeed)
				{
					if (PeanutSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PeanutSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PeanutSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PearTreeSeed)
				{
					if (PearTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PearTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PearTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PeasSeed)
				{
					if (PeasSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PeasSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PeasSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PineappleTreeSeed)
				{
					if (PineappleTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PineappleTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PineappleTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PistacioTreeSeed)
				{
					if (PistacioTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PistacioTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PistacioTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PlumTreeSeed)
				{
					if (PlumTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PlumTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PlumTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PomegranateTreeSeed)
				{
					if (PomegranateTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PomegranateTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PomegranateTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PotatoSeed)
				{
					if (PotatoSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PotatoSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PotatoSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is PumpkinSeed)
				{
					if (PumpkinSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (PumpkinSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						PumpkinSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is RadishSeed)
				{
					if (RadishSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (RadishSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						RadishSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is RedPepperSeed)
				{
					if (RedPepperSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (RedPepperSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						RedPepperSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is RedRaspberryTreeSeed)
				{
					if (RedRaspberryTreeSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (RedRaspberryTreeSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						RedRaspberryTreeSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is RiceSeed)
				{
					if (RiceSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (RiceSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						RiceSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SnowHopsSeed)
				{
					if (SnowHopsSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SnowHopsSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SnowHopsSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SnowPeasSeed)
				{
					if (SnowPeasSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SnowPeasSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SnowPeasSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SoySeed)
				{
					if (SoySeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SoySeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SoySeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SpinachSeed)
				{
					if (SpinachSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SpinachSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SpinachSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SquashSeed)
				{
					if (SquashSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SquashSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SquashSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is StrawberrySeed)
				{
					if (StrawberrySeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (StrawberrySeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						StrawberrySeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SugarSeed)
				{
					if (SugarSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SugarSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SugarSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SunFlowerSeed)
				{
					if (SunFlowerSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SunFlowerSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SunFlowerSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SweetHopsSeed)
				{
					if (SweetHopsSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SweetHopsSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SweetHopsSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is SweetPotatoSeed)
				{
					if (SweetPotatoSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (SweetPotatoSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						SweetPotatoSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is TeaSeed)
				{
					if (TeaSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (TeaSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						TeaSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is TomatoSeed)
				{
					if (TomatoSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (TomatoSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						TomatoSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is TurnipSeed)
				{
					if (TurnipSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (TurnipSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						TurnipSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is WatermelonSeed)
				{
					if (WatermelonSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (WatermelonSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						WatermelonSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
				else if ( curItem is WheatSeed)
				{
					if (WheatSeed + curItem.Amount > StorageLimit)
						from.SendMessage("You are trying to add "+ ( (WheatSeed + curItem.Amount) - m_StorageLimit ) +" too much! The warehouse can store only "+ m_StorageLimit +" of this resource.");
					else
					{
						WheatSeed += curItem.Amount;
						curItem.Delete();
						from.SendGump(new SeedContainerGump((PlayerMobile)from, this));
						BeginCombine(from);
					}
				}
            }
			else
				from.SendLocalizedMessage(1045158); // You must have the item in your backpack to target it.
		}

        public SeedContainer(Serial serial) : base( serial )
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
			writer.Write( (int) 2 ); // version
			//version 2
			writer.Write((int)m_StorageLimit);
			//version 1
            writer.Write((int)m_WithdrawIncrement);
            //version 0
			writer.Write((int)m_AlmondTreeSeed);
			writer.Write((int)m_AppleTreeSeed);
			writer.Write((int)m_ApricotTreeSeed);
			writer.Write((int)m_AsparagusSeed);
			writer.Write((int)m_AvocadoTreeSeed);
			writer.Write((int)m_BananaTreeSeed);
			writer.Write((int)m_BeetSeed);
			writer.Write((int)m_BitterHopsSeed);
			writer.Write((int)m_BlackberryTreeSeed);
			writer.Write((int)m_BlackRaspberryTreeSeed);
			writer.Write((int)m_BlueberryTreeSeed);
			writer.Write((int)m_BroccoliSeed);
			writer.Write((int)m_CabbageSeed);
            writer.Write((int)m_CantaloupeSeed);
            writer.Write((int)m_CarrotSeed);
            writer.Write((int)m_CauliflowerSeed);
			writer.Write((int)m_CelerySeed);
            writer.Write((int)m_CherryTreeSeed);
			writer.Write((int)m_ChiliPepperSeed);
			writer.Write((int)m_CocoaTreeSeed);
			writer.Write((int)m_CoconutPalmSeed);
			writer.Write((int)m_CoffeeSeed);
			writer.Write((int)m_CornSeed);
			writer.Write((int)m_CottonSeed);
			writer.Write((int)m_CranberryTreeSeed);
			writer.Write((int)m_CucumberSeed);
			writer.Write((int)m_DatePalmSeed);
			writer.Write((int)m_EggplantSeed);
			writer.Write((int)m_ElvenHopsSeed);
			writer.Write((int)m_FieldCornSeed);
			writer.Write((int)m_FlaxSeed);
			writer.Write((int)m_GarlicSeed);
			writer.Write((int)m_GingerSeed);
			writer.Write((int)m_GinsengSeed);
			writer.Write((int)m_GrapefruitTreeSeed);
			writer.Write((int)m_GreenBeanSeed);
			writer.Write((int)m_GreenPepperSeed);
			writer.Write((int)m_GreenSquashSeed);
			writer.Write((int)m_HaySeed);
			writer.Write((int)m_HoneydewMelonSeed);
			writer.Write((int)m_KiwiSeed);
			writer.Write((int)m_LemonTreeSeed);
			writer.Write((int)m_LettuceSeed);
			writer.Write((int)m_LimeTreeSeed);
			writer.Write((int)m_MandrakeSeed);
			writer.Write((int)m_MangoTreeSeed);
			writer.Write((int)m_NightshadeSeed);
			writer.Write((int)m_OatsSeed);
			writer.Write((int)m_OnionSeed);
			writer.Write((int)m_OrangePepperSeed);
			writer.Write((int)m_OrangeTreeSeed);
			writer.Write((int)m_PeachTreeSeed);
			writer.Write((int)m_PeanutSeed);
			writer.Write((int)m_PearTreeSeed);
			writer.Write((int)m_PeasSeed);
			writer.Write((int)m_PineappleTreeSeed);
			writer.Write((int)m_PistacioTreeSeed);
			writer.Write((int)m_PlumTreeSeed);
			writer.Write((int)m_PomegranateTreeSeed);
			writer.Write((int)m_PotatoSeed);
			writer.Write((int)m_PumpkinSeed);
			writer.Write((int)m_RadishSeed);
			writer.Write((int)m_RedPepperSeed);
			writer.Write((int)m_RedRaspberryTreeSeed);
			writer.Write((int)m_RiceSeed);
			writer.Write((int)m_SnowHopsSeed);
			writer.Write((int)m_SnowPeasSeed);
			writer.Write((int)m_SoySeed);
			writer.Write((int)m_SpinachSeed);
			writer.Write((int)m_SquashSeed);
			writer.Write((int)m_StrawberrySeed);
			writer.Write((int)m_SugarSeed);
			writer.Write((int)m_SunFlowerSeed);
			writer.Write((int)m_SweetHopsSeed);
			writer.Write((int)m_SweetPotatoSeed);
			writer.Write((int)m_TeaSeed);
			writer.Write((int)m_TomatoSeed);
			writer.Write((int)m_TurnipSeed);
			writer.Write((int)m_WatermelonSeed);
			writer.Write((int)m_WheatSeed);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 2:
				{
					m_StorageLimit = reader.ReadInt();
					goto case 1;
				}
				case 1:
				{
					m_WithdrawIncrement = reader.ReadInt();
					goto case 0;
				}
				case 0:
				{
					m_AlmondTreeSeed = reader.ReadInt();
					m_AppleTreeSeed = reader.ReadInt();
					m_ApricotTreeSeed = reader.ReadInt();
					m_AsparagusSeed = reader.ReadInt();
					m_AvocadoTreeSeed = reader.ReadInt();
					m_BananaTreeSeed = reader.ReadInt();
					m_BeetSeed = reader.ReadInt();
					m_BitterHopsSeed = reader.ReadInt();
					m_BlackberryTreeSeed = reader.ReadInt();
					m_BlackRaspberryTreeSeed = reader.ReadInt();
					m_BlueberryTreeSeed = reader.ReadInt();
					m_BroccoliSeed = reader.ReadInt();
					m_CabbageSeed = reader.ReadInt();
					m_CantaloupeSeed = reader.ReadInt();
					m_CarrotSeed = reader.ReadInt();
					m_CauliflowerSeed = reader.ReadInt();
					m_CelerySeed = reader.ReadInt();
					m_CherryTreeSeed = reader.ReadInt();
					m_ChiliPepperSeed = reader.ReadInt();
					m_CocoaTreeSeed = reader.ReadInt();
					m_CoconutPalmSeed = reader.ReadInt();
					m_CoffeeSeed = reader.ReadInt();
					m_CornSeed = reader.ReadInt();
					m_CottonSeed = reader.ReadInt();
					m_CranberryTreeSeed = reader.ReadInt();
					m_CucumberSeed = reader.ReadInt();
					m_DatePalmSeed = reader.ReadInt();
					m_EggplantSeed = reader.ReadInt();
					m_ElvenHopsSeed = reader.ReadInt();
					m_FieldCornSeed = reader.ReadInt();
					m_FlaxSeed = reader.ReadInt();
					m_GarlicSeed = reader.ReadInt();
					m_GingerSeed = reader.ReadInt();
					m_GinsengSeed = reader.ReadInt();
					m_GrapefruitTreeSeed = reader.ReadInt();
					m_GreenBeanSeed = reader.ReadInt();
					m_GreenPepperSeed = reader.ReadInt();
					m_GreenSquashSeed = reader.ReadInt();
					m_HaySeed = reader.ReadInt();
					m_HoneydewMelonSeed = reader.ReadInt();
					m_KiwiSeed = reader.ReadInt();
					m_LemonTreeSeed = reader.ReadInt();
					m_LettuceSeed = reader.ReadInt();
					m_LimeTreeSeed = reader.ReadInt();
					m_MandrakeSeed = reader.ReadInt();
					m_MangoTreeSeed = reader.ReadInt();
					m_NightshadeSeed = reader.ReadInt();
					m_OatsSeed = reader.ReadInt();
					m_OnionSeed = reader.ReadInt();
					m_OrangePepperSeed = reader.ReadInt();
					m_OrangeTreeSeed = reader.ReadInt();
					m_PeachTreeSeed = reader.ReadInt();
					m_PeanutSeed = reader.ReadInt();
					m_PearTreeSeed = reader.ReadInt();
					m_PeasSeed = reader.ReadInt();
					m_PineappleTreeSeed = reader.ReadInt();
					m_PistacioTreeSeed = reader.ReadInt();
					m_PlumTreeSeed = reader.ReadInt();
					m_PomegranateTreeSeed = reader.ReadInt();
					m_PotatoSeed = reader.ReadInt();
					m_PumpkinSeed = reader.ReadInt();
					m_RadishSeed = reader.ReadInt();
					m_RedPepperSeed = reader.ReadInt();
					m_RedRaspberryTreeSeed = reader.ReadInt();
					m_RiceSeed = reader.ReadInt();
					m_SnowHopsSeed = reader.ReadInt();
					m_SnowPeasSeed = reader.ReadInt();
					m_SoySeed = reader.ReadInt();
					m_SpinachSeed = reader.ReadInt();
					m_SquashSeed = reader.ReadInt();
					m_StrawberrySeed = reader.ReadInt();
					m_SugarSeed = reader.ReadInt();
					m_SunFlowerSeed = reader.ReadInt();
					m_SweetHopsSeed = reader.ReadInt();
					m_SweetPotatoSeed = reader.ReadInt();
					m_TeaSeed = reader.ReadInt();
					m_TomatoSeed = reader.ReadInt();
					m_TurnipSeed = reader.ReadInt();
					m_WatermelonSeed = reader.ReadInt();
					m_WheatSeed = reader.ReadInt();
					break;
				}
			}
        }
    }
}

namespace Server.Items
{
    public class SeedContainerGump : Gump
    {
        private PlayerMobile m_From;
        private SeedContainer m_Key;

        public SeedContainerGump(PlayerMobile from, SeedContainer key ) : base( 25, 25 )
        {
            m_From = from;
            m_Key = key;

            m_From.CloseGump(typeof(SeedContainerGump));

            AddPage(0);

            AddBackground(50, 10, 1045, 595, 5054);
            AddImageTiled(60, 20, 1025, 575, 2624);
            AddAlphaRegion(60, 20, 1025, 575);

            AddLabel(525, 25, 0x486, "Garden Seed Container");

            AddLabel(125, 50, 0x486, "Almond Seeds");
            AddLabel(275, 50, 0x480, key.AlmondTreeSeed.ToString());
            AddButton(75, 50, 4005, 4007, (m_Key.AlmondTreeSeed <= 0) ? 999 : 1, GumpButtonType.Reply, 0);

            AddLabel(125, 75, 0x486, "Apple Seeds");
            AddLabel(275, 75, 0x480, key.AppleTreeSeed.ToString());
            AddButton(75, 75, 4005, 4007, (m_Key.AppleTreeSeed <= 0) ? 999 : 2, GumpButtonType.Reply, 0);

            AddLabel(125, 100, 0x486, "Apricot Seeds");
            AddLabel(275, 100, 0x480, key.ApricotTreeSeed.ToString());
            AddButton(75, 100, 4005, 4007, (m_Key.ApricotTreeSeed <= 0) ? 999 : 3, GumpButtonType.Reply, 0);

            AddLabel(125, 125, 0x486, "Asparagus Seeds");
            AddLabel(275, 125, 0x480, key.AsparagusSeed.ToString());
            AddButton(75, 125, 4005, 4007, (m_Key.AsparagusSeed <= 0) ? 999 : 4, GumpButtonType.Reply, 0);

			AddLabel(125, 150, 0x486, "Avocado Seeds");
			AddLabel(275, 150, 0x480, key.AvocadoTreeSeed.ToString());
			AddButton(75, 150, 4005, 4007, (m_Key.AvocadoTreeSeed <= 0) ? 999 : 5, GumpButtonType.Reply, 0);

			AddLabel(125, 175, 0x486, "Banana Seeds");
			AddLabel(275, 175, 0x480, key.BananaTreeSeed.ToString());
			AddButton(75, 175, 4005, 4007, (m_Key.BananaTreeSeed <= 0) ? 999 : 6, GumpButtonType.Reply, 0);

			AddLabel(125, 200, 0x486, "Beet Seeds");
			AddLabel(275, 200, 0x480, key.BeetSeed.ToString());
			AddButton(75, 200, 4005, 4007, (m_Key.BeetSeed <= 0) ? 999 : 7, GumpButtonType.Reply, 0);

			AddLabel(125, 225, 0x486, "Biter Hops Seeds");
			AddLabel(275, 225, 0x480, key.BitterHopsSeed.ToString());
			AddButton(75, 225, 4005, 4007, (m_Key.BitterHopsSeed <= 0) ? 999 : 8, GumpButtonType.Reply, 0);

			AddLabel(125, 250, 0x486, "Blackberry Seeds");
			AddLabel(275, 250, 0x480, key.BlackberryTreeSeed.ToString());
			AddButton(75, 250, 4005, 4007, (m_Key.BlackberryTreeSeed <= 0) ? 999 : 9, GumpButtonType.Reply, 0);

			AddLabel(125, 275, 0x486, "Black Raspberry Seeds");
			AddLabel(275, 275, 0x480, key.BlackRaspberryTreeSeed.ToString());
			AddButton(75, 275, 4005, 4007, (m_Key.BlackRaspberryTreeSeed <= 0) ? 999 : 10, GumpButtonType.Reply, 0);
						
			AddLabel(125, 300, 0x486, "Blueberry Seeds");
			AddLabel(275, 300, 0x480, key.BlueberryTreeSeed.ToString());
			AddButton(75, 300, 4005, 4007, (m_Key.BlueberryTreeSeed <= 0) ? 999 : 11, GumpButtonType.Reply, 0);

			AddLabel(125, 325, 0x486, "Broccoli Seeds");
			AddLabel(275, 325, 0x480, key.BroccoliSeed.ToString());
			AddButton(75, 325, 4005, 4007, (m_Key.BroccoliSeed <= 0) ? 999 : 12, GumpButtonType.Reply, 0);

			AddLabel(125, 350, 0x486, "Cabbage Seeds");
			AddLabel(275, 350, 0x480, key.CabbageSeed.ToString());
			AddButton(75, 350, 4005, 4007, (m_Key.CabbageSeed <= 0) ? 999 : 13, GumpButtonType.Reply, 0);

			AddLabel(125, 375, 0x486, "Canealoupe Seeds");
			AddLabel(275, 375, 0x480, key.CantaloupeSeed.ToString());
			AddButton(75, 375, 4005, 4007, (m_Key.CantaloupeSeed <= 0) ? 999 : 14, GumpButtonType.Reply, 0);

			AddLabel(125, 400, 0x486, "Carrot Seeds");
			AddLabel(275, 400, 0x480, key.CarrotSeed.ToString());
			AddButton(75, 400, 4005, 4007, (m_Key.CarrotSeed <= 0) ? 999 : 15, GumpButtonType.Reply, 0);

			AddLabel(125, 425, 0x486, "Cauliflower Seeds");
			AddLabel(275, 425, 0x480, key.CauliflowerSeed.ToString());
			AddButton(75, 425, 4005, 4007, (m_Key.CauliflowerSeed<= 0) ? 999 : 16, GumpButtonType.Reply, 0);

			AddLabel(125, 450, 0x486, "Celery Seeds");
			AddLabel(275, 450, 0x480, key.CelerySeed.ToString());
			AddButton(75, 450, 4005, 4007, (m_Key.CelerySeed <= 0) ? 999 : 17, GumpButtonType.Reply, 0);

			AddLabel(125, 475, 0x486, "Cherry Seeds");
			AddLabel(275, 475, 0x480, key.CherryTreeSeed.ToString());
			AddButton(75, 475, 4005, 4007, (m_Key.CherryTreeSeed <= 0) ? 999 : 18, GumpButtonType.Reply, 0);

			AddLabel(125, 500, 0x486, "Chili Pepper Seeds");
			AddLabel(275, 500, 0x480, key.ChiliPepperSeed.ToString());
			AddButton(75, 500, 4005, 4007, (m_Key.ChiliPepperSeed <= 0) ? 999 : 19, GumpButtonType.Reply, 0);

			AddLabel(125, 525, 0x486, "Cocoa Seeds");
			AddLabel(275, 525, 0x480, key.CocoaTreeSeed.ToString());
			AddButton(75, 525, 4005, 4007, (m_Key.CocoaTreeSeed <= 0) ? 999 : 20, GumpButtonType.Reply, 0);

			AddLabel(375, 50, 0x486, "Coconut Palm Seeds");
			AddLabel(525, 50, 0x480, key.CoconutPalmSeed.ToString());
			AddButton(325, 50, 4005, 4007, (m_Key.CoconutPalmSeed <= 0) ? 999 : 21, GumpButtonType.Reply, 0);

			AddLabel(375, 75, 0x486, "Coffee Seeds");
			AddLabel(525, 75, 0x480, key.CoffeeSeed.ToString());
			AddButton(325, 75, 4005, 4007, (m_Key.CoffeeSeed <= 0) ? 999 : 22, GumpButtonType.Reply, 0);

			AddLabel(375, 100, 0x486, "Corn Seeds");
			AddLabel(525, 100, 0x480, key.CornSeed.ToString());
			AddButton(325, 100, 4005, 4007, (m_Key.CornSeed <= 0) ? 999 : 23, GumpButtonType.Reply, 0);

			AddLabel(375, 125, 0x486, "Cotton Seeds");
			AddLabel(525, 125, 0x480, key.CottonSeed.ToString());
			AddButton(325, 125, 4005, 4007, (m_Key.CottonSeed <= 0) ? 999 : 24, GumpButtonType.Reply, 0);

			AddLabel(375, 150, 0x486, "Cranberry Seeds");
			AddLabel(525, 150, 0x480, key.CranberryTreeSeed.ToString());
			AddButton(325, 150, 4005, 4007, (m_Key.CranberryTreeSeed <= 0) ? 999 : 25, GumpButtonType.Reply, 0);

			AddLabel(375, 175, 0x486, "Cucumber Seeds");
			AddLabel(525, 175, 0x480, key.CucumberSeed.ToString());
			AddButton(325, 175, 4005, 4007, (m_Key.CucumberSeed <= 0) ? 999 : 26, GumpButtonType.Reply, 0);

			AddLabel(375, 200, 0x486, "Date Palm Seeds");
			AddLabel(525, 200, 0x480, key.DatePalmSeed.ToString());
			AddButton(325, 200, 4005, 4007, (m_Key.DatePalmSeed <= 0) ? 999 : 27, GumpButtonType.Reply, 0);

			AddLabel(375, 225, 0x486, "Eggplant Seeds");
			AddLabel(525, 225, 0x480, key.EggplantSeed.ToString());
			AddButton(325, 225, 4005, 4007, (m_Key.EggplantSeed <= 0) ? 999 : 28, GumpButtonType.Reply, 0);

			AddLabel(375, 250, 0x486, "Elven Hops Seeds");
			AddLabel(525, 250, 0x480, key.ElvenHopsSeed.ToString());
			AddButton(325, 250, 4005, 4007, (m_Key.ElvenHopsSeed <= 0) ? 999 : 29, GumpButtonType.Reply, 0);

			AddLabel(375, 275, 0x486, "Field Corn Seeds");
			AddLabel(525, 275, 0x480, key.FieldCornSeed.ToString());
			AddButton(325, 275, 4005, 4007, (m_Key.FieldCornSeed <= 0) ? 999 : 30, GumpButtonType.Reply, 0);

			AddLabel(375, 300, 0x486, "Flax Seeds");
			AddLabel(525, 300, 0x480, key.FlaxSeed.ToString());
			AddButton(325, 300, 4005, 4007, (m_Key.FlaxSeed <= 0) ? 999 : 31, GumpButtonType.Reply, 0);

			AddLabel(375, 325, 0x486, "Garlic Seeds");
			AddLabel(525, 325, 0x480, key.GarlicSeed.ToString());
			AddButton(325, 325, 4005, 4007, (m_Key.GarlicSeed <= 0) ? 999 : 32, GumpButtonType.Reply, 0);

			AddLabel(375, 350, 0x486, "Ginger Seeds");
			AddLabel(525, 350, 0x480, key.GingerSeed.ToString());
			AddButton(325, 350, 4005, 4007, (m_Key.GingerSeed <= 0) ? 999 : 33, GumpButtonType.Reply, 0);

			AddLabel(375, 375, 0x486, "Ginseng Seeds");
			AddLabel(525, 375, 0x480, key.GinsengSeed.ToString());
			AddButton(325, 375, 4005, 4007, (m_Key.GinsengSeed <= 0) ? 999 : 34, GumpButtonType.Reply, 0);

			AddLabel(375, 400, 0x486, "Grapefruit Seeds");
			AddLabel(525, 400, 0x480, key.GrapefruitTreeSeed.ToString());
			AddButton(325, 400, 4005, 4007, (m_Key.GrapefruitTreeSeed <= 0) ? 999 : 35, GumpButtonType.Reply, 0);

			AddLabel(375, 425, 0x486, "Green Bean Seeds");
			AddLabel(525, 425, 0x480, key.GreenBeanSeed.ToString());
			AddButton(325, 425, 4005, 4007, (m_Key.GreenBeanSeed <= 0) ? 999 : 36, GumpButtonType.Reply, 0);

			AddLabel(375, 450, 0x486, "Green Pepper Seeds");
			AddLabel(525, 450, 0x480, key.GreenPepperSeed.ToString());
			AddButton(325, 450, 4005, 4007, (m_Key.GreenPepperSeed <= 0) ? 999 : 37, GumpButtonType.Reply, 0);

			AddLabel(375, 475, 0x486, "Green Squash Seeds");
			AddLabel(525, 475, 0x480, key.GreenSquashSeed.ToString());
			AddButton(325, 475, 4005, 4007, (m_Key.GreenSquashSeed <= 0) ? 999 : 38, GumpButtonType.Reply, 0);

			AddLabel(375, 500, 0x486, "Hay Seeds");
			AddLabel(525, 500, 0x480, key.HaySeed.ToString());
			AddButton(325, 500, 4005, 4007, (m_Key.HaySeed <= 0) ? 999 : 39, GumpButtonType.Reply, 0);

			AddLabel(375, 525, 0x486, "Honeydew Melon Seeds");
			AddLabel(525, 525, 0x480, key.HoneydewMelonSeed.ToString());
			AddButton(325, 525, 4005, 4007, (m_Key.HoneydewMelonSeed <= 0) ? 999 : 40, GumpButtonType.Reply, 0);

			AddLabel(625, 50, 0x486, "Kiwi Seeds");
			AddLabel(775, 50, 0x480, key.KiwiSeed.ToString());
			AddButton(575, 50, 4005, 4007, (m_Key.KiwiSeed <= 0) ? 999 : 41, GumpButtonType.Reply, 0);

			AddLabel(625, 75, 0x486, "Lemon Seeds");
			AddLabel(775, 75, 0x480, key.LemonTreeSeed.ToString());
			AddButton(575, 75, 4005, 4007, (m_Key.LemonTreeSeed <= 0) ? 999 : 42, GumpButtonType.Reply, 0);

			AddLabel(625, 100, 0x486, "Lettuce Seeds");
			AddLabel(775, 100, 0x480, key.LettuceSeed.ToString());
			AddButton(575, 100, 4005, 4007, (m_Key.LettuceSeed <= 0) ? 999 : 43, GumpButtonType.Reply, 0);

			AddLabel(625, 125, 0x486, "Lime Seeds");
			AddLabel(775, 125, 0x480, key.LimeTreeSeed.ToString());
			AddButton(575, 125, 4005, 4007, (m_Key.LimeTreeSeed <= 0) ? 999 : 44, GumpButtonType.Reply, 0);

			AddLabel(625, 150, 0x486, "Mandrake Seeds");
			AddLabel(775, 150, 0x480, key.MandrakeSeed.ToString());
			AddButton(575, 150, 4005, 4007, (m_Key.MandrakeSeed <= 0) ? 999 : 45, GumpButtonType.Reply, 0);

			AddLabel(625, 175, 0x486, "Mango Tree Seeds");
			AddLabel(775, 175, 0x480, key.MangoTreeSeed.ToString());
			AddButton(575, 175, 4005, 4007, (m_Key.MangoTreeSeed <= 0) ? 999 : 46, GumpButtonType.Reply, 0);

			AddLabel(625, 200, 0x486, "Nightshade Seeds");
			AddLabel(775, 200, 0x480, key.NightshadeSeed.ToString());
			AddButton(575, 200, 4005, 4007, (m_Key.NightshadeSeed <= 0) ? 999 : 47, GumpButtonType.Reply, 0);

			AddLabel(625, 225, 0x486, "Oats Seeds");
			AddLabel(775, 225, 0x480, key.OatsSeed.ToString());
			AddButton(575, 225, 4005, 4007, (m_Key.OatsSeed <= 0) ? 999 : 48, GumpButtonType.Reply, 0);

			AddLabel(625, 250, 0x486, "Onion Seeds");
			AddLabel(775, 250, 0x480, key.OnionSeed.ToString());
			AddButton(575, 250, 4005, 4007, (m_Key.OnionSeed <= 0) ? 999 : 49, GumpButtonType.Reply, 0);

			AddLabel(625, 275, 0x486, "Orange Pepper Seeds");
			AddLabel(775, 275, 0x480, key.OrangePepperSeed.ToString());
			AddButton(575, 275, 4005, 4007, (m_Key.OrangePepperSeed <= 0) ? 999 : 50, GumpButtonType.Reply, 0);

			AddLabel(625, 300, 0x486, "Orange Seeds");
			AddLabel(775, 300, 0x480, key.OrangeTreeSeed.ToString());
			AddButton(575, 300, 4005, 4007, (m_Key.OrangeTreeSeed <= 0) ? 999 : 51, GumpButtonType.Reply, 0);

			AddLabel(625, 325, 0x486, "Peach Seeds");
			AddLabel(775, 325, 0x480, key.PeachTreeSeed.ToString());
			AddButton(575, 325, 4005, 4007, (m_Key.PeachTreeSeed <= 0) ? 999 : 52, GumpButtonType.Reply, 0);

			AddLabel(625, 350, 0x486, "Peanut Seeds");
			AddLabel(775, 350, 0x480, key.PeanutSeed.ToString());
			AddButton(575, 350, 4005, 4007, (m_Key.PeanutSeed <= 0) ? 999 : 53, GumpButtonType.Reply, 0);

			AddLabel(625, 375, 0x486, "Pear Seeds");
			AddLabel(775, 375, 0x480, key.PearTreeSeed.ToString());
			AddButton(575, 375, 4005, 4007, (m_Key.PearTreeSeed <= 0) ? 999 : 54, GumpButtonType.Reply, 0);

			AddLabel(625, 400, 0x486, "Pea Seeds");
			AddLabel(775, 400, 0x480, key.PeasSeed.ToString());
			AddButton(575, 400, 4005, 4007, (m_Key.PeasSeed <= 0) ? 999 : 55, GumpButtonType.Reply, 0);

			AddLabel(625, 425, 0x486, "Pineapple Seeds");
			AddLabel(775, 425, 0x480, key.PineappleTreeSeed.ToString());
			AddButton(575, 425, 4005, 4007, (m_Key.PineappleTreeSeed <= 0) ? 999 : 56, GumpButtonType.Reply, 0);

			AddLabel(625, 450, 0x486, "Pistacio Seeds");
			AddLabel(775, 450, 0x480, key.PistacioTreeSeed.ToString());
			AddButton(575, 450, 4005, 4007, (m_Key.PistacioTreeSeed <= 0) ? 999 : 57, GumpButtonType.Reply, 0);

			AddLabel(625, 475, 0x486, "Plum Tree Seeds");
			AddLabel(775, 475, 0x480, key.PlumTreeSeed.ToString());
			AddButton(575, 475, 4005, 4007, (m_Key.PlumTreeSeed <= 0) ? 999 : 58, GumpButtonType.Reply, 0);

			AddLabel(625, 500, 0x486, "Pomegranate Seeds");
			AddLabel(775, 500, 0x480, key.PomegranateTreeSeed.ToString());
			AddButton(575, 500, 4005, 4007, (m_Key.PomegranateTreeSeed <= 0) ? 999 : 59, GumpButtonType.Reply, 0);

			AddLabel(625, 525, 0x486, "Potato Seeds");
			AddLabel(775, 525, 0x480, key.PotatoSeed.ToString());
			AddButton(575, 525, 4005, 4007, (m_Key.PotatoSeed <= 0) ? 999 : 60, GumpButtonType.Reply, 0);

			AddLabel(875, 50, 0x486, "Pumpkin Seeds");
			AddLabel(1025, 50, 0x480, key.PumpkinSeed.ToString());
			AddButton(825, 50, 4005, 4007, (m_Key.PumpkinSeed <= 0) ? 999 : 61, GumpButtonType.Reply, 0);

			AddLabel(875, 75, 0x486, "Rasish Seeds");
			AddLabel(1025, 75, 0x480, key.RadishSeed.ToString());
			AddButton(825, 75, 4005, 4007, (m_Key.RadishSeed <= 0) ? 999 : 62, GumpButtonType.Reply, 0);

			AddLabel(875, 100, 0x486, "Red Pepper Seeds");
			AddLabel(1025, 100, 0x480, key.RedPepperSeed.ToString());
			AddButton(825, 100, 4005, 4007, (m_Key.RedPepperSeed <= 0) ? 999 : 63, GumpButtonType.Reply, 0);

			AddLabel(875, 125, 0x486, "Red Raspberry Seeds");
			AddLabel(1025, 125, 0x480, key.RedRaspberryTreeSeed.ToString());
			AddButton(825, 125, 4005, 4007, (m_Key.RedRaspberryTreeSeed <= 0) ? 999 : 64, GumpButtonType.Reply, 0);

			AddLabel(875, 150, 0x486, "Rice Seeds");
			AddLabel(1025, 150, 0x480, key.RiceSeed.ToString());
			AddButton(825, 150, 4005, 4007, (m_Key.RiceSeed <= 0) ? 999 : 65, GumpButtonType.Reply, 0);

			AddLabel(875, 175, 0x486, "Snow Hops Seeds");
			AddLabel(1025, 175, 0x480, key.SnowHopsSeed.ToString());
			AddButton(825, 175, 4005, 4007, (m_Key.SnowHopsSeed <= 0) ? 999 : 66, GumpButtonType.Reply, 0);

			AddLabel(875, 200, 0x486, "Snow Peas Seeds");
			AddLabel(1025, 200, 0x480, key.SnowPeasSeed.ToString());
			AddButton(825, 200, 4005, 4007, (m_Key.SnowPeasSeed <= 0) ? 999 : 67, GumpButtonType.Reply, 0);

			AddLabel(875, 225, 0x486, "Soy Seeds");
			AddLabel(1025, 225, 0x480, key.SoySeed.ToString());
			AddButton(825, 225, 4005, 4007, (m_Key.SoySeed <= 0) ? 999 : 68, GumpButtonType.Reply, 0);

			AddLabel(875, 250, 0x486, "Spinach Seeds");
			AddLabel(1025, 250, 0x480, key.SpinachSeed.ToString());
			AddButton(825, 250, 4005, 4007, (m_Key.SpinachSeed <= 0) ? 999 : 69, GumpButtonType.Reply, 0);

			AddLabel(875, 275, 0x486, "Squash Seeds");
			AddLabel(1025, 275, 0x480, key.SquashSeed.ToString());
			AddButton(825, 275, 4005, 4007, (m_Key.SquashSeed <= 0) ? 999 : 70, GumpButtonType.Reply, 0);

			AddLabel(875, 300, 0x486, "Strawberry Seeds");
			AddLabel(1025, 300, 0x480, key.StrawberrySeed.ToString());
			AddButton(825, 300, 4005, 4007, (m_Key.StrawberrySeed <= 0) ? 999 : 71, GumpButtonType.Reply, 0);

			AddLabel(875, 325, 0x486, "Sugar Seeds");
			AddLabel(1025, 325, 0x480, key.SugarSeed.ToString());
			AddButton(825, 325, 4005, 4007, (m_Key.SugarSeed <= 0) ? 999 : 72, GumpButtonType.Reply, 0);

			AddLabel(875, 350, 0x486, "Sun Flower Seeds");
			AddLabel(1025, 350, 0x480, key.SunFlowerSeed.ToString());
			AddButton(825, 350, 4005, 4007, (m_Key.SunFlowerSeed <= 0) ? 999 : 73, GumpButtonType.Reply, 0);

			AddLabel(875, 375, 0x486, "Sweet Hops Seeds");
			AddLabel(1025, 375, 0x480, key.SweetHopsSeed.ToString());
			AddButton(825, 375, 4005, 4007, (m_Key.SweetHopsSeed <= 0) ? 999 : 74, GumpButtonType.Reply, 0);

			AddLabel(875, 400, 0x486, "Sweet Potato Seeds");
			AddLabel(1025, 400, 0x480, key.SweetPotatoSeed.ToString());
			AddButton(825, 400, 4005, 4007, (m_Key.SweetPotatoSeed <= 0) ? 999 : 75, GumpButtonType.Reply, 0);

			AddLabel(875, 425, 0x486, "Tea Seeds");
			AddLabel(1025, 425, 0x480, key.TeaSeed.ToString());
			AddButton(825, 425, 4005, 4007, (m_Key.TeaSeed <= 0) ? 999 : 76, GumpButtonType.Reply, 0);

			AddLabel(875, 450, 0x486, "Tomato Seeds");
			AddLabel(1025, 450, 0x480, key.TomatoSeed.ToString());
			AddButton(825, 450, 4005, 4007, (m_Key.TomatoSeed <= 0) ? 999 : 77, GumpButtonType.Reply, 0);

			AddLabel(875, 475, 0x486, "Turnip Seeds");
			AddLabel(1025, 475, 0x480, key.TurnipSeed.ToString());
			AddButton(825, 475, 4005, 4007, (m_Key.TurnipSeed <= 0) ? 999 : 78, GumpButtonType.Reply, 0);

			AddLabel(875, 500, 0x486, "Watermelon Seeds");
			AddLabel(1025, 500, 0x480, key.WatermelonSeed.ToString());
			AddButton(825, 500, 4005, 4007, (m_Key.WatermelonSeed <= 0) ? 999 : 79, GumpButtonType.Reply, 0);

			AddLabel(875, 525, 0x486, "Wheat Seeds");
			AddLabel(1025, 525, 0x480, key.WheatSeed.ToString());
			AddButton(825, 525, 4005, 4007, (m_Key.WheatSeed <= 0) ? 999 : 80, GumpButtonType.Reply, 0);

			AddLabel(575, 550, 88, "Each Max:" );
			AddLabel(650, 550, 0x480, key.StorageLimit.ToString() );	

            AddLabel(375, 550, 88, "Add resource");
            AddButton(325, 550, 4005, 4007, 999, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Key.Deleted)
                return;

            else if (info.ButtonID == 1)
            {
                if (m_Key.AlmondTreeSeed >= m_Key.WithdrawIncrement)
                {
                    m_From.AddToBackpack(new AlmondTreeSeed(m_Key.WithdrawIncrement));
                    m_Key.AlmondTreeSeed = m_Key.AlmondTreeSeed - m_Key.WithdrawIncrement;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
                else 
                {
                    m_From.AddToBackpack(new AlmondTreeSeed(m_Key.AlmondTreeSeed));
                    m_Key.AlmondTreeSeed = 0;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
            }
            else if (info.ButtonID == 2)
            {
                if (m_Key.AppleTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new AppleTreeSeed(m_Key.WithdrawIncrement));
                  m_Key.AppleTreeSeed = m_Key.AppleTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump( new SeedContainerGump( m_From, m_Key ) );
				}
                else
                {
                    m_From.AddToBackpack(new AppleTreeSeed(m_Key.AppleTreeSeed));
                    m_Key.AppleTreeSeed = 0;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
            }
            else if (info.ButtonID == 3)
            {
                if (m_Key.ApricotTreeSeed >= m_Key.WithdrawIncrement)
                {
                    m_From.AddToBackpack(new ApricotTreeSeed(m_Key.WithdrawIncrement));
                    m_Key.ApricotTreeSeed = m_Key.ApricotTreeSeed - m_Key.WithdrawIncrement;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
                else 
                {
                    m_From.AddToBackpack(new ApricotTreeSeed(m_Key.ApricotTreeSeed));
                    m_Key.ApricotTreeSeed = 0;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
            }
			else if (info.ButtonID == 4)
			{
				if (m_Key.AsparagusSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new AsparagusSeed(m_Key.WithdrawIncrement));				
					m_Key.AsparagusSeed = m_Key.AsparagusSeed -m_Key.WithdrawIncrement;				
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));	
				}
				else
				{
					m_From.AddToBackpack(new AsparagusSeed(m_Key.AsparagusSeed));
					m_Key.AsparagusSeed = 0;
                  m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 5)
			{
				if (m_Key.AvocadoTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new AvocadoTreeSeed(m_Key.WithdrawIncrement));
					m_Key.AvocadoTreeSeed = m_Key.AvocadoTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else 
				{
					m_From.AddToBackpack(new AvocadoTreeSeed(m_Key.AvocadoTreeSeed));
					m_Key.AvocadoTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 6)
			{
				if (m_Key.BananaTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new BananaTreeSeed(m_Key.WithdrawIncrement));
					m_Key.BananaTreeSeed = m_Key.BananaTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else 
				{
					m_From.AddToBackpack(new BananaTreeSeed(m_Key.AvocadoTreeSeed));
					m_Key.BananaTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 7)
			{
				if (m_Key.BeetSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new BeetSeed(m_Key.WithdrawIncrement));
					m_Key.BeetSeed = m_Key.BeetSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new BeetSeed(m_Key.BeetSeed));
					m_Key.BeetSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 8)
			{
				if (m_Key.BitterHopsSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new BitterHopsSeed(m_Key.WithdrawIncrement));
					m_Key.BitterHopsSeed = m_Key.BitterHopsSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new BitterHopsSeed(m_Key.BitterHopsSeed));
					m_Key.BitterHopsSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 9)
			{
				if (m_Key.BlackberryTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new BlackberryTreeSeed(m_Key.WithdrawIncrement));
					m_Key.BlackberryTreeSeed = m_Key.BlackberryTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new BlackberryTreeSeed(m_Key.BlackberryTreeSeed));
					m_Key.BlackberryTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 10)
			{
				if (m_Key.BlackRaspberryTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new BlackRaspberryTreeSeed(m_Key.WithdrawIncrement));
					m_Key.BlackRaspberryTreeSeed = m_Key.BlackRaspberryTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new BlackRaspberryTreeSeed(m_Key.BlackRaspberryTreeSeed));
					m_Key.BlackRaspberryTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if ( info.ButtonID == 11 )
			{
				if ( m_Key.BlueberryTreeSeed >= m_Key.WithdrawIncrement)
				{
                  m_From.AddToBackpack(new BlueberryTreeSeed(m_Key.WithdrawIncrement));
					m_Key.BlueberryTreeSeed = m_Key.BlueberryTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump( new SeedContainerGump( m_From, m_Key ) );
				}
				else
				{
					m_From.AddToBackpack(new BlueberryTreeSeed(m_Key.BlueberryTreeSeed));
					m_Key.BlueberryTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 12)
			{
				if (m_Key.BroccoliSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new BroccoliSeed(m_Key.WithdrawIncrement));
					m_Key.BroccoliSeed = m_Key.BroccoliSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new BroccoliSeed(m_Key.BroccoliSeed));
					m_Key.BroccoliSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 13)
			{
				if (m_Key.CabbageSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CabbageSeed(m_Key.WithdrawIncrement));
					m_Key.CabbageSeed = m_Key.CabbageSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CabbageSeed(m_Key.CabbageSeed));
					m_Key.CabbageSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 14)
			{
				if (m_Key.CantaloupeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CantaloupeSeed(m_Key.WithdrawIncrement));
					m_Key.CantaloupeSeed = m_Key.CantaloupeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CantaloupeSeed(m_Key.CantaloupeSeed));
					m_Key.CantaloupeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 15)
			{
				if (m_Key.CarrotSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CarrotSeed(m_Key.WithdrawIncrement));
					m_Key.CarrotSeed = m_Key.CarrotSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CarrotSeed(m_Key.CarrotSeed));
					m_Key.CarrotSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 16)
			{
				if (m_Key.CauliflowerSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CauliflowerSeed(m_Key.WithdrawIncrement));
					m_Key.CauliflowerSeed = m_Key.CauliflowerSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CauliflowerSeed(m_Key.CauliflowerSeed));
					m_Key.CauliflowerSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			if (info.ButtonID == 17)
			{
				if (m_Key.CelerySeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CelerySeed(m_Key.WithdrawIncrement));
					m_Key.CelerySeed = m_Key.CelerySeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CelerySeed(m_Key.CelerySeed));
					m_Key.CelerySeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 18)
			{
				if (m_Key.CherryTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CherryTreeSeed(m_Key.WithdrawIncrement));
					m_Key.CherryTreeSeed = m_Key.CherryTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CherryTreeSeed(m_Key.CherryTreeSeed));
					m_Key.CherryTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			if (info.ButtonID == 19)
			{
				if (m_Key.ChiliPepperSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new ChiliPepperSeed(m_Key.WithdrawIncrement));
					m_Key.ChiliPepperSeed = m_Key.ChiliPepperSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new ChiliPepperSeed(m_Key.ChiliPepperSeed));
					m_Key.ChiliPepperSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if ( info.ButtonID == 20 )
			{
				if ( m_Key.CocoaTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CocoaTreeSeed(m_Key.WithdrawIncrement));
					m_Key.CocoaTreeSeed = m_Key.CocoaTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump( new SeedContainerGump( m_From, m_Key ) );
				}
				else
				{
					m_From.AddToBackpack(new CocoaTreeSeed(m_Key.CocoaTreeSeed));
					m_Key.CocoaTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if ( info.ButtonID == 21 )
			{
				if ( m_Key.CoconutPalmSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CoconutPalmSeed(m_Key.WithdrawIncrement));
					m_Key.CoconutPalmSeed = m_Key.CoconutPalmSeed - m_Key.WithdrawIncrement;
					m_From.SendGump( new SeedContainerGump( m_From, m_Key ) );
				}
				else
				{
					m_From.AddToBackpack(new CoconutPalmSeed(m_Key.CoconutPalmSeed));
					m_Key.CoconutPalmSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 22)
			{
				if (m_Key.CoffeeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CoffeeSeed(m_Key.WithdrawIncrement));
					m_Key.CoffeeSeed = m_Key.CoffeeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CoffeeSeed(m_Key.CoffeeSeed));
					m_Key.CoffeeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 23)
			{
				if (m_Key.CornSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CornSeed(m_Key.WithdrawIncrement));
					m_Key.CornSeed = m_Key.CornSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CornSeed(m_Key.CornSeed));
					m_Key.CornSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 24)
			{
				if (m_Key.CottonSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CottonSeed(m_Key.WithdrawIncrement));
					m_Key.CottonSeed = m_Key.CottonSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CottonSeed(m_Key.CottonSeed));
					m_Key.CottonSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 25)
			{
				if (m_Key.CranberryTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CranberryTreeSeed(m_Key.WithdrawIncrement));
					m_Key.CranberryTreeSeed = m_Key.CranberryTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CranberryTreeSeed(m_Key.CranberryTreeSeed));
					m_Key.CranberryTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 26)
			{
				if (m_Key.CucumberSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new CucumberSeed(m_Key.WithdrawIncrement));
					m_Key.CucumberSeed = m_Key.CucumberSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new CucumberSeed(m_Key.CucumberSeed));
					m_Key.CucumberSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 27)
			{
				if (m_Key.DatePalmSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new DatePalmSeed(m_Key.WithdrawIncrement));
					m_Key.DatePalmSeed = m_Key.DatePalmSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new DatePalmSeed(m_Key.DatePalmSeed));
					m_Key.DatePalmSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 28)
			{
				if (m_Key.EggplantSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new EggplantSeed(m_Key.WithdrawIncrement));
					m_Key.EggplantSeed = m_Key.EggplantSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new EggplantSeed(m_Key.EggplantSeed));
					m_Key.EggplantSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 29)
			{
				if (m_Key.ElvenHopsSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new ElvenHopsSeed(m_Key.WithdrawIncrement));
					m_Key.ElvenHopsSeed = m_Key.ElvenHopsSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new ElvenHopsSeed(m_Key.ElvenHopsSeed));
					m_Key.ElvenHopsSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 30)
			{
				if (m_Key.FieldCornSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new FieldCornSeed(m_Key.WithdrawIncrement));
					m_Key.FieldCornSeed = m_Key.FieldCornSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new FieldCornSeed(m_Key.FieldCornSeed));
					m_Key.FieldCornSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}

            else if (info.ButtonID == 31)
            {
                if (m_Key.FlaxSeed >= m_Key.WithdrawIncrement)
                {
                    m_From.AddToBackpack(new FlaxSeed(m_Key.WithdrawIncrement));
                    m_Key.FlaxSeed = m_Key.FlaxSeed - m_Key.WithdrawIncrement;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
                else
                {
                    m_From.AddToBackpack(new FlaxSeed(m_Key.FlaxSeed));
                    m_Key.FlaxSeed = 0;
                    m_From.SendGump(new SeedContainerGump(m_From, m_Key));
                }
			}
			else if (info.ButtonID == 32)
			{
				if (m_Key.GarlicSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GarlicSeed(m_Key.WithdrawIncrement));
					m_Key.GarlicSeed = m_Key.GarlicSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GarlicSeed(m_Key.GarlicSeed));
					m_Key.GarlicSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 33)
			{
				if (m_Key.GingerSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GingerSeed(m_Key.WithdrawIncrement));
					m_Key.GingerSeed = m_Key.GingerSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GingerSeed(m_Key.GingerSeed));
					m_Key.GingerSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 34)
			{
				if (m_Key.GinsengSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GinsengSeed(m_Key.WithdrawIncrement));
					m_Key.GinsengSeed = m_Key.GinsengSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GinsengSeed(m_Key.GinsengSeed));
					m_Key.GinsengSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 35)
			{
				if (m_Key.GrapefruitTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GrapefruitTreeSeed(m_Key.WithdrawIncrement));
					m_Key.GrapefruitTreeSeed = m_Key.GrapefruitTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GrapefruitTreeSeed(m_Key.GrapefruitTreeSeed));
					m_Key.GrapefruitTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 36)
			{
				if (m_Key.GreenBeanSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GreenBeanSeed(m_Key.WithdrawIncrement));
					m_Key.GreenBeanSeed = m_Key.GreenBeanSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GreenBeanSeed(m_Key.GreenBeanSeed));
					m_Key.GreenBeanSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 37)
			{
				if (m_Key.GreenPepperSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GreenPepperSeed(m_Key.WithdrawIncrement));
					m_Key.GreenPepperSeed = m_Key.GreenPepperSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GreenPepperSeed(m_Key.GreenPepperSeed));
					m_Key.GreenPepperSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 38)
			{
				if (m_Key.GreenSquashSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new GreenSquashSeed(m_Key.WithdrawIncrement));
					m_Key.GreenSquashSeed = m_Key.GreenSquashSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new GreenSquashSeed(m_Key.GreenSquashSeed));
					m_Key.GreenSquashSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 39)
			{
				if (m_Key.HaySeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new HaySeed(m_Key.WithdrawIncrement));
					m_Key.HaySeed = m_Key.HaySeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new HaySeed(m_Key.HaySeed));
					m_Key.HaySeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 40)
			{
				if (m_Key.HoneydewMelonSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new HoneydewMelonSeed(m_Key.WithdrawIncrement));
					m_Key.HoneydewMelonSeed = m_Key.HoneydewMelonSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new HoneydewMelonSeed(m_Key.HoneydewMelonSeed));
					m_Key.HoneydewMelonSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 41)
			{
				if (m_Key.KiwiSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new KiwiSeed(m_Key.WithdrawIncrement));
					m_Key.KiwiSeed = m_Key.KiwiSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new KiwiSeed(m_Key.KiwiSeed));
					m_Key.KiwiSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 42)
			{
				if (m_Key.LemonTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new LemonTreeSeed(m_Key.WithdrawIncrement));
					m_Key.LemonTreeSeed = m_Key.LemonTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new LemonTreeSeed(m_Key.LemonTreeSeed));
					m_Key.LemonTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 43)
			{
				if (m_Key.LettuceSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new LettuceSeed(m_Key.WithdrawIncrement));
					m_Key.LettuceSeed = m_Key.LettuceSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new LettuceSeed(m_Key.LettuceSeed));
					m_Key.LettuceSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 44)
			{
				if (m_Key.LimeTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new LimeTreeSeed(m_Key.WithdrawIncrement));
					m_Key.LimeTreeSeed = m_Key.LimeTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new LimeTreeSeed(m_Key.LimeTreeSeed));
					m_Key.LimeTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 45)
			{
				if (m_Key.MandrakeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new MandrakeSeed(m_Key.WithdrawIncrement));
					m_Key.MandrakeSeed = m_Key.MandrakeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new MandrakeSeed(m_Key.MandrakeSeed));
					m_Key.MandrakeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 46)
			{
				if (m_Key.MangoTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new MangoTreeSeed(m_Key.WithdrawIncrement));
					m_Key.MangoTreeSeed = m_Key.MangoTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new MangoTreeSeed(m_Key.MangoTreeSeed));
					m_Key.MangoTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 47)
			{
				if (m_Key.NightshadeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new NightshadeSeed(m_Key.WithdrawIncrement));
					m_Key.NightshadeSeed = m_Key.NightshadeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new NightshadeSeed(m_Key.NightshadeSeed));
					m_Key.NightshadeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 48)
			{
				if (m_Key.OatsSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new OatsSeed(m_Key.WithdrawIncrement));
					m_Key.OatsSeed = m_Key.OatsSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new OatsSeed(m_Key.OatsSeed));
					m_Key.OatsSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 49)
			{
				if (m_Key.OnionSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new OnionSeed(m_Key.WithdrawIncrement));
					m_Key.OnionSeed = m_Key.OnionSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new OnionSeed(m_Key.OnionSeed));
					m_Key.OnionSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 50)
			{
				if (m_Key.OrangePepperSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new OrangePepperSeed(m_Key.WithdrawIncrement));
					m_Key.OrangePepperSeed = m_Key.OrangePepperSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new OrangePepperSeed(m_Key.OrangePepperSeed));
					m_Key.OrangePepperSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 51)
			{
				if (m_Key.OrangeTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new OrangeTreeSeed(m_Key.WithdrawIncrement));
					m_Key.OrangeTreeSeed = m_Key.OrangeTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new OrangeTreeSeed(m_Key.OrangeTreeSeed));
					m_Key.OrangeTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 52)
			{
				if (m_Key.PeachTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PeachTreeSeed(m_Key.WithdrawIncrement));
					m_Key.PeachTreeSeed = m_Key.PeachTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PeachTreeSeed(m_Key.PeachTreeSeed));
					m_Key.PeachTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 53)
			{
				if (m_Key.PeanutSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PeanutSeed(m_Key.WithdrawIncrement));
					m_Key.PeanutSeed = m_Key.PeanutSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PeanutSeed(m_Key.PeanutSeed));
					m_Key.PeanutSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 54)
			{
				if (m_Key.PearTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PearTreeSeed(m_Key.WithdrawIncrement));
					m_Key.PearTreeSeed = m_Key.PearTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PearTreeSeed(m_Key.PearTreeSeed));
					m_Key.PearTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 55)
			{
				if (m_Key.PeasSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PeasSeed(m_Key.WithdrawIncrement));
					m_Key.PeasSeed = m_Key.PeasSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PeasSeed(m_Key.PeasSeed));
					m_Key.PeasSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 56)
			{
				if (m_Key.PineappleTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PineappleTreeSeed(m_Key.WithdrawIncrement));
					m_Key.PineappleTreeSeed = m_Key.PineappleTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PineappleTreeSeed(m_Key.PineappleTreeSeed));
					m_Key.PineappleTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 57)
			{
				if (m_Key.PistacioTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PistacioTreeSeed(m_Key.WithdrawIncrement));
					m_Key.PistacioTreeSeed = m_Key.PistacioTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PistacioTreeSeed(m_Key.PistacioTreeSeed));
					m_Key.PistacioTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 58)
			{
				if (m_Key.PlumTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PlumTreeSeed(m_Key.WithdrawIncrement));
					m_Key.PlumTreeSeed = m_Key.PlumTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PlumTreeSeed(m_Key.PlumTreeSeed));
					m_Key.PlumTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 59)
			{
				if (m_Key.PomegranateTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PomegranateTreeSeed(m_Key.WithdrawIncrement));
					m_Key.PomegranateTreeSeed = m_Key.PomegranateTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PomegranateTreeSeed(m_Key.PomegranateTreeSeed));
					m_Key.PomegranateTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 60)
			{
				if (m_Key.PotatoSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PotatoSeed(m_Key.WithdrawIncrement));
					m_Key.PotatoSeed = m_Key.PotatoSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PotatoSeed(m_Key.PotatoSeed));
					m_Key.PotatoSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 61)
			{
				if (m_Key.PumpkinSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new PumpkinSeed(m_Key.WithdrawIncrement));
					m_Key.PumpkinSeed = m_Key.PumpkinSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new PumpkinSeed(m_Key.PumpkinSeed));
					m_Key.PumpkinSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 62)
			{
				if (m_Key.RadishSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new RadishSeed(m_Key.WithdrawIncrement));
					m_Key.RadishSeed = m_Key.RadishSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new RadishSeed(m_Key.RadishSeed));
					m_Key.RadishSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 63)
			{
				if (m_Key.RedPepperSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new RedPepperSeed(m_Key.WithdrawIncrement));
					m_Key.RedPepperSeed = m_Key.RedPepperSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new RedPepperSeed(m_Key.RedPepperSeed));
					m_Key.RedPepperSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 64)
			{
				if (m_Key.RedRaspberryTreeSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new RedRaspberryTreeSeed(m_Key.WithdrawIncrement));
					m_Key.RedRaspberryTreeSeed = m_Key.RedRaspberryTreeSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new RedRaspberryTreeSeed(m_Key.RedRaspberryTreeSeed));
					m_Key.RedRaspberryTreeSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 65)
			{
				if (m_Key.RiceSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new RiceSeed(m_Key.WithdrawIncrement));
					m_Key.RiceSeed = m_Key.RiceSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new RiceSeed(m_Key.RiceSeed));
					m_Key.RiceSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 66)
			{
				if (m_Key.SnowHopsSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SnowHopsSeed(m_Key.WithdrawIncrement));
					m_Key.SnowHopsSeed = m_Key.SnowHopsSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SnowHopsSeed(m_Key.SnowHopsSeed));
					m_Key.SnowHopsSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 67)
			{
				if (m_Key.SnowPeasSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SnowPeasSeed(m_Key.WithdrawIncrement));
					m_Key.SnowPeasSeed = m_Key.SnowPeasSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SnowPeasSeed(m_Key.SnowPeasSeed));
					m_Key.SnowPeasSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 68)
			{
				if (m_Key.SoySeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SoySeed(m_Key.WithdrawIncrement));
					m_Key.SoySeed = m_Key.SoySeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SoySeed(m_Key.SoySeed));
					m_Key.SoySeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 69)
			{
				if (m_Key.SpinachSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SpinachSeed(m_Key.WithdrawIncrement));
					m_Key.SpinachSeed = m_Key.SpinachSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SpinachSeed(m_Key.SpinachSeed));
					m_Key.SpinachSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 70)
			{
				if (m_Key.SquashSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SquashSeed(m_Key.WithdrawIncrement));
					m_Key.SquashSeed = m_Key.SquashSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SquashSeed(m_Key.SquashSeed));
					m_Key.SquashSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 71)
			{
				if (m_Key.StrawberrySeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new StrawberrySeed(m_Key.WithdrawIncrement));
					m_Key.StrawberrySeed = m_Key.StrawberrySeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new StrawberrySeed(m_Key.StrawberrySeed));
					m_Key.StrawberrySeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 72)
			{
				if (m_Key.SugarSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SugarSeed(m_Key.WithdrawIncrement));
					m_Key.SugarSeed = m_Key.SugarSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SugarSeed(m_Key.SugarSeed));
					m_Key.SugarSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 73)
			{
				if (m_Key.SunFlowerSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SunFlowerSeed(m_Key.WithdrawIncrement));
					m_Key.SunFlowerSeed = m_Key.SunFlowerSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SunFlowerSeed(m_Key.SunFlowerSeed));
					m_Key.SunFlowerSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 74)
			{
				if (m_Key.SweetHopsSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SweetHopsSeed(m_Key.WithdrawIncrement));
					m_Key.SweetHopsSeed = m_Key.SweetHopsSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SweetHopsSeed(m_Key.SweetHopsSeed));
					m_Key.SweetHopsSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 75)
			{
				if (m_Key.SweetPotatoSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new SweetPotatoSeed(m_Key.WithdrawIncrement));
					m_Key.SweetPotatoSeed = m_Key.SweetPotatoSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new SweetPotatoSeed(m_Key.SweetPotatoSeed));
					m_Key.SweetPotatoSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 76)
			{
				if (m_Key.TeaSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new TeaSeed(m_Key.WithdrawIncrement));
					m_Key.TeaSeed = m_Key.TeaSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new TeaSeed(m_Key.TeaSeed));
					m_Key.TeaSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 77)
			{
				if (m_Key.TomatoSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new TomatoSeed(m_Key.WithdrawIncrement));
					m_Key.TomatoSeed = m_Key.TomatoSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new TomatoSeed(m_Key.TomatoSeed));
					m_Key.TomatoSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 78)
			{
				if (m_Key.TurnipSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new TurnipSeed(m_Key.WithdrawIncrement));
					m_Key.TurnipSeed = m_Key.TurnipSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new TurnipSeed(m_Key.TurnipSeed));
					m_Key.TurnipSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 79)
			{
				if (m_Key.WatermelonSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new WatermelonSeed(m_Key.WithdrawIncrement));
					m_Key.WatermelonSeed = m_Key.WatermelonSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new WatermelonSeed(m_Key.WatermelonSeed));
					m_Key.WatermelonSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 80)
			{
				if (m_Key.WheatSeed >= m_Key.WithdrawIncrement)
				{
					m_From.AddToBackpack(new WheatSeed(m_Key.WithdrawIncrement));
					m_Key.WheatSeed = m_Key.WheatSeed - m_Key.WithdrawIncrement;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
				else
				{
					m_From.AddToBackpack(new WheatSeed(m_Key.WheatSeed));
					m_Key.WheatSeed = 0;
					m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				}
			}
			else if (info.ButtonID == 999)
			{
				m_From.SendMessage("Please select items to add to the Acorn.");
				m_From.SendGump(new SeedContainerGump(m_From, m_Key));
				m_Key.BeginCombine(m_From);
			}
        }
    }
}

namespace Server.Items
{
    public class SeedContainerTarget : Target
    {
        private SeedContainer m_Key;

        public SeedContainerTarget(SeedContainer key) : base( 18, false, TargetFlags.None )
        {
            m_Key = key;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (m_Key.Deleted)
                return;

            m_Key.EndCombine(from, targeted);
        }
    }
}