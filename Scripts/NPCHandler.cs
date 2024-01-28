using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Variables;

public partial class NPCHandler : Control
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	Label NPCDescription1, NPCDescription2, NPCDescription3, NPCDescription4, NPCDescription5, NPCDescription6, NPCDescription7, NPCDescription8, NPCDescription9;
	[Export]
	Button NPCButton1, NPCButton2, NPCButton3, NPCButton4, NPCButton5, NPCButton6, NPCButton7, NPCButton8, NPCButton9;
	[Export]
	ProgressBar NPCProgress1, NPCProgress2, NPCProgress3, NPCProgress4, NPCProgress5, NPCProgress6, NPCProgress7, NPCProgress8, NPCProgress9;

	List<Label> labels;
	List<Button> buttons;
	List<ProgressBar> progressBars;
	public override void _Ready()
	{
		labels = new List<Label>(){NPCDescription1,NPCDescription2,NPCDescription3,NPCDescription4,NPCDescription5,NPCDescription6,NPCDescription7,NPCDescription8,NPCDescription9};
		buttons = new List<Button>(){NPCButton1,NPCButton2,NPCButton3,NPCButton4,NPCButton5,NPCButton6,NPCButton7,NPCButton8,NPCButton9};
		progressBars = new List<ProgressBar>(){NPCProgress1,NPCProgress2,NPCProgress3,NPCProgress4,NPCProgress5,NPCProgress6,NPCProgress7,NPCProgress8,NPCProgress9};

		for (int i = 0; i < 9; i++)
		{
			buttons[i].Text = "Buy NPC: " + AllObjects.allNPC[i].Cost;
			labels[i].Text = AllObjects.allNPC[i].NpcName + "\n\n" + AllObjects.allNPC[i].Description;
		}
		foreach(ProgressBar progressBar in progressBars)
		{
			progressBar.Hide();
		}

		//Loading already unlocked NPCS
		foreach(NPC npc in AllObjects.CurrentProfile.UnlockedNPCs)
		{
			LoadNPCs(npc.NpcId);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		for (int i = 0; i < 9; i++)
		{
			if(progressBars[i].Visible == true)
			{
				progressBars[i].Value = AllObjects.CheckTimer(i);
			}
		}

		for (int i = 0; i < 9; i++)
		{
			if(progressBars[i].Visible == true)
			{
				progressBars[i].MaxValue = AllObjects.Multiply(AllObjects.GetNPCID(i).ActionTime,"NPCDECREASE");
			}
		}

		
	}

	private void _on_button_1_pressed()
	{
		NPCButtonPressed(0);
	} 
	private void _on_button_2_pressed()
	{
		NPCButtonPressed(1);
	} 
	private void _on_button_3_pressed()
	{
		NPCButtonPressed(2);
	} 
	private void _on_button_4_pressed()
	{
		NPCButtonPressed(3);
	} 
	private void _on_button_5_pressed()
	{
		NPCButtonPressed(4);
	} 
	private void _on_button_6_pressed()
	{
		NPCButtonPressed(5);
	} 
	private void _on_button_7_pressed()
	{
		NPCButtonPressed(6);
	} 
	private void _on_button_8_pressed()
	{
		NPCButtonPressed(7);
	} 
	private void _on_button_9_pressed()
	{
		NPCButtonPressed(8);
	} 
	private void NPCButtonPressed(int npcID)
	{
		NPC currentNPC = AllObjects.allNPC[npcID];

		if(AllObjects.CurrentProfile.MoneyBalance >= currentNPC.Cost)
		{
			buttons[npcID].Text = "NPC Bought";
			buttons[npcID].Disabled = true;
			progressBars[npcID].Show();
			AllObjects.CurrentProfile.RemoveMoney(currentNPC.Cost);
			currentNPC.Unlock(GetNode<NPCHandler>("/root/MainScreen/NPCs"));
		}
	}
	private void LoadNPCs(int npcID)
	{
		NPC currentNPC = AllObjects.allNPC[npcID];
		
		buttons[npcID].Text = "NPC Bought";
		buttons[npcID].Disabled = true;
		progressBars[npcID].Show();
		progressBars[npcID].MaxValue = AllObjects.GetNPCID(npcID).ActionTime;
		currentNPC.Load(GetNode<NPCHandler>("/root/MainScreen/NPCs"));
	}
	public void NPCAction(int NpcId)
	{
		AllObjects.CurrentProfile.UnlockedNPCs[NpcId].NPCAction();
	}
}