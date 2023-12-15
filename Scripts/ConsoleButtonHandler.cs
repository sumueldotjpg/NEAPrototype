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
	public void OutputText(string output)
	{
		Console.BbcodeEnabled = true;
		Console.AddText($"[color=green]s[/color]\n{output}");
	}

	public void _on_button_timer_timeout()
	{
		OutputText($"You have hacked {selectedPOI.Name} here is your reward {selectedPOI.Reward}");
		HackButton.Disabled = false;
	}
	public void AttackPOI(POI poi, Attack attack)
	{
		if(timer.IsStopped())
		{
			if (attack.GetStrength() > poi.GetStrength() && !poi.IsUnlocked)
			{
				poi.Unlock();
				OutputText($"You have begin to hack: {poi.Name} using: {attack.Name}");
				HackButton.Disabled = true;

				timer.Start(10f);
			}
			else if (attack.GetStrength() > poi.GetStrength())
			{
				OutputText($"[color=red]{poi.Name} is already unlocked[/color]");
			}
			else
			{
				OutputText($"[color=red]You are not strong enough to hack {poi.Name} yet[/color]");
			}
		}
		else
		{
			OutputText($"You have not finished hacking the previous POI yet.");
		}
	}

}
