using System;
using Server;

namespace Server.Items
{
	public class SpawnerRobe : BaseSuit
	{
		[Constructable]
		public SpawnerRobe() : base( AccessLevel.GameMaster, 0x8A5, 0x204F )
		{
			Name = "Spawner Robe";
		}

		public override bool OnEquip( Mobile from )
		{
			if ( ItemID == 0x204F )
			{
				from.Title = "[Spawner]";
				from.DisplayGuildTitle = false;
			}

			Container mobilePack = from.Backpack;

			Item bracelet = from.FindItemOnLayer( Layer.Bracelet );

			if ( bracelet != null )
			{
				mobilePack.DropItem( bracelet );
			}

			GoldBracelet brace = new GoldBracelet();
  			brace.Movable = false;
			brace.Attributes.LowerManaCost = 100;
			brace.Attributes.LowerRegCost = 100;
			brace.Attributes.RegenHits = 100;
			brace.Attributes.RegenStam = 100;
			brace.Attributes.RegenMana = 100;
			brace.Attributes.SpellDamage = 100;
			brace.Attributes.CastRecovery = 12;
			brace.Attributes.CastSpeed = 12;
			from.EquipItem( brace );

			return base.OnEquip( from );
		}

		public override void OnRemoved( Object o )
		{
			if( o is Mobile )
			{
				((Mobile)o).Title = null;
			}

			if( o is Mobile && ((Mobile)o).GuildTitle != null )
			{
				((Mobile)o).DisplayGuildTitle = true;
			}
		}

		public override bool OnDragLift( Mobile from )
		{
			Item bracelet = from.FindItemOnLayer( Layer.Bracelet );

			if ( bracelet != null && bracelet.Movable==false )
			{
				bracelet.Delete();
			}

			return true;
		}

		public override void OnDoubleClick( Mobile m )
		{
			if ( !m.Hidden == true )
			{
				m.Hidden = true;

				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 13 );

				m.PlaySound( 0x228 );
			}
			else
			{
				m.Hidden = false;

				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 13 );

				m.PlaySound( 0x228 );
			} 
		}

		public SpawnerRobe( Serial serial ) : base( serial )
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