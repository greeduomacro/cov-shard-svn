using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		public delegate void HearthstoneUsedEventHandler(Hearthstone hs);
		public static event HearthstoneUsedEventHandler Event_OnUsed;

		private DateTime _LastUsed = DateTime.Now.Subtract(DefStoneCoolDown);
		private TimeSpan _Cooldown = DefStoneCoolDown;

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastUsed { get { return _LastUsed; } set { _LastUsed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan Cooldown { get { return _Cooldown; } set { _Cooldown = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan TimeLeft { get { return GetTimeLeft(); } }

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			AddUsageProperties(list);
		}

		private void AddUsageProperties(ObjectPropertyList list)
		{
			string prop = "<BASEFONT COLOR=#00FF00>";

			prop += String.Format(
				"Use: Returns you to {0}.\n" +
				"Speak to an Innkeeper in a different place to change your home location.\n" +
				"({1} Min Cooldown)",
				_Home.Name, (int)_Cooldown.TotalMinutes);

			prop += "<BASEFONT COLOR=#FFFFFF>";

			TimeSpan timeLeft = GetTimeLeft();

			if (timeLeft != TimeSpan.Zero)
			{
				int mins = (int)timeLeft.TotalMinutes;

				prop += "\n";
				prop += String.Format("[{0} Minute{1} Remaining]", mins, (mins != 1 ? "s" : ""));
			}

			list.Add(prop);
		}

		public override void OnDoubleClick(Mobile from)
		{
			base.OnDoubleClick(from);

			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				Cast(from);
			}
			else if (IsAccessibleTo(from))
			{
				if (CanUse(from))
				{
					Cast(from);
				}
			}

			InvalidateProperties();
		}

		public override bool IsAccessibleTo(Mobile check)
		{
			if (check.AccessLevel >= AccessLevel.GameMaster || _Owner == check)
				return base.IsAccessibleTo(check);

			return false;
		}

		public bool CanUse(Mobile from)
		{
			return (GetTimeLeft() == TimeSpan.Zero);
		}

		public void Cast(Mobile caster)
		{
			HearthSpell hs = new HearthSpell(this, caster);

			if (hs.Cast())
			{
				_LastUsed = DateTime.Now;

				Event_Invoke("OnUsed");
			}
		}

		public TimeSpan GetTimeLeft()
		{
			DateTime now = DateTime.Now;
			TimeSpan ts = TimeSpan.Zero;

			if (now < _LastUsed.Add(_Cooldown))
				ts = _LastUsed.Add(_Cooldown).Subtract(now);

			return ts;
		}

		public void SerializeUsage(GenericWriter writer)
		{
			writer.Write((int)0);

			writer.Write(_LastUsed);
			writer.Write(_Cooldown);
		}

		public void DeserializeUsage(GenericReader reader)
		{
			int version = reader.ReadInt();

			_LastUsed = reader.ReadDateTime();
			_Cooldown = reader.ReadTimeSpan();
		}

		private void Event_Invoke(string name)
		{
			switch (name.ToUpper())
			{
				default: { } break;
				case "ONUSED":
					{
						if (Event_OnUsed != null)
						{ Event_OnUsed.Invoke(this); }
					} break;
			}
		}
	}
}