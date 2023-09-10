using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Variables;

namespace Main
{
	public class MainCreation
	{
		public static void Load()
		{			
			//POI Creation
			AllObjects.allPOIs.Add(new POI("Google","Invades privacy, knows too much, and tracks your life.",1));
			AllObjects.allPOIs.Add(new POI("Microsoft","Cluttered software, endless updates, and constant crashes",2));
			AllObjects.allPOIs.Add(new POI("Apple","Sells shiny gadgets, forces you to buy their ecosystem.",3));
			AllObjects.allPOIs.Add(new POI("Amazon","Delivers everything, destroys local businesses, and work ethics.",4));
			AllObjects.allPOIs.Add(new POI("Meta","Wastes time, promotes envy, and spreads fake connections.",5));
			AllObjects.allPOIs.Add(new POI("Samsung","Overpriced devices, bloatware, and endless pre-installed apps",6));
			AllObjects.allPOIs.Add(new POI("Intel","Sluggish innovation, overheating CPUs, and relentless fan noise.",7));
			AllObjects.allPOIs.Add(new POI("IBM","Dinosaur of tech, barely relevant, labyrinthine products and services.",8));
			AllObjects.allPOIs.Add(new POI("Uber","Exploits drivers, surge pricing, surge of bad publicity.",9));
			AllObjects.allPOIs.Add(new POI("Adobe","Subscription trap for basic software, endless security vulnerabilities.",10));
			AllObjects.allPOIs.Add(new POI("AMD","Riding on Intel's coattails, occasional performance bursts, chip instability.",11));
			AllObjects.allPOIs.Add(new POI("Tesla","Overhyped electric cars, questionable self-driving claims, stock market circus.",12));
			AllObjects.allPOIs.Add(new POI("Nvidia","Pricey graphics cards, mining frenzy enabler, gaming elitism symbol.",13));

			//PuzzleCreation
			AllObjects.allPuzzles.Add(new Puzzle(1,"What is this? \nTravel\n----------\nCCCCC","travel over seas"));

			//NPCCreation
			AllObjects.allNPC.Add(new Agent("Agent Siaros", 1, 30));
			AllObjects.allNPC.Add(new IdleNPC("Slow Thomas", 2, 500, 2000));

			//UpgradeCreation
			AllObjects.allUpgrades.Add(new Upgrade(1,"Increases rewards by 50%", 50000));
			AllObjects.allUpgrades.Add(new Upgrade(2,"Reduces the cooldown on NPCs", 100000));
		}
	}
}
