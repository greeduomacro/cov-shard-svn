using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
    public class BankHiive : Item, TranslocationItem
    {
        private int m_Charges;
        private int m_Recharges;
        private Mobile m_Owner;

        [CommandProperty( AccessLevel.GameMaster )]
        public int Charges
        {
            get { return m_Charges; }
            set
            {
                if ( value > this.MaxCharges )
                    m_Charges = this.MaxCharges;
                else if ( value < 0 )
                    m_Charges = 0;
                else
                    m_Charges = value;

                InvalidateProperties();
            }
        }

        [CommandProperty( AccessLevel.GameMaster )]
        public int Recharges
        {
            get { return m_Recharges; }
            set
            {
                if ( value > this.MaxRecharges )
                    m_Recharges = this.MaxRecharges;
                else if ( value < 0 )
                    m_Recharges = 0;
                else
                    m_Recharges = value;

                InvalidateProperties();
            }
        }

        [CommandProperty( AccessLevel.GameMaster )]
        public int MaxCharges { get { return 200; } }

        [CommandProperty( AccessLevel.GameMaster )]
        public int MaxRecharges { get { return 1; } }

        public string TranslocationItemName { get { return "A Bank Hive"; } }

        [Constructable]
        public BankHiive()
            : base( 0x91A )
        {

            Weight = 3.0;
            Light = LightType.Circle150;
            Hue = 1282;


            m_Charges = 100;
            m_Recharges = 0;
            m_Owner = null;
        }
        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );
            list.Add( 1042971, "Bank hive." );
            list.Add( 1054132, Charges.ToString() );
            list.Add( 1070722, "Recharges remaining: " + ( MaxRecharges - Recharges ).ToString() );
        }
        public override void OnDoubleClick( Mobile from )
        {
            if ( from.Criminal )
            {
                from.SendMessage( "Thou art a criminal and cannot access thy bank box." );
            }
            else if ( IsChildOf( from.Backpack ) )
            {
                if ( this.m_Owner != from )
                    this.m_Owner = from;

                if ( CanOpenBank( from, this ) )
                    DoOpenBank( from, this );
            }
            else
            {
                if ( m_Owner == null )
                    m_Owner = from;
                if ( CanOpenBank( from, this ) && from == this.m_Owner )
                    DoOpenBank( from, this );
            }
        }
        public bool CanOpenBank( Mobile from, BankHiive bt )
        {
            if ( bt.Charges > 0 )
            {
                return true;
            }
            else
            {
                from.SendLocalizedMessage( 502412 ); // There are no charges left on that item.
                return false;
            }
        }
        public void DoOpenBank( Mobile from, BankHiive bt )
        {
            BankBox box = from.BankBox;

            if ( box != null )
            {
                box.Open();
                bt.Charges--;
                bt.Name = "Bank hive. Charges: " + Charges + " Recharges left: " + ( MaxRecharges - Recharges );
            }
            else
                from.SendMessage( "Please page a gm immediately... you seem to have misplaced your bankbox....Boggle!" );

        }

        public BankHiive( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( ( int )0 ); // version

            writer.WriteEncodedInt( ( int )m_Charges );
            writer.WriteEncodedInt( ( int )m_Recharges );
            writer.Write( m_Owner );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            m_Charges = reader.ReadEncodedInt();
            m_Recharges = reader.ReadEncodedInt();
            m_Owner = reader.ReadMobile();
        }
    }
}
