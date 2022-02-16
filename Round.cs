using System;

//Name if the game
namespace ArenaFighter {
	//The name of the class for round of fight 
	public class Round { 		
		static Random RandomNumberGenerator = new Random(); //Create the random class object
				
		public int RollDice             //Rolldice attribute
		{                               
									
			get { return RandomNumberGenerator.Next(1, 7); }    //generate Random number from 1 to 6
		}

		public Character Player { get; set; } 		//Player property field		
		public Character Opponent { get; set; }     //Opponent property field													
		public Character Winner { get; set; }       //winner property field 													
		public Character Loser { get; set; }        //loser property field 		
		public int PlayerRoll { get; set; }         //PlayerRoll property field 													
		public int OpponentRoll { get; set; }       //OpponentRoll property field

		//IsDraw  property field and check the round is draw or not
		public bool IsDraw { get; set; }
		//IsFinal property field and check is this final round
		public bool IsFinal { get; set; }

		// Round class constructor
		 public Round(Character player, Character opponent, bool rollDice = true) {
			//start by setting the initial values
			this.Player = player;
			this.Opponent = opponent;
			this.IsDraw = false;
			this.IsFinal = false;

			// if dice should be rolled, do so. Otherwise, just set the dice rolls to 0
			if (rollDice)
			{
				this.PlayerRoll = RollDice;
			}
			else {
				this.OpponentRoll = 0;
			}
			if (rollDice)
			{
				this.OpponentRoll = RollDice;
			}
			else
			{
				this.PlayerRoll = 0;
			}
			

			if((player.Strength + PlayerRoll) > (opponent.Strength + OpponentRoll)) {
				// if the player is stronger, then the player wins.
				this.Winner = player;
				this.Loser = opponent;
			} else if((player.Strength + PlayerRoll) == (opponent.Strength + OpponentRoll)) {
				// if the characters are evenly matched, it's a draw.
				this.IsDraw = true;
			} else {
				// if the opponent is stronger, then the opponent wins.
				this.Winner = opponent;
				this.Loser = player;
			}

			// If the round isn't a draw, deal damage to the loser.
			if(!this.IsDraw) { this.Loser.Health -= this.Winner.Damage; }

			// If one of the combatants are dead after damage has been dealt, mark this as the final round.
			if(player.IsDead || opponent.IsDead) { this.IsFinal = true; }
		}

		
		//print details of round
		public void Print() {
			Console.WriteLine($"Rolls: {Player.Name} {Player.Strength + PlayerRoll} ({Player.Strength}+{PlayerRoll}) vs "+
				$"{Opponent.Name} {Opponent.Strength + OpponentRoll} ({Opponent.Strength}+{OpponentRoll})");
			if(this.IsDraw) {
				Console.WriteLine("Evenly matched, the combatants circle each other, looking for a better opportunity.");
			} else {
				//terinatery condition for colour
				if (Winner == Player) {
					Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
					Console.ForegroundColor = ConsoleColor.Red;
				}
				
				Console.WriteLine($"{Winner.Name} attacks {Loser.Name}! {Loser.Name} takes {Winner.Damage} damage{((Loser.IsDead)?", and falls to the ground, dead":"")}.");
				//this line again change colour to black
				Console.ResetColor();
			}
			Console.WriteLine($"Remaining Health: {Player.Name} ({Player.HealthString}), {Opponent.Name} ({Opponent.HealthString})");
		}
	}
}