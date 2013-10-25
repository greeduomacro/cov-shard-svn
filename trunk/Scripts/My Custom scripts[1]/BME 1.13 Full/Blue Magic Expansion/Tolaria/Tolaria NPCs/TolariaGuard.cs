//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class TolariaGuard: TolariaNPC
	{
		public override string m_Speech{ get{ return "Tolaria is in the process of being built. Until then, if you want to become a Blue Mage you'll have to find Ben and he is in the Serpetine Passage in Ilshenar."; } }

		[Constructable]
		public TolariaGuard()
		{
			Body = 400;
			Name = NameList.RandomName( "male" );
			Title = "the tolaria guard";

			Static item = new Static( 11022 );
			item.Layer = Layer.Helm;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11022 );
			item.Layer = Layer.Neck;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11016 );
			item.Layer = Layer.InnerTorso;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11014 );
			item.Layer = Layer.Pants;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11027 );
			item.Layer = Layer.Shoes;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11018 );
			item.Layer = Layer.Arms;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11020 );
			item.Layer = Layer.Gloves;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11012 );
			item.Layer = Layer.Cloak;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 11009 );
			item.Layer = Layer.TwoHanded;
			item.Hue = 2714;
			EquipItem( item );

			item = new Static( 9934 );
			item.Layer = Layer.FirstValid;
			item.Hue = 2714;
			EquipItem( item );
		}

		public TolariaGuard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
