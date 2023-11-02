using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Variables;

public partial class UpgradeHandler : Control
{

	[Export]
    Button Economy1, Economy2, Economy3, Economy4, Hacking1, Hacking2, Hacking3, Hacking4, NPC1, NPC2, NPC3, NPC4, Virus1, Virus2, Virus3, Virus4;


    private int upgradePoints;
	private int upgradeLevelTotal = 0;
	private int economyLevel, hackingLevel, npcLevel, virusLevel;

	private List<Upgrade> upgrades;
	private List<List<Button>> buttons;

	public override void _Ready()
	{
		upgrades = AllObjects.allUpgrades;

		buttons = new List<List<Button>> {
		new List<Button> {Economy1, Economy2, Economy3, Economy4},
		new List<Button> {Hacking1, Hacking2, Hacking3, Hacking4},
		new List<Button> {NPC1, NPC2, NPC3, NPC4},
		new List<Button> {Virus1, Virus2, Virus3, Virus4}};

		upgradePoints = AllObjects.CurrentProfile.UnlockedUpgrades.Count;
		foreach(List<Button> buttonList in buttons)
		{
			foreach(Button button in buttonList)
			{
				button.Disabled = true;
			}
		}
		SetUpgradeLevel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetUpgradeLevel()
	{
		//Rechecking upgradeLevel
		int before = upgradeLevelTotal;
		upgradeLevelTotal = (upgradePoints+1)/2;
		if (upgradeLevelTotal > 4)
		{
			upgradeLevelTotal=4;
		}
		else if(upgradeLevelTotal<1)
		{
			upgradeLevelTotal=1;
		}
		if(before!=upgradeLevelTotal)
		{
			foreach(List<Button> buttonList in buttons)
			{
				for (int i = 0; i < upgradeLevelTotal; i++)
				{
					buttonList[i].Disabled = false;
				}		
			}
		}
	}
}
