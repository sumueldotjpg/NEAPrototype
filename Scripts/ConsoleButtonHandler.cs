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
	Button Button1, Button2, Button3, Button4, Button5;

	bool hackSelection = false;
	POI selectedPOI;
	Attack selectedAttack;
	int selectCounter = 0;
	bool selectType = true;

	public override void _Ready()
	{
		Button4.Disabled = true;
		Button5.Disabled = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_console_option_1_pressed()
	{
		string Hackables = "You can hack: ";
		foreach(POI poi in AllObjects.allPOIs)
		{
			if(poi.IsUnlocked)
			{
				Hackables += poi.Name + ", ";
			}
		}
		OutputText(Hackables);
		Button1.Disabled = true;
		timer.Start(2);
	}
	public void _on_button_console_option_2_pressed()
	{
		string Hackables = "You have attacks: ";
		foreach(Attack attack in AllObjects.allAttacks)
		{
			if(attack.IsUnlocked)
			{
				Hackables += attack.Name + ", ";
			}
		}
		OutputText(Hackables);
		Button2.Disabled = true;
		timer.Start(2);
	}
	public void _on_button_console_option_3_pressed()
	{
		hackSelection = true;
		string selection = "Points of Interest: ";
		foreach(POI poi in AllObjects.allPOIs)
		{
			if(poi.IsUnlocked)
			{
				selection += poi.Name + ", ";
			}
		}
		selection += "\nAttacks: ";
		foreach(Attack attack in AllObjects.allAttacks)
		{
			if(attack.IsUnlocked)
			{
				selection += attack.Name + ", ";
			}
		}
		Button3.Disabled = true;
		Button4.Disabled = false;
		Button5.Disabled = false;
		OutputText(selection);
		OutputText("\n" + AllObjects.allPOIs[0].Name);
	}
	public void _on_button_console_option_4_pressed()
	{
		if (selectType)
		{ 
			if((selectCounter += 1) > AllObjects.allPOIs.Count)
			{
				selectCounter += 1;
			}
			else
			{
				selectCounter = 0;
			}
			OutputText($"[color=red]{AllObjects.allPOIs[selectCounter].Name}[/color]");
		}
		else
		{
			if((selectCounter += 1) > AllObjects.allAttacks.Count)
			{
				selectCounter += 1;
			}
			else
			{
				selectCounter = 0;
			}
			if (selectedPOI.Strength < AllObjects.CurrentProfile.UnlockedAttacks[AllObjects.CurrentProfile.UnlockedAttacks.Count + 1].Strength)
			{
				OutputText($"[color=red]{AllObjects.allAttacks[selectCounter].Name}[/color]");
			}
			else
			{
				OutputText(AllObjects.allAttacks[selectCounter].Name);
			}
		}
	}
	public void _on_button_console_option_5_pressed()
	{
		if(selectType)
		{
			selectedPOI = AllObjects.allPOIs[selectCounter];
			OutputText($"You have selected {selectedPOI.Name}");
			selectType = false;
			selectCounter = 0;
		}
		else
		{
			selectedAttack = AllObjects.allAttacks[selectCounter];
			OutputText($"You have selected {selectedAttack.Name}");
			selectType = true;
			selectCounter = 0;

			AttackPOI(selectedPOI,selectedAttack);
			Button4.Disabled = true;
			Button5.Disabled = true;
			Button3.Disabled = false;
		}
	}
	public void OutputText(string output)
	{
		Console.BbcodeEnabled = true;
		Console.AddText($"\n{output}");
	}

	public void _on_button_timer_timeout()
	{
		Button1.Disabled = false;
		Button2.Disabled = false;
		Button3.Disabled = false;
		Button4.Disabled = false;
	}
	public void AttackPOI(POI poi, Attack attack)
	{
		if (attack.Strength > poi.Strength && !poi.IsUnlocked)
		{
			poi.Unlock();
			OutputText($"You have hacked: {poi.Name}");
		}
		else if (attack.Strength > poi.Strength)
		{
			OutputText($"{poi.Name} is already unlocked");
		}
		else
		{
			OutputText($"You are not strong enough to hack {poi.Name} yet");
		}
	}

}
