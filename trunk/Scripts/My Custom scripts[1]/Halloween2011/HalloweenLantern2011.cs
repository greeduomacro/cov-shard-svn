// Original Author Unknown
// Updated to be halloween 2007 by GreyWolf

using System;
using Server;
using Server.Items;

namespace Server.Items
{  
	public class HalloweenLantern2011 : Lantern
	{
           	[Constructable]
           	public HalloweenLantern2011()
           	{
           		Name = "a Spooky Lantern";
			Hue = Utility.RandomList( m_Hues );
			LootType = LootType.Blessed;
           	}

           	[Constructable]
           	public HalloweenLantern2011(int amount)
           	{
           	}

           	public HalloweenLantern2011(Serial serial) : base( serial )
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

			list.Add( "Halloween 2011" );
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
