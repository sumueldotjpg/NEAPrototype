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

		foreach(POI poi in AllObjects.CurrentProfile.UnlockedPOIs)
		{
			if(selectedPOI.Name == poi.Name)
			{
				selectedPOI.PermenantUnlock();
			}
		}

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
		
		string rewardedAttack = RewardPOIAttack(selectedPOI);
		if(rewardedAttack == "")
		{

		}
		else
		{
			OutputText($"You have discovered how to use the {rewardedAttack} cyber attack","green");
		}
		HackButton.Disabled = false;
	}
	public void AttackPOI(POI poi, Attack attack)
	{
		if(timer.IsStopped())
		{
			if (attack.GetStrength() > poi.GetStrength() && (!poi.IsUnlocked || Convert.ToString(poi.GetType()) == "Variables.FarmingPOI"))
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
	public string RewardPOIAttack(POI poi)
	{
		//Reward new Attack if required
		switch(poi.Name)
		{
			case "Apple":
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[1]);
			AttackList.AddItem("Phishing");
			return "Phishing";
			case "Meta":
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[2]);
			AttackList.AddItem("Spoofing");
			return "Spoofing";
			case "Intel":
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[3]);
			AttackList.AddItem("Key Logger");
			return "Key Logger";
			case "Adobe":
			AllObjects.CurrentProfile.UnlockedAttacks.Add(AllObjects.allAttacks[4]);
			AttackList.AddItem("SQL Injection");
			return "SQL Injection";
			case "WorldWideWeb":
			StartupScript startup = new StartupScript{};
			startup.WinGame();
			return null;
			default:
			return "";
		}	
	}
}
