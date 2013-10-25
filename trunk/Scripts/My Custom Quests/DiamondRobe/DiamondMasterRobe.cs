using System;
using Server;
using Server.Items;

namespace Server.Items
{
   [FlipableAttribute( 0x2683, 0x2684 )]
    public class MasterRobe : BaseArmor

   {
	
		public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int AosStrReq{ get{ return 25; } }

		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }


      [Constructable]
      public MasterRobe() : base( 0x2683 )
      {
         Weight = 5.0;
         Name = "Diamond imbued Mastery Robe";
	     Hue = 0x76;
         Layer = Layer.OuterTorso;
      }

      public override void OnDoubleClick( Mobile m )
      {
         if( Parent != m )
         {
            m.SendMessage( "You must be wearing the robe to use it!" );
         }
         else
         {
            if ( ItemID == 0x2683 || ItemID == 0x2684 )
            {
               m.SendMessage( "You lower the hood." );
               m.PlaySound( 0x57 );
               ItemID = 0x1F03;
               m.NameMod = null;
               m.RemoveItem(this);
               m.EquipItem(this);
               if( m is Mobile && m.Kills >= 5)
               {
               ((Mobile)m).Criminal = true;
                }
                if( m is Mobile && m.GuildTitle != null)
               {
               ((Mobile)m).DisplayGuildTitle = true;
                }
            }
            else if ( ItemID == 0x1F03 || ItemID == 0x1F04 )
            {
               m.SendMessage( "You pull the hood over your head." );
               m.PlaySound( 0x57 );
               ItemID = 0x2683;
               //m.NameMod = "a shrouded figure";
               m.DisplayGuildTitle = false;
               m.Criminal = false;
               m.RemoveItem(this);
               m.EquipItem(this);
            }
         }
      }

       public override bool OnEquip( Mobile from )
      {
         if ( ItemID == 0x2683 )
         {
         //from.NameMod = "a shrouded figure";
         from.DisplayGuildTitle = false;
         from.Criminal = false;
         }
         return base.OnEquip(from);
      }

      public override void OnRemoved( Object o )
      {
      if( o is Mobile )
      {
          ((Mobile)o).NameMod = null;
      }
      if( o is Mobile && ((Mobile)o).Kills >= 5)
               {
               ((Mobile)o).Criminal = true;
                }
      if( o is Mobile && ((Mobile)o).GuildTitle != null )
               {
          ((Mobile)o).DisplayGuildTitle = true;
                }
      base.OnRemoved( o );
      }

      public MasterRobe( Serial serial ) : base( serial )
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

