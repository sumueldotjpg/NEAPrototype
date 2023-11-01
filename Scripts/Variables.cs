using Godot;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Variables
{
	//(MONEYMADE-UTILITYCOSTS)*NPCMULTIPLIERS = MONEYADDEDPERSECOND
	/// <summary>
	/// Stores all objects in lists
	/// </summary>
	public class AllObjects
	{
		public static List<Puzzle> allPuzzles { get; private set; } = new List<Puzzle>{};
		public static List<SaveProfile> allProfiles { get; private set; } = new List<SaveProfile>{};
		public static List<NPC> allNPC  { get; private set; } = new List<NPC>{};
		public static List<POI> allPOIs  { get; private set; } = new List<POI>{};
		public static List<Upgrade> allUpgrades { get; private set; } = new List<Upgrade>{};

		public static SaveProfile CurrentProfile { get; private set; } = new SaveProfile("ProfileNotLoaded",-337,-337,null,null,null);

		public static void ProfileLoad(List<SaveProfile> allSaveProfiles)
		{
			allProfiles = allSaveProfiles;
		}

		public static void SetCurrentProfile(SaveProfile current)
		{
			CurrentProfile = current;
		}
	}
	/// <summary>
	///Profile for storing game save data
	/// </summary>
	public class SaveProfile
	{
		public string Title { get; private set; }
		public int MoneyBalance { get; private set; }
		public int DetectionPercentage { get; private set; }
		public List<POI> UnlockedPOIs { get; private set; }
		public List<NPC> UnlockedNPCs { get; private set; }
		public List<Upgrade> UnlockedUpgrades { get; private set; }
		
		public SaveProfile(string title, int moneybalance, int detectionpercentage, List<POI> unlockedpois, List<NPC> unlockednpcs, List<Upgrade> unlockedupgrades)
		{
			Title = title;
			MoneyBalance = moneybalance;
			DetectionPercentage = detectionpercentage;
			UnlockedPOIs = unlockedpois;
			UnlockedNPCs = unlockednpcs;
			UnlockedUpgrades = unlockedupgrades;
		}
		public void SetTitle(string title)
		{
			Title = title;
		}

		public void AddMoney(int amount)
		{
			MoneyBalance += amount;
		}

		public void RemoveMoney(int amount)
		{
			MoneyBalance -= amount;
		}
		public void DetectionDecrease(int amount)
		{
			DetectionPercentage -= DetectionPercentage * amount;
		}
	}
	/// <summary>
	///Game Puzzles
	/// </summary>
	public class Puzzle
	{
		public int PuzzleId { get; private set; }
		public string Question { get; private set; }
		public string Answer { get; private set; }
		public Puzzle(int puzzleid, string question, string answer)
		{
			PuzzleId = puzzleid;
			Question = question;
			Answer = answer;
		}
		/// <summary>
		/// Gets the puzzle
		/// </summary>
		public static Puzzle GetPuzzle(string poiName)
		{
			POI currentPOI = POI.GetPOI(poiName);
			foreach(Puzzle puzzle in AllObjects.allPuzzles)
			{
				if (currentPOI.Id == puzzle.PuzzleId)
				{
					return puzzle;
				}
			}
			throw new Exception("Puzzle Not Found");
		}
	} 
	/// <summary>
	///NPC's that help the player
	/// <summary>
	public class NPC
	{
		public string NpcName { get; protected set; }
		public int NpcId { get; protected set; }
		public string Description { get; protected set; }
		public int ActionTime { get; protected set; }
		public bool IsUnlocked {get; protected set;}
		public NPC(string npcname,int npcid, string description, int actiontime)
		{
			NpcName = npcname;
			NpcId = npcid;
			Description = description;
			ActionTime = actiontime;
			IsUnlocked = false;
		}
		public virtual void NPCAction()
		{
		}
	}

	public class Investor : NPC
	{
		public int InvestPercent {get; private set; }
		public int CurrentNetWorth {get; private set; }
		public Investor(string npcname, int npcid, string description, int actiontime, int investpercent) : base(npcname, npcid, description, actiontime)
		{
			NpcName = npcname;
			NpcId = npcid;
			ActionTime = actiontime;
			IsUnlocked = false;

			InvestPercent = investpercent;
		}
		public override void NPCAction()
		{
			Random investProfit = new Random();
			bool sell = true;
			int moneyInvested = 0;
			//Invests the percentage of money set
			if (sell)
			{
				moneyInvested = AllObjects.CurrentProfile.MoneyBalance*InvestPercent;
				AllObjects.CurrentProfile.RemoveMoney(moneyInvested);
			}
			//Returns the money invested with a 0.7-15 multiplier 
			else
			{
				AllObjects.CurrentProfile.AddMoney(moneyInvested*(investProfit.Next(7,15)/10));
			}
		}
	}
	public class IdleNPC : NPC
	{
		public int EarnRate {get; private set;}
		public IdleNPC(string npcname,int npcid, string description, int actiontime, int earnrate) : base(npcname, npcid, description, actiontime)
		{
			NpcName = npcname;
			NpcId = npcid;
			ActionTime = actiontime;
			IsUnlocked = false;

			EarnRate = earnrate; 
		}

        public override void NPCAction()
        {
			//Pays player every NPCAction
            AllObjects.CurrentProfile.AddMoney(EarnRate);
        }
    }
	public class Agent : NPC
	{
		public int DecreaseDetectionRate {get; private set;}
		public Agent(string npcname,int npcid, string description, int actiontime, int DecreaseDetectionRate) : base(npcname, npcid, description, actiontime)
		{
			NpcName = npcname;
			NpcId = npcid;
			ActionTime = actiontime;
			IsUnlocked = false;
		}

        public override void NPCAction()
        {
			//Decrease the progress of getting detected
            AllObjects.CurrentProfile.DetectionDecrease(DecreaseDetectionRate);
        }
    }

	/// <summary>
	///Points of interest on the globe
	/// </summary>
	public class POI
	{
		public string Name {get; private set;}
		public string Description {get; private set;}
		public int Id { get; private set; }
		public bool IsUnlocked {get; private set;}
		public POI(string name, string description, int puzzleid)
		{
			Name = name;
			Description = description;
			Id = puzzleid;
			IsUnlocked = false;
		}
		public static POI GetPOI(string poiName)
		{
			foreach(POI poi in AllObjects.allPOIs)
			{
				if (poi.Name.ToLower() == poiName.ToLower())
				{
					return poi;
				}
			}
			GD.Print(poiName);
			throw new Exception("There isnt any POIs with that name");
		}
		public static POI GetPOIwID(int poiID)
		{
			foreach(POI poi in AllObjects.allPOIs)
			{
				if (poi.Id == poiID)
				{
					return poi;
				}
			}
			GD.Print(poiID);
			throw new Exception("There isnt any POIs with that ID");
		}
		public static void UnlockPOI(POI poi)
		{
			poi.IsUnlocked = false;
		}
	}
	public class FarmingPOI : POI
	{
		public int Cooldown {get; private set;}
		public int Reward {get; private set;}
		public FarmingPOI(string name, string description, int puzzleid, int cooldown, int reward) :  base(name, description, puzzleid)
		{
			Cooldown = cooldown;
			Reward = reward;
		}
		public void Payout()
		{
			AllObjects.CurrentProfile.AddMoney(Reward);
		}
	}
	/// <summary>
	///Help speed up gameplay
	/// </summary>
	public class Upgrade
	{
		public int upgradeID { get; private set; }
		public string description { get; private set; }
		public int cost { get; private set; }
		public int level { get; private set; }
		public bool isUnlocked {get; private set;}

		public Upgrade(int upgradeid, string Description, int Cost)
		{
			upgradeID = upgradeid;
			description = Description;
			cost = Cost;
			level = 1;
			isUnlocked = false;
		}
	}
}                                