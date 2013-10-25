using System;
using Server.Items;
using Server.Misc;
using System.Collections;

/* BlarneyStone2007: RunUO script written by David, Feb 2004.
 * Special release for paid support area only.
 * Please do not distribute, including upload to RunUO.com.
 * Thank you.
 */

namespace Server.Items
{
	public class BlarneyStone2009 : Item
	{
		private bool i_Active = true;
		private int i_Range = 4;
		private DateTime i_SpeakNext = DateTime.Now;
		
		private string[] i_Messages = 
		{
			"Happy St. Patrick's Day!",
			"If you're enough lucky to be Irish ... you're lucky enough!",
			"There are only two kinds of people in the world, the Irish, and those who wish they were.",
			"May the leprechauns be near you to spread luck along your way.",
			"When Irish eyes are smiling, watch your step!",
			"May you live as long as you want, and never want as long as you live.",
		};
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string Speak1
		{
			get { return i_Messages[0]; }
			set { i_Messages[0] = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string Speak2
		{
			get { return i_Messages[1]; }
			set { i_Messages[1] = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string Speak3
		{
			get { return i_Messages[2]; }
			set { i_Messages[2] = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string Speak4
		{
			get { return i_Messages[3]; }
			set { i_Messages[3] = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string Speak5
		{
			get { return i_Messages[4]; }
			set { i_Messages[4] = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string Speak6
		{
			get { return i_Messages[5]; }
			set { i_Messages[5] = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Active
		{
			get { return i_Active; }
			set { i_Active = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Range
		{
			get { return i_Range; }
			set { i_Range = value & 0xF; }
		}

		public override bool HandlesOnMovement{ get{ return true; } }
		public override void OnMovement( Mobile m, Point3D oldLocation ) 
		{                                                    
			if( i_Active && m.Player && m.InRange( this, i_Range ) && ( !m.Hidden || m.AccessLevel == AccessLevel.Player ) )
			{ 
				if ( DateTime.Now > i_SpeakNext ) 
				{                
					i_SpeakNext = (DateTime.Now).AddSeconds( Utility.RandomMinMax( 5, 15 ) );
					
					string msg = i_Messages[Utility.Random( i_Messages.Length )];
					PublicOverheadMessage( Network.MessageType.Regular, 0x3B2, false, msg ); 
				} 
			} 
		} 

		[Constructable]
		public BlarneyStone2009() : base( 6009 )
		{
			Movable = true;
			Hue = 1369;
			Name = "Blarney Stone 2009";
			LootType = LootType.Blessed;
		}

		public BlarneyStone2009( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); 
			writer.Write( i_Active );
			writer.Write( i_Range );

			for ( int i = 0; i < i_Messages.Length; ++i )
				writer.Write( i_Messages[i] );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			i_Active = reader.ReadBool();
			i_Range = reader.ReadInt();

			for ( int i = 0; i < i_Messages.Length; ++i )
				i_Messages[i] = reader.ReadString();
		}
	}
}