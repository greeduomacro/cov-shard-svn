/*
Special thanks to Ryan.
With RunUO we now have the ability to become our own Richard Garriott.
Carpenter Building System created by Lucid Nagual & MODed from Daat99's OWLTR system.
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2005 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       \_    Carp/Fletcher BODs &     ~\
       )   Carpenter Building System   )
      /~   Version [1].0.0 & Above   _/
     /                              _/
   _/_______________________________/
 -=(_)______________________________)=-
 */
using System;
using Server;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class LumberjackAxe : BaseAxe
	{
		
		public override HarvestSystem HarvestSystem{ get{ return Lumberjacking.System; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override int AosSpeed{ get{ return 37; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 37; } }

				
		[Constructable]
		public LumberjackAxe() : this( 100 )
		{
		}

		[Constructable]
		public LumberjackAxe( int uses ) : base( 0xF49 )
		{
                        Name = "a lumberjacks axe";
			Weight = 11.0;
			Hue = 0x973;
			UsesRemaining = uses;
			ShowUsesRemaining = true;
		}

		public LumberjackAxe( Serial serial ) : base( serial )
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