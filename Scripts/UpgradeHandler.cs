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
			GD.Print(progressBars[i].Value + "value");
			GD.Print(AllObjects.CurrentProfile.UpgradeLevels[i].Level);
			progressBars[i].Value = Convert.ToDouble(AllObjects.CurrentProfile.UpgradeLevels[i].Level)/100;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_economy_pressed()
	{
		if (EconomyBar.Value < 100)
		{
			AllObjects.CurrentProfile.UpgradeLevels[0].IncreaseLevel();
			double newValue = AllObjects.CurrentProfile.UpgradeLevels[1].Level * 0.25;
			EconomyBar.Value = newValue;

			GD.Print(EconomyBar.Value + "value" + newValue);
			GD.Print(AllObjects.CurrentProfile.UpgradeLevels[0].Level);
		}
		else
		{
			throw new Exception("upgraded too much");
		}
	}
	public void _on_button_hacking_pressed()
	{ 

	}
	public void _on_button_npc_pressed()
	{ 

	}
	public void _on_button_virus_pressed()
	{ 

	}
}
