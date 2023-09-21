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
			AllObjects.allPOIs.Add(new POI("GenuineSolutions","Lacking innovation, poor customer service, struggling reputation.",0));
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
			AllObjects.allPOIs.Add(new POI("WorldWideWeb","Widespread Misinformation, Privacy Concerns, The Final Boss",11));
			AllObjects.allPOIs.Add(new FarmingPOI("AMD","Riding on Intel's coattails, occasional performance bursts, chip instability.",12,60,1000));
			AllObjects.allPOIs.Add(new FarmingPOI("Tesla","Overhyped electric cars, questionable self-driving claims, stock market circus.",13,300,50000));
			AllObjects.allPOIs.Add(new FarmingPOI("Nvidia","Pricey graphics cards, mining frenzy enabler, gaming elitism symbol.",14,600,2000000));

			//POITree Creation
			TreeNode GenuineSolutions = new TreeNode(new List<int>(){1,2},1);
			TreeNode Google = new TreeNode(new List<int>(){4,5},2);
			TreeNode Microsoft = new TreeNode(new List<int>(){3,12},3);
			TreeNode Apple = new TreeNode(new List<int>(){8},3);
			TreeNode Amazon = new TreeNode(new List<int>(){7},4);
			TreeNode Meta = new TreeNode(new List<int>(){6,13},5);
			TreeNode Samsung = new TreeNode(new List<int>(){11},6);
			TreeNode Intel = new TreeNode(new List<int>(){9,14},7);
			TreeNode IBM = new TreeNode(new List<int>(){10},8);
			TreeNode Uber = new TreeNode(new List<int>(){11},9);
			TreeNode Adobe = new TreeNode(new List<int>(){11},10);
			TreeNode WorldWideWeb = new TreeNode(new List<int>(){},11);
			TreeNode AMD = new TreeNode(new List<int>(){},12);
			TreeNode Tesla = new TreeNode(new List<int>(){},13);
			TreeNode Nvidia = new TreeNode(new List<int>(){},14);

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
