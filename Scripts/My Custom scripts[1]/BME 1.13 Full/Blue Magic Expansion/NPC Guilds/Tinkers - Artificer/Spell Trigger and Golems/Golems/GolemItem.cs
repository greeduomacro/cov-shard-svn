// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public enum GolemType
	{
		Blood,
		Clay,
		Iron,
		Fire
	}

	public class GolemItem : BaseUniqueItem
	{
		private GolemType m_Golem;

		public GolemType Golem
		{
			get { return m_Golem; }
			set { m_Golem = value; }
		}

		[Constructable]
		public GolemItem() : this( GolemType.Iron )
		{
		}

		[Constructable]
		public GolemItem( GolemType gt ) : base( 0x1F1C )
		{
			m_Golem = gt;

			switch ( m_Golem )
			{
				case GolemType.Blood:
				{
					Hue = 1157;
					ItemID = 9764;
					Name = "a blood golem";
					break;
				}
				case GolemType.Clay:
				{
					Hue = 1192;
					ItemID = 9763;
					Name = "a clay golem";
					break;
				}
				case GolemType.Iron:
				{
					Hue = 1102;
					ItemID = 9724;
					Name = "an iron golem";
					break;
				}
				case GolemType.Fire:
				{
					Hue = 1161;
					ItemID = 10089;
					Name = "a fire golem";
					break;
				}
			}

			Weight = 10.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Container pack = from.Backpack;

			if ( !(pack != null && Parent == pack) )
			{
				from.SendLocalizedMessage( 1080058 ); // This must be in your backpack to use it.
				return;
			}
			else if ( !(from is PlayerMobile) )
				return;

			List<Mobile> pets = ((PlayerMobile)from).AllFollowers;
			bool cansummon = true;

			for ( int i = 0; i < pets.Count; i++ )
			{
				if ( pets[i] is BloodGolem || pets[i] is ClayGolem || pets[i] is IronGolem || pets[i] is FireGolem )
				{
					cansummon = false;
					break;
				}
			}

			if ( !cansummon )
			{
				from.SendMessage( "You can only summon one golem at any given time." );
				return;
			}

			BaseCreature bc = null;

			switch ( m_Golem )
			{
				case GolemType.Blood: bc = new BloodGolem(); break;
				case GolemType.Clay: bc = new ClayGolem(); break;
				case GolemType.Iron: { from.Target = new InternalTarget( this ); } break;
				case GolemType.Fire: bc = new FireGolem(); break;
			}

			if ( bc != null )
			{
				bc.SetControlMaster( from );
				from.SendMessage( 1192, "You summon the golem." );
				bc.MoveToWorld( new Point3D( from.X + Utility.RandomMinMax( -1, 1 ), from.Y + Utility.RandomMinMax( -1, 1 ), from.Z ), from.Map );
				Delete();
			}
		}

		public GolemItem( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( (int) m_Golem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Golem = (GolemType)reader.ReadInt();
		}

		private class InternalTarget : Target
		{
			private GolemItem m_GolemItem;

			public InternalTarget( GolemItem gi ) : base( 1, false, TargetFlags.None )
			{
				m_GolemItem = gi;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is BaseArmor )
				{
					BaseArmor armor = (BaseArmor)o;

					if ( armor.RootParent != from )
					{
						from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
						return;
					}

					BaseCreature bc = new IronGolem();
					bc.Race = armor.RequiredRace;
					bc.Body = 766;
					bc.Hue = CraftResources.GetHue( armor.Resource ) == 0 ? 1102 : armor.Hue;
					bc.EquipItem( armor );

					bc.SetControlMaster( from );
					from.SendMessage( 1192, "You summon the golem." );
					bc.MoveToWorld( new Point3D( from.X + Utility.RandomMinMax( -1, 1 ), from.Y + Utility.RandomMinMax( -1, 1 ), from.Z ), from.Map );
					m_GolemItem.Delete();
				}
				else if ( o is BaseWeapon )
				{
					BaseWeapon weapon = (BaseWeapon)o;

					if ( weapon.RootParent != from )
					{
						from.SendLocalizedMessage( 1045158 ); // You must have the item in your backpack to target it.
						return;
					}

					BaseCreature bc = new IronGolem();
					bc.Race = weapon.RequiredRace;
					bc.Body = 766;
					bc.Hue = CraftResources.GetHue( weapon.Resource ) == 0 ? 1102 : weapon.Hue;
					bc.EquipItem( weapon );

					bc.SetControlMaster( from );
					from.SendMessage( 1192, "You summon the golem." );
					bc.MoveToWorld( new Point3D( from.X + Utility.RandomMinMax( -1, 1 ), from.Y + Utility.RandomMinMax( -1, 1 ), from.Z ), from.Map );
					m_GolemItem.Delete();
				}
				else
					from.SendLocalizedMessage( 1046439 ); // This is not a valid target.
			}
		}

	}
}