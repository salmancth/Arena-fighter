using System;
using System.Collections.Generic;


namespace ArenaFighter {
	//Main class for battle
	public class Battle {	
		public Character Player { get; set; }		
		public Character Opponent { get; set; }	
		public Round LastRound { get; set; }		
		public List<Round> Rounds { get; set; }		
		public bool IsFinished { get; private set; } //Is battle complete

		//Battel class constructor
		public Battle(Character player, Character opponent) {
			this.Player = player;
			player.Battles.Add(this);
			this.Opponent = opponent;
			this.IsFinished = false;
		}

		// fight round  of the player 
		public void Fight(bool inputRequired = true) {
			do {
				//run the code for a new round
					FightRound();
					if(inputRequired) { Console.ReadKey(); }
				}		while(!LastRound.IsFinal); // repeat until the battle is done
				this.IsFinished = true;			
			Console.WriteLine("\nThe winner for todays game is -" + this.LastRound.Winner.Name); // and print the name of the winner to the console.
			Console.WriteLine($"{this.LastRound.Winner.Name} is the victorious!");

			if(inputRequired) { Console.ReadKey(); }
		}

		
		public void FightRound(bool rollDice = true) {
			// Create the round, roll the dice etc...
			this.LastRound = new Round(Player, Opponent, rollDice);

			// print the round's data to the console.
			Console.WriteLine("\n--------------");
			this.LastRound.Print();
		}

		//This all Stats about the each round
		public void Print() {
			foreach(var item in Rounds) {
				Console.WriteLine("\n--------------");
				item.Print();
			}
			Console.WriteLine("\n--------------");
			Console.WriteLine($"{this.LastRound.Winner.Name} is the winner for todays game!");
		}
	}
}
