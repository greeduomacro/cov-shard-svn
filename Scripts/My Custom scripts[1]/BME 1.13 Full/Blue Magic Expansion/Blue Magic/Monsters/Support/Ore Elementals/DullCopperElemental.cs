// Created by Peoharen
using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ore elemental corpse" )]
	public class BlueDullCopperElemental : DullCopperElemental
	{
		[Constructable]
		public BlueDullCopperElemental() : this( 10 )
		{
		}

		[Constructable]
		public BlueDullCopperElemental( int oreamount ) : base( oreamount )
		{
		}

		public override void OnDeath( Container c )
		{
			Ability.Aura( this, HitsMaxSeed / 12, HitsMaxSeed / 10, ResistanceType.Fire, 3, null, "The elemental explodes!" );
			base.OnDeath( c );
		}

		public BlueDullCopperElemental( Serial serial ) : base( serial )
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