using System;
using Server;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Items
{
	public class QuinaTele : Item
	{
		[Constructable]
		public QuinaTele() : base( 14186 )
		{
			Hue = 1365;
			Movable = false;
		}

		public QuinaTele( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				PlayerMobile player = (PlayerMobile)m;

				if ( QuestHelper.GetQuest( player, typeof( FindingQuinaQuest ) ) != null )
				{
					player.MoveToWorld( new Point3D( 1576, 849, -25 ), Map.Ilshenar );
					player.PlaySound( 0x20E );

				}
				else
					player.SendMessage( "You may not enter this." );
			}

			return false;
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