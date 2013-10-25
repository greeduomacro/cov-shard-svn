using System;using System.Collections;using System.Collections.Generic;using Server.Items;using Server.Targeting;using Server.ContextMenus;using Server.Gumps;using Server.Misc;using Server.Network;using Server.Spells;namespace Server.Mobiles
{[CorpseName( "Hermy's Corpse" )]public class Hermy : Mobile{public virtual bool IsInvulnerable{ get{ return true; } }
[Constructable]public Hermy(){
//////////////////////////////name
Name = "Hermy";
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
public Hermy( Serial serial ) : base( serial ){}
public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
{ base.GetContextMenuEntries( from, list ); list.Add( new HermyEntry( from, this ) ); } 
public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( (int) 0 );}
public override void Deserialize( GenericReader reader ){base.Deserialize( reader );int version = reader.ReadInt();}
public class HermyEntry : ContextMenuEntry{private Mobile m_Mobile;private Mobile m_Giver;
public HermyEntry( Mobile from, Mobile giver ) : base( 6146, 3 ){m_Mobile = from;m_Giver = giver;}
public override void OnClick(){if( !( m_Mobile is PlayerMobile ) )return;
PlayerMobile mobile = (PlayerMobile) m_Mobile;{
///////////////////////////////////////////////// gumpname
if ( ! mobile.HasGump( typeof( HermyGump ) ) ){
mobile.SendGump( new HermyGump( mobile ));}}}}
public override bool OnDragDrop( Mobile from, Item dropped ){               Mobile m = from;PlayerMobile mobile = m as PlayerMobile;
if ( mobile != null){
/////////////////////////////////////////////////////////// item to be dropped
if( dropped is PresentBomb3 ){if(dropped.Amount!=30)
{this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "There's not the right amount here!", mobile.NetState );return false;}
dropped.Delete(); 
///////////////the reward
mobile.AddToBackpack( new Gold( 1200 ) );
mobile.AddToBackpack( new SwordOfChristmas( ) );
////////////////////////////////////////////////////////// thanksmessage
this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Thank You For Finding the Exploding Presents! Thank You!", mobile.NetState );
return true;}else if ( dropped is Whip){this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );return false;}else{this.PrivateOverheadMessage( MessageType.Regular, 1153, false,"I have no need for this...", mobile.NetState );}}return false;}}}
