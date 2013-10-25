//Created by Peoharen
using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class Mato : BaseCreature
	{
		private Mobile FocusOn;
		private DateTime m_StanceDelay;
		public int OnCombo;

		[Constructable]
		public Mato() : base( AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4 )
		{
			OnCombo = 0;

			Body = 400;
			Name = "Mato";
			Title = "the Master of Nine";

			SetStr( 125 ); // +25%
			SetDex( 125 );
			SetInt( 5000 );

			SetHits( 25000 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 20 );
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Poison, 20 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Hiding, 100.0 );
			SetSkill( SkillName.Stealth, 100.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Necromancy, 100.0 );
			SetSkill( SkillName.SpiritSpeak, 100.0 );
			SetSkill( SkillName.Bushido, 150.0 );
			SetSkill( SkillName.Parry, 150.0 );
			SetSkill( SkillName.Tactics, 80.0 ); // +50%
			SetSkill( SkillName.Wrestling, 80.0 ); // +16%
			// 25 + 50 + 16 = 91%
			// Weapon: 15~16 = 28.65~30.56

			Fame = 30000;
			Karma = -30000;

			VirtualArmor = 150;

			#region Equipment
			Ability.GiveItem( this, 0, new MonkFists() );
			#endregion
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosSuperBoss, 8 );
		}

		public override void OnDeath( Container c )
		{
			if ( c != null && Utility.RandomDouble() > 0.33 )
				c.DropItem( new MarkovsBardiche() );

			for ( int i = 0; i < 6; i++ )
				c.DropItem( new BlueDraconicRune( 1 ) );

			base.OnDeath( c );
		}

		#region MonkAI
		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is BaseCreature )
				damage *= 10;

			// little complex math here. 0 = nothing, 
			// 1 = air 1st hit, 2 = air 2nd hit, 3 = air 3rd hit, 4 = air combo.
			// and so on.
			if ( OnCombo == 0 )
				OnCombo = (Utility.Random( 6 ) * 4) + 1;

			// This system works fine for pure element combos.
			int oncombo = OnCombo / 4;

			if ( OnCombo % 4 == 0 ) // On Finisher
				OnCombo = 0;
			else
				++OnCombo;

			SpecialMove.SetCurrentMove( this, new MonkStrike( (MonkElement)oncombo ) );
			// TODO support mixed elements.
		}
		#endregion

		public override void OnActionCombat()
		{
			if ( DateTime.Now > m_StanceDelay )
			{
				m_StanceDelay = DateTime.Now + TimeSpan.FromSeconds( 30 );
			}

			base.OnActionCombat();
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public Mato( Serial serial ) : base( serial )
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

// Roll a 2
// Times four for 8.
// Add one for 1.
/*
0: nothing
1: Air 1
2: Air 2
3: Air 3
4: Air Combo
5: Earth 1
6: Earth 2
7: Earth 3
8: Earth Combo
9: Fire 1
10: Fire 2
11: Fire 3
12: Fire Combo
13: Water 1
14: Water 2
15: Water 3
16: Water Combo
17: Light 1
18: Light 2
19: Light 3
20: Light Combo
21: Dark 1
22: Dark 2
23: Dark 3
24: Dark Combo
25: Void 1
26: Void 2
27: Void 3
28: Void Combo
29: Light/Air 1
30: Light/Air 2
31: Light/Air 3
32: Light/Air Combo
33: Light/Earth 1
34: Light/Earth 2
35: Light/Earth 3
36: Light/Earth Combo
37: Light/Fire 1
38: Light/Fire 2
39: Light/Fire 3
40: Light/Fire Combo
41: Light/Water 1
42: Light/Water 2
43: Light/Water 3
44: Light/Water Combo
45: Light/Void 1
46: Light/Void 2
47: Light/Void 3
48: Light/Void Combo
49: Dark/Air 1
50: Dark/Air 2
51: Dark/Air 3
52: Dark/Air Combo
53: Dark/Earth 1
54: Dark/Earth 2
55: Dark/Earth 3
56: Dark/Earth Combo
57: Dark/Fire 1
58: Dark/Fire 2
59: Dark/Fire 3
50: Dark/Fire Combo
61: Dark/Water 1
62: Dark/Water 2
63: Dark/Water 3
64: Dark/Water Combo
65: Dark/Void 1
66: Dark/Void 2
67: Dark/Void 3
68: Dark/Void 4
69: Dark/Void 5
*/

