using System;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Fur : Item, IDyable
	{
		[Constructable]
		public Fur() : this( 1 )
		{
		}

		[Constructable]
		public Fur( int amount ) : base( 0x1875 )
		{
            Name = "Boura fur";
			Stackable = true;
            Hue = 553;
			Weight = 4.0;
			Amount = amount;
		}

		public Fur( Serial serial ) : base( serial )
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
		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 502655 ); // What spinning wheel do you wish to spin this on?
				from.Target = new PickWheelTarget( this );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public static void OnSpun( ISpinningWheel wheel, Mobile from, int hue )
		{
			Item item = new DarkYarn( 3 );
			item.Hue = hue;

			from.AddToBackpack( item );
			from.SendLocalizedMessage( 1010576 ); // You put the balls of yarn in your backpack.
		}

		private class PickWheelTarget : Target
		{
			private Fur m_Fur;

			public PickWheelTarget( Fur fur ) : base( 3, false, TargetFlags.None )
			{
				m_Fur = fur;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Fur.Deleted )
					return;

				ISpinningWheel wheel = targeted as ISpinningWheel;

				if ( wheel == null && targeted is AddonComponent )
					wheel = ((AddonComponent)targeted).Addon as ISpinningWheel;

				if ( wheel is Item )
				{
					Item item = (Item)wheel;

					if ( !m_Fur.IsChildOf( from.Backpack ) )
					{
						from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
					}
					else if ( wheel.Spinning )
					{
						from.SendLocalizedMessage( 502656 ); // That spinning wheel is being used.
					}
					else
					{
						m_Fur.Consume();
						wheel.BeginSpin( new SpinCallback( Fur.OnSpun ), from, m_Fur.Hue );
					}
				}
				else
				{
					from.SendLocalizedMessage( 502658 ); // Use that on a spinning wheel.
				}
			}
		}
	}
}