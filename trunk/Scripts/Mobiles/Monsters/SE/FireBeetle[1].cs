using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Gumps;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using System.Reflection;
using Server.Mobiles;
using Server.Commands;

namespace Server.Mobiles
{
	[CorpseName( "a fire beetle corpse" )]
	public class FireBeetle : Beetle
	{

		[Constructable]
		public FireBeetle() : base("a fire beetle")
		{
			Hue = 1260;

			SetDamageType( ResistanceType.Physical, 0);
            SetDamageType( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 70, 75 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 90.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

            Tamable = true;
            ControlSlots = 2;

		}

                public FireBeetle(Serial serial) : base( serial )
                {

		}

		#region Pack Animal Methods

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( PackAnimal.CheckAccess( this, from ) )
			{
				if(item is BaseOre)
				{
					BaseOre m_Ore = item as BaseOre;

					int toConsume = m_Ore.Amount;

					if ( toConsume > 30000 )
					{
						toConsume = 30000;
					}
					else if ( m_Ore.Amount < 2 )
					{
						from.SendLocalizedMessage( 501989 ); // You burn away the impurities but are left with no useable metal.
						m_Ore.Delete();
						return true;
					}

					BaseIngot ingot = m_Ore.GetIngot();
					ingot.Amount = toConsume * 2;

					m_Ore.Consume( toConsume );

					from.PlaySound( 0x57 );
					
					AddToBackpack( ingot );
					return true;
				}
			}

			return base.OnDragDrop( from, item );
		}

		#endregion

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