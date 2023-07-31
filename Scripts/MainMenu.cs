using Godot;
using System;

public partial class MainMenu : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	Control MainMenuNode = null;
	Control SettingsNode  = null;
	public override void _Ready()
	{
		MainMenuNode = GetNode<Control>("Main");
		SettingsNode = GetNode<Control>("Settings");
		GD.Print(MainMenuNode.GetType());

		MainMenuNode.Visible = true;
		SettingsNode.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/GlobeScene.tscn");
	}

	//settings buttons
	private void _on_button_setttings_pressed()
	{
		MainMenuNode.Visible = false;
		SettingsNode.Visible = true;
	}
	private void _on_check_button_full_screen_toggled(bool button_pressed)
	{
		Vector2I WindowSize = new Vector2I(10,30);
		if(button_pressed)
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.ExclusiveFullscreen);
		}
		else
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
			DisplayServer.WindowSetSize(WindowSize, 1 );
		}
	}
	private void _on_button_back_pressed()
	{
		MainMenuNode.Visible = true;
		SettingsNode.Visible = false;
	}


	private void _on_button_quit_pressed()
	{
		GetTree().Quit();
	}
}
