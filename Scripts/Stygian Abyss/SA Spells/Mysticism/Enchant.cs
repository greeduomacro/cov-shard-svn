using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Commands;
using Server.Gumps;
using Server.Spells;
using Server.Spells.Mystic;

namespace Server.Spells.Mystic
{
    public class EnchantSpell : MysticSpell
    {
        // Temporarily enchants a held weapon with a hit spell effect.

        public override int RequiredMana { get { return 6; } }
        public override double RequiredSkill { get { return 8; } }

        private static SpellInfo m_Info = new SpellInfo(
                "Enchant", "In Ort Ylem",
                680,
                9022, //change to correct number.
                Reagent.MandrakeRoot,
                Reagent.SulfurousAsh,
                Reagent.SpidersSilk
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.75); } }

        public EnchantSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
        {
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            if (!Caster.CanBeginAction(typeof(EnchantSpell)))
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            BaseWeapon weapon = Caster.Weapon as BaseWeapon;

            if (weapon == null || weapon is Fists)
            {
                Caster.SendLocalizedMessage(501078); // You must be holding a weapon.
            }
            else if (CheckSequence())
            {
                if (weapon.Enchanted == true)
                {
                    Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
                    return;
                }

                if (!Caster.CanBeginAction(typeof(EnchantSpell)))
                {
                    Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
                    return;
                }
                else
                {
                    if (Caster.HasGump(typeof(EnchantGump)))
                        Caster.CloseGump(typeof(EnchantGump));

                    Caster.SendGump(new EnchantGump());
                    Caster.FixedParticles(0x3779, 1, 15, 9905, 32, 2, EffectLayer.Head);
                    Caster.FixedParticles(0x37B9, 1, 14, 9502, 32, 5, (EffectLayer)255);

                    TimeSpan duration = TimeSpan.FromSeconds((Caster.Skills[SkillName.Mysticism].Value / 3.4) * 4 + 9.0);

                    if (Caster.Skills[SkillName.Mysticism].Value >= 80.0)
                        weapon.Attributes.SpellChanneling = 1;


                    Timer t = (Timer)m_Table[weapon];

                    if (t != null)
                        t.Stop();

                    weapon.Enchanted = true;

                    m_Table[weapon] = t = new ExpireTimer(weapon, duration);

                    t.Start();
                }

                FinishSequence();
            }
        }
    
        private static Hashtable m_Table = new Hashtable();

        private class ExpireTimer : Timer
        {
            private BaseWeapon m_Weapon;
          
            public ExpireTimer(BaseWeapon weapon, TimeSpan delay) : base(delay)
            {
                m_Weapon = weapon;
                Priority = TimerPriority.FiftyMS;
            }
            protected override void OnTick()
            {
                if (m_Weapon.WeaponAttributes.HitDispel >= 30)
                {
                    m_Weapon.WeaponAttributes.HitDispel = 0;
                    m_Weapon.PublicOverheadMessage(MessageType.Regular, 68, 1115273);
                }
                else if (m_Weapon.WeaponAttributes.HitFireball >= 30)
                {
                    m_Weapon.WeaponAttributes.HitFireball = 0;
                    m_Weapon.PublicOverheadMessage(MessageType.Regular, 68, 1115273);
                }
                else if (m_Weapon.WeaponAttributes.HitHarm >= 30)
                {
                    m_Weapon.WeaponAttributes.HitHarm = 0;
                    m_Weapon.PublicOverheadMessage(MessageType.Regular, 68, 1115273);
                }
                else if (m_Weapon.WeaponAttributes.HitLightning >= 30)
                {
                    m_Weapon.WeaponAttributes.HitLightning = 0;
                    m_Weapon.PublicOverheadMessage(MessageType.Regular, 68, 1115273);
                }
                else if (m_Weapon.WeaponAttributes.HitMagicArrow >= 30)
                {
                    m_Weapon.WeaponAttributes.HitMagicArrow = 0;
                    m_Weapon.PublicOverheadMessage(MessageType.Regular, 68, 1115273);
                }

                Effects.PlaySound(m_Weapon.GetWorldLocation(), m_Weapon.Map, 0x1E7);
                m_Weapon.Enchanted = false;
                m_Weapon.Attributes.SpellChanneling = -1;
                m_Table.Remove(this);
               
            }
        }
    }
}

public class EnchantGump : Gump
{
    //private string m_Name;
   // public BaseWeapon m_Item;
    public EnchantGump() : base(0, 0)
    {
        this.Closable = true;
        this.Disposable = true;
        this.Dragable = true;
        this.Resizable = false;

        AddPage(0);
        AddBackground(130, 90, 280, 180, 9270);   /// Background
        AddAlphaRegion(141, 101, 257, 158);   /// Alpha Region
        AddImageTiled(374, 100, 26, 160, 10460);   /// Celctic Bars on right
        AddItem(133, 98, 6882);   /// Top-Left Skull
        AddItem(340, 98, 6883);   /// Top-Right Skull
        AddItem(350, 250, 6881);   /// Bottom-Right Skull
        AddItem(122, 250, 6880);   /// Bottom-Left Skull
        AddHtml(165, 112, 117, 18, @"<BASEFONT COLOR=AQUA>Select Enchant</BASEFONT>", (bool)false, (bool)false);
        AddButton(165, 140, 9702, 9703, 1, GumpButtonType.Reply, 0);
        AddLabel(185, 138, 87, @"Hit Dispel");
        AddButton(165, 160, 9702, 9703, 2, GumpButtonType.Reply, 0);
        AddLabel(185, 158, 87, @"Hit Fireball");
        AddButton(165, 180, 9702, 9703, 3, GumpButtonType.Reply, 0);
        AddLabel(185, 178, 87, @"Hit Harm");
        AddButton(165, 200, 9702, 9703, 4, GumpButtonType.Reply, 0);
        AddLabel(185, 198, 87, @"Hit Lightning");
        AddButton(165, 220, 9702, 9703, 5, GumpButtonType.Reply, 0);
        AddLabel(185, 218, 87, @"Hit Magic Arrow");
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile m = state.Mobile;

        BaseWeapon weapon = m.Weapon as BaseWeapon;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        m.CloseGump(typeof(EnchantGump));
                        break;
                    }
                case 1:
                    {
                        weapon.WeaponAttributes.HitDispel += 30;
                        weapon.Attributes.SpellChanneling = 1;
                        m.PlaySound(0x64E);
                        m.FixedParticles(0x3728, 1, 13, 9912, 1150, 7, EffectLayer.Head);
                        m.FixedParticles(0x3779, 1, 15, 9502, 67, 7, EffectLayer.Head);
                        m.CloseGump(typeof(EnchantGump));
                        break;
                    }
                case 2:
                    {          
                        weapon.WeaponAttributes.HitFireball += 30;
                        m.PlaySound(0x64E);
                        m.FixedParticles(0x3728, 1, 13, 9912, 1150, 7, EffectLayer.Head);
                        m.FixedParticles(0x3779, 1, 15, 9502, 67, 7, EffectLayer.Head);
                        m.CloseGump(typeof(EnchantGump));
                        break;
                    }
                case 3:
                    {          
                        weapon.WeaponAttributes.HitHarm += 30;
                        m.PlaySound(0x64E);
                        m.FixedParticles(0x3728, 1, 13, 9912, 1150, 7, EffectLayer.Head);
                        m.FixedParticles(0x3779, 1, 15, 9502, 67, 7, EffectLayer.Head);
                        m.CloseGump(typeof(EnchantGump));
                        break;
                    }
                case 4:
                    {     
                        weapon.WeaponAttributes.HitLightning += 30;
                        m.PlaySound(0x64E);
                        m.FixedParticles(0x3728, 1, 13, 9912, 1150, 7, EffectLayer.Head);
                        m.FixedParticles(0x3779, 1, 15, 9502, 67, 7, EffectLayer.Head);
                        m.CloseGump(typeof(EnchantGump));
                        break;
                    }
                case 5:
                    {
                        weapon.WeaponAttributes.HitMagicArrow += 30;
                        m.PlaySound(0x64E);
                        m.FixedParticles(0x3728, 1, 13, 9912, 1150, 7, EffectLayer.Head);
                        m.FixedParticles(0x3779, 1, 15, 9502, 67, 7, EffectLayer.Head);
                        m.CloseGump(typeof(EnchantGump));
                        break;
                    }
               }
          }
     }
    

    

                   
           
     

                        
     


	