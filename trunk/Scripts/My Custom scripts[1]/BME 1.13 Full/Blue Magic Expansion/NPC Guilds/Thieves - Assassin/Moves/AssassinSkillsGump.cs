// Created by Peoharen
using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Gumps
{
	public class AssassinSkillsGump : Gump
	{
		public AssassinSkillsGump( Mobile m ) : base( 0, 0 )
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 300, 186, 9390 );
			AddLabel( 80, 7, 1193, "Assassin's   Skills" );


			AddLabel( 20, 30, 1193, "Assassinate" );
			AddButton( 145, 35, 11400, 11402, 1, GumpButtonType.Reply, 0 );
			AddLabel( 20, 55, 1193, "Armor Ignore" );
			AddButton( 145, 60, 11400, 11402, 2, GumpButtonType.Reply, 0 );
			AddLabel( 20, 80, 1193, "Bleed Attack" );
			AddButton( 145, 85, 11400, 11402, 3, GumpButtonType.Reply, 0 );
			AddLabel( 20, 105, 1193, "Mortal Strike" );
			AddButton( 145, 110, 11400, 11402, 4, GumpButtonType.Reply, 0 );
			AddLabel( 20, 130, 1193, "Shadow Strike" );
			AddButton( 145, 135, 11400, 11402, 5, GumpButtonType.Reply, 0 );

			AddLabel( 200, 35, 1193, "Move" );
			AddBackground( 190, 60, 60, 60, 9200 );

			WeaponAbility ability = WeaponAbility.GetCurrentAbility( m );

			if ( SpecialMove.GetContext( m, typeof( AssassinateMove ) ) )
				AddImage( 198, 68, 21284, 1193 );
			else if ( ability is ArmorIgnore )
				AddImage( 198, 68, 20992, 1193 );
			else if ( ability is BleedAttack )
				AddImage( 198, 68, 20993, 1193 );
			else if ( ability is MortalStrike )
				AddImage( 198, 68, 21000, 1193 );
			else if ( ability is ShadowStrike )
				AddImage( 198, 68, 21003, 1193 );
			else
				AddImage( 198, 68, 2279 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 0 )
				return;

			switch( info.ButtonID )
			{
				case 1: { SpecialMove.SetCurrentMove( sender.Mobile, new AssassinateMove() ); sender.Mobile.SendMessage( "You prepare to use Assassinate." ); break; }
				case 2: { WeaponAbility.SetCurrentAbility( sender.Mobile, new ArmorIgnore() ); sender.Mobile.SendMessage( "You prepare to use Armor Ignore." ); break; }
				case 3: { WeaponAbility.SetCurrentAbility( sender.Mobile, new BleedAttack() ); sender.Mobile.SendMessage( "You prepare to use Bleed Attack" ); break; }
				case 4: { WeaponAbility.SetCurrentAbility( sender.Mobile, new MortalStrike() ); sender.Mobile.SendMessage( "You prepare to use Mortal Strike" ); break; }
				case 5: { WeaponAbility.SetCurrentAbility( sender.Mobile, new ShadowStrike() ); sender.Mobile.SendMessage( "You prepare to use Shadow Strike" ); break; }
			}

			sender.Mobile.CloseGump( typeof( AssassinSkillsGump ) );
			sender.Mobile.SendGump( new AssassinSkillsGump( sender.Mobile ) );
		}
	}
}