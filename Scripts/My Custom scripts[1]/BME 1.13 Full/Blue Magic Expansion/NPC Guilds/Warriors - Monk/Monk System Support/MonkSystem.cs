// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
	public enum MonkElement
	{
		None = 0x0,
		Air,
		Earth,
		Fire,
		Water,
		Light,
		Dark,
		Void, 
		AirCombo,				// The Gathering Storm: Target takes a -2 on attack rolls for 30 seconds. A successful Fortitude save ends this effect. Undead are immune. 
		EarthCombo,				// The Trembling Earth: The force of the earth is behind your attacks, increasing your critical attack multiplyer by 2 and partially bewildering your foe, preventing them from casting spells. A successfull Fortitude ends this effect. Lasts 30 seconds.
		FireCombo,				// Breath of the Fire Dragon: A cone of searing flame shoots forth, damaging the targets in the area of the flames for 1d6 (1 to 6) damage each monk level. A successful Reflex save reduces the damage by half.
		WaterCombo,				// The Raging Sea: This attack slows your enemies attacks. A successful Fortitude ends this effect. Lasts for 30 seconds.
		LightCombo,				// Healing Ki: Activate to heal all nearby allies for 1d4 (1 to 4), plus an additional 1d4 (1 to 4) for every two monk levels. (Does not harm undead)
		DarkCombo,				// Touch of Despair: This strike causes and enemy to take half healing from positive energy, reduces fortification by 25%, and causes the opponent to take 25% more damage from negative energy for 60 seconds. A successful Fortitude save negates this effect.
		VoidCombo,				// ?
		LightAirCombo,			// Dance of Clouds: Activate to grant all nearby allies 20% concealment for 60 seconds.
		LightEarthCombo,		// Grasp the Earth Dragon: Activate to grant all nearby allies become immunity to daze, stun, and sleep for 30 seconds.
		LightFireCombo,			// Walk of the Sun: Activate to grant nearby allies gain a +2 morale bonus to attack, saves, and skills for 60 seconds.
		LightWaterCombo,		// Aligning the Heavens: Activate to reduce the spell point costs of all nearby allies by a 25% for 60 Seconds.
		LightVoidCombo,			// Moment of Clarity: Activate this to grant your allies a +5 Insight bonus to hit and to skill checks for a very short period of time.
		DarkAirCombo,			// Falling Star Strike: Target is blinded for 60 seconds. Periodic fortitude saves to negate.
		DarkEarthCombo,			// Pain Touch: Target is nauseated for 60 seconds. Periodic fortitude saves to negate.
		DarkFireCombo,			// Karmic Strike: The attack is automatically a critical threat, but then next strike on you for 3 seconds will also be a critical. Unknown if Fortification applies. Apparently it is broken.
		DarkWaterCombo,			// Freezing The Lifeblood: Your attack paralyzes a humanoid and making them helpless for 60 seconds. A successful fortitude save negates this effect. This target periodically makes a save to attempt to break free of this effect.
		DarkVoidCombo,			// Curse of the Void: You can make an attack that charms your opponent for a short period of time. A successful Will save negates this effect. Each time the target takes damage there is a chance that they will break free of this effect.
		ElementCombo,			// Shining Star: You use the combined power of Earth, Wind, and Fire to force your enemy to dance. A successful Will save negates this effect. (DC 10 + Monk Level + Charisma mod)
		LightSpecialOne,		// Restoring the Balance: Works like Remove Curse.
		LightSpecialTwo,		// Rise of the Phoenix: Works like Raise Dead.
		DarkSpecialOne,			// Touch of Death: Massive damage.
		DarkSpecialTwo			// Winter's Touch: -25 ColdResistSeed, works on untamed creatures, permanent.
	}

	public sealed class MonkElements
	{
		public MonkElement First;
		public MonkElement Second;
		public MonkElement Third;

		public MonkElements()
		{
			First = MonkElement.None;
			Second = MonkElement.None;
			Third = MonkElement.None;
		}
	}

	public class MonkSystem
	{
		public static Dictionary<Mobile, MonkElements> ComboChain = new Dictionary<Mobile, MonkElements>();

		public static bool IsMonk( Mobile m )
		{
			if ( m is BaseCreature )
				return true;
			else
				return (m.FindItemOnLayer( Layer.Gloves ) is MonkFists);
		}

		public static void AddHit( Mobile m, MonkElement element )
		{
			if ( m is BaseCreature )
				return;

			if ( element == MonkElement.LightSpecialOne ||
				element == MonkElement.LightSpecialTwo ||
				element == MonkElement.DarkSpecialOne ||
				element == MonkElement.DarkSpecialTwo )
					return;

			if ( !ComboChain.ContainsKey( m ) )
				ComboChain.Add( m, new MonkElements() );

			if ( (int)element < 1 || (int)element > 6 )
			{
				ComboChain[m].First = MonkElement.None;
				ComboChain[m].Second = MonkElement.None;
				ComboChain[m].Third = MonkElement.None;
			}
			else if ( ComboChain[m].First == MonkElement.None )
				ComboChain[m].First = element;
			else if ( ComboChain[m].Second == MonkElement.None )
				ComboChain[m].Second = element;
			else if ( ComboChain[m].Third == MonkElement.None )
				ComboChain[m].Third = element;
			else
			{
				ComboChain[m].First = element;
				ComboChain[m].Second = MonkElement.None;
				ComboChain[m].Third = MonkElement.None;
			}
		}

		public static MonkElement GetCombo( Mobile m )
		{
			// No Mobile
			if ( !ComboChain.ContainsKey( m ) )
				return MonkElement.None;

			// No Combo
			else if ( ComboChain[m].First == MonkElement.None || ComboChain[m].Second == MonkElement.None || ComboChain[m].Third == MonkElement.None )
				return MonkElement.None;

			// Air Combos
			else if ( ComboChain[m].First == MonkElement.Air )
			{
				if ( ComboChain[m].Second == MonkElement.Air && ComboChain[m].Third == MonkElement.Air )
					return MonkElement.AirCombo;
				else if ( ComboChain[m].Second == MonkElement.Light && ComboChain[m].Third == MonkElement.Air )
					return MonkElement.LightAirCombo;
				else if ( ComboChain[m].Second == MonkElement.Air && ComboChain[m].Third == MonkElement.Light )
					return MonkElement.LightAirCombo;
				else if ( ComboChain[m].Second == MonkElement.Dark && ComboChain[m].Third == MonkElement.Air )
					return MonkElement.DarkAirCombo;
				else if ( ComboChain[m].Second == MonkElement.Air && ComboChain[m].Third == MonkElement.Dark )
					return MonkElement.DarkAirCombo;
			}

			// Earth Combos
			else if ( ComboChain[m].First == MonkElement.Earth )
			{
				if ( ComboChain[m].Second == MonkElement.Earth && ComboChain[m].Third == MonkElement.Earth )
					return MonkElement.EarthCombo;
				else if ( ComboChain[m].Second == MonkElement.Light && ComboChain[m].Third == MonkElement.Earth )
					return MonkElement.LightEarthCombo;
				else if ( ComboChain[m].Second == MonkElement.Earth && ComboChain[m].Third == MonkElement.Light )
					return MonkElement.LightEarthCombo;
				else if ( ComboChain[m].Second == MonkElement.Dark && ComboChain[m].Third == MonkElement.Earth )
					return MonkElement.DarkEarthCombo;
				else if ( ComboChain[m].Second == MonkElement.Earth && ComboChain[m].Third == MonkElement.Dark )
					return MonkElement.DarkEarthCombo;
			}

			// Fire Combos
			else if ( ComboChain[m].First == MonkElement.Fire )
			{
				if ( ComboChain[m].Second == MonkElement.Fire && ComboChain[m].Third == MonkElement.Fire )
					return MonkElement.FireCombo;
				else if ( ComboChain[m].Second == MonkElement.Light && ComboChain[m].Third == MonkElement.Fire )
					return MonkElement.LightFireCombo;
				else if ( ComboChain[m].Second == MonkElement.Fire && ComboChain[m].Third == MonkElement.Light )
					return MonkElement.LightFireCombo;
				else if ( ComboChain[m].Second == MonkElement.Dark && ComboChain[m].Third == MonkElement.Fire )
					return MonkElement.DarkFireCombo;
				else if ( ComboChain[m].Second == MonkElement.Fire && ComboChain[m].Third == MonkElement.Dark )
					return MonkElement.DarkFireCombo;
			}

			// Water Combos
			else if ( ComboChain[m].First == MonkElement.Water )
			{
				if ( ComboChain[m].Second == MonkElement.Water && ComboChain[m].Third == MonkElement.Water )
					return MonkElement.WaterCombo;
				else if ( ComboChain[m].Second == MonkElement.Light && ComboChain[m].Third == MonkElement.Water )
					return MonkElement.LightWaterCombo;
				else if ( ComboChain[m].Second == MonkElement.Water && ComboChain[m].Third == MonkElement.Light )
					return MonkElement.LightWaterCombo;
				else if ( ComboChain[m].Second == MonkElement.Dark && ComboChain[m].Third == MonkElement.Water )
					return MonkElement.DarkWaterCombo;
				else if ( ComboChain[m].Second == MonkElement.Water && ComboChain[m].Third == MonkElement.Dark )
					return MonkElement.DarkWaterCombo;
			}

			// Light Combos
			else if ( ComboChain[m].First == MonkElement.Light )
			{
				if ( ComboChain[m].Second == MonkElement.Light && ComboChain[m].Third == MonkElement.Light )
					return MonkElement.LightCombo;
				else if ( ComboChain[m].Second == MonkElement.Air && ComboChain[m].Third == MonkElement.Air )
					return MonkElement.LightAirCombo;
				else if ( ComboChain[m].Second == MonkElement.Earth && ComboChain[m].Third == MonkElement.Earth )
					return MonkElement.LightEarthCombo;
				else if ( ComboChain[m].Second == MonkElement.Fire && ComboChain[m].Third == MonkElement.Fire )
					return MonkElement.LightFireCombo;
				else if ( ComboChain[m].Second == MonkElement.Water && ComboChain[m].Third == MonkElement.Water )
					return MonkElement.LightWaterCombo;
			}

			// Dark Combos
			else if ( ComboChain[m].First == MonkElement.Dark )
			{
				if ( ComboChain[m].Second == MonkElement.Dark && ComboChain[m].Third == MonkElement.Dark )
					return MonkElement.DarkCombo;
				else if ( ComboChain[m].Second == MonkElement.Air && ComboChain[m].Third == MonkElement.Air )
					return MonkElement.DarkAirCombo;
				else if ( ComboChain[m].Second == MonkElement.Earth && ComboChain[m].Third == MonkElement.Earth )
					return MonkElement.DarkEarthCombo;
				else if ( ComboChain[m].Second == MonkElement.Fire && ComboChain[m].Third == MonkElement.Fire )
					return MonkElement.DarkFireCombo;
				else if ( ComboChain[m].Second == MonkElement.Water && ComboChain[m].Third == MonkElement.Water )
					return MonkElement.DarkWaterCombo;
			}

			return MonkElement.None;
		}
	}
}


	/*
	// Pure MonkElement Combo
	if ( 
		ComboChain[m].First == ComboChain[m].Second && 
		ComboChain[m].First == ComboChain[m].Third )
		return (MonkElement)( (int)ComboChain[m].First & 0x10 );

	// Light MonkElement Combo
	else if ( ComboChain[m].First == MonkElement.Light )
	{
		if ( 
			ComboChain[m].Second != MonkElement.Light && 
			ComboChain[m].Second != MonkElement.Dark && 
			ComboChain[m].Third == ComboChain[m].Second 
		)
			return (MonkElement)( (int)ComboChain[m].Second & 0x20 );
	}

	// Dark MonkElement Combo
	else if ( ComboChain[m].First == MonkElement.Dark )
	{
		if ( ComboChain[m].Second != MonkElement.Light && 
			ComboChain[m].Second != MonkElement.Dark && 
			ComboChain[m].Third == ComboChain[m].Second 
		)
			return (MonkElement)((int)ComboChain[m].Second & 0x40);
	}

	// MultiMonkElement Combo
	else if ( ComboChain[m].Second != MonkElement.Light && ComboChain[m].Second != MonkElement.Dark && ComboChain[m].Third != MonkElement.Light && ComboChain[m].Third != MonkElement.Dark )
	{
		if ( ComboChain[m].First != ComboChain[m].Second && ComboChain[m].First != ComboChain[m].Third && ComboChain[m].Second != ComboChain[m].Third )
			return MonkElement.MonkElementCombo;
	}
	*/


