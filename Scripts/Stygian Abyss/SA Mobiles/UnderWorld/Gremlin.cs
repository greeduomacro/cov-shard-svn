using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a gremlin corpse" )]
	public class Gremlin : BaseCreature
	{
		[Constructable]
		public Gremlin() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gremlin";
			Body = 724; 

			SetStr( 119 );
			SetDex( 103 );
			SetInt( 50 );

			SetHits( 67 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 29 );
			SetResistance( ResistanceType.Fire, 37 );
			SetResistance( ResistanceType.Cold, 19 );
			SetResistance( ResistanceType.Poison, 18 );
			SetResistance( ResistanceType.Energy, 29 );

			SetSkill( SkillName.Anatomy, 89.2 );
			SetSkill( SkillName.MagicResist, 67.0 );
			SetSkill( SkillName.Tactics, 71.4 );
            SetSkill( SkillName.Archery, 100.0 );
            SetSkill( SkillName.Healing, 67.6, 70.0 );

            PackItem(new Apple(Utility.RandomMinMax(3, 5)));
            PackItem(new Arrow(Utility.RandomMinMax(60, 70)));
            PackItem(new Bandage(Utility.RandomMinMax(1, 15)));

            if (0.1 > Utility.RandomDouble())
                AddItem(new OrcishBow());
            else
                AddItem(new Bow());

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

        private Mobile FindTarget()
        {
            foreach (Mobile m in this.GetMobilesInRange(10))
            {
                if (m.Player && m.Hidden && m.AccessLevel == AccessLevel.Player)
                {
                    return m;
                }
            }

            return null;
        }

        private void TryToDetectHidden()
        {
            Mobile m = FindTarget();

            if (m != null)
            {
                if (DateTime.Now >= this.NextSkillTime && UseSkill(SkillName.DetectHidden))
                {
                    Target targ = this.Target;

                    if (targ != null)
                        targ.Invoke(this, this);

                    Effects.PlaySound(this.Location, this.Map, 0x340);
                }
            }
        }

        public override bool CanHeal { get { return true; } }
        public override bool CanRummageCorpses { get { return true; } }
        public override int Meat { get { return 1; } }

		public Gremlin( Serial serial ) : base( serial )
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