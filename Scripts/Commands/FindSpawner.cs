using System;
using Server;
using Server.Targeting;

namespace Server.Commands
{
	public class FindSpawner
	{
		public static void Initialize()
		{
			CommandSystem.Register( "FindSpawner", AccessLevel.GameMaster, new CommandEventHandler( FindSpawner_OnCommand ) );
		}

		public static void FindSpawner_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;

            if ( null != from )
                from.Target = new FindSpawnerTarget();
		}

		private class FindSpawnerTarget : Target
		{
			public FindSpawnerTarget() : base( -1, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
                ISpawner spawner = null;

                if ( targeted is Item )
                    spawner = ((Item)targeted).Spawner;
                else if ( targeted is Mobile )
                    spawner = ((Mobile)targeted).Spawner;

                if ( null == spawner || !(spawner is IEntity) )
                    from.SendMessage( 33, @"That is not a spawned entity" );
                else
                {
                    from.Map = ((IEntity)spawner).Map;
                    from.Location = ((IEntity)spawner).Location;
                }
			}
		}
    }
}