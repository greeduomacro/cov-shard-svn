
using System;
using Server.Items;

namespace Server.Items
{
    public class AlchemyBoxTypes
    {
        private static Type[] m_Bottle = new Type[]
		{
			typeof( Bottle )		
		};
        public static Type[] Bottle { get { return m_Bottle; } }

        private static Type[] m_PotionKeg = new Type[]
		{
			typeof( PotionKeg )		
		};
        public static Type[] PotionKeg { get { return m_PotionKeg; } }

        private static Type[] m_NightSightPotion = new Type[]
		{
			typeof( NightSightPotion ),      
		};
        public static Type[] NightSightPotion { get { return m_NightSightPotion; } }

        private static Type[] m_CurePotion = new Type[]
        {
            typeof( CurePotion ),
            typeof( LesserCurePotion ),
            typeof( GreaterCurePotion )         
        };
        public static Type[] CurePotion { get { return m_CurePotion; } }

        private static Type[] m_AgilityPotion = new Type[]
        {
            typeof( AgilityPotion ), typeof( GreaterAgilityPotion )
        };
        public static Type[] AgilityPotion { get { return m_AgilityPotion; } }

        private static Type[] m_StrengthPotion = new Type[]
        {
            typeof( StrengthPotion ), typeof( GreaterStrengthPotion )
        };
        public static Type[] StrengthPotion { get { return m_StrengthPotion; } }

        private static Type[] m_PoisonPotion = new Type[]
        {
            typeof( PoisonPotion ), typeof( LesserPoisonPotion ), typeof( GreaterPoisonPotion ), typeof( DeadlyPoisonPotion ),     
        };

        public static Type[] PoisonPotion { get { return m_PoisonPotion; } }

        private static Type[] m_RefreshPotion = new Type[]
        {
            typeof( RefreshPotion ), typeof( TotalRefreshPotion )
        };
        public static Type[] RefreshPotion { get { return m_RefreshPotion; } }

        private static Type[] m_HealPotion = new Type[]
        {
            typeof( HealPotion ), typeof( LesserHealPotion ), typeof( GreaterHealPotion )
        };
        public static Type[] HealPotion { get { return m_HealPotion; } }

        private static Type[] m_ExplosionPotion = new Type[]
        {
            typeof( ExplosionPotion ), typeof( LesserExplosionPotion ), typeof( GreaterExplosionPotion )
        };
        public static Type[] ExplosionPotion { get { return m_ExplosionPotion; } }
    }
}

