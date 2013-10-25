using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;
using Server.Engines.BulkOrders;
using Server.Commands;


namespace Server.ACC.CM
{
	[Flags]
	public enum MyPlayerFlag // First 16 bits are reserved for default-distro use, start custom flags at 0x00010000
	{
		None				= 0x00000000,
		UseMyOwnFilter		= 0x00000001
	}
	
	public class BODModule : Module
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GetBOD", AccessLevel.GameMaster, new CommandEventHandler( BODGump_OnCommand ) );
			CommandSystem.Register( "MyBOD", AccessLevel.Player, new CommandEventHandler( MyBOD_OnCommand ) );
		}
		
		public override string Name(){ return "BOD Module"; }
		
		private DateTime m_NextFletcherBulkOrder;
		private DateTime m_NextCarpenterBulkOrder;
		private MyPlayerFlag m_Flags;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool UseMyOwnFilter
		{
			get{ return GetMyFlag( MyPlayerFlag.UseMyOwnFilter ); }
			set{ SetMyFlag( MyPlayerFlag.UseMyOwnFilter, value ); }
		}
		
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextFletcherBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextFletcherBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextFletcherBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan NextCarpenterBulkOrder
		{
			get
			{
				TimeSpan ts = m_NextCarpenterBulkOrder - DateTime.Now;
				
				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;
				
				return ts;
			}
			set
			{
				try{ m_NextCarpenterBulkOrder = DateTime.Now + value; }
				catch{}
			}
		}
		
		
		public bool GetMyFlag( MyPlayerFlag flag )
		{
			return ( (m_Flags & flag) != 0 );
		}
		
		public void SetMyFlag( MyPlayerFlag flag, bool value )
		{
			if ( value )
				m_Flags |= flag;
			else
				m_Flags &= ~flag;
		}
		
		public BODModule( Serial serial ) : base( serial )
		{
			m_BOBFilter = new Engines.BulkOrders.BOBFilter();
		}
		
		private Engines.BulkOrders.BOBFilter m_BOBFilter;
		
		public Engines.BulkOrders.BOBFilter BOBFilter
		{
			get{ return m_BOBFilter; }
		}
		
		
		private static void BODGump_OnCommand( CommandEventArgs e )
		{
			BODModule BOD = ( BODModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( BODModule ) );
			
			e.Mobile.Target = new InternalTarget( BOD );
		}
		
		private static void MyBOD_OnCommand( CommandEventArgs e )
		{
			BODModule bod_mod = ( BODModule )CentralMemory.GetModule( e.Mobile.Serial, typeof( BODModule ) );
			
			if( bod_mod == null )
			{
				CentralMemory.AppendModule( e.Mobile.Serial, new BODModule( e.Mobile.Serial ), true );
				e.Mobile.SendMessage( "Please try again" );
			}
			else
			{
				//Next BOD times.
				
				e.Mobile.SendMessage( "Time til next carpenter BOD: {0}", bod_mod.m_NextCarpenterBulkOrder );
				e.Mobile.SendMessage( "Time til next fletcher BOD:  {0}", bod_mod.m_NextFletcherBulkOrder );
				return;
			}
		}
		
		public override void Append( Module mod, bool negatively )
		{
		}
		
		
		private class InternalTarget : Target
		{
			private BODModule bod_mod;
			
			public InternalTarget( BODModule mod ) : base( 1, false, TargetFlags.None )
			{
				bod_mod = mod;
			}
			
			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is PlayerMobile )
				{
					PlayerMobile pm = ( PlayerMobile )targeted;
					BODModule BOD = ( BODModule )CentralMemory.GetModule( pm.Serial, typeof( BODModule ) );
					
					if ( BOD != null )
						from.SendGump( new PropertiesGump( from, BOD ) );
					else
					{
						from.SendMessage( "This player does not have a module. A new one has been created." );
						CentralMemory.AppendModule( from.Serial, new BODModule( from.Serial ), true );
					}
				}
				else
					from.SendMessage("Can Only Target PLAYERS!");
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
			

			writer.Write( NextFletcherBulkOrder );
			writer.Write( NextCarpenterBulkOrder );
			m_BOBFilter.Serialize( writer );
			writer.Write( (int) m_Flags );	
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
		
			NextFletcherBulkOrder = reader.ReadTimeSpan();
			NextCarpenterBulkOrder = reader.ReadTimeSpan();
			m_BOBFilter = new Engines.BulkOrders.BOBFilter( reader );
			m_Flags = (MyPlayerFlag)reader.ReadInt();
			
			if ( m_BOBFilter == null )
				m_BOBFilter = new Engines.BulkOrders.BOBFilter();
			
			
		}
	}
}



