using Godot;
using System;
using System.Collections.Generic;

namespace Variables
{
	(MONEYMADE-UTILITYCOSTS)*NPCMULTIPLIERS = MONEYADDEDPERSECOND
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
	}
	/// <summary>
	///Profile for storing game save data
	/// </summary>
	public class SaveProfile
	{
		public string Title { get; private set; }
		public int MoneyBalance { get; private set; }
		public List<POI> UnlockedPOIs { get; private set; }
		public List<NPC> UnlockedNPCs { get; private set; }
		public List<Upgrade> UnlockedUpgrades { get; private set; }
		
		public SaveProfile(string title, int moneybalance, List<POI> unlockedpois, List<NPC> unlockednpcs, List<Upgrade> unlockedupgrades)
		{
			Title = title;
			MoneyBalance = moneybalance;
			UnlockedPOIs = unlockedpois;
			UnlockedNPCs = unlockednpcs;
			UnlockedUpgrades = unlockedupgrades;
		}
		public void SetTitle(string title)
		{
			Title = title;
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
				if (currentPOI.PuzzleId == puzzle.PuzzleId)
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
		public string NpcName { get; private set; }
		public int NpcId { get; private set; }
		public int ActionTime { get; private set; }
		public bool IsUnlocked {get; private set;}
		public NPC(string npcname,int  npcid, int actiontime)
		{
			NpcName = npcname;
			NpcId = npcid;
			ActionTime = actiontime;
			IsUnlocked = false;
		}
		public virtual void NPCAction()
		{
		}
	}

	public class Investor : NPC
	{
		public int InvestAmount {get; private set; }
		public int CurrentNetWorth {get; private set; }
		public Investor(string npcname,int npcid, int actiontime, int investamount)
		{
			NpcName = npcname;
			NpcId = npcid;
			ActionTime = actiontime;
			IsUnlocked = false;

			InvestAmount = investamount;
		}

		public override void NPCAction()
		{
			//buy equivelant of {invest amount} or sell all crypto owned 
		}
	}
	public class IdleNPC : NPC
	{
		public int EarnRate {get; private set;}
		public IdleNPC(string npcname,int npcid, int actiontime, int earnrate)
		{
			NpcName = npcname;
			NpcId = npcid;
			ActionTime = actiontime;
			IsUnlocked = false;

			EarnRate = earnrate; 
		}
	}
	/// <summary>
	///Points of interest on the globe
	/// </summary>
	public class POI
	{
		public string Name {get; private set;}
		public string Description {get; private set;}
		public int PuzzleId { get; private set; }
		public bool IsUnlocked {get; private set;}
		public POI(string name, string description, int puzzleid)
		{
			Name = name;
			Description = description;
			PuzzleId = puzzleid;
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
			throw new Exception("There isnt any POIs with that name");
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
