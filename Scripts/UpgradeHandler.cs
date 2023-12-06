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
	[Export]
	Label EconomyLabel, HackingLabel, NPCLabel, VirusLabel;

	List<ProgressBar> progressBars = new List<ProgressBar>(){};
	List<Label> labels = new List<Label> ();
	public override void _Ready()
	{
		progressBars.AddRange(new List<ProgressBar>{EconomyBar,HackingBar, NPCBar, VirusBar});
		labels.AddRange(new List<Label> { EconomyLabel, HackingLabel, NPCLabel, VirusLabel });

		for (int i = 0;i < 4;i++)
		{
			labels[i].Text = $"Current Cost: {AllObjects.CurrentProfile.UpgradeLevels[i].Cost} \n{AllObjects.CurrentProfile.UpgradeLevels[i].Description}";
			GD.Print(AllObjects.CurrentProfile.UpgradeLevels[i].Cost);
			GD.Print(AllObjects.CurrentProfile.UpgradeLevels[i].UpgradeID);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_economy_pressed()
	{
		if (EconomyBar.Value < 100 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[0].Cost)
		{
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[0].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[0].IncreaseLevel();
			double newValue = AllObjects.CurrentProfile.UpgradeLevels[0].Level * 25;
			EconomyBar.Value = newValue;
			labels[0].Text = $"Current Cost: {AllObjects.CurrentProfile.UpgradeLevels[0].Cost} \n{AllObjects.CurrentProfile.UpgradeLevels[0].Description}";
			
		}
		else if(EconomyBar.Value < 100)
		{
			
		}
		else
		{
			EconomyButton.Disabled = true;
		}
	}
	public void _on_button_hacking_pressed()
	{
        if (HackingBar.Value < 100 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[1].Cost)
        {
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[1].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[1].IncreaseLevel();
            double newValue = AllObjects.CurrentProfile.UpgradeLevels[1].Level * 25;
            HackingBar.Value = newValue;
			labels[1].Text = $"Current Cost: {AllObjects.CurrentProfile.UpgradeLevels[1].Cost} \n{AllObjects.CurrentProfile.UpgradeLevels[1].Description}";
        }
        else
        {
            HackingButton.Disabled = true;
        }
    }
	public void _on_button_npc_pressed()
	{
        if (NPCBar.Value < 100 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[2].Cost)
        {
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[2].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[2].IncreaseLevel();
            double newValue = AllObjects.CurrentProfile.UpgradeLevels[2].Level * 25;
            NPCBar.Value = newValue;
			labels[2].Text = $"Current Cost: {AllObjects.CurrentProfile.UpgradeLevels[2].Cost} \n{AllObjects.CurrentProfile.UpgradeLevels[3].Description}";
        }
        else
        {
			NPCButton.Disabled = true;
        }
    }
	public void _on_button_virus_pressed()
	{
        if (VirusBar.Value < 100 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[3].Cost)
        {
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[3].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[3].IncreaseLevel();
            double newValue = AllObjects.CurrentProfile.UpgradeLevels[3].Level * 25;
            VirusBar.Value = newValue;
			labels[3].Text = $"Current Cost: {AllObjects.CurrentProfile.UpgradeLevels[3].Cost} \n{AllObjects.CurrentProfile.UpgradeLevels[3].Description}";
        }
        else
        {
            VirusButton.Disabled = true;
        }
    }
}
