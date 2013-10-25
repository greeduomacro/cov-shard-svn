
using System;
using Server;
using Server.Items;

namespace Server.Items
{  
	public class HalloweenBagAllGifts2011 : Bag
	{
           	[Constructable]
           	public HalloweenBagAllGifts2011()
           	{
            Name = "Have A Spooky Halloween 2011";
			Hue = 1258;
			LootType = LootType.Cursed;

			DropItem (new HalloweenLantern2011() );    	
			DropItem(new HalloweenCloak2011());
			DropItem(new HalloweenTunic2011());
			DropItem(new HalloweenDoublet2011());
			DropItem(new HalloweenBoots2011());
			DropItem( new HalloweenOuiJaBoard2011() );
            DropItem(new HalloweenGhoulStatuette2011());
			DropItem( new BloodyTableAddonDeed() );
			DropItem( new CandyBag() );
            DropItem( new PumpkinSludge());

           	}

           	[Constructable]
           	public HalloweenBagAllGifts2011(int amount)
           	{
           	}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( "Halloween 2011" );
		}

           	public HalloweenBagAllGifts2011(Serial serial) : base( serial )
           	{
           	}

          	public override void Serialize(GenericWriter writer)
          	{
           		base.Serialize(writer);

           		writer.Write((int)0); // version 
     		}

           	public override void Deserialize(GenericReader reader)
      	{
           		base.Deserialize(reader);

          		int version = reader.ReadInt();
           	}
	}
}
