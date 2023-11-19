using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Variables;

public partial class UpgradeHandler : Control
{

	[Export]
    Button EconomyButton, HackingButton, NPCButton, VirusButton;
	[Export]
	ProgressBar EconomyBar, HackingBar, NPCBar, VirusBar;

	List<ProgressBar> progressBars = new List<ProgressBar>(){};
	public override void _Ready()
	{
		progressBars.AddRange(new List<ProgressBar>{EconomyBar,HackingBar, NPCBar, VirusBar});

		for (int i = 0; i < 4; i++)
		{
			progressBars[i].Value = Convert.ToDouble(AllObjects.CurrentProfile.UpgradeLevels[i].Level)/100;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
}
