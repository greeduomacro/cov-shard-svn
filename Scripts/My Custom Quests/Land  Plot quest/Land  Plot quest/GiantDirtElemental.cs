using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Mobiles; 

namespace Server.Mobiles
{
	[CorpseName( "a Giant dirt elemental corpse" )]
	public class GiantDirtElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public GiantDirtElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Giant Dirt Elemental";
			Body = 752;
			BaseSoundID = 268;
			Hue = 341;

			SetStr( 400, 600 );
			SetDex( 100, 200 );
			SetInt( 71, 92 );

			SetHits( 2600, 2800 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 75 );
			SetResistance( ResistanceType.Energy, 55, 75 );

			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 75;
			
			
			PackItem( new Dirt() );			
					
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems );			
		}

		private DateTime m_NextQuake;

		public override void OnThink()
		{
			base.OnThink();

			if ( DateTime.Now < m_NextQuake)
				return;		
					
			m_NextQuake = DateTime.Now + TimeSpan.FromSeconds(30.0 * Utility.RandomDouble() );			
			
			Timer.DelayCall( TimeSpan.FromSeconds( 30.0 ), new TimerCallback( Quake ) );			
		}

        private void Quake()
        {

            ArrayList list = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(7))
            {
                if (m == this || m == null)
                    continue;
                {
                    if (m.Player && m.AccessLevel == AccessLevel.Player && m.Alive)
                        list.Add(m);
                }
            }
                for (int i = 0; i < list.Count; ++i)
                {
                    Mobile m = (Mobile)list[i];
                    m.Hits -= Utility.Random(25, 35);
                    m.SendMessage("an earthquake shakes the dungeon and almost knocks you off your feet.");
                    this.Say("*" + m.Name + " I will send you through the floor of this dungeon!");
                    m.PlaySound(0x101);
                    m.Animate(22, 5, 1, true, false, 0);
                    return;
                }
            }
                   
		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }


		public GiantDirtElemental( Serial serial ) : base( serial )
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