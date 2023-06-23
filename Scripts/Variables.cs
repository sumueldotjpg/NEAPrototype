using Godot;
using System;
using System.Collections.Generic;

namespace Variables
{
	public static class AllObjects
	{
		public static List<Puzzle> allPuzzles { get; private set; }
		public static List<SaveProfile> allProfiles { get; private set; }
		public static List<NPC> allNPC  { get; private set; }
		public static List<POI> allPOIs  = new List<POI> {};
		public static List<Upgrades> allUpgrades { get; private set; }
	}
	public class SaveProfile
	{
		public int moneyBalance { get; private set; }
		public List<POI> unlockedPOIs { get; private set; }
		public List<NPC> unlockedNPCs { get; private set; }
		public List<Upgrades> unlockedUpgrades { get; private set; }

	}
	public class Puzzle
	{
		public int puzzleId { get; private set; }
		public string outPut { get; private set; }
		public Puzzle(int puzzleid, string output)
		{
			puzzleId = puzzleid;
			output = outPut;
		}
	}
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
	public class POI
	{
		public string name {get; private set;}
		public string description {get; private set;}
		public int puzzleId { get; private set; }
		public bool isUnlocked {get; private set;}
		public POI(string Name, string Description, int PuzzleId)
		{
			name = Name;
			description = Description;
			puzzleId = PuzzleId;
			isUnlocked = false;
		}
	}
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