// Created by Peoharen
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class FocusGem : Item
	{
		private DateTime m_NextUse;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime LastUse
		{
			get { return m_NextUse; }
			set { m_NextUse = value; }
		}

		[Constructable]
		public FocusGem() : base( 0x1368 ) // 0x0DEC Tomato Plant Stage 1
		{
			Name = "Focus Gem";
			Hue = 1194;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this, 1 ) )
				from.SendLocalizedMessage( 500446 ); // That is too far away.
			else if ( !IsAccessibleTo( from ) )
				from.SendLocalizedMessage( 500447 ); // That is not accessible.
			else if ( DateTime.Now < m_NextUse )
			{
				TimeSpan delay = DateTime.Now - m_NextUse;
				from.SendLocalizedMessage( 1074882, "\t" + delay.TotalSeconds.ToString() ); // You must wait ~1_val~ seconds for this to recharge.
			}
			else if ( from is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)from;

				if ( pm.NpcGuild != NpcGuild.MagesGuild && pm.AccessLevel == AccessLevel.Player )
					pm.SendMessage( "You must be in the Mage's Guild in order to use this." );
				else if ( !pm.Spellweaving )
					pm.SendLocalizedMessage( 1073220 ); // You must have completed the epic arcanist quest to use this ability.
				else if ( pm.Skills[SkillName.Spellweaving].Value < 50 )
					pm.SendMessage( "You must have at least 50.0 in Spellweaving in order to use this." );
				else if ( pm.Backpack == null )
					pm.SendMessage( "You need a backpack in order to use this." );
				else
				{
					ArcaneFocus focus = Server.Spells.Spellweaving.ArcanistSpell.FindArcaneFocus( pm );
					int bonus = (int)(pm.Skills[SkillName.Spellweaving].Value / 24);

					if ( focus != null && focus.StrengthBonus > bonus )
					{
						pm.SendMessage( "Your current focus is better than the one this will provide." );
						return;
					}

					focus = new ArcaneFocus( TimeSpan.FromHours( bonus ), bonus );
					pm.Backpack.DropItem( focus );

					if ( pm.AccessLevel == AccessLevel.Player )
					{
						m_NextUse = DateTime.Now + TimeSpan.FromHours( 6 );
						pm.SendMessage( "A focus has been created and dropped into your pack, you may use this gem again in 6 hours." );
					}
					else
					{
						focus.StrengthBonus = 6;
						pm.SendMessage( "A focus has been created and dropped into your pack, as staff you have not set the delay on this item." );
					}
				}
			}
		}

		public FocusGem( Serial serial ) : base( serial )
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