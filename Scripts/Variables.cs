using Godot;
using System;
using System.Collections.Generic;

namespace Variables
{
	/// <summary>
	/// Stores all objects in lists
	/// </summary>
	public class AllObjects
	{
		public static List<Puzzle> allPuzzles { get; private set; } = new List<Puzzle>{};
		public static List<SaveProfile> allProfiles { get; private set; } = new List<SaveProfile>{};
		public static List<NPC> allNPC  { get; private set; } = new List<NPC>{};
		public static List<POI> allPOIs  { get; private set; } = new List<POI>{};
		public static List<Upgrades> allUpgrades { get; private set; } = new List<Upgrades>{};
	}
	/// <summary>
	///Profile for storing game save data
	/// </summary>
	public class SaveProfile
	{
		public int moneyBalance { get; private set; }
		public List<POI> unlockedPOIs { get; private set; }
		public List<NPC> unlockedNPCs { get; private set; }
		public List<Upgrades> unlockedUpgrades { get; private set; }

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
		public string npcName { get; private set; }
		public int npcId { get; private set; }
		public int actionTime { get; private set; }
		public bool isUnlocked {get; private set;}
		public NPC(string npcname,int  npcid, int actiontime)
		{
			npcName = npcname;
			npcId = npcid;
			actionTime = actiontime;
			isUnlocked = false;
		}
		public void NPCAction()
		{
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
	public class Upgrades
	{
		public int upgradeID { get; private set; }
		public string description { get; private set; }
		public int cost { get; private set; }
		public int level { get; private set; }
		public bool isUnlocked {get; private set;}

		public Upgrades(int upgradeid, string Description, int Cost)
		{
			upgradeID = upgradeid;
			description = Description;
			cost = Cost;
			level = 1;
			isUnlocked = false;
		}
	}
}