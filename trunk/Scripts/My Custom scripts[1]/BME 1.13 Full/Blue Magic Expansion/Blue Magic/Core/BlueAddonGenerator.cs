// Created by Peoharen
using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Commands;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Network;
using Server.Targeting;

namespace Server
{
	public class BlueAddonGenerator
	{
		// AddonGenerator.Template
		#region Template
		public const string Template = @"
// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class {nameaddon} : BaseAddon
	{   
		public override BaseAddonDeed Deed{ get { return new {namedeed}(); } }

		[ Constructable ]
		public {nameaddon}()
		{
{components}
{specialcomponents}
		}

		public {nameaddon}( Serial serial ) : base( serial )
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

	public class {namedeed} : BaseAddonDeed
	{
		public override BaseAddon Addon{ get { return new {nameaddon}(); } }

		[Constructable]
		public {namedeed}()
		{
		}

		public {namedeed}( Serial serial ) : base( serial )
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
}";
		#endregion

		#region Command
		public static void Initialize()
		{
			CommandSystem.Register("BlueAddonGen", AccessLevel.Administrator, new CommandEventHandler( AddonGen_Command ) );
		}

		[Description( "Brings up the addon script generator gump. When used with the name (and eventually namespace) parameter generates an addon script from the targeted region." )]
		private static void AddonGen_Command( CommandEventArgs e )
		{
			e.Mobile.SendGump( new BlueAddonGeneratorGump() );
		}
		#endregion

		#region Gump
		public class BlueAddonGeneratorGump : Gump
		{
			public BlueAddonGeneratorGump() : base( 25, 25 )
			{
				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;
				AddPage( 0 );
				AddBackground( 0, 0, 171, 100, 9270 );
				AddLabel( 15, 15, 1365, "Addon Generator" );
				AddLabel( 15, 40, 1150, "Name" );
				AddTextEntry( 55, 40, 100, 20, 0, 0/*ID*/, "PeoharenIsAwesome" );
				AddButton( 85, 65, 2714, 2715, 1/*ID*/, GumpButtonType.Reply, 0 );
				AddLabel( 15, 65, 1150, "Generate" );
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( info.ButtonID > 0 )
				{
					BoundingBoxPicker.Begin( sender.Mobile, new BoundingBoxCallback( BlueAddonGenerator.GenerateAddon ), info.TextEntries[0].Text );
				}
			}
		}
		#endregion

		#region Generator
		public static void GenerateAddon( Mobile from, Map map, Point3D start, Point3D end, object state )
		{
			if ( state == null || !(state is string) )
				return;

			Rectangle2D bounds = new Rectangle2D( start, end );
			StringBuilder components = new StringBuilder();
			StringBuilder specialcomponents = new StringBuilder();

			// Now with 33% more automation!
			List<Item> items = new List<Item>();
			int lowestX = 65555, lowestY = 65555;
			Item item = null;

			foreach( Item found in map.GetItemsInBounds( bounds ) )
			{
				if ( found != null )
					items.Add( found );
			}

			// Get X/Y for adjustment, not center it like normal addons. I like the positive only values for working with the file it's self.
			for ( int i = 0; i < items.Count; i++ )
			{
				if ( items[i].X < lowestX )
					lowestX = items[i].X;

				if ( items[i].Y < lowestY )
					lowestY = items[i].Y;
			}

			for ( int i = 0; i < items.Count; i++ )
			{
				item = items[i];

				if ( item is SleepingTreeAddon )
					specialcomponents.Append( @"
			Components.Add( new SleepingTreeAddon() );" );
				else if ( item is AddonComponentBarrier )
					specialcomponents.Append( @"
			Components.Add( new AddonComponentBarrier() );" );
				else if ( item is AddonComponentLever )
					specialcomponents.Append( @"
			Components.Add( new AddonComponentBarrier() );" );
				else if ( item is BaseDoor )
				{
					BaseDoor door = (BaseDoor)item;
					components.Append( String.Format( @"
			AddComponent( new DoorAddonComponent( new Point3D{0}, {1}, {2}, {3}, {4}, {5}, {6} ), {7}, {8}, {9} );", door.Offset, door.ClosedID, door.OpenedID, door.ClosedSound, door.OpenedSound, door.Locked.ToString().ToLower(), door.Hue, (item.X - start.X - lowestX), (item.Y - start.Y - lowestY), item.Z ) );
				}
				else
					components.Append( String.Format( @"
			AddComponent( new HuedAddonComponent( {0}, {1} ), {2}, {3}, {4} );", item.Hue, item.ItemID, (item.X - start.X), (item.Y - start.Y), item.Z ) );
			}

			components.Append( String.Format( @"
" ) );

			string file = String.Copy( Template );
			string name = (state as string);
			file = file.Replace( "{nameaddon}", (name + "Addon") );
			file = file.Replace( "{namedeed}", (name + "AddonDeed") );
			file = file.Replace( "{components}", components.ToString() );
			file = file.Replace( "{specialcomponents}", specialcomponents.ToString() );

			if ( !Directory.Exists( "Scripts.Workbench" ) )
				Directory.CreateDirectory( "Scripts.Workbench" );

			if ( !Directory.Exists( "Scripts.Workbench/Addons" ) )
				Directory.CreateDirectory( "Scripts.Workbench/Addons" );

			string filepath = "Scripts.Workbench/Addons/" + (state as string) + ".cs";

			if ( File.Exists( filepath ) )
				File.Delete( filepath );

			StreamWriter sw = new StreamWriter( filepath );
			sw.Write( file.ToString() );
			sw.Close();
		}
		#endregion

	}

	#region HuedAddonComponent
	public class HuedAddonComponent : AddonComponent
	{
		[Constructable]
		public HuedAddonComponent( int hue, int itemid ) : base( itemid )
		{
			Hue = hue;
		}

		public HuedAddonComponent( Serial serial ) : base( serial )
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
	#endregion

	#region Door
	public class DoorAddonComponent : AddonComponent
	{
		private Point3D m_ChangeBy;
		private int m_ClosedID;
		private int m_OpenedID;
		private int m_CloseSound;
		private int m_OpenSound;
		public bool m_Locked;
		public DoorAddonComponent Linked;
		private CloseTimer Timer;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Locked
		{
			get { return m_Locked; }
			set
			{
				m_Locked = value;

				if ( Linked != null )
					Linked.m_Locked = value;
			}
		}


		//public DoorAddonComponent( Direction d, int closedid, int openedid, int hue ) : this( GetOffset( d ), closedid, openedid, false, hue )
		//{
		//}

		public DoorAddonComponent( Point3D changeby, int closedid, int openedid, int closesound, int opensound, bool locked, int hue ) : base( closedid )
		{
			m_ChangeBy = changeby;
			m_ClosedID = closedid;
			m_OpenedID = openedid;
			m_CloseSound = closesound;
			m_OpenSound = opensound;
			m_Locked = locked;
			Hue = hue;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Locked )
			{
				if ( from.AccessLevel == AccessLevel.Player )
				{
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 502503 ); // That is locked.
					return;
				}

				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 502502 ); // That is locked, but you open it with your godly powers.
			}


			if ( ItemID == m_ClosedID )
				from.PlaySound( m_OpenSound );
			else
				from.PlaySound( m_CloseSound );

			OpenClose();

			if ( Linked != null )
				Linked.OpenClose();
		}

		public void OpenClose()
		{
			if ( ItemID == m_ClosedID )
			{
				ItemID = m_OpenedID;
				X += m_ChangeBy.X;
				Y += m_ChangeBy.Y;
				Z += m_ChangeBy.Z;

				if ( Timer != null )
					Timer.Stop();

				Timer = new CloseTimer( this );
				Timer.Start();
			}
			else
			{
				ItemID = m_ClosedID;
				X -= m_ChangeBy.X;
				Y -= m_ChangeBy.Y;
				Z -= m_ChangeBy.Z;

				if ( Timer != null )
					Timer.Stop();
			}
		}

		public override void OnLocationChange( Point3D old )
		{
		}


		/*
		private Point3D GetOffset( Direction d )
		{
			Point3D point;

			switch( d )
			{
				case Direction.North: point = new Point3D(  ); break;
				case Direction.Right: point = new Point3D(  ); break;
				case Direction.East: point = new Point3D(  ); break;
				case Direction.Down: point = new Point3D(  ); break;
				case Direction.South: point = new Point3D(  ); break;
				case Direction.Left: point = new Point3D(  ); break;
				case Direction.West: point = new Point3D(  ); break;
				case Direction.Up: point = new Point3D(  ); break;
				default: point = new Point3D(  ); break;
			}
			return point;
		}
		*/

		public DoorAddonComponent( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( m_ChangeBy );
			writer.Write( (int) m_ClosedID );
			writer.Write( (int) m_OpenedID );
			writer.Write( (int) m_CloseSound );
			writer.Write( (int) m_OpenSound);
			writer.Write( (bool) m_Locked );
			writer.Write( Linked );

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_ChangeBy = reader.ReadPoint3D();
			m_ClosedID = reader.ReadInt();
			m_OpenedID = reader.ReadInt();
			m_CloseSound = reader.ReadInt();
			m_OpenSound = reader.ReadInt();
			m_Locked = reader.ReadBool();
			Linked = (DoorAddonComponent)reader.ReadItem();
		}


		private class CloseTimer : Timer
		{
			private DoorAddonComponent m_Door;

			public CloseTimer( DoorAddonComponent door ) : base( TimeSpan.FromSeconds( 20.0 ) )
			{
				Priority = TimerPriority.OneSecond;
				m_Door = door;
			}

			protected override void OnTick()
			{
				if ( m_Door != null )
					m_Door.OpenClose();

				Stop();
			}
		}


	}
	#endregion

	#region AddonComponentBarrier
	public class AddonComponentBarrier : AddonComponent
	{
		[Constructable]
		public AddonComponentBarrier( bool eastwest ) : base( 10779 )
		{
			/*
			West/East Facing Door
				Closed: 10779
				Open: 10780
			North/South Facing Door
				Closed: 10773
				Open: 10774
			*/
			ItemID = eastwest ? 10779 : 10773;
		}

		public void Open()
		{
			if ( ItemID == 10779 )
				ItemID = 10780;
			else if ( ItemID == 10773 )
				ItemID = 10774;

			Effects.PlaySound( Location, Map, 0x539 );
		}

		public void Close()
		{
			if ( ItemID == 10780 )
				ItemID = 10779;
			else if ( ItemID == 10774 )
				ItemID = 10773;

			Effects.PlaySound( Location, Map, 0x539 );
		}

		public AddonComponentBarrier( Serial serial ) : base( serial )
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
	#endregion

	#region AddonComponentLever
	public class AddonComponentLever : AddonComponent
	{
		public AddonComponentBarrier Barrier;
		public int Delay;

		public AddonComponentLever( AddonComponentBarrier barrier, int delay ) : base( 4237 )
		{
			Barrier = barrier;
			Delay = delay;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this, 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( ItemID == 4238 )
				from.PublicOverheadMessage( MessageType.Regular, from.SpeechHue, false, "I must wait before flipping that again." );
			else if ( Barrier != null )
			{
				ItemID = 4238;
				Effects.PlaySound( Location, Map, 0x3E8 );
				Barrier.Open();
				new InternalTimer( this, Delay ).Start();
			}
		}

		public AddonComponentLever( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (Item) Barrier );
			writer.Write( (int) Delay );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Barrier = (AddonComponentBarrier)reader.ReadItem();
			Delay = reader.ReadInt();
			ItemID = 4238;
		}

		private class InternalTimer : Timer
		{
			AddonComponentLever m_Lever;

			public InternalTimer( AddonComponentLever lever, int delay ) : base( TimeSpan.FromSeconds( delay ) )
			{
				m_Lever = lever;
			}

			protected override void OnTick()
			{
				if ( m_Lever != null )
				{
					m_Lever.ItemID = 4237;
					Effects.PlaySound( m_Lever.Location, m_Lever.Map, 0x3E8 );

					if ( m_Lever.Barrier != null )
						m_Lever.Barrier.Close();
				}
			}
		}
	}
	#endregion



}