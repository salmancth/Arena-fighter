using System;
using System.Collections.Generic;


namespace ArenaFighter {
	class Program {
		//main function
		static Random RandomNumberGenerator = new Random();
		static void Main(string[] args) 
		{
			// we get player name
			Console.WriteLine("Write the name of your player");
			string playerName = Console.ReadLine();



			// Now create the character object 
			//use random class infoGen to produce random num for strength and health
			Character player = new Character(playerName, Character.infoGen.Next(1, 10) + 2, Character.infoGen.Next(1, 10) + 2);

			//  The game will offer 20 game chance for the player. So we create the  20 randomly generated opponents that the player will fight, and store them in a list
			List<Character> Opponents = Character.GenerateCharacters(20);
			
			Console.Clear(); // Clear the screen 

			/* Here we start the game loop.
			This will keep running until the player dies or retires. */
			bool isRunning = true;
			while(isRunning) 
			{
				// Print the player's information and the options they can take.
				player.Print();

				Console.WriteLine("\nHi " + playerName + ", Do you want to fight? \nPlease press F for fight or R for retire.");
			
				// When a key is pressed, either fight with an available opponent or Retire the player from fighting
				ConsoleKeyInfo cki = Console.ReadKey(true);
				//ConsoleKeyIfo is struct system that can tell which key is press 
				switch(cki.Key) 
				{
					case ConsoleKey.F:
						
						if(Opponents.Count > 0) {
							//Clear the screen, and print both characters' stats
							Console.Clear();
							Character opponent = Opponents[0];

							Console.WriteLine("\nPlayer:");
							player.Print();

							Console.WriteLine("\nOpponent:");
							opponent.Print();

							// fight is initiated
							Console.ReadKey(true);

							// Create the battle 
							Battle battle = new Battle(player, opponent);

							// Start the fight.
							battle.Fight();

							/*
							When fight is complete check who is dead.
							*/
							if(opponent.IsDead) {
								//this line remove the opponent from the list
								Opponents.Remove(opponent);
							} else if (player.IsDead) {
								isRunning = false;
							}
						} else {
							// End the game if no one to fight
							Console.WriteLine("There is no one left alive. You monster!");
							isRunning = false;
							Console.ReadKey(true);
						}
						break;
					case ConsoleKey.R:

						//if Retiring, End the game
						Console.WriteLine("You have ended the violence by not fighting.");
						isRunning = false;
						Console.ReadKey(true);
						break;
					default:
						break;
				}
				Console.Clear();
			}
			// Now the system shows the scoreboard as game ended.
			Console.WriteLine("Final Statistics:\n");
			player.Print(includeScore: true);

			Console.ReadKey();

            
		}
	}
}
