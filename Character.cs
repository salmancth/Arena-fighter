using System;
using System.Collections.Generic;

using Lexicon.CSharp.InfoGenerator;

namespace ArenaFighter {
	//This is  start of character class
	public class Character {
		
		/// this is C sharp library that is use to gnerate string name and here we create string name
		static public InfoGenerator infoGen = new InfoGenerator(DateTime.Now.Millisecond);

		
		private string name; //name field							
		public string Name  //name field getter
		{
			get {
				return name;
			}
		}

		
		public int Strength { get; set; } //Strength property field										 
		public int Health { get; set; }  //Health property field

		// Health as a string, for display purposes

		public string HealthString
		{
			get {
				if(Health > 0) {
					return Health.ToString();
				} else {
					return "Dead";
				}
			}
		}

		
		// A list of the battles this character has fought
		
		public List<Battle> Battles { get; set; }

		
		// The damage value of this character. Strength divided by 2, rounded down.
		
		public int Damage
		{
			get { return Strength / 2; }
		}

		//check the character is dead or not
		public bool IsDead
		{
			get
			{
				if(Health > 0) {
					return false;
				} else {
					return true;
				}
			}
		}

		//without argument constructor
		public Character() : this("Tester", 8, 8) { }

		//one  argument constructor
		public Character(string name) : this(name, 8, 8) {}

		//three  argument constructor
		public Character(string name, int strength, int health) {
			this.name = name;
			this.Strength = strength;
			this.Health = health;
			this.Battles = new List<Battle>();
		}

		
		//method is use for randomly created characters
		//count is use to how many num of chracters
		//infoGen is the class that is use to randomly string
		public static List<Character> GenerateCharacters(int count) {
			List<Character> characterList = new List<Character>();
			for(int i = 0; i < count; i++) {
				string name = infoGen.NextFirstName();
				name = name.Substring(0, 1).ToUpper() + name.Substring(1);
				characterList.Add(new Character(name, infoGen.Next(1, 10) + 2, infoGen.Next(1, 10) + 2));
			}
			return characterList;
		}

		
		/// Prints the score for this character
		public void ShowScore() {
			int score = 0;
			foreach(var item in Battles) 
			{
				if(item.LastRound.Winner == this) {
					score += 5;
					Console.WriteLine($"{this.Name} fought bravely and killed {item.LastRound.Opponent.Name}.");
				} else {
					score += 2;
					Console.WriteLine($"{this.Name} lost his all energy and after killing many, was killed by {item.LastRound.Opponent.Name}.");
				}
			}
			Console.WriteLine($"{this.Name} Played great today and acheived a total score  {score}.");
		}

	
		// Prints the character's information.
		
		public void Print(bool includeScore = false) 
		{
			Console.WriteLine($"Name of the player: {Name}");
			Console.WriteLine($"Strength of the player: {Strength}");
			Console.WriteLine($"Damage: {Damage}");
			Console.WriteLine($"Health: {HealthString}");

			// if character play any game , show them
			if(includeScore) {
				this.ShowScore();
			}
		}

	}
}
