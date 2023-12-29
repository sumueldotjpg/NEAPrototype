using Godot;
using Main;
using System;
using System.Collections.Generic;
using Variables;

public partial class StartupScript : Node2D
{
	[Export]
	Control TabNode, GlobeNode, ConsoleNode, UpgradesNode, NPCsNode, DebugNode;
	
	[Export]
	Label BalanceText;

	[Export]
	Node3D Globe;

	[Export]
	TabContainer poiTabs;

	protected List<Label3D> AllPOILabels = new List<Label3D>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		//Update POI colours
		TabNode.Visible = true;
		GlobeNode.Visible = true;
		ConsoleNode.Visible = false;
		UpgradesNode.Visible = false;
		NPCsNode.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		BalanceText.Text = $"Balance = {AllObjects.CurrentProfile.MoneyBalance}";

		//handle poi colours
		foreach(Node node in Globe.GetChild(2).GetChildren())
		{	
			Label3D currentLabel = (Label3D)node;
			string nodeType = Convert.ToString(node.GetType());
			if(nodeType == "Godot.Label3D")
			{
				string poiName = node.Name;
				POI labelPOI = AllObjects.GetPOI(poiName);

				if(Convert.ToString(labelPOI.GetType()) == "Variables.FarmingPOI")
				{
					//yellow
					currentLabel.Modulate = new Color(1,1,0);
				}
				else if(labelPOI.IsUnlocked)
				{
					//blue
					currentLabel.Modulate = new Color(0,1,0);
				}
				else
				{
					//red
					currentLabel.Modulate = new Color(1,0,0);
				}
			}
		}
	}
	private void _on_add_money_button_pressed()
	{
		AllObjects.CurrentProfile.AddMoney(100000);
	}
	
	private void _on_button_globe_pressed()
	{
		GlobeNode.Visible = true;
		ConsoleNode.Visible = false;
		UpgradesNode.Visible = false;
		NPCsNode.Visible = false;
	}
	private void _on_button_console_pressed()
	{
		GlobeNode.Visible = false;
		ConsoleNode.Visible = true;
		UpgradesNode.Visible = false;
		NPCsNode.Visible = false;
	}
	private void _on_button_upgrades_pressed()
	{
		GlobeNode.Visible = false;
		ConsoleNode.Visible = false;
		UpgradesNode.Visible = true;
		NPCsNode.Visible = false;
	}
	private void _on_button_np_cs_pressed()
	{
		GlobeNode.Visible = false;
		ConsoleNode.Visible = false;
		UpgradesNode.Visible = false;
		NPCsNode.Visible = true;
	}
	private void _on_button_settings_pressed()
	{
		GetTree().Quit();
	}
	private void _on_button_exit_pressed()
	{
		SaveManager.SaveProfiles();
		GetTree().Quit();
	}
}
