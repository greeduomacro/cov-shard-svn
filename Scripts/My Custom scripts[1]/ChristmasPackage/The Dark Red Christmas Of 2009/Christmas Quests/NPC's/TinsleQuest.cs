using System;using System.Collections;using System.Collections.Generic;using Server.Items;using Server.Targeting;using Server.ContextMenus;using Server.Gumps;using Server.Misc;using Server.Network;using Server.Spells;namespace Server.Mobiles
{[CorpseName( "Tinsle's Corpse" )]public class Tinsle : Mobile{public virtual bool IsInvulnerable{ get{ return true; } }
[Constructable]public Tinsle(){
//////////////////////////////name
Name = "Tinsle";
/////////////////////////////////title
Title = "The Worried Elf of Christmas";
////////sex
Body = 0x190;
//////skincolor
Hue = 0x83EA;
////////haircolor
int hairHue = 0x47E;
////////clothing and other apperance
AddItem( new ShortHair( hairHue ) );
AddItem( new Server.Items.JesterHat( 64 ) );AddItem( new Server.Items.Robe( 64 ) );AddItem( new Server.Items.Boots() );Blessed = true;CantWalk = true;}
public Tinsle( Serial serial ) : base( serial ){}
public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
{ base.GetContextMenuEntries( from, list ); list.Add( new TinsleEntry( from, this ) ); } 
public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( (int) 0 );}
public override void Deserialize( GenericReader reader ){base.Deserialize( reader );int version = reader.ReadInt();}
public class TinsleEntry : ContextMenuEntry{private Mobile m_Mobile;private Mobile m_Giver;
public TinsleEntry( Mobile from, Mobile giver ) : base( 6146, 3 ){m_Mobile = from;m_Giver = giver;}
public override void OnClick(){if( !( m_Mobile is PlayerMobile ) )return;
PlayerMobile mobile = (PlayerMobile) m_Mobile;{
///////////////////////////////////////////////// gumpname
if ( ! mobile.HasGump( typeof( TinsleGump ) ) ){
mobile.SendGump( new TinsleGump( mobile ));}}}}
public override bool OnDragDrop( Mobile from, Item dropped ){               Mobile m = from;PlayerMobile mobile = m as PlayerMobile;
if ( mobile != null){
/////////////////////////////////////////////////////////// item to be dropped
if( dropped is PresentBomb2 ){if(dropped.Amount!=30)
{this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", mobile.NetState );return false;}
dropped.Delete(); 
///////////////the reward
mobile.AddToBackpack( new Gold( 1000 ) );
mobile.AddToBackpack( new AxeOfXmas( ) );
////////////////////////////////////////////////////////// thanksmessage
this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Thank You For Finding the Exploding Presents! Thank You!", mobile.NetState );
return true;}else if ( dropped is Whip){this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );return false;}else{this.PrivateOverheadMessage( MessageType.Regular, 1153, false,"I have no need for this...", mobile.NetState );}}return false;}}}
