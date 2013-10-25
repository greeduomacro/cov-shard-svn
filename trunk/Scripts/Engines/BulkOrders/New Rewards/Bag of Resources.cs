/*
 created by:
     /\            888                   888     .d8888b.   .d8888b.  
____/_ \____       888                   888    d88P  Y88b d88P  Y88b 
\  ___\ \  /       888                   888    888    888 888    888 
 \/ /  \/ /    .d88888  8888b.   8888b.  888888 Y88b. d888 Y88b. d888 
 / /\__/_/\   d88" 888     "88b     "88b 888     "Y888P888  "Y888P888 
/__\ \_____\  888  888 .d888888 .d888888 888           888        888 
    \  /      Y88b 888 888  888 888  888 Y88b.  Y88b  d88P Y88b  d88P 
     \/        "Y88888 "Y888888 "Y888888  "Y888  "Y8888P"   "Y8888P"  
*/
using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class BagOfResources : Bag
	{
		[Constructable]
		public BagOfResources() : base()
		{
			Weight = 100.0;
			Name = "Bag of Resources";
			//TotalWeight = 0;
			Hue = CraftResources.GetHue( (CraftResource)Utility.RandomMinMax( (int)CraftResource.DullCopper, (int)CraftResource.Sunstone ) );
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			base.OnDragDrop( from, dropped );
			
			//TotalWeight = 0;
			if (dropped is BaseOre || dropped is BaseHides || dropped is Log || dropped is PineLog ||
				dropped is AshLog || dropped is MahoganyLog || dropped is YewLog || dropped is OakLog  )
				return true;
			return false;
		}

		public override bool OnDragDropInto( Mobile from, Item dropped, Point3D p )
		{
			base.OnDragDropInto( from, dropped, p );

			//TotalWeight = 0;
			if (dropped is BaseOre || dropped is BaseHides || dropped is PineLog ||
				dropped is AshLog || dropped is MahoganyLog || dropped is YewLog || dropped is OakLog )
				return true;
			return false;
		}
		
		public override void GetProperties( ObjectPropertyList list )
		{

			base.GetProperties(list);

			//if(TotalWeight != 0) 
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( InvalidateProperties ) );

			//TotalWeight = 0;
		}

		public BagOfResources( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			//TotalWeight = 0;
		}
	}
}
