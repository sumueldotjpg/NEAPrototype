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
			POI GenuineSolutions = new POI("Genuine Solutions","Lacking innovation, poor customer service, struggling reputation.",0,new List<int>(){1,2});
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
			Attack BruteForce = new Attack(1,"Brute Force", 1);
			Attack Phishing = new Attack(2, "Phishing", 3);
			Attack Spoofing = new Attack(3, "Spoofing", 4);
			Attack KeyLogger = new Attack(4, "Key Logger" , 6);
			Attack SQLInjection = new Attack(5, "SQL Injection", 7);

			AllObjects.allAttacks.AddRange(new List<Attack>(){BruteForce,Phishing,Spoofing,KeyLogger,SQLInjection});

			//NPCCreation
			Investor investorWinston = new Investor("Winston \"The Wagerer\" Whitman", 2, "Investment Strategy: High-risk, high-reward. Loves to invest in emerging markets and startups.\nBackground: Former gambler turned investor, always seeking the thrill of a successful venture.", 120, 20000, 0.05f);
			Investor investorVictoria = new Investor("Victoria \"Value Maven\" Valdez", 5, "Investment Strategy: Conservative and long-term. Prefers stable, blue-chip stocks and bonds.\nBackground: Finance expert with a knack for predicting market trends. Known for her patience.", 210, 50000, 0.07f);
			Investor investorGordon = new Investor("Gordon \"Growth Guru\" Greene", 8, "Investment Strategy: Focuses on rapid growth opportunities. Enjoys technology and innovative companies.\nBackground: Tech-savvy entrepreneur turned investor, always looking for the next big thing.", 300, 80000, 0.10f);

			IdleNPC idleOlivia = new IdleNPC("Olivia \"The Overtime Overachiever\" Owens", 0, "Role: Works extra hours and contributes to your income during downtime.\nPersonality: Diligent and hardworking. Takes pride in maximizing every moment.", 5, 2000, 1000);
			IdleNPC idleMilo = new IdleNPC("Milo \"The Musician\" Montoya", 3, "Role: Busks on the street, adding to your income with his musical talents.\nPersonality: Free-spirited and artistic. Believes in the power of music to bring joy.", 150, 30000, 30000);
			IdleNPC idleHarper = new IdleNPC("Harper \"The Handy Helper\" Hernandez", 6, "Role: Takes odd jobs and performs small tasks, earning you money.\nPersonality: Helpful and resourceful. Always ready to lend a hand.", 240, 60000, 200000);

			Agent agentXander = new Agent("Xander \"The Shadow\" Xavier", 1, "Role: Operates covertly to reduce your risk of detection.\nBackground: Former intelligence operative. Mysterious and skilled in staying off the radar.", 60, 10000, 0.05f);
			Agent agentZara = new Agent("Zara \"Zero Trace\" Zephyr", 4, "Role: Specializes in erasing digital footprints and maintaining anonymity.\nBackground: Hacker turned agent. Tech-savvy and elusive.", 180, 40000, 0.08f);
			Agent agentDylan = new Agent("Dylan \"The Distraction\" Donovan", 7, "Role: Creates diversions to divert attention away from your activities.\nBackground: Circus-born agent, master of misdirection in covert operations.", 270, 70000, 0.1f);

			AllObjects.allNPC.AddRange(new List<NPC>(){idleOlivia,agentXander,investorWinston,idleMilo,agentZara,investorVictoria,idleHarper,agentDylan,investorGordon});

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
