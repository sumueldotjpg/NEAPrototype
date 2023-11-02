using Godot;
using System;
using System.Collections.Generic;
using Variables;

public partial class UpgradeHandler : Node
{

	[Export]
    Button Economy1, Economy2, Economy3, Economy4, Hacking1, Hacking2, Hacking3, Hacking4, NPC1, NPC2, NPC3, NPC4, Virus1, Virus2, Virus3, Virus4;


    private int upgradePoints;
	public override void _Ready()
	{
		List<Upgrade> upgrades = AllObjects.allUpgrades;
		List<List<Button>> buttons = new List<List<Button>> {new List<Button> {Economy1, Economy2, Economy3, Economy4}, new List<Button> { Hacking1, Hacking2, Hacking3, Hacking4}, new List<Button> { NPC1, NPC2, NPC3, NPC4}, new List<Button> { Virus1, Virus2, Virus3, Virus4}};
		upgradePoints = AllObjects.CurrentProfile.UnlockedUpgrades.Count;
		
		foreach(Upgrade upgrade in upgrades)
		{
			if 
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
