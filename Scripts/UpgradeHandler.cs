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
			labels[i].Text = AllObjects.CurrentProfile.UpgradeLevels[i].Description;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_economy_pressed()
	{
		if (EconomyBar.Value < 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[0].Cost)
		{
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[0].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[0].IncreaseLevel();
			double newValue = AllObjects.CurrentProfile.UpgradeLevels[0].Level * 20;
			EconomyBar.Value = newValue;
			labels[0].Text = AllObjects.CurrentProfile.UpgradeLevels[0].Description;
		}
		else if(EconomyBar.Value >= 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[0].Cost)
		{
            EconomyBar.Value = 100;
            EconomyButton.Disabled = true;
            labels[0].Text = "This is an economy upgrade to increase your money earnt.\nThis upgrade has been maxed out";
        }
		else
		{
			
		}
	}
	public void _on_button_hacking_pressed()
	{
        if (HackingBar.Value < 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[1].Cost)
        {
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[1].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[1].IncreaseLevel();
            double newValue = AllObjects.CurrentProfile.UpgradeLevels[1].Level * 20;
            HackingBar.Value = newValue;
			labels[1].Text = AllObjects.CurrentProfile.UpgradeLevels[1].Description;
        }
        else if (HackingBar.Value >= 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[1].Cost)
        {
            HackingBar.Value = 100;
            HackingButton.Disabled = true;
            labels[1].Text = "This is a hacking upgrade to increase reward on hacking places.\nThis upgrade has been maxed out";
        }
        else
        {

        }
    }
	public void _on_button_npc_pressed()
	{
        if (NPCBar.Value < 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[2].Cost)
        {
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[2].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[2].IncreaseLevel();
            double newValue = AllObjects.CurrentProfile.UpgradeLevels[2].Level * 20;
            NPCBar.Value = newValue;
			labels[2].Text = AllObjects.CurrentProfile.UpgradeLevels[2].Description;
        }
        else if (HackingBar.Value >= 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[2].Cost)
        {
            NPCBar.Value = 100;
            NPCButton.Disabled = true;
            labels[2].Text = "This is an NPC upgrade to descrease the action time of your NPCs.\nThis upgrade has been maxed out";
        }
        else
        {

        }
    }
	public void _on_button_virus_pressed()
	{
        if (VirusBar.Value < 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[3].Cost)
        {
            AllObjects.CurrentProfile.RemoveMoney(AllObjects.CurrentProfile.UpgradeLevels[3].Cost);
            AllObjects.CurrentProfile.UpgradeLevels[3].IncreaseLevel();
            double newValue = AllObjects.CurrentProfile.UpgradeLevels[3].Level * 20;
            VirusBar.Value = newValue;
			labels[3].Text = AllObjects.CurrentProfile.UpgradeLevels[3].Description;
        }
        else if (VirusBar.Value >= 80 && AllObjects.CurrentProfile.MoneyBalance >= AllObjects.CurrentProfile.UpgradeLevels[3].Cost)
        {
            VirusBar.Value = 100;
            VirusButton.Disabled = true;
            labels[3].Text = "This is a virus upgrade to increase the strength of your attacks.\nThis upgrade has been maxed out";
        }
        else
        {

        }
    }
}
