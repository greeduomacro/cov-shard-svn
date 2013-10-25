// Created by Peoharen
using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class FrogDropBag : Bag
	{
		[Constructable]
		public FrogDropBag() : this( false )
		{
			Name = "Frog Drop Bag";
			Hue = 1365;
			LootType = LootType.Blessed;
		}

		[Constructable]
		public FrogDropBag( bool additems )
		{
			Name = "Frog Drop Bag";
			LootType = LootType.Blessed;

			if ( additems )
				Fill();
		}

		private void Fill()
		{
			DropItem( new WorldMap() );
			DropItem( new RedLeaves() );
			DropItem( new Sand() );
			DropItem( new SpecialHairDye() );
			DropItem( new Rope() );
			DropItem( new Vines() );
			DropItem( new TribalPaint() );
			DropItem( new RockArtifact() );
			DropItem( new SheafOfHay() );
			DropItem( new Gold( 500 ) );
		}

		private static Type[] m_FrogDropItems = new Type[]
		{
			typeof( WorldMap ),
			typeof( RedLeaves ),
			typeof( Sand ),
			typeof( SpecialHairDye ),
			typeof( Rope ),
			typeof( Vines ),
			typeof( TribalPaint ),
			typeof( RockArtifact ),
			typeof( SheafOfHay )
		};

		public bool CheckType( Item item )
		{
			Type type = item.GetType();

			for ( int i = 0; i < m_FrogDropItems.Length; i++ )
			{
				if ( type == m_FrogDropItems[i] )
					return true;
			}

			return false;
		}

		public override bool CheckHold( Mobile m, Item item, bool message, bool checkItems, int plusItems, int plusWeight )
		{
			if ( !CheckType( item ) )
			{
				if ( message )
					m.SendLocalizedMessage( 1074836 ); // The container can not hold that type of object.

				return false;
			}

			return base.CheckHold( m, item, message, checkItems, plusItems, plusWeight );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1114057, "<BASEFONT COLOR='#007FFF'>[Holds Frog Drop's Required Items]" ); // ~1_VAL~
		}

		public FrogDropBag( Serial serial ) : base( serial )
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
		}
	}
}