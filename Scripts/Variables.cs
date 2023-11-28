using Godot;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Globalization;

namespace Variables
{
	//(MONEYMADE-UTILITYCOSTS)*NPCMULTIPLIERS = MONEYADDEDPERSECOND
	/// <summary>
	/// Stores all objects in lists
	/// </summary>
	public class AllObjects
	{
		public static List<SaveProfile> allProfiles { get; private set; } = new List<SaveProfile>{};
		public static List<NPC> allNPC  { get; private set; } = new List<NPC>{};
		public static List<POI> allPOIs  { get; private set; } = new List<POI>{};
		public static List<Attack> allAttacks { get; private set;} = new List<Attack>{};
		public static List<Upgrade> allUpgrades { get; private set; } = new List<Upgrade>{};

		public static SaveProfile CurrentProfile { get; private set; } = new SaveProfile("ProfileNotLoaded",-337,-337,null,null,null,null);

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
		public List<Upgrade> UpgradeLevels { get; private set; }
		public List<Attack> UnlockedAttacks { get; private set;}
        public List<Multiplier> Multipliers { get; private set;}

        public SaveProfile(string title, int moneybalance,int detectionpercentage, List<POI> unlockedpois, List<NPC> unlockednpcs, List<Upgrade> upgradelevels, List<Attack> unlockedattacks)
		{
			Title = title;
			MoneyBalance = moneybalance;
			DetectionPercentage = detectionpercentage;
			UnlockedPOIs = unlockedpois;
			UnlockedNPCs = unlockednpcs;
			UpgradeLevels = upgradelevels;
			UnlockedAttacks = unlockedattacks;
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
		public void DetectionDecrease(float amount)
		{
			DetectionPercentage -= Convert.ToInt32(DetectionPercentage * amount);
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
		public float InvestPercent {get; private set; }
		public int CurrentNetWorth {get; private set; }
		public Investor(string npcname, int npcid, string description, int actiontime, float investpercent) : base(npcname, npcid, description, actiontime)
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
				moneyInvested = Convert.ToInt32(AllObjects.CurrentProfile.MoneyBalance*InvestPercent);
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
		public float DecreaseDetectionRate {get; private set;}
		public Agent(string npcname,int npcid, string description, int actiontime, float DecreaseDetectionRate) : base(npcname, npcid, description, actiontime)
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
		public int BaseStrength { get; private set;}
		public bool IsUnlocked {get; private set;}
		public List<int> Children {get; private set;}
		public POI(string name, string description, int basestrength, List<int> children)
		{
			Name = name;
			Description = description;
			BaseStrength = basestrength;
			Children = children;
			if (Name == "GenuineSolutions")
			{
				IsUnlocked = true;
			}
			else
			{
				IsUnlocked = false;
			}
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
		public void Unlock()
		{
			IsUnlocked = true;
			AllObjects.CurrentProfile.UnlockedPOIs.Add(this);
		}
		public int GetStrength()
		{
			int strength = this.BaseStrength;
			foreach (Multiplier multiplier in AllObjects.CurrentProfile.Multipliers)
			{
				if (multiplier.MultiplierType=="POISTRENGTH")
				{
					strength += (int)multiplier.MultiplierAmount;
				}
			}
			return strength;
		}
	}
	public class FarmingPOI : POI
	{
		public int Cooldown {get; private set;}
		public int Reward {get; private set;}
		public FarmingPOI(string name, string description, int strength, List<int> children, int cooldown, int reward) :  base(name, description, strength, children)
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
		public int UpgradeID { get; private set; }
		public string Description { get; protected set; }
		
		//To calculate cost of Upgrade ==> OriginalBaseCost * (e^Level)
		//So in order to get cost later on ===> CurrentCost / (e^Level-1) == OriginalBaseCost
		//Then OriginalBaseCost * (e^Level)
		//In total the formula is NewCost = OldCost / (e^-1)
		public int BaseCost { get; protected set; }
		public int Level { get; protected set; }

		public Upgrade(int upgradeid, string description, int basecost)
		{
			UpgradeID = upgradeid;
			Description = description;
			BaseCost = basecost;
			Level = 0;
		}
		
		public virtual void IncreaseLevel()
		{
			Level += 1;
		
			BaseCost = BaseCost*((int)Math.E);
			
			if (Level == 0)
			{
				//Original Base Values
			}
			else if(0 < Level && Level < 5)
			{
				//Formula for upgrading values
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = "";
		}
	}
	/// <summary>
	/// Economy upgrade that multiplies amount earned every tick
	/// </summary>
	public class EconomyUpgrade : Upgrade
	{
		public float IncomeIncrease {get; private set;}
		public EconomyUpgrade(int upgradeid, string description, int basecost) : base(upgradeid, description, basecost)
		{
			
		}
		public override void IncreaseLevel()
		{
			Level += 1;

			BaseCost = BaseCost*((int)Math.E);

			if (Level == 0)
			{
				AllObjects.CurrentProfile.Multipliers.Add(new Multiplier("INCOMEINCREASE",0.3f));
			}
			else if(0 < Level && Level < 5)
			{
				foreach(Multiplier multiplier in AllObjects.CurrentProfile.Multipliers)
				{
					if(multiplier.MultiplierAmount == Level-1 * 0.3f && multiplier.MultiplierType == "INCOMEINCREASE")
					{
						multiplier.ChangeMultiplierAmount(Level * 0.3f);
					}
				}
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is an economy upgrade to increase your money earnt.\nCurrent Level: {Level}\nCost to Upgrade: {BaseCost}";
		}
	}
	/// <summary>
	/// Hacking upgrade that increases the strength of attacks
	/// </summary>
	public class HackingUpgrade : Upgrade
	{
		public int StrengthIncrease {get; private set;}
		public HackingUpgrade(int upgradeid, string description, int basecost, int strengthincrease) : base(upgradeid, description, basecost)
		{
			StrengthIncrease = strengthincrease;
		}
		public override void IncreaseLevel()
		{
			Level += 1;
		
			BaseCost = BaseCost*((int)Math.E);

			if (Level == 0)
			{
				//Original Base Values
			}
			else if(0 < Level && Level < 5)
			{
				//Formula for upgrading values
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is a hacking upgrade to do smthn.\nCurrent Level: {Level}\nCost to Upgrade: {BaseCost}";
		}
	}
	public class NPCUpgrade : Upgrade
	{
		public float ActionDecrease {get; private set;}
		public NPCUpgrade(int upgradeid, string description, int basecost, float actiondecrease) : base(upgradeid, description, basecost)
		{
		
		}
		public override void IncreaseLevel()
		{
			Level += 1;
		
			BaseCost = BaseCost*((int)Math.E);

			if (Level == 0)
			{
				//Original Base Values
			}
			else if(0 < Level && Level < 5)
			{
				//Formula for upgrading values
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is an NPC upgrade to descrease the action time of your NPCs.\nCurrent Level: {Level}\nCost to Upgrade: {BaseCost}";
		}
	}
	public class VirusUpgrade : Upgrade
	{
		public int StrengthIncrease {get; private set;}
		public VirusUpgrade(int upgradeid, string description, int basecost, int strengthincrease) : base(upgradeid, description, basecost)
		{
			
		}
		public override void IncreaseLevel()
		{
			Level += 1;
		
			BaseCost = BaseCost*((int)Math.E);
			
			if (Level == 0)
			{
				AllObjects.CurrentProfile.Multipliers.Add(new Multiplier("ATTACKSTRENGTH",1));
			}
			else if(0 < Level && Level < 5)
			{
				foreach(Multiplier multiplier in AllObjects.CurrentProfile.Multipliers)
				{
					if(multiplier.MultiplierAmount == Level-1 * 0.3f && multiplier.MultiplierType == "ATTACKSTRENGTH")
					{
						multiplier.ChangeMultiplierAmount(Level);
					}
				}
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is a virus upgrade to increase the strength of your attacks.\nCurrent Level: {Level}\nCost to Upgrade: {BaseCost}";
		}
	}
	
    public class Attack
	{
		public int AttackID { get; private set; }
		public string Name { get; private set; }
		public int Cost { get; private set; }
		public int BaseStrength { get; private set;}
		public bool IsUnlocked { get; private set;}
		public Attack(int attackid, string name, int cost, int basestrength)
		{
			AttackID = attackid;
			Name = name;
			Cost = cost;
			BaseStrength = basestrength;
			IsUnlocked = false;
		}
		public int GetStrength()
		{
			int strength = this.BaseStrength;
			foreach (Multiplier multiplier in AllObjects.CurrentProfile.Multipliers)
			{
				if (multiplier.MultiplierType=="ATTACKSTRENGTH")
				{
					strength += (int)multiplier.MultiplierAmount;
				}
			}
			return strength;
		}
	}
	public class Multiplier
	{
		public string MultiplierType { get; private set; }
		public float MultiplierAmount { get; private set; }
		public Multiplier(string multipliertype, float multiplieramount)
		{
            MultiplierType = multipliertype;
            MultiplierAmount = multiplieramount; 
		}
		public void ChangeMultiplierAmount(float amount)
		{
			MultiplierAmount = amount;
		}
	}
}
