/*
 * User: Masternightmage
 * Date: 10/16/2005
 * Time: 8:11 PM
 *
 * Please do not remove header or try and claim this script as your own!
 * This is a cutom quest and the first quest I have ever made so leave it as it is do not mod these files!
 *
 */

using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( " corpse of satan" )]
	public class ManOfSin : BaseCreature

	{
        public virtual bool IsInvulnerable { get { return true; } }

		[Constructable]
		public ManOfSin() : base( AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			Title = "Power Of Darkness";
			Name = "Lucifer";
			Body = 0x190;
			BaseSoundID = 0x165;
			Hue = 1194;
			
			Item BoneGloves = new BoneGloves();
			BoneGloves.Hue = 1194;
			BoneGloves.LootType = LootType.Blessed;
			BoneGloves.Movable = false;
			AddItem( BoneGloves );
			
			Item BoneChest = new BoneChest();
			BoneChest.Hue = 1194;
			BoneChest.LootType = LootType.Blessed;
			BoneChest.Movable = false;
			AddItem( BoneChest );
			
			Item BoneArms = new BoneArms();
			BoneArms.Hue = 1194;
			BoneArms.LootType = LootType.Blessed;
			BoneArms.Movable = false;
			AddItem( BoneArms );
			
			Item BoneHelm = new BoneHelm();
			BoneHelm.Hue = 1194;
			BoneHelm.LootType = LootType.Blessed;
			BoneHelm.Movable = false;
			AddItem( BoneHelm );
			
			Item LongPants = new LongPants();
			LongPants.Hue = 1194;
			LongPants.LootType = LootType.Blessed;
			LongPants.Movable = false;
			AddItem( LongPants );
			
			Item FancyShirt = new FancyShirt();
			FancyShirt.Hue = 1194;
			FancyShirt.LootType = LootType.Blessed;
			FancyShirt.Movable = false;
			AddItem( FancyShirt );
			
			Item Boots = new Boots();
			Boots.Hue = 1;
			Boots.LootType = LootType.Blessed;
			Boots.Movable = false;
			AddItem( Boots ); 
			
			Item DeathAxe = new DeathAxe();
			DeathAxe.Hue = 1194;
			DeathAxe.LootType = LootType.Blessed;
			DeathAxe.Movable = false;
			AddItem( DeathAxe );
			
			SetStr( 300, 450 );
			SetDex( 150, 300 );
			SetInt( 420, 420 );
			
			SetHits( 10000, 15000 );
			
			SetDamage( 20, 28 );
			
			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Cold, 100 );
			SetDamageType( ResistanceType.Fire, 100 );
			SetDamageType( ResistanceType.Energy, 100 );
			SetDamageType( ResistanceType.Poison, 100 );
			
			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Energy, 100 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.Anatomy,  99.0, 100.0 );
			SetSkill( SkillName.EvalInt,  99.0, 100.0 );
			SetSkill( SkillName.Magery,  99.0, 100.0 );
			SetSkill( SkillName.MagicResist,  99.0, 100.0 );
			SetSkill( SkillName.Swords, 99.0, 100.0 );
			SetSkill( SkillName.Tactics, 99.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 99.0, 100.0 );

			Fame = -15000;
			Karma = -15000;

			VirtualArmor = 35;


			PackItem( new Gold( 50, 60 ) );

			new SkeletalMount().Rider = this;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public override bool OnBeforeDeath()
		{
			IMount mount = this.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( mount is Mobile )
				((Mobile)mount).Delete();

			return base.OnBeforeDeath();
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.BodyMod == 183 || m.BodyMod == 184 )
				return false;

			return base.IsEnemy( m );
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is Dragon || to is WhiteWyrm || to is SwampDragon || to is Drake || to is Nightmare || to is Daemon )
				damage *= 5;
		}

		public ManOfSin( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ManOfSinEntry( from, this ) );
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

		public class ManOfSinEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

			public ManOfSinEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{


				if( !( m_Mobile is PlayerMobile ) )
					return;

				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( ManOfSinQuestGump ) ) )
					{
						mobile.SendGump( new ManOfSinQuestGump( mobile ));

					}
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is AngelFeather)
				{
					if(dropped.Amount !=10)
					{
						this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I THOUGHT I SAID 30 OF THEM! I SHOULD SLAY YOU", mobile.NetState );
						return false;
					}

					dropped.Delete();
				
					switch ( Utility.Random( 1 ))
				 {
					case 0: mobile.AddToBackpack( new DeathAxe() ); break;
					

				//case 2: mobile.AddToBackpack( new Tokens( 50 ) );
			//break;
			}

					return true;
				}
				else if ( dropped is AngelFeather)
				{


					this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
					return false;
				}
				else
				{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "ARGS YOU DAMN FOOL THIS IS NOT A ANGEL FEATHER GO GET ME THE FEATHERS!!!", mobile.NetState );
				}
			}
			return false;
		}
		}

}





