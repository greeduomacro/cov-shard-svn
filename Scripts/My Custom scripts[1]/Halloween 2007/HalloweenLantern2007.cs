// Original Author Unknown
// Updated to be halloween 2007 by GreyWolf

using System;
using Server;
using Server.Items;

namespace Server.Items
{  
	public class HalloweenLantern2007 : Lantern
	{
           	[Constructable]
           	public HalloweenLantern2007()
           	{
           		Name = "a spooky lantern";
			Hue = Utility.RandomList( m_Hues );
			LootType = LootType.Blessed;
           	}

           	[Constructable]
           	public HalloweenLantern2007(int amount)
           	{
           	}

           	public HalloweenLantern2007(Serial serial) : base( serial )
           	{
           	}

		private static int[] m_Hues = new int[]
		{
			0x846,
			0x489,
			0x83A,
			0x852,
			0x47E
		};

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060662, "Halloween\t2007" );
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
