using System;
using Server;
using Server.Network;
using Server.Mobiles;


namespace Server.Commands
{
	public class FlashCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "Flash1", AccessLevel.Seer, new CommandEventHandler( FlashOne_OnCommand ) );
			CommandSystem.Register( "Flash2", AccessLevel.Seer, new CommandEventHandler( FlashTwo_OnCommand ) );
			CommandSystem.Register( "Flash3", AccessLevel.Seer, new CommandEventHandler( FlashThree_OnCommand ) );
			CommandSystem.Register( "Flash4", AccessLevel.Seer, new CommandEventHandler( FlashFour_OnCommand ) );
			CommandSystem.Register( "Flash5", AccessLevel.Seer, new CommandEventHandler( FlashFive_OnCommand ) );
		}

		[Description( "" )]
		public static void FlashOne_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Send( new FlashEffect( FlashType.FadeOut ) );
		}

		[Description( "" )]
		public static void FlashTwo_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Send( new FlashEffect( FlashType.FadeIn ) );
		}

		[Description( "" )]
		public static void FlashThree_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Send( new FlashEffect( FlashType.LightFlash ) );
		}

		[Description( "" )]
		public static void FlashFour_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Send( new FlashEffect( FlashType.FadeInOut ) );
		}

		[Description( "" )]
		public static void FlashFive_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Send( new FlashEffect( FlashType.BlackFlash ) );
		}
	}
}

namespace Server
{
	public enum FlashType : byte
	{
		FadeOut,
		FadeIn,
		LightFlash,
		FadeInOut,
		BlackFlash
	}

	public sealed class FlashEffect : Packet
	{
		public FlashEffect( FlashType flashType ) : base( 0x70, 28 )
		{
			m_Stream.Write( (byte) 4 ); //effectType
			m_Stream.Write( (int) 0 ); //fromSerial
			m_Stream.Write( (int) 0 ); //toSerial
			m_Stream.Write( (ushort) flashType ); //in regular 0x70 ItemID is here
		
			m_Stream.Fill( 16 );

			/* all this properties below are not used in Flash
			m_Stream.Write( ( short )0 );//fromX
			m_Stream.Write( ( short )0 );//fromY
			m_Stream.Write( ( sbyte )0 );//fromZ
			m_Stream.Write( ( short )0 );//toX
			m_Stream.Write( ( short )0 );//toY
			m_Stream.Write( ( sbyte )0 );//toZ
			m_Stream.Write( ( byte )0 );//speed 
			m_Stream.Write( ( byte )0 );//duration
			m_Stream.Write( ( short )0 );
			m_Stream.Write( ( bool )0 );//fixeddirection
			m_Stream.Write( ( bool )0 );//explodes
			*/
		}
	}
}