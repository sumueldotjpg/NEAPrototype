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
			POI Microsoft = new POI("Microsoft","Cluttered software, endless updates, and constant crashes",1,new List<int>(){3,12});
			POI Apple = new POI("Apple","Sells shiny gadgets, forces you to buy their ecosystem.",3,new List<int>(){8});
			POI Amazon = new POI("Amazon","Delivers everything, destroys local businesses, and work ethics.",3,new List<int>(){7});
			POI Meta = new POI("Meta","Wastes time, promotes envy, and spreads fake connections.",3,new List<int>(){6,13});
			POI Samsung = new POI("Samsung","Overpriced devices, bloatware, and endless pre-installed apps",6,new List<int>(){11});
			POI Intel = new POI("Intel","Sluggish innovation, overheating CPUs, and relentless fan noise.",5,new List<int>(){9,14});
			POI IBM = new POI("IBM","Dinosaur of tech, barely relevant, labyrinthine products and services.",5,new List<int>(){10});
			POI Uber = new POI("Uber","Exploits drivers, surge pricing, surge of bad publicity.",7,new List<int>(){11});
			POI Adobe = new POI("Adobe","Subscription trap for basic software, endless security vulnerabilities.",7,new List<int>(){11});
			POI WorldWideWeb = new POI("WorldWideWeb","Widespread Misinformation, Privacy Concerns, The Final Boss",10,new List<int>(){});
			FarmingPOI AMD = new FarmingPOI("AMD","Riding on Intel's coattails, occasional performance bursts, chip instability.",3,new List<int>(){},60,1000);
			FarmingPOI Tesla = new FarmingPOI("Tesla","Overhyped electric cars, questionable self-driving claims, stock market circus.",5,new List<int>(){},300,50000);
			FarmingPOI Nvidia = new FarmingPOI("Nvidia","Pricey graphics cards, mining frenzy enabler, gaming elitism symbol.",7,new List<int>(){},600,2000000);

			AllObjects.allPOIs.AddRange(new List<POI>(){GenuineSolutions,Google,Microsoft,Apple,Amazon,Meta,Samsung,Intel,IBM,Uber,Adobe,WorldWideWeb,AMD,Tesla,Nvidia});

			//AttackCreation
			Attack Phishing = new Attack(1,"Phishing", 5, 1);
			Attack Spoofing = new Attack(2, "Spoofing", 10000, 2);

			AllObjects.allAttacks.AddRange(new List<Attack>(){Phishing,Spoofing});

			//NPCCreation
			AllObjects.allNPC.Add(new Agent("Agent Siaros", 1, "Agent Siaros will keep the cops at bay and slowly decrease the chance of you being discovered", 3000, 0.05f));
			AllObjects.allNPC.Add(new IdleNPC("Slow Thomas", 2, "Slow Thomas will get you some money kind of slowly", 500, 1000000));

			//UpgradeCreation
			EconomyUpgrade EconomyUpgrade = new EconomyUpgrade(1, 10000, 0);
			HackingUpgrade HackingUpgrade = new HackingUpgrade(2, 20000, 0);
			NPCUpgrade NPCUpgrade = new NPCUpgrade(3, 30000, 0);
			VirusUpgrade VirusUpgrade = new VirusUpgrade(4, 40000, 0);

			AllObjects.allUpgrades.AddRange(new List<Upgrade>() {EconomyUpgrade,HackingUpgrade,NPCUpgrade,VirusUpgrade});

			//LoadProfiles
			SaveManager.LoadProfiles();
		}
	}
}
