using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Variables;
using Main;

public partial class MainMenu : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	Control MainMenuNode = null;
	Control ProfilesNode = null;
	Control SettingsNode  = null;
	public override void _Ready()
	{
		MainMenuNode = GetNode<Control>("Main");
		ProfilesNode = GetNode<Control>("Profiles");
		SettingsNode = GetNode<Control>("Settings");

		MainMenuNode.Visible = true;
		ProfilesNode.Visible = false;
		SettingsNode.Visible = false;
		
		DisplayServer.WindowSetMinSize(new Vector2I(1000,1020));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_play_pressed()
	{
		MainCreation.Load();

		MainMenuNode.Visible = false;
		ProfilesNode.Visible = true;
		SettingsNode.Visible = false;
	}

	//settings buttons
	private void _on_button_settings_pressed()
	{
		MainMenuNode.Visible = false;
		ProfilesNode.Visible = false;
		SettingsNode.Visible = true;
	}
	private void _on_check_button_full_screen_toggled(bool button_pressed)
	{
		Vector2I WindowSize = new Vector2I(1920,1040);
		if(button_pressed)
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.ExclusiveFullscreen);
		}
		else
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
			DisplayServer.WindowSetSize(WindowSize, 0 );
		}
	}
	private void _on_button_back_pressed()
	{
		MainMenuNode.Visible = true;
		SettingsNode.Visible = false;
	}


	private void _on_button_quit_pressed()
	{
		SaveManager.SaveProfiles();
		GetTree().Quit();
	}
}
