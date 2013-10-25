// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class StealFromCreature : BaseCreature
	{
		public StealFromCreature( AIType aitype, FightMode fightmode, int spot, int meleerange, double passivespeed, double activespeed ) : base( aitype, fightmode, spot, meleerange, passivespeed, activespeed )
		{
		}

		public override void OnKilledBy( Mobile mob )
		{
			if ( Backpack != null )
			{
				List<Item> items = Backpack.FindItemsByType<Item>();

				for( int i = items.Count - 1; i > -1; i-- )
				{
					if ( items[i] == null || items[i] is Gold )
						continue;

					items[i].Delete();
				}
			}

			base.OnKilledBy( mob );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public StealFromCreature( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}