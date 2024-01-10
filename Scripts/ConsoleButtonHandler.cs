using Godot;
using System;
using System.Diagnostics.Metrics;
using System.Linq;
using Variables;

public partial class ConsoleButtonHandler : Control
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	RichTextLabel Console;
	[Export]
	Timer timer;
	[Export]
	ProgressBar progressBar;
	[Export]
	Button HackButton;
	[Export]
	ItemList POIList, AttackList;

	bool hackSelection = false;
	POI selectedPOI;
	Attack selectedAttack;
	int selectCounter = 0;
	bool selectType = true;

	public override void _Ready()
	{
		foreach(POI poi in AllObjects.allPOIs)
		{
			POIList.AddItem(poi.Name);
		}
		foreach(Attack attack in AllObjects.CurrentProfile.UnlockedAttacks)
		{
			AttackList.AddItem(attack.Name);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		progressBar.Value = timer.TimeLeft/timer.WaitTime*100;
	}
	public void _on_button_console_option_3_pressed()
	{
		selectedPOI = AllObjects.GetPOI(POIList.GetItemText(POIList.GetSelectedItems()[0]));
		selectedAttack = AllObjects.GetAttack(AttackList.GetItemText(AttackList.GetSelectedItems()[0]));

		AttackPOI(selectedPOI,selectedAttack);
	}
	public void OutputText(string output,string colour)
	{
		Console.BbcodeEnabled = true;
		Console.AppendText($"\n[color={colour}]{output}[/color]");
	}

	public void _on_button_timer_timeout()
	{
		OutputText($"You have hacked {selectedPOI.Name} here is your reward {selectedPOI.Reward}","green");
		
		if(RewardPOI(selectedPOI) == "")
		{

		}
		else
		{
			OutputText($"You have discovered how to use the {RewardPOI(selectedPOI)} cyber attack","green");
		}
		HackButton.Disabled = false;
	}
	public void AttackPOI(POI poi, Attack attack)
	{
		if(timer.IsStopped())
		{
			if (attack.GetStrength() > poi.GetStrength() && !poi.IsUnlocked)
			{
				if (Convert.ToString(poi.GetType()) != "Variables.FarmingPOI")
				{
					poi.UnlockPOI();
					OutputText($"You have begun to hack: {poi.Name} using: {attack.Name}", "green");
					HackButton.Disabled = true;

					timer.Start(10f);
				}
				else
				{
					poi.UnlockPOI();
					OutputText($"You have begun to hack: {poi.Name} using: {attack.Name}", "green");
					HackButton.Disabled = true;

					timer.Start();
				}
			}
			else if (attack.GetStrength() > poi.GetStrength())
			{
				OutputText($"[color=red]{poi.Name} is already unlocked[/color]","red");
			}
			else
			{
				OutputText($"[color=red]You are not strong enough to hack {poi.Name} yet[/color]","red");
			}
		}
		else
		{
			OutputText($"You have not finished hacking the previous POI yet.","red");
		}
	}
	public string RewardPOI(POI poi)
	{
		//Reward new Attack if required
		switch(poi.BaseStrength)
		{
			case 2:
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[1]);
			return "Phishing";
			case 4:
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[2]);
			return "Spoofing";
			case 6:
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[3]);
			return "Key Logger";
			case 8:
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[4]);
			return "SQL Injection";
			default:
			return "";
		}	
	}
}
