using Godot;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;

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

		public static SaveProfile CurrentProfile { get; private set; } = new SaveProfile("ProfileNotLoaded",-337,-337,null,null,null,null,null);

		public static void ProfileLoad(List<SaveProfile> allSaveProfiles)
		{
			allProfiles = allSaveProfiles;
		}

		public static void SetCurrentProfile(SaveProfile current)
		{
			CurrentProfile = current;
		}
		public static Attack GetAttack(string attackName)
		{
			foreach(Attack attack in AllObjects.allAttacks)
			{
				if (attack.Name.ToLower() == attackName.ToLower())
				{
					return attack;
				}
			}
			throw new Exception("There isnt any Attacks with that name");
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
		public static POI GetPOIID(int poiID)
		{
			foreach(POI poi in AllObjects.allPOIs)
			{
				if (poi.Id == poiID)
				{
					return poi;
				}
			}
			throw new Exception("There isnt any POIs with that ID");
		}
		public static float Multiply(int originalValue, string multiplierType)
		{
			float multiplier;
			switch (multiplierType)
			{
				case "ATTACKSTENGTH":
					multiplier = 0;
					foreach(Multiplier mp in AllObjects.CurrentProfile.Multipliers)
					{
						if(mp.MultiplierType == multiplierType)
						{
							multiplier += mp.MultiplierAmount;
						}
					}
				return originalValue + multiplier;
				
				default:
					multiplier = 1;
					foreach(Multiplier mp in AllObjects.CurrentProfile.Multipliers)
					{
						if(mp.MultiplierType == multiplierType)
						{
							multiplier += mp.MultiplierAmount;
						}
					}
				return originalValue*multiplier;
			}
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

		public SaveProfile(string title, int moneybalance,int detectionpercentage, List<POI> unlockedpois, List<NPC> unlockednpcs, List<Upgrade> upgradelevels, List<Attack> unlockedattacks, List<Multiplier> multipliers)
		{
			Title = title;
			MoneyBalance = moneybalance;
			DetectionPercentage = detectionpercentage;
			UnlockedPOIs = unlockedpois;
			UnlockedNPCs = unlockednpcs;
			UpgradeLevels = upgradelevels;
			UnlockedAttacks = unlockedattacks;
			Multipliers = multipliers;
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
		public int Reward{get; protected set;}
		public POI(string name, string description, int basestrength, List<int> children)
		{
			Name = name;
			Description = description;
			BaseStrength = basestrength;
			Children = children;
			IsUnlocked = false;
		}
		public void UnlockPOI()
		{
			int BaseReward = Convert.ToInt32(AllObjects.Multiply(9000,"REWARDINCREASE"));
			int UnlockReward;

			//Reward Money
			if (BaseStrength == 0)
			{
				UnlockReward = BaseReward;
				AllObjects.CurrentProfile.AddMoney(UnlockReward);
			}
			else
			{
				UnlockReward = Convert.ToInt32(BaseReward*Math.Pow(Math.E,BaseStrength-1));
				AllObjects.CurrentProfile.AddMoney(UnlockReward);
			}

			IsUnlocked = false;
			Reward = UnlockReward;
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
		public int UpgradeID { get; protected set; }
		public string Description { get; protected set; }
		
		//To calculate cost of Upgrade ==> OriginalBaseCost * (e^Level)
		//So in order to get cost later on ===> CurrentCost / (e^Level-1) == OriginalBaseCost
		//Then OriginalBaseCost * (e^Level)
		//In total the formula is NewCost = OldCost / (e^-1)
		public int Cost { get; protected set; }
		public int Level { get; protected set; }

		[JsonConstructor]
        public Upgrade(int upgradeid, int cost, int level)
        {
			UpgradeID = upgradeid;
			Cost = cost;
			Level = level;
			GD.Print(0);
	    }
		public Upgrade(int upgradeid, int basecost)
		{
			UpgradeID = upgradeid;
			Cost = basecost;
			Level = 0;

			GD.Print(1);
		}
        public virtual void IncreaseLevel()
		{
			Level += 1;
		
			Cost = Convert.ToInt32((float)Cost*((float)Math.E));
			
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

			Description = "base upgrade";
		}
	}
	/// <summary>
	/// Economy upgrade that multiplies amount earned every tick
	/// </summary>
	public class EconomyUpgrade : Upgrade
	{
		public EconomyUpgrade(int upgradeid, int cost, int level) : base(upgradeid, cost, level)
		{
			Description = $"This is an economy upgrade to increase your money earnt.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
        public override void IncreaseLevel()
		{
			Level += 1;

			Cost = Convert.ToInt32((float)Cost*((float)Math.E));

			if(0 < Level && Level < 6)
			{
				AllObjects.CurrentProfile.Multipliers.Add(new Multiplier("INCOMEINCREASE",0.3f));
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is an economy upgrade to increase your money earnt.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
	}
	/// <summary>
	/// Hacking upgrade that increases the strength of attacks
	/// </summary>
	public class HackingUpgrade : Upgrade
	{
		public HackingUpgrade(int upgradeid, int cost, int level) : base(upgradeid, cost, level)
		{
			Description = $"This is a hacking upgrade to increase reward on hacking places.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
        public override void IncreaseLevel()
		{
			Level += 1;
		
			Cost = Convert.ToInt32((float)Cost*((float)Math.E));

			if(0 < Level && Level < 6)
			{
				AllObjects.CurrentProfile.Multipliers.Add(new Multiplier("REWARDINCREASE",0.1f));
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is a hacking upgrade to increase reward on hacking places.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
	}
	public class NPCUpgrade : Upgrade
	{
		public NPCUpgrade(int upgradeid, int cost, int level) : base(upgradeid, cost, level)
		{
			Description = $"This is an NPC upgrade to descrease the action time of your NPCs.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
        public override void IncreaseLevel()
		{
			Level += 1;
		
			Cost = Convert.ToInt32((float)Cost*((float)Math.E));

			if(0 < Level && Level < 6)
			{
				AllObjects.CurrentProfile.Multipliers.Add(new Multiplier("NPCDECREASE",0.02f));
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is an NPC upgrade to descrease the action time of your NPCs.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
	}
	public class VirusUpgrade : Upgrade
	{
		public VirusUpgrade(int upgradeid, int cost, int level) : base(upgradeid, cost, level)
		{
			Description = $"This is a virus upgrade to increase the strength of your attacks.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
        public override void IncreaseLevel()
		{
			Level += 1;
		
			Cost = Convert.ToInt32((float)Cost*((float)Math.E));
			
			if(0 < Level && Level < 6)
			{
				AllObjects.CurrentProfile.Multipliers.Add(new Multiplier("ATTACKSTRENGTH",1));
			}
			else
			{
				throw new Exception("Upgrade upgraded went too far");
			}

			Description = $"This is a virus upgrade to increase the strength of your attacks.\nCurrent Level: {Level}\nCost to Upgrade: {Cost}";
		}
	}
	
	public class Attack
	{
		public int AttackID { get; private set; }
		public string Name { get; private set; }
		public int BaseStrength { get; private set;}
		public bool IsUnlocked { get; private set;}
		public Attack(int attackid, string name, int basestrength)
		{
			AttackID = attackid;
			Name = name;
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
