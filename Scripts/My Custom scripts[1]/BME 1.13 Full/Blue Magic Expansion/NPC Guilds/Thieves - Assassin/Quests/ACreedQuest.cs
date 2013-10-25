// Created by Peoharen
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public abstract class ACreedQuest : BaseQuest
	{
		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromDays( 7 ); } }
		public virtual bool FailIfKillNPC{ get{ return false; } }
		public virtual bool FailIfNoticed{ get { return false; } }

		public ACreedQuest() : base()
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