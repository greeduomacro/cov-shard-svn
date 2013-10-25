// Created by Peoharen
using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;

namespace Server.Items
{
	public abstract class BaseCustomWand : BaseWand
	{
		public BaseCustomWand( int charges ) : base( WandEffect.Identification, charges, charges )
		{
		}

		public BaseCustomWand( Serial serial ) : base( serial )
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

		public override void GetProperties( ObjectPropertyList list )
		{
			AddNameProperties( list );

			list.Add( 1011296, Charges.ToString() ); // [ Charges: ~1_CHARGES~ ]

			if ( Crafter != null )
				list.Add( 1050043, Crafter.Name ); // crafted by ~1_NAME~

			if ( SkillBonuses != null )
				SkillBonuses.GetProperties( list );

			if ( Slayer != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( Slayer );

				if ( entry != null )
					list.Add( entry.Title );
			}

			if ( Slayer2 != SlayerName.None )
			{
				SlayerEntry entry = SlayerGroup.GetEntryByName( Slayer2 );

				if ( entry != null )
					list.Add( entry.Title );
			}

			base.AddResistanceProperties( list );

			int prop;

			if ( (prop = WeaponAttributes.BloodDrinker) != 0 )
				list.Add( 1113591, prop.ToString() ); // Blood Drinker

			if ( (prop = WeaponAttributes.BattleLust) != 0 )
				list.Add( 1113710, prop.ToString() ); // Battle Lust

			if ((prop = WeaponAttributes.UseBestSkill) != 0)
				list.Add(1060400); // use best weapon skill

			if ((prop = (GetDamageBonus() + Attributes.WeaponDamage)) != 0)
				list.Add(1060401, prop.ToString()); // damage increase ~1_val~%

			if ((prop = Attributes.DefendChance) != 0)
				list.Add(1060408, prop.ToString()); // defense chance increase ~1_val~%

			if ((prop = Attributes.EnhancePotions) != 0)
				list.Add(1060411, prop.ToString()); // enhance potions ~1_val~%

			if ((prop = Attributes.CastRecovery) != 0)
				list.Add(1060412, prop.ToString()); // faster cast recovery ~1_val~

			if ((prop = Attributes.CastSpeed) != 0)
				list.Add(1060413, prop.ToString()); // faster casting ~1_val~

			if ((prop = (GetHitChanceBonus() + Attributes.AttackChance)) != 0)
				list.Add(1060415, prop.ToString()); // hit chance increase ~1_val~%

			if ((prop = WeaponAttributes.HitColdArea) != 0)
				list.Add(1060416, prop.ToString()); // hit cold area ~1_val~%

			if ((prop = WeaponAttributes.HitDispel) != 0)
				list.Add(1060417, prop.ToString()); // hit dispel ~1_val~%

			if ((prop = WeaponAttributes.HitEnergyArea) != 0)
				list.Add(1060418, prop.ToString()); // hit energy area ~1_val~%

			if ((prop = WeaponAttributes.HitFireArea) != 0)
				list.Add(1060419, prop.ToString()); // hit fire area ~1_val~%

			if ((prop = WeaponAttributes.HitFireball) != 0)
				list.Add(1060420, prop.ToString()); // hit fireball ~1_val~%

			if ((prop = WeaponAttributes.HitHarm) != 0)
				list.Add(1060421, prop.ToString()); // hit harm ~1_val~%

			if ((prop = WeaponAttributes.HitLeechHits) != 0)
				list.Add(1060422, prop.ToString()); // hit life leech ~1_val~%

			if ((prop = WeaponAttributes.HitLightning) != 0)
				list.Add(1060423, prop.ToString()); // hit lightning ~1_val~%

			#region SA
			if ( (prop = WeaponAttributes.HitCurse) != 0 )
				list.Add( 1113712, prop.ToString() ); // Hit Curse ~1_val~%

			if ( (prop = WeaponAttributes.HitFatigue) != 0 )
				list.Add( 1113700, prop.ToString() ); // Hit Fatigue ~1_val~%

			if ( (prop = WeaponAttributes.HitManaDrain) != 0 )
				list.Add( 1113699, prop.ToString() ); // Hit Mana Drain ~1_val~%
			#endregion

			if ((prop = WeaponAttributes.HitLowerAttack) != 0)
				list.Add(1060424, prop.ToString()); // hit lower attack ~1_val~%

			if ((prop = WeaponAttributes.HitLowerDefend) != 0)
				list.Add(1060425, prop.ToString()); // hit lower defense ~1_val~%

			if ((prop = WeaponAttributes.HitMagicArrow) != 0)
				list.Add(1060426, prop.ToString()); // hit magic arrow ~1_val~%

			if ((prop = WeaponAttributes.HitLeechMana) != 0)
				list.Add(1060427, prop.ToString()); // hit mana leech ~1_val~%

			if ((prop = WeaponAttributes.HitPhysicalArea) != 0)
				list.Add(1060428, prop.ToString()); // hit physical area ~1_val~%

			if ((prop = WeaponAttributes.HitPoisonArea) != 0)
				list.Add(1060429, prop.ToString()); // hit poison area ~1_val~%

			if ((prop = WeaponAttributes.HitLeechStam) != 0)
				list.Add(1060430, prop.ToString()); // hit stamina leech ~1_val~%

			if ((prop = Attributes.BonusDex) != 0)
				list.Add(1060409, prop.ToString()); // dexterity bonus ~1_val~

			if ((prop = Attributes.BonusHits) != 0)
				list.Add(1060431, prop.ToString()); // hit point increase ~1_val~

			if ((prop = Attributes.BonusInt) != 0)
				list.Add(1060432, prop.ToString()); // intelligence bonus ~1_val~

			if ((prop = Attributes.LowerManaCost) != 0)
				list.Add(1060433, prop.ToString()); // lower mana cost ~1_val~%

			if ((prop = Attributes.LowerRegCost) != 0)
				list.Add(1060434, prop.ToString()); // lower reagent cost ~1_val~%

			if ((prop = GetLowerStatReq()) != 0)
				list.Add(1060435, prop.ToString()); // lower requirements ~1_val~%

			if ((prop = (GetLuckBonus() + Attributes.Luck)) != 0)
				list.Add(1060436, prop.ToString()); // luck ~1_val~

			if ((prop = WeaponAttributes.MageWeapon) != 0)
				list.Add(1060438, (30 - prop).ToString()); // mage weapon -~1_val~ skill

			if ((prop = Attributes.BonusMana) != 0)
				list.Add(1060439, prop.ToString()); // mana increase ~1_val~

			if ((prop = Attributes.RegenMana) != 0)
				list.Add(1060440, prop.ToString()); // mana regeneration ~1_val~

			if ((prop = Attributes.NightSight) != 0)
				list.Add(1060441); // night sight

			if ((prop = Attributes.ReflectPhysical) != 0)
				list.Add(1060442, prop.ToString()); // reflect physical damage ~1_val~%

			if ((prop = Attributes.RegenStam) != 0)
				list.Add(1060443, prop.ToString()); // stamina regeneration ~1_val~

			if ((prop = Attributes.RegenHits) != 0)
				list.Add(1060444, prop.ToString()); // hit point regeneration ~1_val~

			if ((prop = WeaponAttributes.SelfRepair) != 0)
				list.Add(1060450, prop.ToString()); // self repair ~1_val~

			if ((prop = Attributes.SpellChanneling) != 0)
				list.Add(1060482); // spell channeling

			if ((prop = Attributes.SpellDamage) != 0)
				list.Add(1060483, prop.ToString()); // spell damage increase ~1_val~%

			if ((prop = Attributes.BonusStam) != 0)
				list.Add(1060484, prop.ToString()); // stamina increase ~1_val~

			if ((prop = Attributes.BonusStr) != 0)
				list.Add(1060485, prop.ToString()); // strength bonus ~1_val~

			if ((prop = Attributes.WeaponSpeed) != 0)
				list.Add(1060486, prop.ToString()); // swing speed increase ~1_val~%

			#region SA
			if ( (prop = AbsorptionAttributes.CastingFocus) != 0 )
				list.Add( 1113696, prop.ToString() ); // Casting Focus ~1_val~%

			if ( (prop = AbsorptionAttributes.EaterFire) != 0 )
				list.Add( 1113593, prop.ToString() ); // Fire Eater ~1_Val~%

			if ( (prop = AbsorptionAttributes.EaterCold) != 0 )
				list.Add( 1113594, prop.ToString() ); // Cold Eater ~1_Val~%

			if ( (prop = AbsorptionAttributes.EaterPoison) != 0 )
				list.Add( 1113595, prop.ToString() ); // Poison Eater ~1_Val~%

			if ( (prop = AbsorptionAttributes.EaterEnergy) != 0 )
				list.Add( 1113596, prop.ToString() ); // Energy Eater ~1_Val~%

			if ( (prop = AbsorptionAttributes.EaterKinetic) != 0 )
				list.Add( 1113597, prop.ToString() ); // Kinetic Eater ~1_Val~%

			if ( (prop = AbsorptionAttributes.EaterDamage) != 0 )
				list.Add( 1113598, prop.ToString() ); // Damage Eater ~1_Val~%

			if ( (prop = AbsorptionAttributes.ResonanceFire) != 0 )
				list.Add( 1113691, prop.ToString() ); // Fire Resonance ~1_val~%

			if ( (prop = AbsorptionAttributes.ResonanceCold) != 0 )
				list.Add( 1113692, prop.ToString() ); // Cold Resonance ~1_val~%

			if ( (prop = AbsorptionAttributes.ResonancePoison) != 0 )
				list.Add( 1113693, prop.ToString() ); // Poison Resonance ~1_val~%

			if ( (prop = AbsorptionAttributes.ResonanceEnergy) != 0 )
				list.Add( 1113694, prop.ToString() ); // Energy Resonance ~1_val~%

			if ( (prop = AbsorptionAttributes.ResonanceKinetic) != 0 )
				list.Add( 1113695, prop.ToString() ); // Kinetic Resonance ~1_val~%
			#endregion

			int phys, fire, cold, pois, nrgy, chaos, direct;

			GetDamageTypes(null, out phys, out fire, out cold, out pois, out nrgy, out chaos, out direct);

			#region Mondain's Legacy
			if (chaos != 0)
				list.Add(1072846, chaos.ToString()); // chaos damage ~1_val~%

			if (direct != 0)
				list.Add(1079978, direct.ToString()); // Direct Damage: ~1_PERCENT~%
			#endregion

			if (phys != 0)
				list.Add(1060403, phys.ToString()); // physical damage ~1_val~%

			if (fire != 0)
				list.Add(1060405, fire.ToString()); // fire damage ~1_val~%

			if (cold != 0)
				list.Add(1060404, cold.ToString()); // cold damage ~1_val~%

			if (pois != 0)
				list.Add(1060406, pois.ToString()); // poison damage ~1_val~%

			if (nrgy != 0)
				list.Add(1060407, nrgy.ToString()); // energy damage ~1_val~%

			if (Core.ML && chaos != 0)
				list.Add(1072846, chaos.ToString()); // chaos damage ~1_val~%

			if (Core.ML && direct != 0)
				list.Add(1079978, direct.ToString()); // Direct Damage: ~1_PERCENT~%

			list.Add(1061168, "{0}\t{1}", MinDamage.ToString(), MaxDamage.ToString()); // weapon damage ~1_val~ - ~2_val~

			if (Core.ML)
				list.Add(1061167, String.Format("{0}s", Speed)); // weapon speed ~1_val~
			else
				list.Add(1061167, Speed.ToString());

			if (MaxRange > 1)
				list.Add(1061169, MaxRange.ToString()); // range ~1_val~

			int strReq = AOS.Scale(StrRequirement, 100 - GetLowerStatReq());

			if (strReq > 0)
				list.Add(1061170, strReq.ToString()); // strength requirement ~1_val~

			if (Layer == Layer.TwoHanded)
				list.Add(1061171); // two-handed weapon
			else
				list.Add(1061824); // one-handed weapon

			if (Core.SE || WeaponAttributes.UseBestSkill == 0)
			{
				switch (Skill)
				{
					case SkillName.Swords: list.Add(1061172); break; // skill required: swordsmanship
					case SkillName.Macing: list.Add(1061173); break; // skill required: mace fighting
					case SkillName.Fencing: list.Add(1061174); break; // skill required: fencing
					case SkillName.Archery: list.Add(1061175); break; // skill required: archery
				}
			}

			if ( HitPoints >= 0 && MaxHitPoints > 0 )
				list.Add( 1060639, "{0}\t{1}", HitPoints, MaxHitPoints ); // durability ~1_val~ / ~2_val~
		}

		public override void OnSingleClick( Mobile from )
		{
		}
	}
}