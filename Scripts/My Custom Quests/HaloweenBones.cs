// Created by Peoharen
/*
Graveyard
	Mooks
		20: HaloweenBones
			Add the following for an "inital" spawn
			10: SkeletalMage
			10: BoneKnight
			10: Mummy
			10: Lich
			10: RottingCorpse
			10: LichLord
	Lieutenants (1 each per player)
		AbysmalHorror
		DarknightCreeper
		Impaler
	Special
		In one building
			2: BoneDemon
			6: Devourer
Once cleared move the teleporter into the center of the pentagram and
	add 10 more UnholyBones to the dungeon.

Dungeon
	10: Daemon
	5: Balron
	5: AncientLich
	10: UnholyBones
		No "inital" spawn.
	Boss
		20: BlueWight
		[add BlueMarkov set hitsmaxseed 50000 hitsmax 50000
*/
using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class HaloweenBones : Item
    {
        private DateTime m_KillDelay;
        public HaloweenBonesTimer m_Timer;
        public int HP;

        [Constructable]
        public HaloweenBones()
            : base(0xECA)
        {
            Name = "Unholy Bones";
            Movable = false;
            HP = 10;
            ItemID = 0xECA + Utility.Random(9);

            m_Timer = new HaloweenBonesTimer(this);
            m_Timer.Start();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this, 1))
            {
                if (DateTime.Now > m_KillDelay)
                {
                    --HP;

                    if (HP < 1)
                        Delete();
                    else
                    {
                        m_KillDelay = DateTime.Now + TimeSpan.FromSeconds(3);
                        from.SendMessage("You hack at the bones slowly ruining them.");
                    }
                }
            }
        }

        public void Spawn()
        {
            BaseCreature undead = null;

            switch (Utility.Random(12))
            {
                case 0:
                case 1:
                case 2: undead = new SkeletalMage(); break;
                case 3:
                case 4:
                case 5: undead = new BoneKnight(); break;
                case 6:
                case 7: undead = new Mummy(); break;
                case 8:
                case 9: undead = new Lich(); break;
                case 10: undead = new RottingCorpse(); break;
                case 11: undead = new LichLord(); break;
            }

            if (undead != null)
                undead.MoveToWorld(this.Location, this.Map);
        }

        public HaloweenBones(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public class HaloweenBonesTimer : Timer
        {
            private HaloweenBones m_Bones;

            public HaloweenBonesTimer(HaloweenBones bones)
                : base(TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30))
            {
                m_Bones = bones;
            }

            protected override void OnTick()
            {
                if (m_Bones == null || m_Bones.HP < 1)
                    Stop();
                else
                {
                    m_Bones.Spawn();
                }
            }
        }
    }
}
