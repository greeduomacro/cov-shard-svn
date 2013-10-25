// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class PowerAttackGump : Gump
	{
		private BaseWeapon Weapon;

		public PowerAttackGump( BaseWeapon weapon ) : base( 50, 50 )
		{
			Weapon = weapon;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 115, 175, 9270 );
			AddLabel( 15, 15, 1193, "Power Attack");

			if ( Weapon != null )
			{
				AddLabel( 35, 45, 1193, "0%" );

				if ( Weapon.Attributes.WeaponDamage == 0 )
					AddButton( 65, 45, 209, 209, 1, GumpButtonType.Reply, 0 );
				else
					AddButton( 65, 45, 208, 209, 1, GumpButtonType.Reply, 0 );

				AddLabel( 25, 75, 1193, "20%" );

				if ( Weapon.Attributes.WeaponDamage == 20 )
					AddButton( 65, 75, 209, 209, 20, GumpButtonType.Reply, 0 );
				else
					AddButton( 65, 75, 208, 209, 20, GumpButtonType.Reply, 0 );

				AddLabel( 25, 105, 1193, "50%" );

				if ( Weapon.Attributes.WeaponDamage == 50 )
					AddButton( 65, 105, 209, 209, 50, GumpButtonType.Reply, 0 );
				else
					AddButton( 65, 105, 208, 209, 50, GumpButtonType.Reply, 0 );

				AddLabel( 25, 135, 1193, "75%" );

				if ( Weapon.Attributes.WeaponDamage == 75 )
					AddButton( 65, 135, 209, 209, 75, GumpButtonType.Reply, 0 );
				else
					AddButton( 65, 135, 208, 209, 75, GumpButtonType.Reply, 0 );
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( Weapon == null || info.ButtonID == 0 )
				return;

			switch( info.ButtonID )
			{
				case 1: Weapon.Attributes.WeaponDamage = 0; Weapon.Attributes.AttackChance = 0; break;
				case 20: Weapon.Attributes.WeaponDamage = 20; Weapon.Attributes.AttackChance = -10; break;
				case 50: Weapon.Attributes.WeaponDamage = 50; Weapon.Attributes.AttackChance = -25; break;
				case 75: Weapon.Attributes.WeaponDamage = 75; Weapon.Attributes.AttackChance = -37; break;
			}
		}

	}
}