using Godot;
using System;

public partial class StartupScript : Node2D
{
	Control TabNode = null;
	Control GlobeNode = null;
	Control ConsoleNode = null;
	Control UpgradesNode = null;
	Control NPCsNode = null;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TabNode = GetNode<Control>("TabButtonControl");
		GlobeNode = GetNode<Control>("Globe");
		ConsoleNode = GetNode<Control>("Console");
		UpgradesNode = GetNode<Control>("Upgrades");
		NPCsNode = GetNode<Control>("NPCs");
		
		TabNode.Visible = true;
		GlobeNode.Visible = true;
		ConsoleNode.Visible = false;
		UpgradesNode.Visible = false;
		NPCsNode.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
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
		GetTree().Quit();
	}
	private void _on_button_np_cs_pressed()
	{
		GetTree().Quit();
	}
	private void _on_button_settings_pressed()
	{
		GetTree().Quit();
	}
	private void _on_button_exit_pressed()
	{
		GetTree().Quit();
	}
}
