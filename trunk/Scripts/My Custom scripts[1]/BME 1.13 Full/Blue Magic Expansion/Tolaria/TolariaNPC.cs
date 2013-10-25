// Created by Peoharen
using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.BlueMagic;

namespace Server.Mobiles
{
	public class TolariaSchedule
	{
		public Type NPC;
		public DayOfWeek WeekDay;
		public int Hour;
		public Point3D Location;
		public Map Map;

		public TolariaSchedule( Type type, DayOfWeek day, int hour, Point3D location, Map map )
		{
			NPC = type;
			WeekDay = day;
			Hour = hour;
			Location = location;
			Map = map;
		}
	}

	[CorpseName( "a corpse" )]
	public class TolariaNPC : BaseCreature
	{
		public static TolariaSchedule[] NPCs =
		{
			#region MoonglowNPCs
			new TolariaSchedule( typeof( DonMoonglowNPC ), DayOfWeek.Monday, 19, new Point3D( 987, 511, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( AndyMoonglowNPC ), DayOfWeek.Tuesday, 19, new Point3D( 987, 511, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( LoydMoonglowNPC ), DayOfWeek.Wednesday, 19, new Point3D( 987, 511, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( JordenMoonglowNPC ), DayOfWeek.Thursday, 19, new Point3D( 987, 511, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( MikeMoonglowNPC ), DayOfWeek.Friday, 19, new Point3D( 987, 511, -30 ), Map.Malas ),

			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Monday, 5, new Point3D( 990, 529, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Tuesday, 8, new Point3D( 990, 529, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Wednesday, 11, new Point3D( 990, 529, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Thursday, 14, new Point3D( 990, 529, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Friday, 17, new Point3D( 990, 529, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Saturday, 20, new Point3D( 990, 529, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomMageMoonglowNPC ), DayOfWeek.Sunday, 23, new Point3D( 990, 529, -30 ), Map.Malas ),

			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Monday, 4, new Point3D( 999, 528, -30 ), Map.Malas ),	
			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Tuesday, 7, new Point3D( 999, 528, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Wednesday, 10, new Point3D( 999, 528, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Thursday, 13, new Point3D( 999, 528, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Friday, 16, new Point3D( 999, 528, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Saturday, 19, new Point3D( 999, 528, -30 ), Map.Malas ),
			new TolariaSchedule( typeof( RandomStudentMoonglowNPC ), DayOfWeek.Sunday, 22, new Point3D( 999, 528, -30 ), Map.Malas )
			#endregion

		};

		public virtual string m_Speech{ get{ return ""; } }

		public TolariaNPC() : base( AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			Race = Race.Human;
			Hue = Utility.RandomSkinHue();
			NameHue = 1154;

			if ( Female )
				Body = 401;
			else
				Body = 400;

			SetStr( 125 );
			SetDex( 125 );
			SetInt( 125 );

			RangeHome = 0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Speech == "" )
			{
				base.OnDoubleClick( from );
				return;
			}

			if ( from.HasGump( typeof( TolariaSpeechGump ) ) )
				from.CloseGump( typeof( TolariaSpeechGump ) );

			from.SendGump( new TolariaSpeechGump( "<b>" + Name + " says:</b><br>" + m_Speech ) );
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public override bool ShowFameTitle { get { return false; } }
		public override bool BardImmune { get { return true; } }

		public TolariaNPC( Serial serial ) : base( serial )
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
			Delete();
		}
	}

	public class TolariaNPCTimer : Timer
	{
		public static List<TolariaNPC> Mobiles = new List<TolariaNPC>();

		public TolariaNPCTimer() : base( TimeSpan.FromHours( 1 ), TimeSpan.FromHours( 1 ) )
		{
		}

		protected override void OnTick()
		{
			for ( int i = Mobiles.Count - 1; i > 0; i-- )
			{
				for ( int j = 0; j < TolariaNPC.NPCs.Length; j++ )
				{
					if ( Mobiles[i].GetType() == TolariaNPC.NPCs[j].NPC )
					{
						Mobiles[i].Delete();
						continue;
					}
				}
			}

			foreach( TolariaSchedule ts in TolariaNPC.NPCs )
			{
				if ( ts == null )
					continue;

				if ( DateTime.Now.DayOfWeek == ts.WeekDay )
				{
					if ( DateTime.Now.Hour >= ts.Hour && DateTime.Now.Hour + 1 < ts.Hour )
					{
						if ( ts.NPC.IsSubclassOf( typeof( TolariaNPC ) ) )
						{
							TolariaNPC bc = CreateMobile( ts.NPC );

							if ( bc != null )
							{
								bc.Location = ts.Location;
								bc.Home = ts.Location;
								Mobiles.Add( bc );
							}
						}
					}
				}
			}
		}

		public TolariaNPC CreateMobile( Type t )
		{
			try
			{
				return (TolariaNPC)Activator.CreateInstance( t );
			}
			catch
			{
			}

			return null;
		}
	}


}
/*
Utility.RandomBlueHue()
Utility.RandomGreenHue()
Utility.RandomRedHue()
Utility.RandomYellowHue()
Utility.RandomNeutralHue()
*/