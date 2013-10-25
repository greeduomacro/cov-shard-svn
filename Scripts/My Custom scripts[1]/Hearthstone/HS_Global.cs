using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public partial class Hearthstone : Item
	{
		private static Dictionary<Mobile, Hearthstone> _Registry = new Dictionary<Mobile, Hearthstone>();
		public static Dictionary<Mobile, Hearthstone> Registry { get { return _Registry; } }

		private static void Register(Mobile m, Hearthstone hs)
		{
			if (m == null || hs == null)
				return;

			Hearthstone cur = GetStone(m);

			if (cur == null)
			{
				if (_Registry.ContainsKey(m))
					_Registry[m] = hs;
				else
					_Registry.Add(m, hs);
			}
			else if (cur != hs)
			{
				hs.Delete();
			}
		}

		public static void Unregister(Mobile m)
		{
			if (m == null)
				return;

			if (_Registry.ContainsKey(m))
			{
				_Registry.Remove(m);
			}
		}

		public static Hearthstone GetStone(Mobile m)
		{
			if (m != null && _Registry.ContainsKey(m))
				return _Registry[m];

			return null;
		}

		public static void HandleMobile_OnSpeech(Mobile m, SpeechEventArgs e)
		{
			if (e.Mobile != null && !e.Handled)
			{
				bool handle = false;

				for (int i = 0; i < DefVendorKeyPhrases.Length; i++)
				{
					if (e.Speech.ToLower().Contains(DefVendorKeyPhrases[i]))
					{
						handle = true;
						break;
					}
				}

				if (handle)
				{
					int thisNoto = Notoriety.Compute(m, m);
					bool neg = false;

					switch (Notoriety.Compute(m, e.Mobile))
					{
						case Notoriety.Ally:
							{
								m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "Greetings, ally! I need to see your Hearthstone...", e.Mobile.NetState);
							} break;

						case Notoriety.Criminal:
							{
								if (thisNoto == Notoriety.Criminal)
								{
									m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "Be quiet, let me see your Hearthstone.", e.Mobile.NetState);
								}
								else
								{
									m.PrivateOverheadMessage(MessageType.Yell, m.SpeechHue, true, "Do you really think I'd want a criminal coming and going freely to my bar? Get out before I call the guards!", e.Mobile.NetState);
									e.Handled = true;
									return;
								}
							} break;

						case Notoriety.Enemy:
							{
								m.PrivateOverheadMessage(MessageType.Yell, m.SpeechHue, true, "Get lost before I kill you, scum.", e.Mobile.NetState);
								e.Handled = true;
								return;
							} //break;

						case Notoriety.Innocent:
							{
								if (thisNoto == Notoriety.Criminal || thisNoto == Notoriety.Murderer)
								{
									m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "Give me one good reason why I should serve you.", e.Mobile.NetState);
									e.Handled = true;
									return;
								}
								else
								{
									m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "One moment, I need to see your Hearthstone...", e.Mobile.NetState);
								}
							} break;

						case Notoriety.Murderer:
							{
								if (thisNoto == Notoriety.Criminal || thisNoto == Notoriety.Murderer)
								{
									m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "Just shut up and show me your damned Hearthstone!", e.Mobile.NetState);
									neg = true;
								}
								else if (thisNoto == Notoriety.Innocent)
								{
									m.PrivateOverheadMessage(MessageType.Yell, m.SpeechHue, true, "Get out of here before I call the guards or kill you, whichever comes first!", e.Mobile.NetState);
								}
								else if (thisNoto == Notoriety.Invulnerable)
								{
									m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "You caught me in a good mood, show me your Hearthstone and be gone!", e.Mobile.NetState);
								}
								else
								{
									m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "One moment, I need to see your Hearthstone...", e.Mobile.NetState);
								}
							} break;

						case Notoriety.Invulnerable:
							{
								m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "Anything you say, boss! I just need to see your Hearthstone...", e.Mobile.NetState);
								e.Handled = true;
								return;
							} //break;
					}

					Hearthstone hs = Hearthstone.GetStone(e.Mobile);

					if (hs != null)
					{
						if (hs.IsChildOf(e.Mobile.Backpack))
						{
							hs.Home.Set(e.Mobile.Location, e.Mobile.Map);
							m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "There, your Hearthstone has been enchanted, allowing you to recall to " + hs.Home.Name + " every so often.", e.Mobile.NetState);
							e.Handled = true;
							return;
						}
						else
						{
							if (neg)
								m.PrivateOverheadMessage(MessageType.Yell, m.SpeechHue, true, "You don't have your Hearthstone with you! You're wasting my time!", e.Mobile.NetState);
							else
								m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "You don't have your Hearthstone with you.", e.Mobile.NetState);

							e.Handled = true;
							return;
						}
					}
					else
					{
						if (neg)
							m.PrivateOverheadMessage(MessageType.Yell, m.SpeechHue, true, "Pathetic, you don't even have a Hearthstone.", e.Mobile.NetState);
						else
							m.PrivateOverheadMessage(MessageType.Regular, m.SpeechHue, true, "Sorry, but you don't have a Hearthstone.", e.Mobile.NetState);

						e.Handled = true;
						return;
					}
				}
			}
		}
	}
}