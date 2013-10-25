// Created by Peoharen
using System;
using Server;

namespace Server.Mobiles
{
	public interface ISpecialPet
	{
		string AbilityOneName{ get; }
		string AbilityTwoName{ get; }
		string AbilityThreeName{ get; }
		int AbilityOneLimit{ get; }
		int AbilityTwoLimit{ get; }
		int AbilityThreeLimit{ get; }
		int AbilityOneCost{ get; }
		int AbilityTwoCost{ get; }
		int AbilityThreeCost{ get; }

		int AbilityOneValue{ get; set; }
		int AbilityTwoValue{ get; set; }
		int AbilityThreeValue{ get; set; }

		void CheckChange( int ability );
	}
}