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
			POI GenuineSolutions = new POI("GenuineSolutions","Lacking innovation, poor customer service, struggling reputation.",0,new List<int>(){1,2});
			POI Google = new POI("Google","Invades privacy, knows too much, and tracks your life.",1,new List<int>(){4,5});
			POI Microsoft = new POI("Microsoft","Cluttered software, endless updates, and constant crashes",2,new List<int>(){3,12});
			POI Apple = new POI("Apple","Sells shiny gadgets, forces you to buy their ecosystem.",3,new List<int>(){8});
			POI Amazon = new POI("Amazon","Delivers everything, destroys local businesses, and work ethics.",4,new List<int>(){7});
			POI Meta = new POI("Meta","Wastes time, promotes envy, and spreads fake connections.",5,new List<int>(){6,13});
			POI Samsung = new POI("Samsung","Overpriced devices, bloatware, and endless pre-installed apps",6,new List<int>(){11});
			POI Intel = new POI("Intel","Sluggish innovation, overheating CPUs, and relentless fan noise.",7,new List<int>(){9,14});
			POI IBM = new POI("IBM","Dinosaur of tech, barely relevant, labyrinthine products and services.",8,new List<int>(){10});
			POI Uber = new POI("Uber","Exploits drivers, surge pricing, surge of bad publicity.",9,new List<int>(){11});
			POI Adobe = new POI("Adobe","Subscription trap for basic software, endless security vulnerabilities.",10,new List<int>(){11});
			POI WorldWideWeb = new POI("WorldWideWeb","Widespread Misinformation, Privacy Concerns, The Final Boss",11,new List<int>(){});
			FarmingPOI AMD = new FarmingPOI("AMD","Riding on Intel's coattails, occasional performance bursts, chip instability.",12,new List<int>(){},60,1000);
			FarmingPOI Tesla = new FarmingPOI("Tesla","Overhyped electric cars, questionable self-driving claims, stock market circus.",13,new List<int>(){},300,50000);
			FarmingPOI Nvidia = new FarmingPOI("Nvidia","Pricey graphics cards, mining frenzy enabler, gaming elitism symbol.",14,new List<int>(){},600,2000000);

			AllObjects.allPOIs.AddRange(new List<POI>(){GenuineSolutions,Google,Microsoft,Apple,Amazon,Meta,Samsung,Intel,IBM,Uber,Adobe,WorldWideWeb,AMD,Tesla,Nvidia});

			//PuzzleCreation
			AllObjects.allPuzzles.Add(new Puzzle(1,"What is this? \nTravel\n----------\nCCCCC","travel over seas"));

			//NPCCreation
			AllObjects.allNPC.Add(new Agent("Agent Siaros", 1, 30));
			AllObjects.allNPC.Add(new IdleNPC("Slow Thomas", 2, 500, 2000));

			//UpgradeCreation
			AllObjects.allUpgrades.Add(new Upgrade(1,"Increases rewards by 50%", 50000));
			AllObjects.allUpgrades.Add(new Upgrade(2,"Reduces the cooldown on NPCs", 100000));

			//LoadProfiles
			SaveManager.LoadProfiles();

			GD.Print(AllObjects.allProfiles.Count);
		}
	}
}
